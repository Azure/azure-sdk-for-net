// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The type of <see cref="DataFeedGranularity"/>.
    /// </summary>
    [CodeGenModel("Granularity")]
    public readonly partial struct DataFeedGranularityType
    {
        /// <summary>
        /// Ingestion happens once a year.
        /// </summary>
        public static DataFeedGranularityType Yearly { get; } = new DataFeedGranularityType(YearlyValue);

        /// <summary>
        /// Ingestion happens once a month.
        /// </summary>
        public static DataFeedGranularityType Monthly { get; } = new DataFeedGranularityType(MonthlyValue);

        /// <summary>
        /// Ingestion happens once a week.
        /// </summary>
        public static DataFeedGranularityType Weekly { get; } = new DataFeedGranularityType(WeeklyValue);

        /// <summary>
        /// Ingestion happens once a day.
        /// </summary>
        public static DataFeedGranularityType Daily { get; } = new DataFeedGranularityType(DailyValue);

        /// <summary>
        /// Ingestion happens once an hour.
        /// </summary>
        public static DataFeedGranularityType Hourly { get; } = new DataFeedGranularityType(HourlyValue);

        /// <summary>
        /// Ingestion happens once a minute.
        /// </summary>
        [CodeGenMember("Minutely")]
        public static DataFeedGranularityType PerMinute { get; } = new DataFeedGranularityType(PerMinuteValue);

        /// <summary>
        /// Ingestion happens once a second.
        /// </summary>
        [CodeGenMember("Secondly")]
        public static DataFeedGranularityType PerSecond { get; } = new DataFeedGranularityType(PerSecondValue);

        /// <summary>
        /// Ingestion happens in a customized interval. Period can be set with
        /// <see cref="DataFeedGranularity.CustomGranularityValue"/>.
        /// </summary>
        public static DataFeedGranularityType Custom { get; } = new DataFeedGranularityType(CustomValue);
    }
}
