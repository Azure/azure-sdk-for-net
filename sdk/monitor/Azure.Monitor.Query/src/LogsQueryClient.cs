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
        /// Creates an instance of <see cref="LogsQueryClient"/> for Azure Public Cloud usage. Uses the default 'https://api.loganalytics.io' endpoint.
        /// <example snippet="Snippet:CreateLogsClient">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public LogsQueryClient(TokenCredential credential) : this(credential, null)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="LogsQueryClient"/> for Azure Public Cloud usage. Uses the default 'https://api.loganalytics.io' endpoint, unless <see cref="LogsQueryClientOptions.Audience"/> is set to an Azure sovereign cloud.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="LogsQueryClientOptions"/> instance to use as client configuration.</param>
        public LogsQueryClient(TokenCredential credential, LogsQueryClientOptions options) : this(string.IsNullOrEmpty(options.Audience?.ToString()) ? _defaultEndpoint : new Uri(options.Audience.ToString()), credential, options)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="LogsQueryClient"/> for the Azure cloud represented by <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public LogsQueryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="LogsQueryClient"/> for the Azure cloud represented by <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="LogsQueryClientOptions"/> instance to use as client configuration.</param>
        public LogsQueryClient(Uri endpoint, TokenCredential credential, LogsQueryClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            Endpoint = endpoint;
            options ??= new LogsQueryClientOptions();
            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? LogsQueryAudience.AzurePublicCloud : options.Audience)}";
            authorizationScope += "//.default";
            var scopes = new List<string> { authorizationScope };

            endpoint = new Uri(endpoint, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline, endpoint);
        }

        /// <summary>
        /// Creates an instance of <see cref="LogsQueryClient"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected LogsQueryClient()
        {
        }

        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <example snippet="Snippet:QueryLogsAsModelCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryWorkspaceAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        ///
        /// Example of querying a primitive:
        /// <example snippet="Snippet:QueryLogsAsPrimitiveCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryWorkspaceAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual Response<IReadOnlyList<T>> QueryWorkspace<T>(string workspaceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = QueryWorkspace(workspaceId, query, timeRange, options, cancellationToken);

            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query. Deserializes the result into a strongly typed model class or a primitive type if the query returns a single column.
        ///
        /// Example of querying a model:
        /// <example snippet="Snippet:QueryLogsAsModelCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;MyLogEntryModel&gt;&gt; response = await client.QueryWorkspaceAsync&lt;MyLogEntryModel&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        /// </code>
        /// </example>
        ///
        /// Example of querying a primitive:
        /// <example snippet="Snippet:QueryLogsAsPrimitiveCall">
        /// <code language="csharp">
        /// Response&lt;IReadOnlyList&lt;string&gt;&gt; response = await client.QueryWorkspaceAsync&lt;string&gt;(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<IReadOnlyList<T>>> QueryWorkspaceAsync<T>(string workspaceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual Response<LogsQueryResult> QueryWorkspace(string workspaceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryWorkspace)}");
            scope.Start();
            try
            {
                return ExecuteAsync(workspaceId, query, timeRange, options, async: false, isWorkspace: true, cancellationToken).EnsureCompleted();
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
        /// <param name="workspaceId">The workspace ID to include in the query (<c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c>).</param>
        /// <param name="query">The Kusto query to fetch the logs.</param>
        /// <param name="timeRange">The time period for which the logs should be looked up.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> with the query results.</returns>
        /// <remarks>
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<LogsQueryResult>> QueryWorkspaceAsync(string workspaceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryWorkspace)}");
            scope.Start();
            try
            {
                return await ExecuteAsync(workspaceId, query, timeRange, options, async: true, isWorkspace: true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <example snippet="Snippet:BatchQuery">
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
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                return ExecuteBatchAsync(batch, async: false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch query. Use the <see cref="LogsBatchQuery"/> to compose a batch query.
        /// <example snippet="Snippet:BatchQuery">
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
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                return await ExecuteBatchAsync(batch, async: true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(7)));
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
        public virtual Response<IReadOnlyList<T>> QueryResource<T>(ResourceIdentifier resourceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = QueryResource(resourceId, query, timeRange, options, cancellationToken);

            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(7)));
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<IReadOnlyList<T>>> QueryResourceAsync<T>(ResourceIdentifier resourceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryResourceAsync(resourceId, query, timeRange, options, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(RowBinder.Shared.BindResults<T>(response.Value.AllTables), response.GetRawResponse());
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(7)));
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual Response<LogsQueryResult> QueryResource(ResourceIdentifier resourceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryResource)}");
            scope.Start();
            try
            {
                // Call Parse to validate resourceId, then trim preceding / as generated code cannot handle it: https://github.com/Azure/autorest.csharp/issues/3322
                string resource = ResourceIdentifier.Parse(resourceId).ToString().TrimStart('/');
                return ExecuteAsync(resource, query, timeRange, options, async: false, isWorkspace: false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns all the Azure Monitor logs matching the given query for an Azure resource.
        /// <example snippet="Snippet:QueryResource">
        /// <code language="csharp">
        /// var client = new LogsQueryClient(new DefaultAzureCredential());
        ///
        /// string resourceId = &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// string tableName = &quot;&lt;table_name&gt;&quot;;
        /// Response&lt;LogsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     new ResourceIdentifier(resourceId),
        ///     $&quot;{tableName} | distinct * | project TimeGenerated&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(7)));
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
        /// When the <paramref name="timeRange"/> argument is <see cref="QueryTimeRange.All"/> and the <paramref name="query"/> argument contains a time range filter, the underlying service uses the time range specified in <paramref name="query"/>.
        /// </remarks>
        public virtual async Task<Response<LogsQueryResult>> QueryResourceAsync(ResourceIdentifier resourceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsQueryClient)}.{nameof(QueryResource)}");
            scope.Start();
            try
            {
                // Call Parse to validate resourceId, then trim preceding / as generated code cannot handle it: https://github.com/Azure/autorest.csharp/issues/3322
                string resource = ResourceIdentifier.Parse(resourceId).ToString().TrimStart('/');
                return await ExecuteAsync(resource, query, timeRange, options, async: true, isWorkspace: false, cancellationToken).ConfigureAwait(false);
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
        /// <param name="query">An interpolated query string.</param>
        /// <returns>A valid Kusto query.</returns>
        public static string CreateQuery(FormattableString query)
        {
            if (query == null) { return null; }

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

        internal static QueryBody CreateQueryBody(string query, QueryTimeRange timeRange, LogsQueryOptions options, out string prefer)
        {
            var queryBody = new QueryBody(query);
            if (timeRange != QueryTimeRange.All)
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

        private async Task<Response<LogsBatchQueryResultCollection>> ExecuteBatchAsync(LogsBatchQuery batch, bool async, CancellationToken cancellationToken = default)
        {
            Response<LogsBatchQueryResultCollection> ConvertBatchResponse(BatchResponse response, Response rawResponse)
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

            using var message = _queryClient.CreateBatchRequest(new BatchRequest(batch.Requests));

            TimeSpan? timeout = null;
            foreach (var batchRequest in batch.Requests)
            {
                var requestTimeout  = batchRequest?.Options?.ServerTimeout;
                if (requestTimeout != null &&
                    (timeout == null || requestTimeout.Value > timeout.Value))
                {
                    timeout = requestTimeout;
                }
            }

            if (timeout != null)
            {
                message.NetworkTimeout = timeout.Value.Add(_networkTimeoutOffset);
                message.Request.Headers.SetValue(HttpHeader.Names.Prefer, $"wait={(int) timeout.Value.TotalSeconds}");
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
                    using var document = JsonDocument.Parse(message.Response.ContentStream);
                    BatchResponse value = BatchResponse.DeserializeBatchResponse(document.RootElement);
                    return ConvertBatchResponse(value, message.Response);
                }
                default:
                {
                    throw new RequestFailedException(message.Response);
                }
            }
        }

        private async Task<Response<LogsQueryResult>> ExecuteAsync(string id, string query, QueryTimeRange timeRange, LogsQueryOptions options, bool async, bool isWorkspace, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            QueryBody queryBody = CreateQueryBody(query, timeRange, options, out string prefer);

            using var message = isWorkspace ? _queryClient.CreateExecuteRequest(id, queryBody, prefer)
                : _queryClient.CreateResourceExecuteRequest(new ResourceIdentifier(id), queryBody, prefer);

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

                    value.Status = value.Error == null ? LogsQueryResultStatus.Success : LogsQueryResultStatus.PartialFailure;

                    var responseError = value.Error;
                    if (responseError != null && options?.AllowPartialErrors != true)
                    {
                        throw value.CreateExceptionForErrorResponse(message.Response.Status);
                    }

                    return Response.FromValue(value, message.Response);
                }
                default:
                {
                    throw new RequestFailedException(message.Response);
                }
            }
        }
    }
}
