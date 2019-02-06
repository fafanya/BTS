using System;
using System.ServiceModel;
using BTS.Service;

namespace BTS.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost selfHost = new ServiceHost(typeof(TrackingService));
            try
            {
                selfHost.Open();
                Console.WriteLine("The service is ready. Press <ENTER> to terminate service.");
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}