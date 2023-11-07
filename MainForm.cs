using System;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using PacketDotNet;
using PacketDotNet.Ieee80211;
using System.Net;
using System.IO;

namespace Sniffer_FW._4._7._2
{
    public partial class MainForm : Form
    {
        DataTable tableDevices = new DataTable();
        DataTable tableCap = new DataTable();
        DataTable tableCapView2 = new DataTable();
        CaptureDeviceList devices = CaptureDeviceList.Instance;
        int packetIndex = 0;
        string filePath = "";

        private static CaptureFileWriterDevice captureFileWriter;
        public MainForm()
        {
            InitializeComponent();
            this.dataGridViewCap.SetDoubleBuffered(true);
        }

        void CountPackets() 
        {
            Invoke((MethodInvoker)delegate
            {
                labelCountPacket.Text = tableCap.Rows.Count.ToString();
            });
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

            });
        }
        void RefreshWithColor ()
        {
            if(buttonStart.Enabled)
            {
                foreach (DataGridViewRow row in this.dataGridViewCap.Rows)
                {
                    row.HeaderCell.Value = (row.Index + 1).ToString();
                    if (row.Index % 2 != 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

                this.dataGridViewCap.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }
            
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string defaultFolderPath = @"c:\!Caps\";
            string defaultFileName = "cap1.pcapng";

            string defaultFilePath = Path.Combine(defaultFolderPath, defaultFileName);

            // Check if the folder exists, create it if necessary
            if (!Directory.Exists(defaultFolderPath))
            {
                Directory.CreateDirectory(defaultFolderPath);
            }

            // Check if the file already exists, increment index if necessary
            int index = 1;
            string uniqueFilePath = defaultFilePath;
            while (File.Exists(uniqueFilePath))
            {
                string baseFileName = Path.GetFileNameWithoutExtension(defaultFilePath);
                string fileExtension = Path.GetExtension(defaultFilePath);
                uniqueFilePath = Path.Combine(defaultFolderPath, $"{baseFileName}_{index}{fileExtension}");
                index++;
            }

            saveFileDialog.InitialDirectory = defaultFolderPath;
            saveFileDialog.FileName = Path.GetFileName(uniqueFilePath);
            saveFileDialog.Filter = string.Empty;


            saveFileDialog.ShowDialog();
            filePath = saveFileDialog.FileName;

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            StartStopCap(true);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            StartStopCap(false);
            RefreshCap();
            RefreshWithColor();
        }

        private void device_OnPacketArrival(object sender, PacketCapture e)
        {
            packetIndex++;

            var time = e.Header.Timeval.Date;
            var len = e.Data.Length;

            var rawPacket = e.GetPacket();
            captureFileWriter.Write(rawPacket);

            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            var totlLenth = packet.TotalPacketLength;

            var timeToTable = $"{time.Hour}:{time.Minute}:{time.Second},{time.Millisecond}";
            DataRow newRow = tableDevices.NewRow();
            tableCap.Rows.Add(new object[] { timeToTable, len, rawPacket.ToString() });
            CountPackets();
            //EthernetPacket
            var ethernetPacket = packet.Extract<EthernetPacket>();
                      
            if (ethernetPacket != null)
            {
                if (ethernetPacket is EthernetPacket ethPacket)
                {
                    //ethPacket.SourceHardwareAddress = PhysicalAddress.Parse("00-11-22-33-44-55");
                    //ethPacket.DestinationHardwareAddress = PhysicalAddress.Parse("00-99-88-77-66-55");

                    var ip = packet.Extract<IPPacket>();
                    if (ip != null)
                    {
                        var ipPacket = "Original IP packet: " + ip.ToString();

                        //manipulate IP parameters
                        //ip.SourceAddress = System.Net.IPAddress.Parse("1.2.3.4");
                        //ip.DestinationAddress = System.Net.IPAddress.Parse("44.33.22.11");
                        //ip.TimeToLive = 11;

                        var sourceIpAddress = IPAddress.Parse(ip.SourceAddress.ToString());
                        var destinationIpAddress = IPAddress.Parse(ip.DestinationAddress.ToString());
                        var protocolType = ip.Protocol.ToString();
                        var packetLength = ip.TotalPacketLength;

                        var tcp = packet.Extract<TcpPacket>();
                        
                        if (tcp != null)
                        {
                            var tcpPacket = "Original TCP packet: " + tcp.ToString();

                            
                            var sourcePort = tcp.SourcePort;
                            var destinationPort = tcp.DestinationPort;

                            AddRowTotableCapView2(timeToTable, sourceIpAddress, destinationIpAddress, protocolType,
                                packetLength, sourcePort, destinationPort, tcpPacket);

                            //manipulate TCP parameters
                            //tcp.SourcePort = 9999;
                            //tcp.DestinationPort = 8888;
                            //tcp.Synchronize = !tcp.Synchronize;
                            //tcp.Finished = !tcp.Finished;
                            //tcp.Acknowledgment = !tcp.Acknowledgment;
                            //tcp.WindowSize = 500;
                            //tcp.AcknowledgmentNumber = 800;
                            //tcp.SequenceNumber = 800;
                        }

                        var udp = packet.Extract<UdpPacket>();
                        if (udp != null)
                        {
                            var udpPackeet = "Original UDP packet: " + udp.ToString();

                            var sourcePort = udp.SourcePort;
                            var destinationPort = udp.DestinationPort;

                            AddRowTotableCapView2 ( timeToTable, sourceIpAddress, destinationIpAddress, protocolType, 
                                packetLength, sourcePort, destinationPort, udpPackeet);

                            //manipulate UDP parameters
                            //udp.SourcePort = 9999;
                            //udp.DestinationPort = 8888;
                        }
                    }

                    #region variant1
                    //if (ethPacket.PayloadPacket is IPv4Packet ipv4Packet)
                    //{
                    //    var sourceIpAddress = ipv4Packet.SourceAddress;
                    //    //var sourceIpPort = ipv4Packet.ParentPack
                    //    var destinationIpAddress = ipv4Packet.DestinationAddress;
                    //    var protocolType = ipv4Packet.Protocol.ToString();
                    //    var packetLength = ipv4Packet.TotalPacketLength;


                    //    var tcpPacket = ipv4Packet.PayloadPacket as TcpPacket;

                    //    if (tcpPacket != null)
                    //    {
                    //        if (tcpPacket is TcpPacket _tcpPacket)
                    //        {
                    //            var payloadPacketString = ipv4Packet.PayloadPacket.ToString();
                    //            var sourcePort = _tcpPacket.SourcePort;
                    //            var destinationPort = _tcpPacket.DestinationPort;

                    //            tableCapView2.Rows.Add(new object[] { timeToTable, sourceIpAddress, destinationIpAddress, protocolType,
                    //        packetLength, sourcePort, destinationPort, payloadPacketString });
                    //        }                            
                    //    }

                    //}
                    //else if (ethPacket.PayloadPacket is UdpPacket udpPacket)
                    //{
                    //    var sourceIpAddress = udpPacket.ParentPacket;                        
                    //    var protocolType = udpPacket.GetType().ToString();
                    //    var packetLength = udpPacket.TotalPacketLength;

                    //    if (udpPacket != null)
                    //    {
                    //        // Handle UdpPacket
                    //        var payloadPacketString = udpPacket.PayloadPacket.ToString();
                    //        var sourcePort = udpPacket.SourcePort;
                    //        var destinationPort = udpPacket.DestinationPort;
                    //        tableCapView2.Rows.Add(new object[] { timeToTable, "", "", "",
                    //        "", sourcePort, destinationPort, payloadPacketString });

                    //    }


                    //}
                    #endregion
                }

                // Use the ToString method to get the IP address in the desired format


                Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
                                  packetIndex,
                                  e.Header.Timeval.Date.ToString(),
                                  e.Header.Timeval.Date.Millisecond,
                                  ethernetPacket.SourceHardwareAddress,
                                  ethernetPacket.DestinationHardwareAddress);
            }

            //RadioPacket
            var radioPacket = packet.Extract<RadioPacket>();
            if (radioPacket != null)
            {
                MessageBox.Show("RadioPacket");
            }

            var ppiPacket = packet.Extract<PpiPacket>();
            if (ppiPacket != null)
            {
                MessageBox.Show("PpiPacket");
            }            
            
        }
        void AddRowTotableCapView2(string timeToTable, IPAddress sourceIpAddress, IPAddress destinationIpAddress, string protocolType,
                            int packetLength, ushort sourcePort, ushort destinationPort, string udpPackeet)
        {
            tableCapView2.Rows.Add(new object[] { timeToTable, sourceIpAddress, destinationIpAddress, protocolType,
                            packetLength, sourcePort, destinationPort, udpPackeet });            
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
                
                captureFileWriter = new CaptureFileWriterDevice(filePath);
                captureFileWriter.Open(device);

                // Start the capturing process
                device.StartCapture();
            }
            else 
            {
                device.OnPacketArrival -= new PacketArrivalEventHandler(device_OnPacketArrival);
                device.Close();
                device.StopCapture();
                captureFileWriter.Close();

            }
        }
        private void dataGridViewCap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {     
            
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshCap();
            RefreshWithColor();
        }
        private void radioButton2View_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCap();
            RefreshWithColor();
        }
    }
}
