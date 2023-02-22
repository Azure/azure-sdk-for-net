using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class AzureBlobFSLinkedService
    {
        /// <summary>
        /// Initializes a new instance of the AzureBlobFSLinkedService class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="connectVia">The integration runtime reference.</param>
        /// <param name="description">Linked service description.</param>
        /// <param name="parameters">Parameters for linked service.</param>
        /// <param name="annotations">List of tags that can be used for
        /// describing the linked service.</param>
        /// <param name="url">Endpoint for the Azure Data Lake Storage Gen2
        /// service. Type: string (or Expression with resultType
        /// string).</param>
        /// <param name="accountKey">Account key for the Azure Data Lake
        /// Storage Gen2 service. Type: string (or Expression with resultType
        /// string).</param>
        /// <param name="servicePrincipalId">The ID of the application used to
        /// authenticate against the Azure Data Lake Storage Gen2 account.
        /// Type: string (or Expression with resultType string).</param>
        /// <param name="servicePrincipalKey">The Key of the application used
        /// to authenticate against the Azure Data Lake Storage Gen2
        /// account.</param>
        /// <param name="tenant">The name or ID of the tenant to which the
        /// service principal belongs. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="azureCloudType">Indicates the azure cloud type of the
        /// service principle auth. Allowed values are AzurePublic, AzureChina,
        /// AzureUsGovernment, AzureGermany. Default value is the data factory
        /// regions’ cloud type. Type: string (or Expression with resultType
        /// string).</param>
        /// <param name="encryptedCredential">The encrypted credential used for
        /// authentication. Credentials are encrypted using the integration
        /// runtime credential manager. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="credential">The credential reference containing
        /// authentication information.</param>
        /// <param name="servicePrincipalCredentialType">The service principal
        /// credential type to use in Server-To-Server authentication.
        /// 'ServicePrincipalKey' for key/secret, 'ServicePrincipalCert' for
        /// certificate. Type: string (or Expression with resultType
        /// string).</param>
        /// <param name="servicePrincipalCredential">The credential of the
        /// service principal object in Azure Active Directory. If
        /// servicePrincipalCredentialType is 'ServicePrincipalKey',
        /// servicePrincipalCredential can be SecureString or
        /// AzureKeyVaultSecretReference. If servicePrincipalCredentialType is
        /// 'ServicePrincipalCert', servicePrincipalCredential can only be
        /// AzureKeyVaultSecretReference.</param>     
        public AzureBlobFSLinkedService(object url, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), IntegrationRuntimeReference connectVia = default(IntegrationRuntimeReference), string description = default(string), IDictionary<string, ParameterSpecification> parameters = default(IDictionary<string, ParameterSpecification>), IList<object> annotations = default(IList<object>), object accountKey = default(object), object servicePrincipalId = default(object), SecretBase servicePrincipalKey = default(SecretBase), object tenant = default(object), object azureCloudType = default(object), object encryptedCredential = default(object), CredentialReference credential = default(CredentialReference), object servicePrincipalCredentialType = default(object), SecretBase servicePrincipalCredential = default(SecretBase))
            : base(additionalProperties, connectVia, description, parameters, annotations)
        {
            Url = url;
            AccountKey = accountKey;
            ServicePrincipalId = servicePrincipalId;
            ServicePrincipalKey = servicePrincipalKey;
            Tenant = tenant;
            AzureCloudType = azureCloudType;
            EncryptedCredential = encryptedCredential;
            Credential = credential;
            ServicePrincipalCredentialType = servicePrincipalCredentialType;
            ServicePrincipalCredential = servicePrincipalCredential;
            CustomInit();
        }
    }
}
