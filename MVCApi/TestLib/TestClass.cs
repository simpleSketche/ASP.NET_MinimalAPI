

namespace TestLib
{
    public class TestClass : ITestLib
    {

        public string PrintMsg(string msg)
        {
            Random rand = new Random(DateTime.Now.Second);
            msg = msg + rand.ToString();
            return msg;
        }
    }
}