using Microsoft.Azure.Management.DataBoxEdge.Models;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Management.DataBoxEdge
{
    internal static class ActivationKeyHelper
    {
        #region GenerateActivationKey

        /// <summary>
        /// Generates the vault certificate.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        internal static GenerateCertResponse GenerateVaultCertificate(IDevicesOperations operations, string resourceGroupName,
            string resourceName)
        {
            return operations.GenerateCertificate(resourceName,
                   resourceGroupName);
        }

        /// <summary>
        /// Imports the raw data of a certificate into a X509Certificate2 object
        /// </summary>
        /// <returns>Returns the X509Certificate2 format of public part of the certificate</returns>
        internal static X509Certificate2 ImportCertificate(string rawData)
        {
            var rawDataByteArray = Encoding.UTF8.GetBytes(rawData);
            var cert = new X509Certificate2(rawDataByteArray);
            return cert;
        }

        /// <summary>
        /// Uploads the vault certificate.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <param name="cert"></param>
        /// <returns></returns>
        internal static UploadCertificateResponse UploadVaultCertificate(IDevicesOperations operations, string resourceGroupName,
            string resourceName, X509Certificate2 cert)
        {
            var request = new UploadCertificateRequest
            {
                Certificate = Convert.ToBase64String(cert.RawData)
            };
             
            return operations.UploadCertificate(resourceName, request,
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
        internal static string GetAadActivationKey(string resourceGroupName, string resourceName,
            string resourceLocation, string certWithPrivateKey,
            UploadCertificateResponse uploadCertificate, string subscriptionId, string cik)
        {
            var RegistrationKeyHashSize = 16;
            var vault = GetVaultCredentials(resourceGroupName, resourceName, resourceLocation, certWithPrivateKey, uploadCertificate, subscriptionId, cik);

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
        public static ActivationKeyComponents GetVaultCredentials(string resourceGroupName,
            string resourceName, string resourceLocation, string serializedCertificate, UploadCertificateResponse uploadCertificate, string subscriptionId, string cik)
        {
            const string AudienceFormat = @"https://azuredataboxedge/{0}/{1}/{2}";

            var aadAudience = string.IsNullOrWhiteSpace(uploadCertificate.AadAudience) ?
                string.Format(AudienceFormat, resourceLocation, uploadCertificate.ResourceId, uploadCertificate.ResourceId) :
                uploadCertificate.AadAudience;

            var vault = new ActivationKeyComponents
            {
                SubscriptionId = subscriptionId,
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
                ServiceDataIntegrityKey = cik,
                IdentityProvider = "AAD"
            };

            return vault;
        }

        /// <summary>
        /// Generates the sha512 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        internal static string GenerateSha512Hash(string text)
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
    }

    #region ActivationKeyComponents
    /// <summary>
    /// Components of Activation Key
    /// </summary>
    public class ActivationKeyComponents
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the SubscriptionId
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
    #endregion
}

