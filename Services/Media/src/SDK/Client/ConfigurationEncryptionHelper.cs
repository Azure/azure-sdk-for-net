using System;
using System.Globalization;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal static class ConfigurationEncryptionHelper
    {
        internal static string DecryptConfigurationString(CloudMediaContext cloudMediaContext, string encryptionKeyId, string initializationVector, string encryptedConfiguration)
        {
            if (cloudMediaContext == null)
            {
                throw new ArgumentNullException("cloudMediaContext");
            }

            if (string.IsNullOrEmpty(encryptionKeyId))
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, StringTable.ErrorArgCannotBeNullOrEmpty, "encryption key identifier"), "encryptionKeyId");
            }

            if (string.IsNullOrEmpty(initializationVector))
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, StringTable.ErrorArgCannotBeNullOrEmpty, "initialization vector"), "initializationVector");
            }

            if (string.IsNullOrEmpty(encryptedConfiguration))
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, StringTable.ErrorArgCannotBeNullOrEmpty, "encrypted configuration"), "encryptedConfiguration");
            }
            string returnValue;
            Guid keyId = EncryptionUtils.GetKeyIdAsGuid(encryptionKeyId);

            byte[] iv = Convert.FromBase64String(initializationVector);

            IContentKey configKey = cloudMediaContext.ContentKeys.Where(c => c.Id == encryptionKeyId).Single();
            byte[] contentKey = configKey.GetClearKeyValue();

            using (ConfigurationEncryption configEnc = new ConfigurationEncryption(keyId, contentKey, iv))
            {
                returnValue = configEnc.Decrypt(encryptedConfiguration);
            }

            return returnValue;
        }
         
    }
}