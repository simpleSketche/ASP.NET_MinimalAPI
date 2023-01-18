using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace TestGHApp
{
    public class TestGHAppInfo : GH_AssemblyInfo
    {
        public override string Name => "TestGHApp";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("27355244-1ea6-4363-806a-f82602d0975a");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}