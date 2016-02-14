using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication1
{
    [Serializable]
    [ILSerialization.HiPerfSerializable]
    public class TestClass
    {
        public String Name;
    }

    class Program
    {

        static void Main(string[] args)
        {
            int len = int.Parse(args[0]);

            TestClass oT = new TestClass();
            oT.Name = "Hello Bin Serializer";

            System.Diagnostics.Stopwatch w = System.Diagnostics.Stopwatch.StartNew();
            w.Start();

            for (int i = 0; i < len; i++)
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, oT);
                ms.Close();
            }

            w.Stop();
            Console.WriteLine("Time elapsed .net binary serializer= " + w.ElapsedMilliseconds);



            //now let us see how our high performance serializer performs
            w = System.Diagnostics.Stopwatch.StartNew();
            w.Start();
            for (int i = 0; i < len; i++)
            {
                MemoryStream ms = new MemoryStream();
                ILSerialization.Formatters.HiPerfBinaryFormatter hpSer = new ILSerialization.Formatters.HiPerfBinaryFormatter();
                hpSer.Serialize(ms, oT);
                ms.Close();
            }

            w.Stop();


            Console.WriteLine("Time elapsed IL hi perf serializer= " + w.ElapsedMilliseconds);

        }
    }
}
