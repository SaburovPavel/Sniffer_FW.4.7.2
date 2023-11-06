using SharpPcap;
using System;

namespace Sniffer_FW._4._7._2
{
    internal class PcapParcer
    {
        public static void device_OnPacketArrival(object sender, PacketCapture e)
        {
            var time = e.Header.Timeval.Date;
            var len = e.Data.Length;
            var rawPacket = e.GetPacket();
            Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
                time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Console.WriteLine(rawPacket.ToString());
        }
    }
}
