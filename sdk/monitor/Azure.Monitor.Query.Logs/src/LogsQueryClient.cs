// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Logs.Models;

namespace Azure.Monitor.Query.Logs
{
    /// <summary> The LogsQueryClient. </summary>
    [CodeGenType("Client")]
    public partial class LogsQueryClient
    {
        private static readonly Uri DefaultEndpoint = new Uri("https://api.loganalytics.io");

        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint => _endpoint;

        /// <summary> Initializes a new instance of LogsQueryClient. </summary>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public LogsQueryClient(TokenCredential credential, LogsQueryClientOptions options) : this(
                  string.IsNullOrEmpty(options?.Audience?.ToString())
                    ? DefaultEndpoint
                    : new Uri(options.Audience.ToString()),
                  credential,
                  options)
        {
        }

        /// <summary> Initializes a new instance of LogsQueryClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LogsQueryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new LogsQueryClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LogsQueryClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LogsQueryClient(Uri endpoint, TokenCredential credential, LogsQueryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new LogsQueryClientOptions();

            // Set authorization scope from Endpoint if Audience is not set.

            string[] scopes;

            if (string.IsNullOrEmpty(options.Audience?.ToString()))
            {
                scopes = AuthorizationScopes;
            }
            else if (endpoint.Host != new Uri(options.Audience.ToString()).Host)
            {
                throw new InvalidOperationException("The endpoint URI and audience do not match. If setting the Audience to a regionally specific value, please use the LogsQueryClient(TokenCredential, LogsQueryClientOptions) constructor.");
            }
            else
            {
                scopes = [$"{options.Audience}/.default"];
            }

            _endpoint = endpoint;
            _tokenCredential = credential;
            _apiVersion = options.Version;

            Pipeline = HttpPipelineBuilder.Build(options, [new BearerTokenAuthenticationPolicy(_tokenCredential, scopes)]);
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <example snippet="Snippet:QueryLogs_QueryLogsAsModelCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryWorkspaceAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        ///
        /// Example of querying a primitive:
        /// <example snippet="Snippet:QueryLogs_QueryLogsAsPrimitiveCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryWorkspaceAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="workspaceId">The workspace ID to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The Kusto query to fetch the logs.</param>
        /// <param name="timeRange">The time period for which the logs should be looked up.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        [RequiresUnreferencedCode(LogsBatchQueryResultCollection.RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(LogsBatchQueryResultCollection.RequiresDynamicCodeMessage)]
        public virtual Response<IReadOnlyList<T>> QueryWorkspace<T>(string workspaceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = QueryWorkspace(workspaceId, query, timeRange, options, cancellationToken);
            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <example snippet="Snippet:QueryLogs_QueryLogsAsModelCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryWorkspaceAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        ///
        /// Example of querying a primitive:
        /// <example snippet="Snippet:QueryLogs_QueryLogsAsPrimitiveCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryWorkspaceAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="workspaceId">The workspace ID to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The Kusto query to fetch the logs.</param>
        /// <param name="timeRange">The time period for which the logs should be looked up.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        [RequiresUnreferencedCode(LogsBatchQueryResultCollection.RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(LogsBatchQueryResultCollection.RequiresDynamicCodeMessage)]
        public virtual async Task<Response<IReadOnlyList<T>>> QueryWorkspaceAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>(string workspaceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryWorkspaceAsync(workspaceId, query, timeRange, options, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace ID to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The Kusto query to fetch the logs.</param>
        /// <param name="timeRange">The time period for which the logs should be looked up.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> containing the query results.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual Response<LogsQueryResult> QueryWorkspace(string workspaceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceId, nameof(workspaceId));

            var body = CreateQueryBody(query, timeRange, options, out var prefer);
            var context = new RequestContext();

            context.CancellationToken = cancellationToken.CanBeCanceled
                ? cancellationToken
                : default;

            // Add a classifer that can detect partial failures and throw if the caller did not opt in to
            // receiving partial failures.
            context.AddClassifier(new PartialFailureHandler(options));

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (options?.ServerTimeout is not null)
            {
                context.AddPolicy(new NetworkTimeoutPolicy(options.ServerTimeout.Value), HttpPipelinePosition.PerCall);
            }

            var result = QueryWorkspace(workspaceId, body, prefer, context);
            var queryResult = (LogsQueryResult)result;

            queryResult.Status = queryResult.Error == null
                ? LogsQueryResultStatus.Success
                : LogsQueryResultStatus.PartialFailure;

            return Response.FromValue(queryResult, result);
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace ID to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The Kusto query to fetch the logs.</param>
        /// <param name="timeRange">The time period for which the logs should be looked up.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> with the query results.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<LogsQueryResult>> QueryWorkspaceAsync(string workspaceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(workspaceId, nameof(workspaceId));

            var body = CreateQueryBody(query, timeRange, options, out var prefer);
            var context = new RequestContext();

            context.CancellationToken = cancellationToken.CanBeCanceled
                ? cancellationToken
                : default;

            // Add a classifer that can detect partial failures and throw if the caller did not opt in to
            // receiving partial failures.
            context.AddClassifier(new PartialFailureHandler(options));

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (options?.ServerTimeout is not null)
            {
                context.AddPolicy(new NetworkTimeoutPolicy(options.ServerTimeout.Value), HttpPipelinePosition.PerCall);
            }

            var result = await QueryWorkspaceAsync(workspaceId, body, prefer, context).ConfigureAwait(false);
            var queryResult = (LogsQueryResult)result;

            queryResult.Status = queryResult.Error == null
                ? LogsQueryResultStatus.Success
                : LogsQueryResultStatus.PartialFailure;

            return Response.FromValue(queryResult, result);
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <example snippet="Snippet:QueryLogs_BatchQuery">
        /// <code language="csharp">
        /// string workspaceId = &quot;&lt;workspace_id&gt;&quot;;
        ///
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// // Query TOP 10 resource groups by event count
        /// // And total event count
        /// var batch = new LogsBatchQuery();
        ///
        /// string countQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        ///
        /// Response&lt;LogsBatchQueryResultCollection&gt; response = await client.QueryBatchAsync(batch);
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
        /// </example>
        /// </summary>
        /// <param name="batch">The batch of queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResultCollection"/> containing the query identifier that has to be passed into <see cref="LogsBatchQueryResultCollection.GetResult"/> to get the result.</returns>
        public virtual Response<LogsBatchQueryResultCollection> QueryBatch(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            TimeSpan? timeout = null;
            Response<BatchResponse> response = null;

            foreach (var item in batch.Requests)
            {
                if (item.Options?.ServerTimeout is not null)
                {
                    if (timeout is null || timeout.Value < item.Options.ServerTimeout.Value)
                    {
                        timeout = item.Options.ServerTimeout.Value;
                    }
                }
            }

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (timeout.HasValue)
            {
                var context = new RequestContext();

                context.CancellationToken = cancellationToken.CanBeCanceled
                    ? cancellationToken
                    : default;

                context.AddPolicy(new NetworkTimeoutPolicy(timeout.Value), HttpPipelinePosition.PerCall);

                var result = QueryBatch(new BatchRequest(batch.Requests), context);
                response = Response.FromValue((BatchResponse)result, result);
            }
            else
            {
                response = QueryBatch(new BatchRequest(batch.Requests), cancellationToken);
            }

            var rawResponse = response.GetRawResponse();
            return ConvertBatchResponse(response.Value, rawResponse, batch);
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <example snippet="Snippet:QueryLogs_BatchQuery">
        /// <code language="csharp">
        /// string workspaceId = &quot;&lt;workspace_id&gt;&quot;;
        ///
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// // Query TOP 10 resource groups by event count
        /// // And total event count
        /// var batch = new LogsBatchQuery();
        ///
        /// string countQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(1)));
        ///
        /// Response&lt;LogsBatchQueryResultCollection&gt; response = await client.QueryBatchAsync(batch);
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
        /// </example>
        /// </summary>
        /// <param name="batch">The batch of Kusto queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResultCollection"/> that allows retrieving query results.</returns>
        public virtual async Task<Response<LogsBatchQueryResultCollection>> QueryBatchAsync(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            TimeSpan? timeout = null;
            Response<BatchResponse> response = null;

            foreach (var item in batch.Requests)
            {
                if (item.Options?.ServerTimeout is not null)
                {
                    if (timeout is null || timeout.Value < item.Options.ServerTimeout.Value)
                    {
                        timeout = item.Options.ServerTimeout.Value;
                    }
                }
            }

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (timeout.HasValue)
            {
                var context = new RequestContext();

                context.CancellationToken = cancellationToken.CanBeCanceled
                    ? cancellationToken
                    : default;

                context.AddPolicy(new NetworkTimeoutPolicy(timeout.Value), HttpPipelinePosition.PerCall);

                var result = await QueryBatchAsync(new BatchRequest(batch.Requests), context).ConfigureAwait(false);
                response = Response.FromValue((BatchResponse)result, result);
            }
            else
            {
                response = await QueryBatchAsync(new BatchRequest(batch.Requests), cancellationToken).ConfigureAwait(false);
            }

            var rawResponse = response.GetRawResponse();
            return ConvertBatchResponse(response.Value, rawResponse, batch);
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryLogs_QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(7)));
        ///
        /// LogsTable resultTable = results.Value.Table;
        /// foreach (LogsTableRow row in resultTable.Rows)
        /// {
        ///     Console.WriteLine($&quot;{row[&quot;OperationName&quot;]} {row[&quot;ResourceGroup&quot;]}&quot;);
        /// }
        ///
        /// foreach (LogsTableColumn columns in resultTable.Columns)
        /// {
        ///     Console.WriteLine(&quot;Name: &quot; + columns.Name + &quot; Type: &quot; + columns.Type);
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="resourceId"> The Azure resource ID where the query should be executed. </param>
        /// <param name="query"> The Kusto query to fetch the logs. </param>
        /// <param name="timeRange"> The time period for which the logs should be looked up. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The logs matching the query.</returns>
        [RequiresUnreferencedCode(LogsBatchQueryResultCollection.RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(LogsBatchQueryResultCollection.RequiresDynamicCodeMessage)]
        public virtual Response<IReadOnlyList<T>> QueryResource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>(ResourceIdentifier resourceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = QueryResource(resourceId, query, timeRange, options, cancellationToken);
            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryLogs_QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(7)));
        ///
        /// LogsTable resultTable = results.Value.Table;
        /// foreach (LogsTableRow row in resultTable.Rows)
        /// {
        ///     Console.WriteLine($&quot;{row[&quot;OperationName&quot;]} {row[&quot;ResourceGroup&quot;]}&quot;);
        /// }
        ///
        /// foreach (LogsTableColumn columns in resultTable.Columns)
        /// {
        ///     Console.WriteLine(&quot;Name: &quot; + columns.Name + &quot; Type: &quot; + columns.Type);
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="resourceId"> The Azure resource ID where the query should be executed. </param>
        /// <param name="query"> The Kusto query to fetch the logs. </param>
        /// <param name="timeRange"> The time period for which the logs should be looked up. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The logs matching the query.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        [RequiresUnreferencedCode(LogsBatchQueryResultCollection.RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(LogsBatchQueryResultCollection.RequiresDynamicCodeMessage)]
        public virtual async Task<Response<IReadOnlyList<T>>> QueryResourceAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>(ResourceIdentifier resourceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryResourceAsync(resourceId, query, timeRange, options, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryLogs_QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(7)));
        ///
        /// LogsTable resultTable = results.Value.Table;
        /// foreach (LogsTableRow row in resultTable.Rows)
        /// {
        ///     Console.WriteLine($&quot;{row[&quot;OperationName&quot;]} {row[&quot;ResourceGroup&quot;]}&quot;);
        /// }
        ///
        /// foreach (LogsTableColumn columns in resultTable.Columns)
        /// {
        ///     Console.WriteLine(&quot;Name: &quot; + columns.Name + &quot; Type: &quot; + columns.Type);
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="resourceId"> The Azure resource ID where the query should be executed. </param>
        /// <param name="query"> The Kusto query to fetch the logs. </param>
        /// <param name="timeRange"> The time period for which the logs should be looked up. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The logs matching the query.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual Response<LogsQueryResult> QueryResource(ResourceIdentifier resourceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            if (!ResourceIdentifier.TryParse(resourceId, out _))
            {
                throw new ArgumentException($"The resource identifier '{resourceId}' is not valid.", nameof(resourceId));
            }

            var resource = resourceId.ToString().TrimStart('/');
            var body = CreateQueryBody(query, timeRange, options, out var prefer);
            var context = new RequestContext();

            context.CancellationToken = cancellationToken.CanBeCanceled
                ? cancellationToken
                : default;

            // Add a classifer that can detect partial failures and throw if the caller did not opt in to
            // receiving partial failures.
            context.AddClassifier(new PartialFailureHandler(options));

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (options?.ServerTimeout is not null)
            {
                context.AddPolicy(new NetworkTimeoutPolicy(options.ServerTimeout.Value), HttpPipelinePosition.PerCall);
            }

            var result = QueryResource(resource, body, prefer, context);
            var queryResult = (LogsQueryResult)result;

            queryResult.Status = queryResult.Error == null
                ? LogsQueryResultStatus.Success
                : LogsQueryResultStatus.PartialFailure;

            return Response.FromValue(queryResult, result);
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryLogs_QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new LogsQueryTimeRange(TimeSpan.FromDays(7)));
        ///
        /// LogsTable resultTable = results.Value.Table;
        /// foreach (LogsTableRow row in resultTable.Rows)
        /// {
        ///     Console.WriteLine($&quot;{row[&quot;OperationName&quot;]} {row[&quot;ResourceGroup&quot;]}&quot;);
        /// }
        ///
        /// foreach (LogsTableColumn columns in resultTable.Columns)
        /// {
        ///     Console.WriteLine(&quot;Name: &quot; + columns.Name + &quot; Type: &quot; + columns.Type);
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="resourceId"> The Azure resource ID where the query should be executed. </param>
        /// <param name="query"> The Kusto query to fetch the logs. </param>
        /// <param name="timeRange"> The time period for which the logs should be looked up. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The logs matching the query.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="LogsQueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<LogsQueryResult>> QueryResourceAsync(ResourceIdentifier resourceId, string query, LogsQueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            if (!ResourceIdentifier.TryParse(resourceId, out _))
            {
                throw new ArgumentException($"The resource identifier '{resourceId}' is not valid.", nameof(resourceId));
            }

            var resource = resourceId.ToString().TrimStart('/');
            var body = CreateQueryBody(query, timeRange, options, out var prefer);
            var context = new RequestContext();

            context.CancellationToken = cancellationToken.CanBeCanceled
                ? cancellationToken
                : default;

            // Add a classifer that can detect partial failures and throw if the caller did not opt in to
            // receiving partial failures.
            context.AddClassifier(new PartialFailureHandler(options));

            // If there is a server timeout set on the options, it should apply to this call only. Since
            // the standard network timeout policy is at the pipeline level and applies to all calls, we
            // need to create a new request context with a per-call policy for this specific call.
            if (options?.ServerTimeout is not null)
            {
                context.AddPolicy(new NetworkTimeoutPolicy(options.ServerTimeout.Value), HttpPipelinePosition.PerCall);
            }

            var result = await QueryResourceAsync(resource, body, prefer, context).ConfigureAwait(false);
            var queryResult = (LogsQueryResult)result;

            queryResult.Status = queryResult.Error == null
                ? LogsQueryResultStatus.Success
                : LogsQueryResultStatus.PartialFailure;

            return Response.FromValue(queryResult, result);
        }

        /// <summary>
        /// Create a Kusto query from an interpolated string. The interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="query">An interpolated query string.</param>
        /// <returns>A valid Kusto query.</returns>
        public static string CreateQuery(FormattableString query)
        {
            if (query == null)
            { return null; }

            string[] args = new string[query.ArgumentCount];
            for (int i = 0; i < query.ArgumentCount; i++)
            {
                args[i] = query.GetArgument(i) switch
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

            return string.Format(CultureInfo.InvariantCulture, query.Format, args);
        }

        internal static QueryBody CreateQueryBody(string query, LogsQueryTimeRange timeRange, LogsQueryOptions options, out string prefer)
        {
            var queryBody = new QueryBody(query);
            if (timeRange != LogsQueryTimeRange.All)
            {
                queryBody.Timespan = timeRange.ToIsoString();
            }

            if (options != null)
            {
                queryBody.Workspaces = options.AdditionalWorkspaces;
            }

            prefer = null;

            StringBuilder preferBuilder = null;

            if (options?.ServerTimeout is TimeSpan timeout)
            {
                preferBuilder = new();
                preferBuilder.Append("wait=");
                preferBuilder.Append((int)timeout.TotalSeconds);
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

        private static Response<LogsBatchQueryResultCollection> ConvertBatchResponse(BatchResponse response, Response rawResponse, LogsBatchQuery batch)
        {
            List<LogsBatchQueryResult> batchResponses = new List<LogsBatchQueryResult>();
            foreach (var innerResponse in response.Responses)
            {
                var body = innerResponse.Body;
                body.Status = innerResponse.Status switch
                {
                    >= 400 => LogsQueryResultStatus.Failure,
                    _ when body.Error != null => LogsQueryResultStatus.PartialFailure,
                    _ => LogsQueryResultStatus.Success
                };
                body.Id = innerResponse.Id;
                batchResponses.Add(body);
            }

            return Response.FromValue(
                new LogsBatchQueryResultCollection(batchResponses, batch),
                rawResponse);
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

        /// <summary>
        /// Applies a network timeout to the outgoing request based on
        /// provided timeout, adjusting for a small offset duration.
        /// </summary>
        /// <seealso cref="Azure.Core.Pipeline.HttpPipelineSynchronousPolicy" />
        private class NetworkTimeoutPolicy : HttpPipelineSynchronousPolicy
        {
            private static readonly TimeSpan NetworkTimeoutOffset = TimeSpan.FromSeconds(15);
            private readonly TimeSpan Timeout;

            /// <summary>
            /// Initializes a new instance of the <see cref="NetworkTimeoutPolicy"/> class.
            /// </summary>
            /// <param name="timeout">The timeout to apply.  Note this will be adjusted to include a small offset duration.</param>
            public NetworkTimeoutPolicy(TimeSpan timeout)
            {
                Timeout = timeout;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                if (!message.Request.Headers.Contains(HttpHeader.Names.Prefer))
                {
                    message.Request.Headers.SetValue(HttpHeader.Names.Prefer, $"wait={(int)Timeout.TotalSeconds}");
                }

                message.NetworkTimeout = Timeout.Add(NetworkTimeoutOffset);
                base.OnSendingRequest(message);
            }
        }

        /// <summary>
        /// Analyzes the response to a query and determines if it is an error based on partial failure
        /// status and the active query options.
        /// </summary>
        /// <seealso cref="Azure.Core.ResponseClassificationHandler" />
        private class PartialFailureHandler : ResponseClassificationHandler
        {
            private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");
            private readonly LogsQueryOptions Options;

            public PartialFailureHandler(LogsQueryOptions options) => Options = options;

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                // If we're allowing partial errors, this was not a 200 response, or
                // the service operation returned no content, then this is not a partial
                // error scenario.
                if (Options?.AllowPartialErrors == true
                    || message?.Response.Status != 200
                    || message?.Response?.ContentStream is null)
                {
                    isError = false;
                    return isError;
                }

                // Not all streams are seekable. If this one is not,
                // we need to reset the stream so that it can be read when
                // creating the actual response.
                var contentStream = message.Response.ContentStream;

                if (!contentStream.CanSeek)
                {
                    contentStream = new MemoryStream();
                    message.Response.ContentStream.CopyTo(contentStream);
                    message.Response.ContentStream = contentStream;

                    contentStream.Position = 0;
                }

                // If the service result contains an error, then this is a partial failure,
                // and the caller has not opted into allowing them, so this should be
                // classified as an error.
                var value = ModelReaderWriter.Read<LogsQueryResult>(message.Response.Content, WireOptions, AzureMonitorQueryLogsContext.Default);
                isError = value.Error != null;

                // If this is an error result, we need to rewrite the error message and reset the
                // result's error content.
                if (isError)
                {
                    value.Error = new ResponseError(
                        value.Error.Code,
                        $"The result was returned but contained a partial error. Exceptions for partial errors can be disabled " +
                        $" using {nameof(LogsQueryOptions)}.{nameof(LogsQueryOptions.AllowPartialErrors)}." +
                        $"Partial errors can be inspected using the {nameof(LogsQueryResult)}.{nameof(LogsQueryResult.Error)} property.{Environment.NewLine}" +
                        $"Error:{Environment.NewLine}{value.Error}");

                    message.Response.ContentStream = ModelReaderWriter
                        .Write(value, WireOptions, AzureMonitorQueryLogsContext.Default)
                        .ToStream();
                }

                message.Response.ContentStream.Position = 0;
                return isError;
            }
        }
    }
}
