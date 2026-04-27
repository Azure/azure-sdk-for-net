// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Deployment properties with additional details. </summary>
    [CodeGenSuppress("DebugSettingDetailLevel")]
    [CodeGenSerialization(nameof(Providers), SerializationValueHook = nameof(SerializationProviders), DeserializationValueHook = nameof(DeserializeProviders))]
    [CodeGenSerialization(nameof(Error), SerializationValueHook = nameof(SerializationError), DeserializationValueHook = nameof(DeserializeError))]
    public partial class ArmDeploymentPropertiesExtended
    {
        /// <summary> Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations. </summary>
        public string DebugSettingDetailLevel
        {
            get => DebugSetting?.DetailLevel;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => DebugSetting.DetailLevel = value;
        }

        /// <summary>
        /// Array of provisioned resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("outputResources")]
        public IReadOnlyList<SubResource> OutputResources
            => OutputResourceDetails.Select(d => ResourceManagerModelFactory.SubResource(d.Id != null ? new Azure.Core.ResourceIdentifier(d.Id) : null)).ToArray();

        /// <summary>
        /// Array of validated resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("validatedResources")]
        public IReadOnlyList<SubResource> ValidatedResources
            => ValidatedResourceDetails.Select(d => ResourceManagerModelFactory.SubResource(d.Id != null ? new Azure.Core.ResourceIdentifier(d.Id) : null)).ToArray();

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
        // The Provider model is omitted and use the ResourceProviderData model instead in Azure.ResourceManager.Resources library.
        /// <summary> The list of resource providers needed for the deployment. </summary>
        [WirePath("providers")]
        public IReadOnlyList<ResourceProviderData> Providers { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SerializationProviders(Utf8JsonWriter writer, IReadOnlyList<ResourceProviderData> providers, ModelReaderWriterOptions options)
        {
            writer.WriteStartArray();
            foreach (var item in providers)
            {
                ((IJsonModel<ResourceProviderData>)item).Write(writer, options);
            }
            writer.WriteEndArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeProviders(JsonProperty property, ref IReadOnlyList<ResourceProviderData> providers, ModelReaderWriterOptions options)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<ResourceProviderData> array = new List<ResourceProviderData>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), options, AzureResourceManagerResourcesContext.Default));
            }
            providers = array;
        }
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
        // The Error model is omitted and use the ResponseError model instead in Azure.ResourceManager.Resources library.
        /// <summary> The deployment error. </summary>
        [WirePath("error")]
        public ResponseError Error { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SerializationError(Utf8JsonWriter writer, ResponseError error, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ResponseError>)error).Write(writer, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeError(JsonProperty property, ref ResponseError error, ModelReaderWriterOptions options)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            error = ModelReaderWriter.Read<ResponseError>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), options, AzureResourceManagerResourcesContext.Default);
        }
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
    }
}
