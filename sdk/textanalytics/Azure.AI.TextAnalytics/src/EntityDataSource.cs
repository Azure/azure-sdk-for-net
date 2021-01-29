// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntityDataSource.
    /// </summary>
    [CodeGenModel("HealthcareEntityLink")]
    public partial class EntityDataSource
    {
        /// <summary> Entity id in the given source catalog. </summary>
        [CodeGenMember("Id")]
        public string EntityId { get; }

        /// <summary> Entity Catalog. Examples include: UMLS, CHV, MSH, etc. </summary>
        [CodeGenMember("DataSource")]
        public string Name { get; }
    }
}
