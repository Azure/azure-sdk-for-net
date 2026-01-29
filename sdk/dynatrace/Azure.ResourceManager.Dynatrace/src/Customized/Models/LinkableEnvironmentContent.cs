// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Dynatrace.Models
{
    /// <summary> Request for getting all the linkable environments for a user. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Region), SerializationValueHook = nameof(WriteRegion), DeserializationValueHook = nameof(ReadRegion))]
    public partial class LinkableEnvironmentContent
    {
        /// <summary> Initializes a new instance of <see cref="LinkableEnvironmentContent"/>. </summary>
        public LinkableEnvironmentContent()
        {
        }

        /// <summary> Tenant Id of the user in which they want to link the environment. </summary>
        public Guid? TenantId { get; set; }

        /// <summary> user principal id of the user. </summary>
        public string UserPrincipal { get; set; }

        /// <summary> Azure region in which we want to link the environment. </summary>
        public Azure.Core.AzureLocation? Region { get; set; }

        internal void WriteRegion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(Region);
        }

        internal static void ReadRegion(JsonProperty property, ref AzureLocation? Region)
        {
            Region = new AzureLocation(property.Value.GetString());
        }
    }
}
