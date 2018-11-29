using Azure.Core;
using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration
{
    public partial class ConfigurationService
    {
        internal const string SdkName = "Azure-Configuration";
        internal const string SdkVersion = "1.0.0";
        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;

        public ServicePipeline Pipeline { get; }

        public readonly ConfigurationServiceOptions Options = new ConfigurationServiceOptions("v1.0");

        static ServicePipeline CreateDefaultPipeline()
        {
            var pipeline = new ServicePipeline(
                new HttpClientTransport(),
                new LoggingPolicy(),
                new RetryPolicy(),
                new TelemetryPolicy(SdkName, SdkVersion, null)
            );
            return pipeline;
        }

        public ConfigurationService(Uri baseUri, string credential, byte[] secret, ServicePipeline pipeline)
        {
            Pipeline = pipeline;
            _baseUri = baseUri;
            _credential = credential;
            _secret = secret;
        }

        public ConfigurationService(Uri baseUri, string credential, byte[] secret)
           : this(baseUri, credential, secret, CreateDefaultPipeline())
        { }

        public async Task<Response<KeyValue>> SetKeyValueAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForSetKeyValue(setting);

            ServiceCallContext context = null;
            try
            {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                context.AddHeader("Accept", MediaTypeKeyValueApplication);
                context.AddHeader(Header.Common.JsonContentType);

                WriteJsonContent(setting, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

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
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, url);

                context.AddHeader("Accept", MediaTypeKeyValueApplication);

                if (options != null && options.PreferredDateTime.HasValue) {
                    var dateTime = options.PreferredDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    context.AddHeader(AcceptDatetimeHeader, dateTime);
                }
                
                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

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

            public ConfigurationServiceOptions(string apiVersion)
            {
                _applicationId = default;
                UserAgentHeader = Header.Common.CreateUserAgent(SdkName, SdkVersion, _applicationId);
            }

            public string ApplicationId
            {
                get { return _applicationId; }
                set {
                    if (string.Equals(_applicationId, value, StringComparison.Ordinal)) return;
                    _applicationId = value;
                    UserAgentHeader = Header.Common.CreateUserAgent(SdkName, SdkVersion, _applicationId);
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
