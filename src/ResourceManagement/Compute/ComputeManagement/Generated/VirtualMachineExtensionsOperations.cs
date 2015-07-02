namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using Microsoft.Azure;
    using Models;

    internal partial class VirtualMachineExtensionsOperations : IServiceOperations<ComputeManagementClient>, IVirtualMachineExtensionsOperations
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineExtensionsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal VirtualMachineExtensionsOperations(ComputeManagementClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the ComputeManagementClient
        /// </summary>
        public ComputeManagementClient Client { get; private set; }

        /// <summary>
        /// The operation to create or update the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>    
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be create or
        /// updated.
        /// </param>    
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>    
        /// <param name='extensionParameters'>
        /// Parameters supplied to the Create Virtual Machine Extension operation.
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineExtension>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Send Request
            AzureOperationResponse<VirtualMachineExtension> response = await BeginCreateOrUpdateWithOperationResponseAsync(
                resourceGroupName, vmName, vmExtensionName, extensionParameters, cancellationToken);
            return await this.Client.GetPutOperationResultAsync<VirtualMachineExtension>(response, 
                () => GetWithOperationResponseAsync(resourceGroupName: resourceGroupName, vmName: vmName, vmExtensionName: vmExtensionName, cancellationToken: cancellationToken),
                cancellationToken);
        }

        /// <summary>
        /// The operation to create or update the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>    
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be create or
        /// updated.
        /// </param>    
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>    
        /// <param name='extensionParameters'>
        /// Parameters supplied to the Create Virtual Machine Extension operation.
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineExtension>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (vmName == null)
            {
                throw new ArgumentNullException("vmName");
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException("vmExtensionName");
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException("extensionParameters");
            }
            if (extensionParameters != null)
            {
                extensionParameters.Validate();
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("vmName", vmName);
                tracingParameters.Add("vmExtensionName", vmExtensionName);
                tracingParameters.Add("extensionParameters", extensionParameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdate", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{vmName}", Uri.EscapeDataString(vmName));
            url = url.Replace("{vmExtensionName}", Uri.EscapeDataString(vmExtensionName));
            List<string> queryParameters = new List<string>();
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            // Serialize Request  
            string requestContent = JsonConvert.SerializeObject(extensionParameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
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
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "Created")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
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
            var result = new AzureOperationResponse<VirtualMachineExtension>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineExtension>(responseContent, this.Client.DeserializationSettings);
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "Created"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineExtension>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// The operation to delete the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>    
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be deleted.
        /// </param>    
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Send request
            AzureOperationResponse response = await BeginDeleteWithOperationResponseAsync(
                resourceGroupName, vmName, vmExtensionName, cancellationToken);
            return await this.Client.GetPostOrDeleteOperationResultAsync(response, cancellationToken);
        }

        /// <summary>
        /// The operation to delete the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>    
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be deleted.
        /// </param>    
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (vmName == null)
            {
                throw new ArgumentNullException("vmName");
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException("vmExtensionName");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("vmName", vmName);
                tracingParameters.Add("vmExtensionName", vmExtensionName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "BeginDelete", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{vmName}", Uri.EscapeDataString(vmName));
            url = url.Replace("{vmExtensionName}", Uri.EscapeDataString(vmExtensionName));
            List<string> queryParameters = new List<string>();
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
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
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "Accepted") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// The operation to get the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>    
        /// <param name='vmName'>
        /// The name of the virtual machine containing the extension.
        /// </param>    
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>    
        /// <param name='expand'>
        /// Name of the property to expand. Allowed value is null or 'instanceView'.
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineExtension>> GetWithOperationResponseAsync(string resourceGroupName, string vmName, string vmExtensionName, string expand = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (vmName == null)
            {
                throw new ArgumentNullException("vmName");
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException("vmExtensionName");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("vmName", vmName);
                tracingParameters.Add("vmExtensionName", vmExtensionName);
                tracingParameters.Add("expand", expand);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{vmName}", Uri.EscapeDataString(vmName));
            url = url.Replace("{vmExtensionName}", Uri.EscapeDataString(vmExtensionName));
            List<string> queryParameters = new List<string>();
            if (expand != null)
            {
                queryParameters.Add(string.Format("$expand={0}", Uri.EscapeDataString(expand)));
            }
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
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
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
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
            var result = new AzureOperationResponse<VirtualMachineExtension>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineExtension>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
