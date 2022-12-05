// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("DistributionMode")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<DistributionMode>))]
    public abstract partial class DistributionMode
    {
        /// <summary>
        /// (Optional)
        ///
        /// Governs the minimum desired number of active concurrent offers a job can have.
        /// </summary>
        public int MinConcurrentOffers { get; set; } = 1;
        /// <summary>
        /// (Optional)
        ///
        /// Governs the maximum number of active concurrent offers a job can have.
        /// </summary>
        public int MaxConcurrentOffers { get; set; } = 1;
    }
}
