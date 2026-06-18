// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("IotSecurityAggregatedAlertData")]
    public partial class IotSecurityAggregatedAlertData
    {
        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="IotSecurityAggregatedAlertData"/>. </summary>
        public IotSecurityAggregatedAlertData()
        {
            Properties = new IoTSecurityAggregatedAlertProperties();
            Tags = new ChangeTrackingDictionary<string, string>();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Date of detection. </summary>
        public DateTimeOffset? AggregatedOn => AggregatedDateUtc;
    }
}
