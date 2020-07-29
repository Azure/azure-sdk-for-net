using System;
using System.Text;
using System.Security.Cryptography;

namespace CdnSignedUrlSignatureComputationSample
{
    class SignedUrlSignature
    {
        /// <summary>
        /// Converts input to URL safe base64 string.
        /// </summary>
        /// <param name="signature">Computed signature.</param>
        /// <returns>Url safe base64 signature.</returns>
        private string ConvertToUrlSafeBase64String(byte[] signature)
        {
            return Convert.ToBase64String(signature).Replace('/', '_').Replace('+', '-');
        }

        /// <summary>
        /// Function to compute signature.
        /// </summary>
        /// <param name="resourcePath">Resource Path.</param>
        /// <param name="expiresParamName">Expires parameter name.</param>
        /// <param name="expiresParamValue">Expires parameter value.</param>
        /// <param name="keyParamName">Key parameter name.</param>
        /// <param name="keyParamValue">Key parameter value.</param>
        /// <param name="secret">Key to use to compute hash.</param>
        /// <returns>Signature.</returns>
        public string GetSignature(string resourcePath, string expiresParamName, string expiresParamValue, string keyParamName, string keyParamValue, string secret)
        {
            if (string.IsNullOrEmpty(resourcePath))
            {
                throw new ArgumentException("Input parameter 'resourcePath' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(expiresParamName))
            {
                throw new ArgumentException("Input parameter 'expiresParamName' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(expiresParamValue))
            {
                throw new ArgumentException("Input parameter 'expiresParamValue' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(keyParamName))
            {
                throw new ArgumentException("Input parameter 'keyParamName' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(keyParamValue))
            {
                throw new ArgumentException("Input parameter 'keyParamValue' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("Input parameter 'secret' cannot be null or empty");
            }

            // Create the string to hash
            string data = resourcePath + "?" + expiresParamName + "=" + expiresParamValue + "&" + keyParamName + "=" + keyParamValue;

            byte[] signature;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(secret)))
            {
                signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            }

            return this.ConvertToUrlSafeBase64String(signature);
        }
    }
}
