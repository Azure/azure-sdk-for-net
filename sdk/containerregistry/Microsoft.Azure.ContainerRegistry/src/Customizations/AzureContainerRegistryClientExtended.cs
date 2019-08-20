using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Azure.ContainerRegistry
{
    public partial class AzureContainerRegistryClient : ServiceClient<AzureContainerRegistryClient>, IAzureContainerRegistryClient, IAzureClient
    {

        // MANUALLY ADDED FOR TESTING PURPOSES
        /// <summary>
        /// Initializes a new instance of the AzureContainerRegistryClient class.
        /// </summary>
        /// <param name='baseUri'
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

        public AzureContainerRegistryClient(System.Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }

            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            BaseUri = "{url}";
            Credentials = credentials;
            if (Credentials != null)

            {
                Credentials.InitializeServiceClient(this);
            }

        }

    }
}
