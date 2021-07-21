// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// The <see cref="LogsQueryClient"/> allows to query the Azure Monitor Logs service.
    /// </summary>
    public class LogsQueryClient
    {
        private static readonly Uri _defaultEndpoint = new Uri("https://api.loganalytics.io");
        private static readonly TimeSpan _networkTimeoutOffset = TimeSpan.FromSeconds(15);
        private readonly QueryRestClient _queryClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClient"/>. Uses the default 'https://api.loganalytics.io' endpoint.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public LogsQueryClient(TokenCredential credential) : this(credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClient"/>. Uses the default 'https://api.loganalytics.io' endpoint.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="LogsQueryClientOptions"/> instance to use as client configuration.</param>
        public LogsQueryClient(TokenCredential credential, LogsQueryClientOptions options) : this(_defaultEndpoint, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public LogsQueryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="LogsQueryClientOptions"/> instance to use as client configuration.</param>
        public LogsQueryClient(Uri endpoint, TokenCredential credential, LogsQueryClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new LogsQueryClientOptions();
            endpoint = new Uri(endpoint, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(
                credential,
                options.AuthenticationScope ?? "https://api.loganalytics.io//.default"));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline, endpoint);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClient"/> for mocking.
        /// </summary>
        protected LogsQueryClient()
        {
        }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <code snippet="Snippet:QueryLogsAsModelCall" language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     TimeSpan.FromDays(1));
        /// </code>
        ///
        /// Example of querying a primitive:
        /// <code snippet="Snippet:QueryLogsAsPrimitiveCall" language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     TimeSpan.FromDays(1));
        /// </code>
        /// </summary>
        /// <param name="workspaceId">The workspace id to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs will be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        public virtual Response<IReadOnlyList<T>> Query<T>(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = Query(workspaceId, query, timeRange, options, cancellationToken);

            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.Tables), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <code snippet="Snippet:QueryLogsAsModelCall" language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     TimeSpan.FromDays(1));
        /// </code>
        ///
        /// Example of querying a primitive:
        /// <code snippet="Snippet:QueryLogsAsPrimitiveCall" language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     TimeSpan.FromDays(1));
        /// </code>
        /// </summary>
        /// <param name="workspaceId">The workspace id to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs will be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        public virtual async Task<Response<IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryAsync(workspaceId, query, timeRange, options, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.Tables), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace id to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs will be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> containing the query results.</returns>
        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return ExecuteAsync(workspaceId, query, timeRange, options, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace id to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs will be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> with the query results.</returns>
        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await ExecuteAsync(workspaceId, query, timeRange, options, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <code snippet="Snippet:BatchQuery" language="csharp">
        /// var endpoint = new Uri(&quot;https://api.loganalytics.io&quot;);
        /// string workspaceId = &quot;&lt;workspace_id&gt;&quot;;
        ///
        /// var client = new LogsQueryClient(endpoint, new DefaultAzureCredential());
        ///
        /// // Query TOP 10 resource groups by event count
        /// // And total event count
        /// var batch = new LogsBatchQuery();
        ///
        /// string countQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     TimeSpan.FromDays(1));
        /// string topQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     TimeSpan.FromDays(1));
        ///
        /// Response&lt;LogsBatchQueryResults&gt; response = await client.QueryBatchAsync(batch);
        ///
        /// var count = response.Value.GetResult&lt;int&gt;(countQueryId).Single();
        /// var topEntries = response.Value.GetResult&lt;MyLogEntryModel&gt;(topQueryId);
        ///
        /// Console.WriteLine($&quot;AzureActivity has total {count} events&quot;);
        /// foreach (var logEntryModel in topEntries)
        /// {
        ///     Console.WriteLine($&quot;{logEntryModel.ResourceGroup} had {logEntryModel.Count} events&quot;);
        /// }
        /// </code>
        /// </summary>
        /// <param name="batch">The batch of queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResults"/> containing the query identifier that has to be passed into <see cref="LogsBatchQueryResults.GetResult"/> to get the result.</returns>
        public virtual Response<LogsBatchQueryResults> QueryBatch(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                var response = _queryClient.Batch(new BatchRequest(batch.Requests), cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <code snippet="Snippet:BatchQuery" language="csharp">
        /// var endpoint = new Uri(&quot;https://api.loganalytics.io&quot;);
        /// string workspaceId = &quot;&lt;workspace_id&gt;&quot;;
        ///
        /// var client = new LogsQueryClient(endpoint, new DefaultAzureCredential());
        ///
        /// // Query TOP 10 resource groups by event count
        /// // And total event count
        /// var batch = new LogsBatchQuery();
        ///
        /// string countQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     TimeSpan.FromDays(1));
        /// string topQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     TimeSpan.FromDays(1));
        ///
        /// Response&lt;LogsBatchQueryResults&gt; response = await client.QueryBatchAsync(batch);
        ///
        /// var count = response.Value.GetResult&lt;int&gt;(countQueryId).Single();
        /// var topEntries = response.Value.GetResult&lt;MyLogEntryModel&gt;(topQueryId);
        ///
        /// Console.WriteLine($&quot;AzureActivity has total {count} events&quot;);
        /// foreach (var logEntryModel in topEntries)
        /// {
        ///     Console.WriteLine($&quot;{logEntryModel.ResourceGroup} had {logEntryModel.Count} events&quot;);
        /// }
        /// </code>
        /// </summary>
        /// <param name="batch">The batch of queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResults"/> that allows retrieving query results.</returns>
        public virtual async Task<Response<LogsBatchQueryResults>> QueryBatchAsync(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                var response = await _queryClient.BatchAsync(new BatchRequest(batch.Requests), cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a Kusto query from an interpolated string. The interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated query string.</param>
        /// <returns>A valid Kusto query.</returns>
        public static string CreateQuery(FormattableString filter)
        {
            if (filter == null) { return null; }

            string[] args = new string[filter.ArgumentCount];
            for (int i = 0; i < filter.ArgumentCount; i++)
            {
                args[i] = filter.GetArgument(i) switch
                {
                    // Null
                    null => throw new ArgumentException(
                        $"Unable to convert argument {i} to a Kusto literal. " +
                        $"Unable to format an untyped null value. Please use typed-null expression " +
                        $"(bool(null), datetime(null), dynamic(null), guid(null), int(null), long(null), real(null), double(null), time(null))"),

                    // Boolean
                    true => "true",
                    false => "false",

                    // Numeric
                    sbyte x => $"int({x.ToString(CultureInfo.InvariantCulture)})",
                    byte x => $"int({x.ToString(CultureInfo.InvariantCulture)})",
                    short x => $"int({x.ToString(CultureInfo.InvariantCulture)})",
                    ushort x => $"int({x.ToString(CultureInfo.InvariantCulture)})",
                    int x => $"int({x.ToString(CultureInfo.InvariantCulture)})",
                    uint x => $"int({x.ToString(CultureInfo.InvariantCulture)})",

                    float x => $"real({x.ToString(CultureInfo.InvariantCulture)})",
                    double x => $"real({x.ToString(CultureInfo.InvariantCulture)})",

                    // Int64
                    long x => $"long({x.ToString(CultureInfo.InvariantCulture)})",
                    ulong x => $"long({x.ToString(CultureInfo.InvariantCulture)})",

                    decimal x => $"decimal({x.ToString(CultureInfo.InvariantCulture)})",

                    // Guid
                    Guid x => $"guid({x.ToString("D", CultureInfo.InvariantCulture)})",

                    // Dates as 8601 with a time zone
                    DateTimeOffset x => $"datetime({x.UtcDateTime.ToString("O", CultureInfo.InvariantCulture)})",
                    DateTime x => $"datetime({x.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture)})",
                    TimeSpan x => $"time({x.ToString("c", CultureInfo.InvariantCulture)})",

                    // Text
                    string x => EscapeStringValue(x),
                    char x => EscapeStringValue(x),

                    // Everything else
                    object x => throw new ArgumentException(
                        $"Unable to convert argument {i} from type {x.GetType()} to a Kusto literal.")
                };
            }

            return string.Format(CultureInfo.InvariantCulture, filter.Format, args);
        }

        private static string EscapeStringValue(string s)
        {
            StringBuilder escaped = new();
            escaped.Append('"');

            foreach (char c in s)
            {
                switch (c)
                {
                    case '"':
                        escaped.Append("\\\"");
                        break;
                    case '\\':
                        escaped.Append("\\\\");
                        break;
                    case '\r':
                        escaped.Append("\\r");
                        break;
                    case '\n':
                        escaped.Append("\\n");
                        break;
                    case '\t':
                        escaped.Append("\\t");
                        break;
                    default:
                        escaped.Append(c);
                        break;
                }
            }

            escaped.Append('"');
            return escaped.ToString();
        }

        private static string EscapeStringValue(char s) =>
            s switch
            {
                _ when s == '"' => "'\"'",
                _ => $"\"{s}\""
            };

        internal static QueryBody CreateQueryBody(string query, DateTimeRange timeRange, LogsQueryOptions options, out string prefer)
        {
            var queryBody = new QueryBody(query);
            if (timeRange != DateTimeRange.All)
            {
                queryBody.Timespan = timeRange.ToString();
            }

            if (options != null)
            {
                queryBody.Workspaces = options.AdditionalWorkspaces;
            }

            prefer = null;

            StringBuilder preferBuilder = null;

            if (options?.ServerTimeout is TimeSpan timeout)
            {
                preferBuilder ??= new();
                preferBuilder.Append("wait=");
                preferBuilder.Append((int) timeout.TotalSeconds);
            }

            if (options?.IncludeStatistics == true)
            {
                if (preferBuilder == null)
                {
                    preferBuilder = new();
                }
                else
                {
                    preferBuilder.Append(',');
                }

                preferBuilder.Append("include-statistics=true");
            }

            if (options?.IncludeVisualization == true)
            {
                if (preferBuilder == null)
                {
                    preferBuilder = new();
                }
                else
                {
                    preferBuilder.Append(',');
                }

                preferBuilder.Append("include-render=true");
            }

            prefer = preferBuilder?.ToString();

            return queryBody;
        }

        private async Task<Response<LogsQueryResult>> ExecuteAsync(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options, bool async, CancellationToken cancellationToken = default)
        {
            if (workspaceId == null)
            {
                throw new ArgumentNullException(nameof(workspaceId));
            }

            QueryBody queryBody = CreateQueryBody(query, timeRange, options, out string prefer);
            using var message = _queryClient.CreateExecuteRequest(workspaceId, queryBody, prefer);

            if (options?.ServerTimeout != null)
            {
                // Offset the service timeout a bit to make sure we have time to receive the response.
                message.NetworkTimeout = options.ServerTimeout.Value.Add(_networkTimeoutOffset);
            }

            if (async)
            {
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message, cancellationToken);
            }

            switch (message.Response.Status)
            {
                case 200:
                {
                    using var document = async ?
                        await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false) :
                        JsonDocument.Parse(message.Response.ContentStream, default);

                    LogsQueryResult value = LogsQueryResult.DeserializeLogsQueryResult(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
                default:
                {
                    if (async)
                    {
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                    else
                    {
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
            }
        }
    }
}
