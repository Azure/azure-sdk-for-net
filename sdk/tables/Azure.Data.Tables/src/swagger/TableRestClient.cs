// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    internal partial class TableRestClient
    {
        internal HttpMessage CreateDeleteRequest(string table, string requestId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables('", false);
            uri.AppendPath(table, true);
            uri.AppendPath("')", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            // Delete requests fail without this header.
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateQueryRequest(string requestId, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables", false);
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            if (queryOptions?.NextTableName != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextTableName, queryOptions.NextTableName, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }

        internal HttpMessage CreateQueryEntitiesRequest(string table, int? timeout, string requestId, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("()", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            if (queryOptions?.NextPartitionKey != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextPartitionKey, queryOptions.NextPartitionKey, true);
            }
            if (queryOptions?.NextRowKey != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextRowKey, queryOptions.NextRowKey, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }
    }
}
