
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.Azure.Management.StorSimple8000Series.Models;
    using Microsoft.Azure.Management.StorSimple8000Series;

    /// <summary>
    /// The managers operations extensions.
    /// </summary>
    public static partial class ManagersOperationsExtensions
    {
        /// <summary>
        /// Use this method to fetch the Registration Key which can used for device registration.
        /// </summary>
        /// <param name="operations">
        /// The operations group for this extension method. 
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="managerName">
        /// The manager name.
        /// </param>
        /// <returns>
        /// The device registration key.
        /// </returns>
        public static string GetDeviceRegistrationKey(this IManagersOperations operations, string resourceGroupName, string managerName)
        {
            Key activationKey = null;

            try
            {
                activationKey = operations.GetActivationKey(resourceGroupName, managerName);
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "The call to get the activation key failed. Check inner exception for more details.",
                    exception);
            }

            ManagerExtendedInfo managerExtendedInfo = null;

            try
            {
                managerExtendedInfo = operations.GetExtendedInfo(resourceGroupName, managerName);
            }
            catch (Microsoft.Rest.Azure.CloudException cloudException)
            {

                if (cloudException != null && cloudException.Response != null
                    && !string.IsNullOrEmpty(cloudException.Response.Content))
                {
                    #if FullNetFx
                    if (cloudException.Response.Content.IndexOf("ResourceExtendedInfoNotFound", StringComparison.InvariantCultureIgnoreCase) >= 0)
                    #else
                    if (cloudException.Response.Content.IndexOf("ResourceExtendedInfoNotFound", StringComparison.OrdinalIgnoreCase) >= 0)
                    #endif
                    {
                        // Manager extended info not found for manager, creating new extended info"
                        var extendedInfo = new ManagerExtendedInfo()
                        {
                            IntegrityKey = GenerateRandomKey(128),
                            Algorithm = "None",
                        };

                        managerExtendedInfo = operations.CreateExtendedInfo(extendedInfo, resourceGroupName, managerName);
                    }
                    else
                    {
                        // cases like user session token expired, etc.
                        throw cloudException;
                    }

                }
            }
            
            var registrationKeyWithoutHash = string.Format(
                "{0}:{1}",
                activationKey.ActivationKey,
                managerExtendedInfo.IntegrityKey);

            var sha512Hash = GenerateSha512Hash(registrationKeyWithoutHash);

            var truncatedHash = sha512Hash.Substring(0, 16);

            return string.Format("{0}#{1}", registrationKeyWithoutHash, truncatedHash);
        }

        /// <summary>
        /// Generate cryptographically random key of given bit size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns> the key </returns>
        private static string GenerateRandomKey(int size)
        {
            byte[] key = new byte[(int)size / 8];
#if FullNetFx
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
#else
            System.Security.Cryptography.RandomNumberGenerator crypto = System.Security.Cryptography.RandomNumberGenerator.Create();
#endif
            crypto.GetBytes(key);
            return Convert.ToBase64String(key);
        }

        /// <summary>
        /// Generate SHA512 hash for the inputText.
        /// </summary>
        /// <param name="inputText">
        /// The input text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GenerateSha512Hash(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return inputText;
            }

            // Convert to Bytes
#if FullNetFx
            byte[] bytes = Encoding.Default.GetBytes(inputText);
#else
            int WindowsDefaultEncodingCodePage = 65001; // utf-8
            byte[] bytes = Encoding.GetEncoding(WindowsDefaultEncodingCodePage).GetBytes(inputText);
#endif

            // Generate the Hashed bytes
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(bytes);

            // Convert result back to string.
            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}