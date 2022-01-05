using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class GoogleAdWordsLinkedService : LinkedService
    {
        /// <summary>
        /// Initializes a new instance of the GoogleAdWordsLinkedService class.
        /// </summary>
        /// <param name="clientCustomerID">The Client customer ID of the
        /// AdWords account that you want to fetch report data for.</param>
        /// <param name="developerToken">The developer token associated with
        /// the manager account that you use to grant access to the AdWords
        /// API.</param>
        /// <param name="authenticationType">The OAuth 2.0 authentication
        /// mechanism used for authentication. ServiceAuthentication can only
        /// be used on self-hosted IR. Possible values include:
        /// 'ServiceAuthentication', 'UserAuthentication'</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="connectVia">The integration runtime reference.</param>
        /// <param name="description">Linked service description.</param>
        /// <param name="parameters">Parameters for linked service.</param>
        /// <param name="annotations">List of tags that can be used for
        /// describing the linked service.</param>
        /// <param name="refreshToken">The refresh token obtained from Google
        /// for authorizing access to AdWords for UserAuthentication.</param>
        /// <param name="clientId">The client id of the google application used
        /// to acquire the refresh token. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="clientSecret">The client secret of the google
        /// application used to acquire the refresh token.</param>
        /// <param name="email">The service account email ID that is used for
        /// ServiceAuthentication and can only be used on self-hosted
        /// IR.</param>
        /// <param name="keyFilePath">The full path to the .p12 key file that
        /// is used to authenticate the service account email address and can
        /// only be used on self-hosted IR.</param>
        /// <param name="trustedCertPath">The full path of the .pem file
        /// containing trusted CA certificates for verifying the server when
        /// connecting over SSL. This property can only be set when using SSL
        /// on self-hosted IR. The default value is the cacerts.pem file
        /// installed with the IR.</param>
        /// <param name="useSystemTrustStore">Specifies whether to use a CA
        /// certificate from the system trust store or from a specified PEM
        /// file. The default value is false.</param>
        /// <param name="encryptedCredential">The encrypted credential used for
        /// authentication. Credentials are encrypted using the integration
        /// runtime credential manager. Type: string (or Expression with
        /// resultType string).</param>
        public GoogleAdWordsLinkedService(object clientCustomerID, SecretBase developerToken, string authenticationType, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), IntegrationRuntimeReference connectVia = default(IntegrationRuntimeReference), string description = default(string), IDictionary<string, ParameterSpecification> parameters = default(IDictionary<string, ParameterSpecification>), IList<object> annotations = default(IList<object>), SecretBase refreshToken = default(SecretBase), object clientId = default(object), SecretBase clientSecret = default(SecretBase), object email = default(object), object keyFilePath = default(object), object trustedCertPath = default(object), object useSystemTrustStore = default(object), object encryptedCredential = default(object))
            : base(additionalProperties, connectVia, description, parameters, annotations)
        {
            ClientCustomerID = clientCustomerID;
            DeveloperToken = developerToken;
            AuthenticationType = authenticationType;
            RefreshToken = refreshToken;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Email = email;
            KeyFilePath = keyFilePath;
            TrustedCertPath = trustedCertPath;
            UseSystemTrustStore = useSystemTrustStore;
            EncryptedCredential = encryptedCredential;
            CustomInit();
        }
    }
}
