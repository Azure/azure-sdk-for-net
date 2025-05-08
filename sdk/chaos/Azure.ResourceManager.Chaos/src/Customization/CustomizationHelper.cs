// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;

namespace Azure.ResourceManager.Chaos
{
    internal static partial class CustomizationHelper
    {
        [Obsolete]
        internal static ChaosCapabilityTypeData GetCapabilityTypeData(ChaosCapabilityMetadataData data)
        {
            _ = data ?? throw new ArgumentNullException(nameof(data));
            var resourceIdentifier = ResourceIdentifier.Parse(data.Id);
            return new ChaosCapabilityTypeData(
                data.Id,
                data.Name,
                data.ResourceType,
                data.SystemData,
                resourceIdentifier.Location,
                data.Publisher,
                data.TargetType,
                data.DisplayName,
                data.Description,
                data.ParametersSchema,
                data.Urn,
                data.Kind,
                (IList<string>)data.AzureRbacActions,
                (IList<string>)data.AzureRbacDataActions,
                GetCapabilityTypeRuntimeProperties(data.RuntimeProperties),
                null);
        }

        [Obsolete]
        internal static ChaosCapabilityTypeRuntimeProperties GetCapabilityTypeRuntimeProperties(ChaosCapabilityMetadataRuntimeProperties runtimeProperties)
        {
            _ = runtimeProperties ?? throw new ArgumentNullException(nameof(runtimeProperties));
            return new ChaosCapabilityTypeRuntimeProperties(runtimeProperties.Kind, null);
        }

        [Obsolete]
        internal static ChaosTargetTypeData GetTargetTypeData(ChaosTargetMetadataData data)
        {
            _ = data ?? throw new ArgumentNullException(nameof(data));
            return new ChaosTargetTypeData(
                data.Id,
                data.Name,
                data.ResourceType,
                data.SystemData,
                data.Id.Location,
                data.DisplayName,
                data.Description,
                data.PropertiesSchema,
                data.ResourceTypes,
                null);
        }
    }
}
