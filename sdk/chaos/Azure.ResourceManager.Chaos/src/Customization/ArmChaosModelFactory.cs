// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Chaos.Models
{
    public partial class ArmChaosModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Chaos.ChaosTargetData"/>. </summary>
             /// <param name="id"> The id. </param>
             /// <param name="name"> The name. </param>
             /// <param name="resourceType"> The resourceType. </param>
             /// <param name="systemData"> The systemData. </param>
             /// <param name="location"> Location of the target resource. </param>
             /// <param name="properties"> The properties of the target resource. </param>
             /// <returns> A new <see cref="Chaos.ChaosTargetData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosTargetData ChaosTargetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, IDictionary<string, BinaryData> properties = null)
        {
            properties ??= new Dictionary<string, BinaryData>();

            return new ChaosTargetData(
                id,
                name,
                resourceType,
                systemData,
                location,
                properties,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Chaos.ChaosCapabilityTypeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the Capability Type resource. </param>
        /// <param name="publisher"> String of the Publisher that this Capability Type extends. </param>
        /// <param name="targetType"> String of the Target Type that this Capability Type extends. </param>
        /// <param name="displayName"> Localized string of the display name. </param>
        /// <param name="description"> Localized string of the description. </param>
        /// <param name="parametersSchema"> URL to retrieve JSON schema of the Capability Type parameters. </param>
        /// <param name="urn"> String of the URN for this Capability Type. </param>
        /// <param name="kind"> String of the kind of this Capability Type. </param>
        /// <param name="azureRbacActions"> Control plane actions necessary to execute capability type. </param>
        /// <param name="azureRbacDataActions"> Data plane actions necessary to execute capability type. </param>
        /// <param name="runtimeKind"> Runtime properties of this Capability Type. </param>
        /// <returns> A new <see cref="Chaos.ChaosCapabilityTypeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosCapabilityTypeData ChaosCapabilityTypeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, IEnumerable<string> azureRbacActions = null, IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null)
        {
            azureRbacActions ??= new List<string>();
            azureRbacDataActions ??= new List<string>();

            return new ChaosCapabilityTypeData(
                id,
                name,
                resourceType,
                systemData,
                location,
                publisher,
                targetType,
                displayName,
                description,
                parametersSchema,
                urn,
                kind,
                azureRbacActions?.ToList(),
                azureRbacDataActions?.ToList(),
                runtimeKind != null ? new ChaosCapabilityTypeRuntimeProperties(runtimeKind, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Chaos.ChaosTargetTypeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the Target Type resource. </param>
        /// <param name="displayName"> Localized string of the display name. </param>
        /// <param name="description"> Localized string of the description. </param>
        /// <param name="propertiesSchema"> URL to retrieve JSON schema of the Target Type properties. </param>
        /// <param name="resourceTypes"> List of resource types this Target Type can extend. </param>
        /// <returns> A new <see cref="Chaos.ChaosTargetTypeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosTargetTypeData ChaosTargetTypeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, string displayName = null, string description = null, string propertiesSchema = null, IEnumerable<string> resourceTypes = null)
        {
            resourceTypes ??= new List<string>();

            return new ChaosTargetTypeData(
                id,
                name,
                resourceType,
                systemData,
                location,
                displayName,
                description,
                propertiesSchema,
                resourceTypes?.ToList(),
                serializedAdditionalRawData: null);
        }
    }
}
