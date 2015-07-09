//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.EventSources;
using Security.Cryptography;
using Security.Cryptography.X509Certificates;

namespace BackupServices.Tests.Helpers
{
    public static class VaultTestHelper
    {
        public const string MsEnhancedProv = "Microsoft Enhanced Cryptographic Provider v1.0";
        public const string DefaultIssuer = "CN=Windows Azure Tools";

        public const string DefaultPassword = "";
        public const string OIDClientAuthValue = "1.3.6.1.5.5.7.3.2";
        public const string OIDClientAuthFriendlyName = "Client Authentication";
        public const int KeySize2048 = 2048;

        /// <summary>
        /// Windows Azure Service Management API requires 2048bit RSA keys.
        /// The private key needs to be exportable so we can save it to .pfx for sharing with team members.
        /// </summary>
        /// <returns>A 2048 bit RSA key</returns>
        private static CngKey Create2048RsaKey()
        {
            var keyCreationParameters = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowExport,
                KeyCreationOptions = CngKeyCreationOptions.None,
                KeyUsage = CngKeyUsages.AllUsages,
                Provider = new CngProvider(MsEnhancedProv)
            };

            keyCreationParameters.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(KeySize2048), CngPropertyOptions.None));

            return CngKey.Create(CngAlgorithm2.Rsa, null, keyCreationParameters);
        }

        /// <summary>
        /// Creates a new self-signed X509 certificate
        /// </summary>
        /// <param name="issuer">The certificate issuer</param>
        /// <param name="friendlyName">Human readable name</param>
        /// <param name="password">The certificate's password</param>
        /// <param name="startTime">Certificate creation date & time</param>
        /// <param name="endTime">Certificate expiry date & time</param>
        /// <returns>An X509Certificate2</returns>
        public static X509Certificate2 CreateSelfSignedCert(string issuer, string friendlyName, string password, DateTime startTime, DateTime endTime)
        {
            string distinguishedNameString = issuer;
            var key = Create2048RsaKey();

            var creationParams = new X509CertificateCreationParameters(new X500DistinguishedName(distinguishedNameString))
            {
                TakeOwnershipOfKey = true,
                StartTime = startTime,
                EndTime = endTime
            };

            // adding client authentication, -eku = 1.3.6.1.5.5.7.3.2, 
            // This is mandatory for the upload to be successful
            OidCollection oidCollection = new OidCollection();
            oidCollection.Add(new Oid(OIDClientAuthValue, OIDClientAuthFriendlyName));
            creationParams.Extensions.Add(new X509EnhancedKeyUsageExtension(oidCollection, false));

            // Documentation of CreateSelfSignedCertificate states:
            // If creationParameters have TakeOwnershipOfKey set to true, the certificate
            // generated will own the key and the input CngKey will be disposed to ensure
            // that the caller doesn't accidentally use it beyond its lifetime (which is
            // now controlled by the certificate object).
            // We don't dispose it ourselves in this case.
            var cert = key.CreateSelfSignedCertificate(creationParams);
            key = null;
            cert.FriendlyName = friendlyName;

            // X509 certificate needs PersistKeySet flag set.  
            // Reload a new X509Certificate2 instance from exported bytes in order to set the PersistKeySet flag.
            var bytes = cert.Export(X509ContentType.Pfx, password);

            // NOTE: PfxValidation is not done here because these are newly created certs and assumed valid.

            ICommonEventSource evtSource = null;
            return X509Certificate2Helper.NewX509Certificate2(bytes, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable, evtSource, doPfxValidation: false);
        }

        /// <summary>
        /// Returns serialized certificate - Base64 encoded based on the content type
        /// </summary>
        /// <param name="cert">The certificate provided</param>
        /// <param name="contentType">Cert content type</param>
        /// <returns>The serialized cert value in string</returns>
        public static string SerializeCert(X509Certificate2 cert, X509ContentType contentType)
        {
            return Convert.ToBase64String(cert.Export(contentType));
        }

        /// <summary>
        /// Generates friendly name
        /// </summary>
        /// <param name="subscriptionId">Subscription id</param>
        /// <param name="prefix">Prefix, likely resource name</param>
        /// <returns>Friendly name</returns>
        public static string GenerateCertFriendlyName(string subscriptionId, string prefix = "")
        {
            return string.Format("{0}{1}-{2}-vaultcredentials", prefix, subscriptionId, DateTime.Now.ToString("M-d-yyyy"));
        }

        /// <summary>
        /// Method to return the Certificate Expiry time in hours
        /// </summary>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public static int GetCertificateExpiryInHours(string resourceType = null)
        {
            return Constants.VaultCertificateExpiryInHoursForBackup;
        }
    }

    public static class Constants
    {
        public const int VaultCertificateExpiryInHoursForBackup = 48;
    }

    public enum AzureBackupVaultStorageType
    {
        GeoRedundant = 1,
        LocallyRedundant,
    }

    public enum AzureBackupVaultStorageTypeState
    {
        Locked = 1,
        Unlocked,
    }
}
