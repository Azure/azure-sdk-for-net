using Azure.Core;
using Azure.Core.Net;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration
{
    public partial class ConfigurationService
    {
        public async Task<Response<KeyValueBatch>> GetBatchAsync(QueryKeyValueCollectionOptions options, CancellationToken cancellation)
        {
            var requestUri = BuildUrlForGetBatch(options);
            ServiceCallContext context = null;
            try
            {
                context = Pipeline.CreateContext(cancellation, ServiceMethod.Get, requestUri);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (options.PreferredDateTime != null)
                {
                    context.AddHeader(AcceptDatetimeHeader, options.PreferredDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat));
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength))
                {
                    throw new Exception("bad response: no content length header");
                }

                await response.ReadContentAsync(contentLength).ConfigureAwait(false);

                Func<ReadOnlySequence<byte>, KeyValueBatch> contentParser = null;
                if (response.Status == 200)
                {
                    contentParser = (ros) => { return KeyValueBatch.Parse(response); };
                }
                return new Response<KeyValueBatch>(response, contentParser);
            }
            catch
            {
                if (context != null) context.Dispose();
                throw;
            }
        }

        Url BuildUrlForGetBatch(QueryKeyValueCollectionOptions options)
        {
            Uri requestUri = new Uri(_baseUri, KvRoute);
            if (options == default) return new Url(requestUri);

            var queryBuild = new StringBuilder();
            bool hasQuery = false;

            if(options.Index != 0)
            {
                AddSeparator(queryBuild, ref hasQuery);
                queryBuild.Append($"after={options.Index}");
            }

            if (!string.IsNullOrEmpty(options.KeyFilter))
            {
                AddSeparator(queryBuild, ref hasQuery);
                queryBuild.Append($"{KeyQueryFilter}={options.KeyFilter}");
            }

            if (options.LabelFilter != null)
            {
                AddSeparator(queryBuild, ref hasQuery);
                if (options.LabelFilter == string.Empty) {
                    options.LabelFilter = "\0";
                }
                queryBuild.Append($"{LabelQueryFilter}={options.LabelFilter}");
            }

            if (options.FieldsSelector != KeyValueFields.All)
            {
                AddSeparator(queryBuild, ref hasQuery);
                var filter = (options.FieldsSelector).ToString().ToLower().Replace(" ", "");
                queryBuild.Append($"{FieldsQueryFilter}={filter}");
            }

            if(hasQuery) requestUri = new Uri(requestUri + queryBuild.ToString());
            return new Url(requestUri);

            void AddSeparator(StringBuilder builder, ref bool hasQueryBeenAdded)
            {
                if (hasQueryBeenAdded)
                {
                    builder.Append('&');
                }
                else
                {
                    builder.Append('?');
                    hasQueryBeenAdded = true;
                }
            }
        }
    }
}
