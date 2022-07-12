﻿using System.Security.Cryptography;
using System.Text;

namespace ecommerceapi.Tools
{
    public class Password
    {
        public static string hashPassword(string password)
        {
            var sha            = SHA256.Create();
            var asByteArray    = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}
