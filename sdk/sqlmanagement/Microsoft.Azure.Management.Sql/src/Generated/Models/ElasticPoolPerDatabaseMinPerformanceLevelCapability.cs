// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The minimum per-database performance level capability.
    /// </summary>
    public partial class ElasticPoolPerDatabaseMinPerformanceLevelCapability
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ElasticPoolPerDatabaseMinPerformanceLevelCapability class.
        /// </summary>
        public ElasticPoolPerDatabaseMinPerformanceLevelCapability()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ElasticPoolPerDatabaseMinPerformanceLevelCapability class.
        /// </summary>
        /// <param name="limit">The minimum performance level per
        /// database.</param>
        /// <param name="unit">Unit type used to measure performance level.
        /// Possible values include: 'DTU', 'VCores'</param>
        /// <param name="status">The status of the capability. Possible values
        /// include: 'Visible', 'Available', 'Default', 'Disabled'</param>
        /// <param name="reason">The reason for the capability not being
        /// available.</param>
        public ElasticPoolPerDatabaseMinPerformanceLevelCapability(double? limit = default(double?), string unit = default(string), CapabilityStatus? status = default(CapabilityStatus?), string reason = default(string))
        {
            Limit = limit;
            Unit = unit;
            Status = status;
            Reason = reason;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the minimum performance level per database.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public double? Limit { get; private set; }

        /// <summary>
        /// Gets unit type used to measure performance level. Possible values
        /// include: 'DTU', 'VCores'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; private set; }

        /// <summary>
        /// Gets the status of the capability. Possible values include:
        /// 'Visible', 'Available', 'Default', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public CapabilityStatus? Status { get; private set; }

        /// <summary>
        /// Gets or sets the reason for the capability not being available.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

    }
}
