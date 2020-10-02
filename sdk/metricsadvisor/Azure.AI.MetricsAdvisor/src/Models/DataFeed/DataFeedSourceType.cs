// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("DataSourceType")]
    public readonly partial struct DataFeedSourceType
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("AzureCosmosDB")]
        public static DataFeedSourceType AzureCosmosDb { get; } = new DataFeedSourceType(AzureCosmosDbValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("InfluxDB")]
        public static DataFeedSourceType InfluxDb { get; } = new DataFeedSourceType(InfluxDbValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("MongoDB")]
        public static DataFeedSourceType MongoDb { get; } = new DataFeedSourceType(MongoDbValue);
    }
}
