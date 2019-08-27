using Microsoft.Azure.ContainerRegistry.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Azure.ContainerRegistry
{
    public partial class AzureContainerRegistryClient : ServiceClient<AzureContainerRegistryClient>, IAzureContainerRegistryClient, IAzureClient
    {

        // MANUALLY ADDED FOR INTERNAL TEST PURPOSES
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

        public AzureContainerRegistryClient(System.Uri loginUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (loginUri == null)
            {
                throw new System.ArgumentNullException("loginUri");
            }

            BaseUri = "{url}";
            Credentials = credentials ?? throw new System.ArgumentNullException("credentials");
            if (Credentials != null)

            {
                Credentials.InitializeServiceClient(this);
            }

        }

        /// <summary>
        /// Initializes a new instance of the AzureContainerRegistryClient class.
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
            //Removes issues with clients potentially setting an incorrect / at the end
            if (loginUrl.EndsWith("/")) {
                loginUrl = loginUrl.Substring(0, loginUrl.Length - 1);
            }

            //Removes issues with clients forgetting to set the http entry point
            if (!loginUrl.ToLower().StartsWith("http"))
            {
                loginUrl = "https://" + loginUrl;
            }

            LoginUri = loginUrl;

            Credentials = credentials ?? throw new System.ArgumentNullException("credentials");
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
        }

        #region Pseudo-Generated
        /* These two methods will fail to run in C# when generated using autorest as header
         * Content-Range is used in a non standard way for cross compatibility. These can 
         * however still be generated (Though this is typically disabled using a directive)
         * and subsequently modified slightly to allow the non standard use of the  Content-Range
         * header. */

        /// <summary>
        /// Upload a chunk of data to specified upload without completing the upload.
        /// The data will be uploaded to the specified Content Range.
        /// </summary>
        /// <param name='value'>
        /// </param>
        /// <param name='contentRange'>
        /// Range of bytes identifying the desired block of content represented by the
        /// body. Start must the end offset retrieved via status check plus one. Note
        /// that this is a non-standard use of the `Content-Range` header.
        /// </param>
        /// <param name='location'>
        /// Link acquired from upload start or previous chunk. Note, do not include
        /// initial / (must do substring(1) )
        /// </param>
        /// <param name='chunk'>
        /// Acquire only chunks of a blob. This endpoint may also support RFC7233
        /// compliant range requests. Support can be detected by issuing a HEAD
        /// request. If the header `Accept-Range: bytes` is returned, range requests
        /// can be used to fetch partial content
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AcrErrorsException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<UploadBlobChunkHeaders>> UploadBlobChunkWithHttpMessagesAsync(Stream value, string contentRange, string location, string chunk = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (LoginUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.LoginUri");
            }
            if (value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "value");
            }
            if (contentRange == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "contentRange");
            }
            if (location == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "location");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("value", value);
                tracingParameters.Add("contentRange", contentRange);
                tracingParameters.Add("location", location);
                tracingParameters.Add("chunk", chunk);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadBlobChunk", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{nextBlobUuidLink}";
            _url = _url.Replace("{url}", LoginUri);
            _url = _url.Replace("{nextBlobUuidLink}", location);
            List<string> _queryParameters = new List<string>();
            if (chunk != null)
            {
                _queryParameters.Add(string.Format("chunk={0}", System.Uri.EscapeDataString(chunk)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PATCH");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (GenerateClientRequestId != null && GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (contentRange != null)
            {
                // Non stadard use of TryAddWithoutValidation
                _httpRequest.Content = new StringContent("");
                _httpRequest.Content.Headers.TryAddWithoutValidation("Content-Range", contentRange);
            }
            if (AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            if (value != null && value != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(value);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");
            }
            // Set Credentials
            if (Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 202)
            {
                var ex = new AcrErrorsException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    AcrErrors _errorBody = SafeJsonConvert.DeserializeObject<AcrErrors>(_responseContent, DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<UploadBlobChunkHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<UploadBlobChunkHeaders>(JsonSerializer.Create(DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Upload a chunk of data to specified upload without completing the upload.
        /// The data will be uploaded to the specified Content Range.
        /// </summary>
        /// <param name='value'>
        /// </param>
        /// <param name='contentRange'>
        /// Range of bytes identifying the desired block of content represented by the
        /// body. Start must the end offset retrieved via status check plus one. Note
        /// that this is a non-standard use of the `Content-Range` header.
        /// </param>
        /// <param name='name'>
        /// Name of the image (including the namespace)
        /// </param>
        /// <param name='uuid'>
        /// A uuid identifying the upload.
        /// </param>
        /// <param name='chunk'>
        /// Initiate Chunk Blob Upload
        /// </param>
        /// <param name='_state'>
        /// Acquired from NextLink
        /// </param>
        /// <param name='_nouploadcache'>
        /// Acquired from NextLink
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AcrErrorsException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<UploadBlobChunkSpecifiedHeaders>> UploadBlobChunkSpecifiedWithHttpMessagesAsync(Stream value, string contentRange, string name, string uuid, string chunk = default(string), string _state = default(string), bool? _nouploadcache = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (LoginUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.LoginUri");
            }
            if (value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "value");
            }
            if (contentRange == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "contentRange");
            }
            if (name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "name");
            }
            if (uuid == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "uuid");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("value", value);
                tracingParameters.Add("contentRange", contentRange);
                tracingParameters.Add("chunk", chunk);
                tracingParameters.Add("name", name);
                tracingParameters.Add("uuid", uuid);
                tracingParameters.Add("_state", _state);
                tracingParameters.Add("_nouploadcache", _nouploadcache);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadBlobChunkSpecified", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "v2/{name}/blobs/uploads/{uuid}";
            _url = _url.Replace("{url}", LoginUri);
            _url = _url.Replace("{name}", System.Uri.EscapeDataString(name));
            _url = _url.Replace("{uuid}", System.Uri.EscapeDataString(uuid));
            List<string> _queryParameters = new List<string>();
            if (chunk != null)
            {
                _queryParameters.Add(string.Format("chunk={0}", System.Uri.EscapeDataString(chunk)));
            }
            if (_state != null)
            {
                _queryParameters.Add(string.Format("_state={0}", System.Uri.EscapeDataString(_state)));
            }
            if (_nouploadcache != null)
            {
                _queryParameters.Add(string.Format("_nouploadcache={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(_nouploadcache, SerializationSettings).Trim('"'))));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PATCH");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (GenerateClientRequestId != null && GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (contentRange != null)
            {
                // Non stadard use of TryAddWithoutValidation
                _httpRequest.Content = new StringContent("");
                _httpRequest.Content.Headers.TryAddWithoutValidation("Content-Range", contentRange);
            }
            if (AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (value == null)
            {
                throw new System.ArgumentNullException("value");
            }
            if (value != null && value != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(value);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");
            }
            // Set Credentials
            if (Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 206)
            {
                var ex = new AcrErrorsException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    AcrErrors _errorBody = SafeJsonConvert.DeserializeObject<AcrErrors>(_responseContent, DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<UploadBlobChunkSpecifiedHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<UploadBlobChunkSpecifiedHeaders>(JsonSerializer.Create(DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }
        #endregion
    }

    public static partial class AzureContainerRegistryClientExtensions {
        /// <summary>
        /// Upload a chunk of data to specified upload without completing the upload.
        /// The data will be uploaded to the specified Content Range.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='value'>
        /// </param>
        /// <param name='contentRange'>
        /// Range of bytes identifying the desired block of content represented by the
        /// body. Start must the end offset retrieved via status check plus one. Note
        /// that this is a non-standard use of the `Content-Range` header.
        /// </param>
        /// <param name='location'>
        /// Link acquired from upload start or previous chunk. Note, do not include
        /// initial / (must do substring(1) )
        /// </param>
        /// <param name='chunk'>
        /// Acquire only chunks of a blob. This endpoint may also support RFC7233
        /// compliant range requests. Support can be detected by issuing a HEAD
        /// request. If the header `Accept-Range: bytes` is returned, range requests
        /// can be used to fetch partial content
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<UploadBlobChunkHeaders> UploadBlobChunkAsync(this IAzureContainerRegistryClient operations, Stream value, string contentRange, string location, string chunk = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.UploadBlobChunkWithHttpMessagesAsync(value, contentRange, location, chunk, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Headers;
            }
        }

        /// <summary>
        /// Upload a chunk of data to specified upload without completing the upload.
        /// The data will be uploaded to the specified Content Range.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='value'>
        /// </param>
        /// <param name='contentRange'>
        /// Range of bytes identifying the desired block of content represented by the
        /// body. Start must the end offset retrieved via status check plus one. Note
        /// that this is a non-standard use of the `Content-Range` header.
        /// </param>
        /// <param name='name'>
        /// Name of the image (including the namespace)
        /// </param>
        /// <param name='uuid'>
        /// A uuid identifying the upload.
        /// </param>
        /// <param name='chunk'>
        /// Initiate Chunk Blob Upload
        /// </param>
        /// <param name='_state'>
        /// Acquired from NextLink
        /// </param>
        /// <param name='_nouploadcache'>
        /// Acquired from NextLink
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<UploadBlobChunkSpecifiedHeaders> UploadBlobChunkSpecifiedAsync(this IAzureContainerRegistryClient operations, Stream value, string contentRange, string name, string uuid, string chunk = default(string), string _state = default(string), bool? _nouploadcache = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.UploadBlobChunkSpecifiedWithHttpMessagesAsync(value, contentRange, name, uuid, chunk, _state, _nouploadcache, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Headers;
            }
        }
    }
}
