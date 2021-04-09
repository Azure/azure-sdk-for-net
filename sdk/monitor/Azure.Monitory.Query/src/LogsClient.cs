// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    public class LogsClient
    {
        private readonly QueryRestClient _queryClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        public LogsClient(TokenCredential credential) : this(credential, null)
        {
        }

        public LogsClient(TokenCredential credential, LogsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new LogsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://api.loganalytics.io//.default"));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline);
        }

        protected LogsClient()
        {
        }

        public virtual Response<IReadOnlyList<T>> Query<T>(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = Query(workspaceId, query, cancellationToken);

            return Response.FromValue(BindResults<T>(response), response.GetRawResponse());
        }

        public virtual async Task<Response<IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryAsync(workspaceId, query, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(BindResults<T>(response), response.GetRawResponse());
        }

        internal static IReadOnlyList<T> BindResults<T>(LogsQueryResult response)
        {
            // TODO: this is very slow
            List<T> results = new List<T>();
            if (typeof(IDictionary<string, object>).IsAssignableFrom(typeof(T)))
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        IDictionary<string, object> rowObject = (IDictionary<string, object>) Activator.CreateInstance<T>();

                        for (var i = 0; i < row.Count; i++)
                        {
                            rowObject[table.Columns[i].Name] = row.GetObject(i);
                        }

                        results.Add((T)rowObject);
                    }
                }
            }
            else if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        // TODO: Validate
                        results.Add((T)Convert.ChangeType(row.GetObject(0), typeof(T), CultureInfo.InvariantCulture));
                    }
                }
            }
            else
            {
                foreach (var table in response.Tables)
                {
                    var columnMap = table.Columns
                        .Select((column, index) => (Property: typeof(T).GetProperty(column.Name, BindingFlags.Instance | BindingFlags.Public), index))
                        .Where(columnMapping => columnMapping.Property?.SetMethod != null)
                        .ToArray();

                    foreach (var row in table.Rows)
                    {
                        T rowObject = Activator.CreateInstance<T>();

                        foreach (var (property, index) in columnMap)
                        {
                            property.SetValue(rowObject, Convert.ChangeType(row.GetObject(index), property.PropertyType, CultureInfo.InvariantCulture));
                        }

                        results.Add(rowObject);
                    }
                }
            }

            // TODO: Maybe support record construction
            return results;
        }

        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _queryClient.Execute(workspaceId, new QueryBody(query), null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _queryClient.ExecuteAsync(workspaceId, new QueryBody(query), null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual LogsBatchQuery CreateBatchQuery()
        {
            return new LogsBatchQuery(_clientDiagnostics, _queryClient);
        }
    }
}