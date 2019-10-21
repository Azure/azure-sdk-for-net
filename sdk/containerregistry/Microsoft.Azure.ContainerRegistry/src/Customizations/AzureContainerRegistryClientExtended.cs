using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System.Net.Http;
namespace Microsoft.Azure.ContainerRegistry
{
    public partial class AzureContainerRegistryClient : ServiceClient<AzureContainerRegistryClient>, IAzureContainerRegistryClient, IAzureClient
    {

        // MANUALLY ADDED FOR INTERNAL TEST PURPOSES / FOR TESTING FRAMEWORK USE ONLY
        /// <summary>
        /// Initializes a new instance of the AzureContainerRegistryClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>

        internal AzureContainerRegistryClient(System.Uri loginUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (loginUri == null)
            {
                throw new System.ArgumentNullException(nameof(loginUri));
            }

            BaseUri = "{url}";
            Credentials = credentials ?? throw new System.ArgumentNullException(nameof(credentials));
            if (Credentials != null)

            {
                Credentials.InitializeServiceClient(this);
            }

        }

        /// <summary>
        /// Initializes a new instance of the AzureContainerRegistryClient class. Allows users to specify a loginUrl
        /// </summary>
        /// <param name='loginUrl'>
        /// Required The base URl of the Azure Container Registry Service
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public AzureContainerRegistryClient(string loginUrl, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }

            // prevents issues if caller sets an incorrect '/' at the end
            if (loginUrl.EndsWith("/")) {
                loginUrl = loginUrl.Substring(0, loginUrl.Length - 1);
            }

            // prevents issues if caller does not prefix url with "http" 
            if (!loginUrl.ToLower().StartsWith("http"))
            {
                loginUrl = $"https://{loginUrl}";
            }

            // set fields / properties
            LoginUri = loginUrl;
            Credentials = credentials; 
            Credentials.InitializeServiceClient(this);
        }
    }

}


