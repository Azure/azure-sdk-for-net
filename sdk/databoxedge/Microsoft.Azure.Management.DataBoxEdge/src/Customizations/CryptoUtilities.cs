namespace Microsoft.Azure.Management.DataBoxEdge
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    /// <summary>
    /// The crypto helper.
    /// </summary>
    public class CryptoUtilities
    {
        /// <summary>
        /// The salt for generating encryption keys.
        /// </summary>
        private static readonly byte[] Salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        /// <summary>
        /// The AES algorithm is used to decrypt the given cipherText.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="sharedSecret">The shared secret.</param>
        /// <returns>The decrypted secret in pain text.</returns>
        public static string DecryptCipherAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            Aes aesAlg = null;

            string plaintext = null;

            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);

            // Create the streams used for decryption.
            byte[] bytes = Convert.FromBase64String(cipherText);
            using (MemoryStream memoryDecrypt = new MemoryStream(bytes))
            {
                aesAlg = Aes.Create();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Get the initialization vector from the encrypted stream
                aesAlg.IV = ReadByteArray(memoryDecrypt);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (CryptoStream cryptoDecrypt = new CryptoStream(memoryDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamDecrypt = new StreamReader(cryptoDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream and place them in a string.
                        plaintext = streamDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            Aes aesAlg = null;
            string plaintext = null;

            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);

            // Create the streams used for decryption.
            byte[] bytes = Convert.FromBase64String(cipherText);
            using (MemoryStream msDecrypt = new MemoryStream(bytes))
            {
                aesAlg = Aes.Create();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                // Get the initialization vector from the encrypted stream
                aesAlg.IV = ReadByteArray(msDecrypt);
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (CryptoStream csDecrypt =
                    new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                }
            }

            return plaintext;
        }

        /// <summary>
        /// This method encrypts a given secret using the public certificate.
        /// </summary>
        /// <param name="plainText">The secret in plain text.</param>
        /// <param name="publicCertificate">The public certificate to be used for encryption.</param>
        /// <returns>The encrypted secret.</returns>
        public static string EncryptSecretRSAPKCS(string plainText, string publicCertificate)
        {
            string encryptedSecret = null;
            encryptedSecret = EncryptStringRsaPkcs1v15(plainText, publicCertificate);
            return encryptedSecret;
        }

        public static string EncryptStringRsaPkcs1v15(string plaintext, string encodedCertificate)
        {
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(encodedCertificate));
            if (string.IsNullOrEmpty(plaintext) || cert == null)
            {
                return null;
            }

            byte[] textBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedTextBytes;

            // Create a new instance of RSACryptoServiceProvider, and encrypt the passed byte array and specify OAEP padding false to use PKCS#1 V1.5 padding.
#if FullNetFx
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
            encryptedTextBytes = rsa.Encrypt(textBytes, false);
#else
            RSA rsa = cert.GetRSAPublicKey();
            encryptedTextBytes = rsa.Encrypt(textBytes, RSAEncryptionPadding.Pkcs1);
#endif
            var encryptedBase64 = Convert.ToBase64String(encryptedTextBytes);
            return encryptedBase64;
        }

        /// <summary>
        /// Helper method to read byte array from a stream.
        /// </summary>
        /// <param name="s">The stream.</param>
        /// <returns>The byte array.</returns>
        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new Exception("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new Exception("Did not read byte array properly");
            }

            return buffer;
        }
    }
}