using DataBoxEdge.Tests;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Management.DataBoxEdge.Tests.Tests
{
    public class ActivationKeyGeneration : DataBoxEdgeTestBase
    {
        #region Constructore
        ActivationKeyGeneration(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion

        [Fact]
        public void Test_GenerateActivationKey()
        {
            /*
             * ToDo: See How it can be recorded
             */
        }

        private string GetAadDeviceRegistrationKey(string resourceGroupName, string resourceName, string resourceLocation)
        {
            var generateCertResponse = GenerateVaultCertificate(resourceGroupName, resourceName);
            var certPublicPart = ImportCertificate(generateCertResponse.PublicKey);
            var uploadCertificate = UploadVaultCertificate(resourceGroupName, resourceName, certPublicPart);
            var regKey = GetAadActivationKey(resourceGroupName, resourceName, resourceLocation,
                generateCertResponse.PrivateKey, uploadCertificate);

            return regKey;
        }



        /// <summary>
        /// Generates the vault certificate.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public GenerateCertResponse GenerateVaultCertificate(string resourceGroupName,
            string resourceName)
        {
            return Client.Devices.GenerateCertificate(resourceName,
                   resourceGroupName);
        }

        /// <summary>
        /// Imports the raw data of a certificate into a X509Certificate2 object
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public X509Certificate2 ImportCertificate(string rawData)
        {
            var rawDataByteArray = Encoding.ASCII.GetBytes(rawData);
            var cert = new X509Certificate2();
            cert.Import(rawDataByteArray);
            return cert;
        }

        /// <summary>
        /// Uploads the vault certificate.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <param name="cert"></param>
        /// <returns></returns>
        private UploadCertificateResponse UploadVaultCertificate(string resourceGroupName,
            string resourceName, X509Certificate2 cert)
        {
            var request = new UploadCertificateRequest
            {
                Certificate = Convert.ToBase64String(cert.GetRawCertData())
            };

            return Client.Devices.UploadCertificate(resourceName, request,
               resourceGroupName);
        }

        /// <summary>
        /// Uploads the vault certificate.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <param name="resourceLocation"></param>
        /// <param name="certWithPrivateKey"></param>
        /// <param name="uploadCertificate"></param>
        /// <returns></returns>
        private string GetAadActivationKey(string resourceGroupName, string resourceName,
            string resourceLocation, string certWithPrivateKey,
            UploadCertificateResponse uploadCertificate)
        {
            var RegistrationKeyHashSize = 16;
            var vault = GetVaultCredentials(resourceGroupName, resourceName, resourceLocation, certWithPrivateKey, uploadCertificate);

            var st = JsonConvert.SerializeObject(vault);
            var plainTextBytes = Encoding.UTF8.GetBytes(st);
            var activation = Convert.ToBase64String(plainTextBytes);
            var hash = GenerateSha512Hash(activation);
            return $"{activation}#{hash.Substring(0, RegistrationKeyHashSize)}";
        }

        /// <summary>
        /// Gets the vault credentials.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <param name="resourceLocation"></param>
        /// <param name="serializedCertificate"></param>
        /// <param name="uploadCertificate"></param>
        /// <returns></returns>
        private VaultCredentials GetVaultCredentials(string resourceGroupName,
            string resourceName, string resourceLocation, string serializedCertificate, UploadCertificateResponse uploadCertificate)
        {
            const string AudienceFormat = @"https://azuredataboxedge/{0}/{1}/{2}";

            var aadAudience = string.IsNullOrWhiteSpace(uploadCertificate.AadAudience) ?
                string.Format(AudienceFormat, resourceLocation, uploadCertificate.ResourceId, uploadCertificate.ResourceId) :
                uploadCertificate.AadAudience;

            var vault = new VaultCredentials
            {
                SubscriptionId = "",
                ResourceType = "dataBoxEdgeDevices",
                ResourceName = resourceName,
                ManagementCert = serializedCertificate,
                ResourceId = uploadCertificate.ResourceId,
                AadAuthority = uploadCertificate.AadAuthority,
                AadAudience = aadAudience,
                AadTenantId = uploadCertificate.AadTenantId,
                ServicePrincipalClientId = uploadCertificate.ServicePrincipalClientId,
                AzureManagementEndpointAudience = uploadCertificate.AzureManagementEndpointAudience,
                ProviderNamespace = "Microsoft.DataBoxEdge",
                ResourceGroup = resourceGroupName,
                ServiceDataIntegrityKey = GenerateCIK(resourceName),
                IdentityProvider = "AAD"
            };

            return vault;
        }

        /// <summary>
        /// Generates the sha512 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string GenerateSha512Hash(string text)
        {
            var alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));

            return ConvertByteArrayToString(result);
        }

        /// <summary>
        /// Converts the byte array to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string ConvertByteArrayToString(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Generate CIK
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public string GenerateCIK(string resourceName)
        {
            var cik = GenerateSha512Hash(resourceName);

            return cik;
        }

    }

    #region VaultCredential
    /// <summary>
    /// Vault credentials
    /// </summary>
    public class VaultCredentials
    {
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string tmp = string.Empty;
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                tmp += $"{propertyInfo.Name}:{propertyInfo.GetValue(this)} ";
            }

            return tmp;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the key name for SubscriptionId entry.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceType entry.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceName entry.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for ManagementCert entry.
        /// </summary>
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the vault.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the AAD Authority.
        /// </summary>
        public string AadAuthority { get; set; }

        /// <summary>
        /// Gets or sets AadAudience
        /// </summary>
        public string AadAudience { get; set; }

        /// <summary>
        /// Gets or sets the AAD Tenant Id.
        /// </summary>
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets the Service Principal Client Id.
        /// </summary>
        public string ServicePrincipalClientId { get; set; }

        /// <summary>
        /// Gets or sets the Azure Management Endpoint Audience.
        /// </summary>
        public string AzureManagementEndpointAudience { get; set; }

        /// <summary>
        /// Gets or sets the ProviderNamespace.
        /// </summary>
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the Resource Group.
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        public string ServiceDataIntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets the IdentityProvider.
        /// </summary>
        public string IdentityProvider { get; set; }
        #endregion
    }
    #endregion
}
