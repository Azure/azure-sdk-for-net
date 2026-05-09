// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.AlertProcessingRules.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AlertProcessingRules.Models
{
    // The C# mgmt generator emits a malformed type reference (`global::.AlertProcessingRuleProperties`)
    // for the factory method when the corresponding internal ctor is suppressed.
    // Suppress the broken factory method and provide a working replacement that calls into
    // the (customized) internal ctor.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(
        "AlertProcessingRuleData",
        typeof(string),
        typeof(string),
        typeof(ResourceType),
        typeof(SystemData),
        typeof(IDictionary<string, string>),
        typeof(AzureLocation),
        typeof(AlertProcessingRuleProperties))]
    public static partial class ArmAlertProcessingRulesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="AlertProcessingRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Alert processing rule properties. </param>
        /// <returns> A new <see cref="AlertProcessingRuleData"/> instance for mocking. </returns>
        public static AlertProcessingRuleData AlertProcessingRuleData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            IDictionary<string, string> tags = default,
            AzureLocation location = default,
            AlertProcessingRuleProperties properties = default)
        {
            tags ??= new Dictionary<string, string>();
            return new AlertProcessingRuleData(
                id?.ToString(),
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                properties);
        }
    }
}
