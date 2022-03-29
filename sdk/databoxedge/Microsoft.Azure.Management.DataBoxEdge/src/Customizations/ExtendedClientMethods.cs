using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Management.DataBoxEdge
{
    public static partial class ExtendedClientMethods
    {
        private const int StandardSizeOfCIK = 128;

        /// <summary>
        /// Use this method to encrypt the user secrets (Storage Account Access Key, Volume Container Encryption Key etc.) using CIK
        /// </summary>
        /// <param name="deviceName">
        /// The resource name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="plainTextSecret">
        /// The plain text secret.
        /// </param>
        /// <returns>
        /// The <see cref="AsymmetricEncryptedSecret"/>.
        /// </returns>
        /// <exception cref="ValidationException">
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public static AsymmetricEncryptedSecret GetAsymmetricEncryptedSecret(
            this IDevicesOperations operations,
                string deviceName,
                string resourceGroupName,
                string plainTextSecret,
                string channelIntegrationKey)
        {
            if (string.IsNullOrWhiteSpace(plainTextSecret))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "plainTextSecret");
            }

            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "resourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(deviceName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "resourceName");
            }

            DataBoxEdgeDeviceExtendedInfo extendedInfo = operations.GetExtendedInformation(deviceName, resourceGroupName);
            string encryptionKey = extendedInfo.EncryptionKey;
            string encryptionKeyThumbprint = extendedInfo.EncryptionKeyThumbprint;

            string ChannelEncryptionKey = CryptoUtilities.DecryptStringAES(encryptionKey, channelIntegrationKey);

            var secret = new AsymmetricEncryptedSecret()
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES256,
                EncryptionCertThumbprint = encryptionKeyThumbprint,
                Value = CryptoUtilities.EncryptStringRsaPkcs1v15(plainTextSecret, ChannelEncryptionKey)
            };

            return secret;
        }


        private static string GetChannelIntegrityKey(string activationKey)
        {
            string[] keys = activationKey.Split('#');
            string encodedString = keys[0];
            byte[] data = Convert.FromBase64String(encodedString);
            string decodedString = Encoding.UTF8.GetString(data);
            var jsondata = (JObject)JsonConvert.DeserializeObject(decodedString);
            string serviceDataIntegrityKey = jsondata["serviceDataIntegrityKey"].Value<string>();
            return serviceDataIntegrityKey;
        }

        /// <summary>
        /// Use this method to generate the activation key for a device to register it with the ASE resource
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="resourceName">Name of the resource</param>
        /// <param name="resourceLocation">Location of the resource</param>

        /// <returns></returns>
        public static string GenerateActivationKey(this IDevicesOperations operations,
            string resourceGroupName,
            string resourceName,
            string cik)
        {
            var resourceLocation = operations.Get(resourceName, resourceGroupName).Location;
            var subscriptionId = (operations as DevicesOperations).Client.SubscriptionId;
            var generateCertResponse = ActivationKeyHelper.GenerateVaultCertificate(operations, resourceGroupName, resourceName);
            var certPublicPart = ActivationKeyHelper.ImportCertificate(generateCertResponse.PublicKey);
            var uploadCertificateResponse = ActivationKeyHelper.UploadVaultCertificate(operations, resourceGroupName, resourceName, certPublicPart);
            var activationKeyToRegisterTheResource = ActivationKeyHelper.GetAadActivationKey(resourceGroupName, resourceName, resourceLocation,
                generateCertResponse.PrivateKey, uploadCertificateResponse, subscriptionId, cik);

            return activationKeyToRegisterTheResource;
        }

        /// <summary>
        /// This method generates the CIK of length 128 chars
        /// </summary>
        /// <returns></returns>
        public static string GenerateCIK(this IDevicesOperations operations)
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            var byteArr = new byte[128];
            randomNumberGenerator.GetBytes(byteArr);
            var cik = Convert.ToBase64String(byteArr).Substring(0, StandardSizeOfCIK);

            return cik;
        }
    }
}
