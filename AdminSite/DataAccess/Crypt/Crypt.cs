using System.Security.Cryptography;

namespace AdminSite.DataAccess.Crypt
{
    /// <summary>
    /// Handles Encryption with Hash and Salt.
    /// </summary>
    public class Crypt
    {
        /// <summary>
        /// Generates the Salt.
        /// </summary>
        /// <returns>Random Number created by RNGCryptTOServiceProvider.</returns>
        public byte[] GenerateSalt()
        {
            const int saltLength = 100; //Given more time I would place this in a settings file.

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        /// <summary>
        /// Combines password and Salt into one byte array.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>HashedSalted byte array</returns>
        private byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        /// <summary>
        /// Hash and Salt the password, using SHA256.
        /// </summary>
        /// <param name="toBeHashed"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(toBeHashed, salt));
            }
        }
    }
}