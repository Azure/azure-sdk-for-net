using Azure.Core;
using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration
{
    public partial class ConfigurationService
    {
        readonly ServicePipeline _pipeline;
        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;

        public readonly ConfigurationServiceOptions Options = new ConfigurationServiceOptions("v1.0");

        public ConfigurationService(Uri baseUri, string credential, byte[] secret, ServicePipeline pipeline)
        {
            _pipeline = pipeline;
            _baseUri = baseUri;
            _credential = credential;
            _secret = secret;
        }

        public ConfigurationService(Uri baseUri, string credential, byte[] secret)
           : this(baseUri, credential, secret, new ServicePipeline(new HttpClientTransport(), new LoggingPolicy(), new RetryPolicy()))
        { }

        public async Task<Response<KeyValue>> SetKeyValueAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForSetKeyValue(setting);

            ServiceCallContext context = null;
            try
            {
                context = _pipeline.CreateContext(cancellation, ServiceMethod.Put, url);
                context.AddHeader(Options.UserAgentHeader);

                context.AddHeader("Accept", MediaTypeKeyValueApplication);
                context.AddHeader(Header.Common.JsonContentType);

                WriteJsonContent(setting, context);

                await _pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength))
                {
                    throw new Exception("bad response: no content length header");
                }

                await response.ReadContentAsync(contentLength).ConfigureAwait(false);

                Func<ReadOnlySequence<byte>, KeyValue> contentParser = null;
                if (response.Status == 200)
                {
                    contentParser = (ros) => { return KeyValueResultParser.Parse(ros); };
                }
                return new Response<KeyValue>(response, contentParser);
            }
            catch
            {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> GetKeyValueAsync(string key, GetKeyValueOptions options, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(key)) {
                throw new ArgumentNullException(nameof(key));
            }

            Url url = BuildUriForGetKeyValue(key, options);

            ServiceCallContext context = null;
            try {
                context = _pipeline.CreateContext(cancellation, ServiceMethod.Get, url);
                context.AddHeader(Options.UserAgentHeader);

                context.AddHeader("Accept", MediaTypeKeyValueApplication);

                if (options != null && options.PreferredDateTime.HasValue) {
                    var dateTime = options.PreferredDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    context.AddHeader(AcceptDatetimeHeader, dateTime);
                }
                
                await _pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength)) {
                    throw new Exception("bad response: no content length header");
                }

                await response.ReadContentAsync(contentLength).ConfigureAwait(false);

                Func<ReadOnlySequence<byte>, KeyValue> contentParser = null;
                if (response.Status == 200) {
                    contentParser = (ros) => { return KeyValueResultParser.Parse(ros); };
                }
                // TODO (pri 1): make sure the right things happen for NotFound reponse
                return new Response<KeyValue>(response, contentParser);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public struct ConfigurationServiceOptions
        {
            internal Header UserAgentHeader;
            string _applicationId;
            string _apiVersion;

            public ConfigurationServiceOptions(string apiVersion)
            {
                _apiVersion = apiVersion;
                _applicationId = default;
                UserAgentHeader = Header.Common.CreateUserAgent(sdkName: "Azure-Configuration", sdkVersion: "1.0.0", _applicationId);
            }

            public string ApplicationId
            {
                get { return _applicationId; }
                set {
                    if (string.Equals(_applicationId, value, StringComparison.Ordinal)) return;
                    _applicationId = value;
                    UserAgentHeader = Header.Common.CreateUserAgent(sdkName: "Azure-CognitiveServices-Face", sdkVersion: "1.0.0", _applicationId);
                }
            }

            #region nobody wants to see these
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => base.Equals(obj);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => base.GetHashCode();

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString() => base.ToString();
            #endregion
        }

        public static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            uri = null;
            credential = null;
            secret = null;
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            // Parse connection string
            string[] args = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 3)
            {
                throw new ArgumentException("invalid connection string segment count", nameof(connectionString));
            }

            const string endpointString = "Endpoint=";
            const string idString = "Id=";
            const string secretString = "Secret=";

            foreach (var arg in args)
            {
                var segment = arg.Trim();
                if (segment.StartsWith(endpointString, StringComparison.OrdinalIgnoreCase))
                {
                    uri = new Uri(segment.Substring(segment.IndexOf('=') + 1));
                }
                else if (segment.StartsWith(idString, StringComparison.OrdinalIgnoreCase))
                {
                    credential = segment.Substring(segment.IndexOf('=') + 1);
                }
                else if (segment.StartsWith(secretString, StringComparison.OrdinalIgnoreCase))
                {
                    var secretBase64 = segment.Substring(segment.IndexOf('=') + 1);
                    secret = Convert.FromBase64String(secretBase64);
                }
            };
        }
    }
}
