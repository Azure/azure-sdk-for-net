
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using System;

    using Microsoft.Azure.Management.StorSimple8000Series.Models;
    using Microsoft.Azure.Management.StorSimple8000Series;
    using Microsoft.Rest;

    public partial class ManagersOperationsExtensions
    {
        /// <summary>
        /// Use this method to encrypt the user secrets (Storage Account Access Key, Volume Container Encryption Key etc.)
        /// </summary>
        /// <param name="managerName">
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
            this IManagersOperations operations,
            string resourceGroupName, 
            string managerName,
            string plainTextSecret)
        {
            if (string.IsNullOrWhiteSpace(plainTextSecret))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "plainTextSecret");
            }

            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "resourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(managerName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "managerName");
            }

            var encryptionSettings = operations.GetEncryptionSettings(resourceGroupName, managerName);
            
            if (encryptionSettings.EncryptionStatus == EncryptionStatus.Disabled)
            {
                throw new InvalidOperationException(
                    "The EncryptionStatus of this resource is disabled. Register atleast 1 device to your resource before proceeding");
            }

            var encryptionKey = operations.GetPublicEncryptionKey(resourceGroupName, managerName);

            if (encryptionKey.Value == null)
            {
                throw new InvalidOperationException(
                    "The encryptionKey is null. Register atleast 1 device to your resource before proceeding");
            }

            var managerExtendedInfo = operations.GetExtendedInfo(resourceGroupName, managerName);

            if (managerExtendedInfo == null || string.IsNullOrEmpty(managerExtendedInfo.IntegrityKey))
            {
                throw new InvalidOperationException("An unexpected error has occured in your system. Please retry the operation after sometime or contact support");
            }

            // Decrypt the encrypted encryption key using integrity key.
            var plainTextEncryptionKey = CryptoHelper.DecryptCipherAES(encryptionKey.Value, managerExtendedInfo.IntegrityKey);

            // Encrypt the user secret using the plain text encryption key.
            var encryptedSecret = CryptoHelper.EncryptSecretRSAPKCS(plainTextSecret, plainTextEncryptionKey);

            return new AsymmetricEncryptedSecret(encryptedSecret, EncryptionAlgorithm.RSAESPKCS1V15, encryptionKey.ValueCertificateThumbprint);
        }
    }
}