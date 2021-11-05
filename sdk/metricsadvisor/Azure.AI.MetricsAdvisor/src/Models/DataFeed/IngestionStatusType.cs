// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes the current status of a <see cref="DataFeed"/>'s attempt to ingest data
    /// from its data source.
    /// </summary>
    public readonly partial struct IngestionStatusType
    {
        /// <summary>
        /// Ingestion hasn't started and hasn't been scheduled yet.
        /// </summary>
        public static IngestionStatusType NotStarted { get; } = new IngestionStatusType(NotStartedValue);

        /// <summary>
        /// Ingestion hasn't started, but it's been scheduled.
        /// </summary>
        public static IngestionStatusType Scheduled { get; } = new IngestionStatusType(ScheduledValue);

        /// <summary>
        /// Ingestion is in progress.
        /// </summary>
        public static IngestionStatusType Running { get; } = new IngestionStatusType(RunningValue);

        /// <summary>
        /// Ingestion finished and was successful.
        /// </summary>
        public static IngestionStatusType Succeeded { get; } = new IngestionStatusType(SucceededValue);

        /// <summary>
        /// Ingestion finished and was not successful.
        /// </summary>
        public static IngestionStatusType Failed { get; } = new IngestionStatusType(FailedValue);

        /// <summary>
        /// No data was available in the data source for the associated timestamp.
        /// </summary>
        public static IngestionStatusType NoData { get; } = new IngestionStatusType(NoDataValue);

        /// <summary>
        /// An error prevented ingestion from occurring.
        /// </summary>
        public static IngestionStatusType Error { get; } = new IngestionStatusType(ErrorValue);

        /// <summary>
        /// Ingestion was in progress, but it's currently paused.
        /// </summary>
        public static IngestionStatusType Paused { get; } = new IngestionStatusType(PausedValue);
    }
}
