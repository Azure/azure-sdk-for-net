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

        public ConfigurationService(string connectionString)
           : this(connectionString, CreateDefaultPipeline())
        { }

        public ConfigurationService(string connectionString, ServicePipeline pipeline)
        {
            Pipeline = pipeline;
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

        public async Task<Response<KeyValue>> AddAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForKvRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(IfNoneMatchWildcard);
                context.AddHeader(Header.Common.JsonContentType);

                WriteJsonContent(setting, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> SetAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForKvRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(Header.Common.JsonContentType);

                WriteJsonContent(setting, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> UpdateAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Url url = BuildUrlForKvRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");
                context.AddHeader(Header.Common.JsonContentType);

                WriteJsonContent(setting, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> DeleteAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Url url = BuildUrlForKvRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Delete, url);

                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> LockAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Url url = BuildUriForLocksRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> UnlockAsync(KeyValue setting, CancellationToken cancellation)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Url url = BuildUriForLocksRoute(setting);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Delete, url);

                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValue>> GetAsync(string key, GetKeyValueOptions options, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }

            Url url = BuildUrlForKvRoute(key, options);

            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);

                if (options != null && options.PreferredDateTime.HasValue) {
                    var dateTime = options.PreferredDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    context.AddHeader(AcceptDatetimeHeader, dateTime);
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<KeyValueBatch>> GetBatchAsync(QueryKeyValueCollectionOptions options, CancellationToken cancellation)
        {
            var requestUri = BuildUrlForGetBatch(options);
            ServiceCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, requestUri);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (options.PreferredDateTime != null) {
                    context.AddHeader(AcceptDatetimeHeader, options.PreferredDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat));
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength)) {
                    throw new Exception("bad response: no content length header");
                }

                await response.ReadContentAsync(contentLength).ConfigureAwait(false);

                Func<ReadOnlySequence<byte>, KeyValueBatch> contentParser = null;
                if (response.Status == 200) {
                    contentParser = (ros) => { return KeyValueBatch.Parse(response); };
                }
                return new Response<KeyValueBatch>(response, contentParser);
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

            public string ApplicationId {
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
    }
}
