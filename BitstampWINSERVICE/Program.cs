using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitstampWINSERVICE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //#if (!DEBUG)
            //            ServiceBase[] ServicesToRun;
            //            ServicesToRun = new ServiceBase[]
            //            {
            //                new Service1()
            //            };
            //            ServiceBase.Run(ServicesToRun);
            //#else
            //            Service1 myServ = new Service1();
            //            myServ.Start();
            //            Thread.Sleep(60000);
            //            myServ.Stop();
            //#endif
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                            new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
