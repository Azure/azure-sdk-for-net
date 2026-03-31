// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat stub: ContainerGroupProfileRevisionResource was removed in TypeSpec migration.
    // Revisions are now accessed through CGProfileResource.GetAllRevisions().
    /// <summary> A class representing the ContainerGroupProfileRevision resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileRevisionResource : ArmResource,
        IJsonModel<ContainerGroupProfileData>, IPersistableModel<ContainerGroupProfileData>
    {
        /// <summary> The resource type for this resource. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ContainerInstance/containerGroupProfiles/revisions";

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileRevisionResource"/>. </summary>
        protected ContainerGroupProfileRevisionResource()
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileRevisionResource(bool _)
        {
        }

        #pragma warning disable CS0649
        private ContainerGroupProfileData _data;
        #pragma warning restore CS0649

        /// <summary> Gets the data representing this resource. </summary>
        public virtual ContainerGroupProfileData Data => _data ?? throw new InvalidOperationException("Resource does not have data.");

        /// <summary> Gets whether this resource has data. </summary>
        public virtual bool HasData => _data != null;

        /// <summary> Creates a resource identifier. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupProfileName, string revisionNumber)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroupProfiles/{containerGroupProfileName}/revisions/{revisionNumber}";
            return new ResourceIdentifier(resourceId);
        }

        ContainerGroupProfileData IJsonModel<ContainerGroupProfileData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("Backward compat type.");
        void IJsonModel<ContainerGroupProfileData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("Backward compat type.");
        ContainerGroupProfileData IPersistableModel<ContainerGroupProfileData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("Backward compat type.");
        string IPersistableModel<ContainerGroupProfileData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ContainerGroupProfileData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("Backward compat type.");
    }
}
