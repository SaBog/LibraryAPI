using System.Security.Cryptography;
using System.Text;

namespace Library.Application.Auth
{
    public static class PasswordManager
    {
        // in example purpose
        public static string Hash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA256.HashData(passwordBytes);
            var hash = Encoding.UTF8.GetString(hashBytes);

            return hash;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            var hash = Hash(password);
            return hashedPassword.Equals(hash);
        }

    }
}
