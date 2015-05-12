using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleKeyVaultClientWebRole
{
    public static class Constants
    {
        public static string StorageAccountKeySecretUrlSetting = "StorageAccountKeySecretUrl";
        public static string StorageAccountNameSetting = "StorageAccountName";
        public static string KeyVaultAuthClientIdSetting = "KeyVaultAuthClientId";
        public static string KeyVaultAuthCertThumbprintSetting = "KeyVaultAuthCertThumbprint";
    }
}