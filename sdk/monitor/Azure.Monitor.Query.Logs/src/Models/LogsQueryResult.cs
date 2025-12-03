// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Monitor.Query.Logs.Models
{
    public partial class LogsQueryResult
    {
        [CodeGenMember("Error")]
        private JsonElement _error;

        [CodeGenMember("Statistics")]
        private readonly JsonElement _statistics;

        [CodeGenMember("Render")]
        private readonly JsonElement _visualization;

        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        // Accessor cache fields.
        private ResponseError _deserializedError;
        private BinaryData _cachedStatistics;
        private BinaryData _cachedVisualization;

        /// <summary>
        /// Gets the single table result of the query.
        /// </summary>
        public LogsTable Table
        {
            get
            {
                if (AllTables.Count != 1)
                {
                    throw new InvalidOperationException($"The result contains multiple tables. Use the {nameof(AllTables)} collection to access all tables.");
                }

                return AllTables[0];
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the query was successful.
        /// </summary>
        public LogsQueryResultStatus Status { get; internal set; }

        /// <summary>
        /// Gets the multi-table result of the query.
        /// </summary>
        [CodeGenMember("Tables")]
        public IReadOnlyList<LogsTable> AllTables { get; }

        /// <summary> Initializes a new instance of <see cref="LogsQueryResult"/>. </summary>
        /// <param name="allTables"> The results of the query in tabular format. </param>
        /// <param name="error"> Any object. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LogsQueryResult(IReadOnlyList<LogsTable> allTables, JsonElement error, JsonElement statistics, JsonElement visualization, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            AllTables = allTables;
            _error = error;
            _statistics = statistics;
            _visualization = visualization;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Returns the query statistics if the <see cref="LogsQueryOptions.IncludeStatistics"/> is set to <c>true</c>. <c>null</c> otherwise.
        /// </summary>
        public BinaryData GetStatistics() => _statistics.ValueKind switch
        {
            JsonValueKind.Undefined => null,
            _ => _cachedStatistics ??= new BinaryData(_statistics.ToString())
        };

        /// <summary>
        /// Returns the query visualization if the <see cref="LogsQueryOptions.IncludeVisualization"/> is set to <c>true</c>. <c>null</c> otherwise.
        /// </summary>
        public BinaryData GetVisualization() => _visualization.ValueKind switch
        {
            JsonValueKind.Undefined => null,
            _ => _cachedVisualization ??= new BinaryData(_visualization.ToString())
        };

        /// <summary>
        /// Gets the error that occurred during query processing. The value is <c>null</c> if the query succeeds.
        /// </summary>
        public ResponseError Error
        {
            get => _error.ValueKind switch
            {
                JsonValueKind.Undefined => null,
                _ => _deserializedError ??= ModelReaderWriter.Read<ResponseError>(
                    BinaryData.FromString(_error.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    AzureMonitorQueryLogsContext.Default)
            };

            internal set
            {
                var data = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureMonitorQueryLogsContext.Default);
                using var doc = JsonDocument.Parse(data.ToStream());

                _error = doc.RootElement.Clone();
                _deserializedError = _error.ValueKind == JsonValueKind.Undefined ? null : value;
            }
        }

        internal Exception CreateExceptionForErrorResponse(int status)
        {
            return new RequestFailedException(
                status,
                $"The result was returned but contained a partial error. Exceptions for partial errors can be disabled " +
                $" using {nameof(LogsQueryOptions)}.{nameof(LogsQueryOptions.AllowPartialErrors)}." +
                $"Partial errors can be inspected using the {nameof(LogsQueryResult)}.{nameof(Error)} property.{Environment.NewLine}" +
                $"Error:{Environment.NewLine}{Error}",
                Error.Code,
                innerException: null
            );
        }
    }
}
