using Azure.Core;
using Azure.Core.Net;
using System;
using System.Buffers;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.JsonLab;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration
{
    public partial class ConfigurationClient
    {
        const string MediaTypeProblemApplication = "application/problem+json";
        const string AcceptDateTimeFormat = "ddd, dd MMM yyy HH:mm:ss 'GMT'";
        const string AcceptDatetimeHeader = "Accept-Datetime";
        const string KvRoute = "/kv/";
        const string LocksRoute = "/locks/";
        const string RevisionsRoute = "/revisions/";
        const string KeyQueryFilter = "key";
        const string LabelQueryFilter = "label";
        const string FieldsQueryFilter = "fields";
        const string IfMatchName = "If-Match";
        Header IfNoneMatchWildcard = new Header("If-None-Match", "*");

        static readonly Header MediaTypeKeyValueApplicationHeader = new Header(
            Header.Constants.Accept,
            Encoding.ASCII.GetBytes("application/vnd.microsoft.appconfig.kv+json")
        );

        // TODO (pri 3): do all the methods that call this accept revisions?
        static void AddFilterHeaders(SettingFilter filter, PipelineCallContext context)
        {
            if (filter == null) return;

            if (filter.ETag.IfMatch != default) {
                context.AddHeader(IfMatchName, $"\"{filter.ETag.IfMatch}\"");
            }

            if (filter.Revision.HasValue) {
                var dateTime = filter.Revision.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                context.AddHeader(AcceptDatetimeHeader, dateTime);
            }
        }

        static async Task<Response<ConfigurationSetting>> CreateKeyValueResponse(PipelineCallContext context)
        {
            ServiceResponse response = context.Response;

            if (response.Status != 200) {
                return new Response<ConfigurationSetting>(response);
            }

            var result = await ConfigurationServiceParser.ParseSettingAsync(response.Content, context.Cancellation);

            return new Response<ConfigurationSetting>(response, result);
        }

        static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
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

        Uri BuildUrlForKvRoute(ConfigurationSetting keyValue)
            => BuildUrlForKvRoute(keyValue.Key, new SettingFilter() { Label = keyValue.Label }); // TODO (pri 2) : does this need to filter ETag?

        Uri BuildUrlForKvRoute(string key, SettingFilter filter)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute + key;

            if (filter != null && filter.Label != null) {
                builder.AppendQuery(LabelQueryFilter, filter.Label);                 
            }

            return builder.Uri;
        }

        Uri BuildUriForLocksRoute(string key, SettingFilter filter)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = LocksRoute + key;

            if (filter != null && filter.Label != null) {
                builder.AppendQuery(LabelQueryFilter, filter.Label);
            }

            return builder.Uri;
        }

        Uri BuildUrlForGetBatch(BatchFilter options)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute;

            if (options.StartIndex != 0) {
                builder.AppendQuery("after", options.StartIndex);
            }

            if (!string.IsNullOrEmpty(options.Key)) {
                builder.AppendQuery(KeyQueryFilter, options.Key);
            }

            if (options.Label != null) {
                if (options.Label == string.Empty) {
                    options.Label = "\0";
                }
                builder.AppendQuery(LabelQueryFilter, options.Label);
            }

            if (options.Fields != SettingFields.All) {
                var filter = (options.Fields).ToString().ToLower();
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

            return builder.Uri;
        }

        class SettingContent : PipelineContent
        {
            ConfigurationSetting _setting;
            PipelineCallContext _context;
            byte[] _secret;
            string _credental;
            int _serializeLength = -1;

            public SettingContent(ConfigurationSetting setting, PipelineCallContext context, byte[] secret, string credental)
            {
                _setting = setting;
                _context = context;
                _secret = secret;
                _credental = credental;
            }

            public override void Dispose() { }

            public override bool TryComputeLength(out long length)
            {
                if(_serializeLength == -1)
                {
                    length = 0;
                    return false;
                }
                length = _serializeLength;
                return true;
            }

            public async override Task WriteTo(Stream stream)
            {
                using (var writer = new ArrayWriter()) {
                    Write(writer);
                    _serializeLength = writer.Written;
                    _context.AddHeader(Header.Common.CreateContentLength(_serializeLength)); // TODO (pri 2): I don't think it should be here. It adds it second time when retry happens.
                    AddAuthenticationHeader(_context, ServiceMethod.Put, writer.Buffer.AsMemory(0, _serializeLength), _secret, _credental);
                    await stream.WriteAsync(writer.Buffer, 0, _serializeLength);
                }

                void Write(ArrayWriter writer)
                {
                    var json = new Utf8JsonWriter<ArrayWriter>(writer);
                    json.WriteObjectStart();
                    json.WriteAttribute("value", _setting.Value);
                    json.WriteAttribute("content_type", _setting.ContentType);
                    json.WriteObjectEnd();
                    json.Flush();
                }
            }

            // TODO (pri 2): Utf8JsonWriter will have Written property soon and this type should be removed then.
            // TODO (pri 2): Utf8JsonWriter will have the ability to write to Stream, at which point this code can be simplified
            class ArrayWriter : IBufferWriter<byte>, IDisposable
            {
                byte[] _buffer;
                int _written = 0;

                public ArrayWriter(int length = 1024)
                {
                    _buffer = ArrayPool<byte>.Shared.Rent(length);
                }

                public int Written => _written;
                public byte[] Buffer => _buffer;

                public void Advance(int count) => _written += count;

                public void Dispose()
                {
                    if (_buffer != null) ArrayPool<byte>.Shared.Return(_buffer);
                    _buffer = null;
                }

                public Memory<byte> GetMemory(int sizeHint = 0) => _buffer.AsMemory(_written);

                public Span<byte> GetSpan(int sizeHint = 0) => _buffer.AsSpan(_written);
            }
        }

        internal static void AddAuthenticationHeader(PipelineCallContext context, ServiceMethod method, ReadOnlyMemory<byte> content, byte[] secret, string credential)
        {
            string contentHash = null;
            using (var alg = SHA256.Create())
            {
                // TODO (pri 3): ToArray should nopt be called here. Instead, TryGetArray, or PipelineContent should do hashing on the fly 
                contentHash = Convert.ToBase64String(alg.ComputeHash(content.ToArray()));
            }

            using (var hmac = new HMACSHA256(secret))
            {
                var host = context.Uri.Host;
                var pathAndQuery = context.Uri.PathAndQuery;

                string verb = method.ToString().ToUpper();
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r");
                var stringToSign = $"{verb}\n{pathAndQuery}\n{utcNowString};{host};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                context.AddHeader("Date", utcNowString);
                context.AddHeader("x-ms-content-sha256", contentHash);
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names
                context.AddHeader("Authorization", $"HMAC-SHA256 Credential={credential}, SignedHeaders={signedHeaders}, Signature={signature}");
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
