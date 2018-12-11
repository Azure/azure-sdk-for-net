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
    public partial class ConfigurationClient
    {
        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;

        public ClientPipeline Pipeline { get; }

        public readonly ConfigurationServiceOptions Options = new ConfigurationServiceOptions("v1.0");

        public ConfigurationClient(string connectionString)
           : this(connectionString, ClientPipeline.Create(SdkName, SdkVersion))
        { }

        public ConfigurationClient(string connectionString, ClientPipeline pipeline)
        {
            Pipeline = pipeline;
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

        public async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
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

        public async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Url url = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
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

        public async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Url url = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
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

        public async Task<Response<ConfigurationSetting>> DeleteAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Url url = BuildUrlForKvRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Delete, url);

                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Url url = BuildUriForLocksRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Put, url);

                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Url url = BuildUriForLocksRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Delete, url);

                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }

            Url url = BuildUrlForKvRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<SettingBatch>> GetBatchAsync(BatchFilter options, CancellationToken cancellation = default)
        {
            var requestUri = BuildUrlForGetBatch(options);
            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, requestUri);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (options.Revision != null) {
                    context.AddHeader(AcceptDatetimeHeader, options.Revision.Value.UtcDateTime.ToString(AcceptDateTimeFormat));
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength)) {
                    throw new Exception("bad response: no content length header");
                }

                await response.Content.ReadAsync(contentLength).ConfigureAwait(false);

                Func<ServiceResponse, SettingBatch> contentParser = null;
                if (response.Status == 200) {
                    contentParser = (rsp) => { return SettingBatch.Parse(rsp); };
                }
                return new Response<SettingBatch>(response, contentParser);
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
