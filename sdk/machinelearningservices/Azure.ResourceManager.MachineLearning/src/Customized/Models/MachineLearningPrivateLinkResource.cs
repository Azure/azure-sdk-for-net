// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy public constructor for private link resources.
    [CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(SerializeIdentity), DeserializationValueHook = nameof(DeserializeIdentity))]
    [CodeGenSuppress("RequiredMembers")]
    [CodeGenSuppress("Sku")]
    public partial class MachineLearningPrivateLinkResource : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateLinkResource"/>. </summary>
        /// <param name="location"> Same as workspace location. </param>
        public MachineLearningPrivateLinkResource(AzureLocation location)
            : base(location)
        {
        }

        /// <summary> Gets the Identity. </summary>
        [CodeGenMember("Identity")]
        [WirePath("identity")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity { get; set; }

        /// <summary> The private link resource required member names. </summary>
        [WirePath("properties.requiredMembers")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> RequiredMembers => Properties?.RequiredMembers is null ? null : new List<string>(Properties.RequiredMembers);

        /// <summary> Optional. This field is required to be implemented by the RP because AML is supporting more than one tier. </summary>
        [WirePath("sku")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningSku Sku { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeIdentity(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeIdentity(JsonProperty property, ref ManagedServiceIdentity identity)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerMachineLearningContext.Default);
        }
    }
}
