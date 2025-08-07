// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Chaos
{
    /// <summary>
    /// A class representing the ChaosCapabilityType data model.
    /// Model that represents a Capability Type resource.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ChaosCapabilityMetadataData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ChaosCapabilityTypeData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ChaosCapabilityTypeData"/>. </summary>
        public ChaosCapabilityTypeData()
        {
            AzureRbacActions = new ChangeTrackingList<string>();
            AzureRbacDataActions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ChaosCapabilityTypeData"/>. </summary>
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
        /// <param name="runtimeProperties"> Runtime properties of this Capability Type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChaosCapabilityTypeData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, AzureLocation? location, string publisher, string targetType, string displayName, string description, string parametersSchema, string urn, string kind, IList<string> azureRbacActions, IList<string> azureRbacDataActions, ChaosCapabilityTypeRuntimeProperties runtimeProperties, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Publisher = publisher;
            TargetType = targetType;
            DisplayName = displayName;
            Description = description;
            ParametersSchema = parametersSchema;
            Urn = urn;
            Kind = kind;
            AzureRbacActions = azureRbacActions;
            AzureRbacDataActions = azureRbacDataActions;
            RuntimeProperties = runtimeProperties;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Location of the Capability Type resource. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> String of the Publisher that this Capability Type extends. </summary>
        public string Publisher { get; }
        /// <summary> String of the Target Type that this Capability Type extends. </summary>
        public string TargetType { get; }
        /// <summary> Localized string of the display name. </summary>
        public string DisplayName { get; }
        /// <summary> Localized string of the description. </summary>
        public string Description { get; }
        /// <summary> URL to retrieve JSON schema of the Capability Type parameters. </summary>
        public string ParametersSchema { get; }
        /// <summary> String of the URN for this Capability Type. </summary>
        public string Urn { get; }
        /// <summary> String of the kind of this Capability Type. </summary>
        public string Kind { get; }
        /// <summary> Control plane actions necessary to execute capability type. </summary>
        public IList<string> AzureRbacActions { get; }
        /// <summary> Data plane actions necessary to execute capability type. </summary>
        public IList<string> AzureRbacDataActions { get; }
        /// <summary> Runtime properties of this Capability Type. </summary>
        internal ChaosCapabilityTypeRuntimeProperties RuntimeProperties { get; set; }
        /// <summary> String of the kind of the resource's action type (continuous or discrete). </summary>
        public string RuntimeKind
        {
            get => RuntimeProperties is null ? default : RuntimeProperties.Kind;
        }
    }
}
