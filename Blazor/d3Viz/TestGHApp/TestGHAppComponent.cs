using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace TestGHApp
{
    public class TestGHAppComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public TestGHAppComponent()
          : base("TestGHApp", "TestGHApp",
            "TestGHApp",
            "TestGHApp", "TestGHApp")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("OpenBrowser", "OpenBrowser", "OpenBrowser", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Success", "Success", "Success", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool toRunWeb = false;
            bool success = false;
            string processName = "";
            if(!DA.GetData(0, ref toRunWeb)){ return; }

            if (toRunWeb)
            {
                ProcessStartInfo ps = new ProcessStartInfo();
                var curFolder = Directory.GetCurrentDirectory();
                string filename = "RunServer.bat";

                ps.FileName = filename;
                //ps.WindowStyle= ProcessWindowStyle.Hidden;
                ps.UseShellExecute= true;
                Process d3Viz = Process.Start(ps);
                processName = d3Viz.ProcessName;

                var ping = new Ping();
                while (!success)
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        try
                        {
                            tcpClient.Connect("127.0.0.1", 4000);
                            success = true;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                Process.Start(new ProcessStartInfo
                {
                    FileName = "http://localhost:4000",
                    UseShellExecute = true
                });
            }
            else
            {
               List<Process> allProcesses = Process.GetProcessesByName("cmd").ToList();
                allProcesses.AddRange(Process.GetProcessesByName("node"));
                foreach (var process in allProcesses)
                {
                    process.Kill();
                }
            }
            
            DA.SetData(0, success);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("c5e6ee91-7056-4bd2-9e73-bee682844b70");
    }
}