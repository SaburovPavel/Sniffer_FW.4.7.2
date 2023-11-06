using System;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Drawing;
using PacketDotNet;
using PacketDotNet.Ieee80211;
using System.Net;
using System.Net.Sockets;

namespace Sniffer_FW._4._7._2
{
    public partial class MainForm : Form
    {
        DataTable tableDevices = new DataTable();
        DataTable tableCap = new DataTable();
        DataTable tableCapView2 = new DataTable();
        CaptureDeviceList devices = CaptureDeviceList.Instance;
        int packetIndex = 0;
        public MainForm()
        {
            InitializeComponent();
            this.dataGridViewCap.SetDoubleBuffered(true);
        }

        void RefreshCap()
        {
            Invoke((MethodInvoker)delegate
            {
                if (radioButton1View.Checked)
                {
                    dataGridViewCap.DataSource = tableCap.DefaultView;
                    dataGridViewCap.Columns["rawPacket"].Width = 400;
                }
                else
                {
                    dataGridViewCap.DataSource = tableCapView2.DefaultView;
                    //dataGridViewCap.Columns["Info"].Width = 400;
                }
                                

                //foreach (DataGridViewRow row in this.dataGridViewCap.Rows)
                //{
                //    row.HeaderCell.Value = (row.Index + 1).ToString();
                //    if (row.Index % 2 != 0)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.LightGray;
                //    }
                //    else
                //    {
                //        row.DefaultCellStyle.BackColor = Color.White;
                //    }
                //}

                this.dataGridViewCap.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            devices = CaptureDeviceList.Instance;

            radioButton1View.Checked = true;
            buttonStop.Enabled = false;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                MessageBox.Show("No devices were found on this machine");
                return;
            }

            DataColumn columnNumDevice = new DataColumn("NDevice", typeof(int));
            tableDevices.Columns.Add(columnNumDevice);

            DataColumn columnnameDevice = new DataColumn("Name", typeof(string));
            tableDevices.Columns.Add(columnnameDevice);

            DataColumn columnDescriptionDevice = new DataColumn("Description", typeof(string));
            tableDevices.Columns.Add(columnDescriptionDevice);



            DataColumn columnTime = new DataColumn("Time", typeof(string));
            tableCap.Columns.Add(columnTime);
            DataColumn columnLen = new DataColumn("Len", typeof(string));
            tableCap.Columns.Add(columnLen);
            DataColumn columnrawPacket = new DataColumn("rawPacket", typeof(string));
            tableCap.Columns.Add(columnrawPacket);
            //DataColumn columnNumDevice = new DataColumn("NDevice", typeof(int));
            //tableCap.Columns.Add(columnNumDevice);
            //DataColumn columnNumDevice = new DataColumn("NDevice", typeof(int));
            //tableCap.Columns.Add(columnNumDevice);

            DataColumn columnTime2 = new DataColumn("Time", typeof(string));
            tableCapView2.Columns.Add(columnTime2);
            DataColumn columnSource = new DataColumn("Source", typeof(string));
            tableCapView2.Columns.Add(columnSource);
            DataColumn columnDestination = new DataColumn("Destination", typeof(string));
            tableCapView2.Columns.Add(columnDestination);
            DataColumn columnProtocol = new DataColumn("Protocol", typeof(string));
            tableCapView2.Columns.Add(columnProtocol);
            DataColumn columnLenth = new DataColumn("Lenth", typeof(string));
            tableCapView2.Columns.Add(columnLenth);
            DataColumn columnSourcePort = new DataColumn("SourcePort", typeof(string));
            tableCapView2.Columns.Add(columnSourcePort);
            DataColumn columnDestPort = new DataColumn("DestPort", typeof(string));
            tableCapView2.Columns.Add(columnDestPort);

            DataColumn columnInfo = new DataColumn("Info ", typeof(string));
            tableCapView2.Columns.Add(columnInfo);

            int i = 0;

            // Print out the devices
            foreach (var dev in devices)
            {
                /* Description */

                DataRow newRow = tableDevices.NewRow();
                tableDevices.Rows.Add(new object[] { i, dev.Name, dev.Description });

                //Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
                i++;
            }

            comboBoxDevices.DataSource = tableDevices;
            comboBoxDevices.DisplayMember = "Description";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            StartStopCap(true);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            StartStopCap(false);
        }

        private void device_OnPacketArrival(object sender, PacketCapture e)
        {
            packetIndex++;

            var time = e.Header.Timeval.Date;
            var len = e.Data.Length;

            var rawPacket = e.GetPacket();

            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);            
            
            var ethernetPacket = packet.Extract<EthernetPacket>();

            var timeToTable = $"{time.Hour}:{time.Minute}:{time.Second},{time.Millisecond}";

            DataRow newRow = tableDevices.NewRow();
            tableCap.Rows.Add(new object[] { timeToTable, len, rawPacket.ToString() });

            if (ethernetPacket != null)
            {
                if (ethernetPacket is EthernetPacket ethPacket)
                {
                    if (ethPacket.PayloadPacket is IPv4Packet ipv4Packet)
                    {
                        var sourceIpAddress = ipv4Packet.SourceAddress;
                        //var sourceIpPort = ipv4Packet.ParentPack
                        var destinationIpAddress = ipv4Packet.DestinationAddress;
                        var protocolType = ipv4Packet.Protocol.ToString();
                        var packetLength = ipv4Packet.TotalPacketLength;

                        var tcpPacket = ipv4Packet.PayloadPacket as TcpPacket;

                        if (tcpPacket != null)
                        {
                            if (tcpPacket is TcpPacket _tcpPacket)
                            {
                                var payloadPacketString = ipv4Packet.PayloadPacket.ToString();
                                var sourcePort = _tcpPacket.SourcePort;
                                var destinationPort = _tcpPacket.DestinationPort;

                                tableCapView2.Rows.Add(new object[] { timeToTable, sourceIpAddress, destinationIpAddress, protocolType,
                            packetLength, sourcePort, destinationPort, payloadPacketString });
                            }                            
                        }

                    }
                    else if (ethPacket.PayloadPacket is UdpPacket udpPacket)
                    {
                        var sourceIpAddress = udpPacket.ParentPacket;                        
                        var protocolType = udpPacket.GetType().ToString();
                        var packetLength = udpPacket.TotalPacketLength;
                        if (udpPacket != null)
                        {
                            // Handle UdpPacket
                            var payloadPacketString = udpPacket.PayloadPacket.ToString();
                            var sourcePort = udpPacket.SourcePort;
                            var destinationPort = udpPacket.DestinationPort;
                            tableCapView2.Rows.Add(new object[] { timeToTable, "", "", "",
                            "", sourcePort, destinationPort, payloadPacketString });

                        }


                    }
                }
                
                // Use the ToString method to get the IP address in the desired format


                Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
                                  packetIndex,
                                  e.Header.Timeval.Date.ToString(),
                                  e.Header.Timeval.Date.Millisecond,
                                  ethernetPacket.SourceHardwareAddress,
                                  ethernetPacket.DestinationHardwareAddress);
            }

            var radioPacket = packet.Extract<RadioPacket>();
            if (radioPacket != null)
            {
                Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
                                  packetIndex,
                                  e.Header.Timeval.Date.ToString(),
                                  e.Header.Timeval.Date.Millisecond,
                                  ethernetPacket.SourceHardwareAddress,
                                  ethernetPacket.DestinationHardwareAddress);
            }

            


            //Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
            //    time.Hour, time.Minute, time.Second, time.Millisecond, len);
            //Console.WriteLine(rawPacket.ToString());

            RefreshCap();
        }

        void StartStopCap(bool action)
        {
            var device = devices[comboBoxDevices.SelectedIndex];

            if (action) 
            {     
                // Register our handler function to the 'packet arrival' event
                device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

                // Open the device for capturing
                int readTimeoutMilliseconds = 1000;
                device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

                // Start the capturing process
                device.StartCapture();
            }
            else 
            {
                device.OnPacketArrival -= new PacketArrivalEventHandler(device_OnPacketArrival);
                device.Close();
                device.StopCapture();
            }
        }

        private void dataGridViewCap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {     
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void radioButton2View_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCap();
        }
    }
}
