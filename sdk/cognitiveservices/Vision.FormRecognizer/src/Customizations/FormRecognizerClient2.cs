namespace Microsoft.Azure.CognitiveServices.FormRecognizer
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public partial interface IFormRecognizerClient : System.IDisposable
    {
        Task<HttpOperationResponse<AnalyzeResult>> AnalyzeWithCustomModelWithHttpMessagesAsync2(System.Guid id, Stream formStream, IList<string> keys = default(IList<string>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken), string contentType= "application/pdf");
    }

    public static partial class FormRecognizerClientExtensions
    {
        public static async Task<AnalyzeResult> AnalyzeWithCustomModelAsync(this IFormRecognizerClient operations, System.Guid id, Stream formStream, string contentType, IList<string> keys = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.AnalyzeWithCustomModelWithHttpMessagesAsync2(id, formStream, keys, null, cancellationToken, contentType: contentType).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }

    public partial class FormRecognizerClient : ServiceClient<FormRecognizerClient>, IFormRecognizerClient
    {
        partial void CustomInitialize()
        {
            // Disable metadata property handling when de/serializing models so we can properly support "$ref" in ElementReference.
            SerializationSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
            DeserializationSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
        }

        public async Task<HttpOperationResponse<AnalyzeResult>> AnalyzeWithCustomModelWithHttpMessagesAsync2(System.Guid id, Stream formStream, IList<string> keys = default(IList<string>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken), string contentType = "application/pdf")
        {
            if (Endpoint == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Endpoint");
            }
            if (formStream == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "formStream");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("id", id);
                tracingParameters.Add("keys", keys);
                tracingParameters.Add("formStream", formStream);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "AnalyzeWithCustomModel", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "custom/models/{id}/analyze";
            _url = _url.Replace("{Endpoint}", Endpoint);
            _url = _url.Replace("{id}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(id, SerializationSettings).Trim('"')));
            List<string> _queryParameters = new List<string>();
            if (keys != null)
            {
                _queryParameters.Add(string.Format("keys={0}", System.Uri.EscapeDataString(string.Join(",", keys))));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


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
            MultipartFormDataContent _multiPartContent = new MultipartFormDataContent();
            if (formStream != null)
            {
                StreamContent _formStream = new StreamContent(formStream);
                FileStream _formStreamAsFileStream = formStream as FileStream;
                if (_formStreamAsFileStream != null)
                {
                    _formStream.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "form_stream",
                        FileName = _formStreamAsFileStream.Name
                    };
                    _formStream.Headers.Add("Content-Type", contentType);
                }
                _multiPartContent.Add(_formStream, "form_stream");
            }
            _httpRequest.Content = _multiPartContent;
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
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorResponseException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    ErrorResponse _errorBody = SafeJsonConvert.DeserializeObject<ErrorResponse>(_responseContent, DeserializationSettings);
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
            var _result = new HttpOperationResponse<AnalyzeResult>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<AnalyzeResult>(_responseContent, DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }
    }
}
