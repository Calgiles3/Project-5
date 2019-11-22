using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashing_DLL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string salt = Hashing.Salt();
            string hash = Hashing.Hash("Cse445ta!", salt);

            System.Diagnostics.Debug.WriteLine(String.Format("salt: {0}\nhash: {1}", salt, hash));
        }
    }
}
