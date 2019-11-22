using System.Security.Cryptography;
using System.Text;

namespace Hashing_DLL
{
    /// <summary>
    /// Implements hashing functionalities for password handling.
    /// </summary>
    public class Hashing
    {
        private static int SALTLENGTH = 16;

        /// <summary>
        /// Create a salt of default length.
        /// </summary>
        /// <returns></returns>
        public static string Salt()
        {
            byte[] salt = new byte[SALTLENGTH];

            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            r.GetBytes(salt);

            string returnString = Encoding.UTF8.GetString(salt);

            return returnString;
        }

        /// <summary>
        /// Hash a password along with a salt.
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <param name="salt">Salt to add to hash</param>
        /// <returns>Hash value in string form for storage</returns>
        public static string Hash(string password, string salt)
        {
            byte[] s = Encoding.UTF8.GetBytes(salt);
            byte[] pw = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[s.Length + password.Length];

            // Concat the salt and password.
            s.CopyTo(saltedPassword, 0);
            pw.CopyTo(saltedPassword, s.Length);

            // Hash the salted password.
            HashAlgorithm hashAlgorithm = SHA256.Create();
            byte[] hashedAndSaltedPW = hashAlgorithm.ComputeHash(saltedPassword);

            // Convert the byte array into string for storage
            string returnString = Encoding.UTF8.GetString(hashedAndSaltedPW);

            return returnString;
        }

        /// <summary>
        /// Compare a password to a stored hash and salt.
        /// </summary>
        /// <param name="password">Password entered by user</param>
        /// <param name="hash">Stored hash for that user.</param>
        /// <param name="salt">Stored salt for that user.</param>
        /// <returns></returns>
        public static bool validatePassword(string password, string hash, string salt)
        {
            string hashedPW = Hash(password, salt);
            return hash.Equals(hashedPW);
        }


    }
}
