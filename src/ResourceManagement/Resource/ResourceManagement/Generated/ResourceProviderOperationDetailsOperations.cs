using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    internal partial class ResourceProviderOperationDetailsOperations : IServiceOperations<ResourceManagementClient>, IResourceProviderOperationDetailsOperations
    {
        /// <summary>
        /// Initializes a new instance of the ResourceProviderOperationDetailsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal ResourceProviderOperationDetailsOperations(ResourceManagementClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the ResourceManagementClient
        /// </summary>
        public ResourceManagementClient Client { get; private set; }

        /// <summary>
        /// Gets a list of resource providers.
        /// </summary>
        /// <param name='resourceProviderNamespace'>
        /// Resource identity.
        /// </param>    
        /// <param name='apiVersion'>
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<IList<ResourceProviderOperationDefinition>>> ListWithOperationResponseAsync(string resourceProviderNamespace, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (resourceProviderNamespace == null)
            {
                throw new ArgumentNullException("resourceProviderNamespace");
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException("apiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceProviderNamespace", resourceProviderNamespace);
                tracingParameters.Add("apiVersion", apiVersion);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "List", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri.TrimEnd('/') + 
                         "/providers/{resourceProviderNamespace}/operations";
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{resourceProviderNamespace}", Uri.EscapeDataString(resourceProviderNamespace));
            List<string> queryParameters = new List<string>();
            if (apiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));
            }
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                CloudException ex = new CloudException(responseContent);
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            AzureOperationResponse<IList<ResourceProviderOperationDefinition>> result = new AzureOperationResponse<IList<ResourceProviderOperationDefinition>>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent"))
            {
              result.Body = JsonConvert.DeserializeObject<List<ResourceProviderOperationDefinition>>(responseContent, this.Client.DeserializationSettings);
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
              result.Body = JsonConvert.DeserializeObject<List<ResourceProviderOperationDefinition>>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
