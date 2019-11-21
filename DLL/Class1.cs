using System;
using System.Net.Security;
using System.Security.Cryptography;

namespace Encrypti
{
    public class Class1
    {
        private const int salt_length = 16;
        public static string Hash(string password)
        {
            byte[] salt = new byte[salt_length];
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            r.GetBytes(salt);


        }
    }
}
