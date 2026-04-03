// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stub: ContainerGroupProfileRevisionResource was removed in TypeSpec migration.
// The old API exposed this as a separate resource type; revisions are now accessed through CGProfileResource.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable AZC0150

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat stub: ContainerGroupProfileRevisionResource was removed in TypeSpec migration.
    // Revisions are now accessed through CGProfileResource.
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

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileRevisionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileRevisionResource(ArmClient client, ContainerGroupProfileData data) : base(client, data.Id)
        {
            _data = data;
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
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

        /// <summary> Gets the resource (not supported). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerGroupProfileRevisionResource> Get(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("ContainerGroupProfileRevisionResource is no longer available. Use CGProfileResource instead.");

        /// <summary> Gets the resource asynchronously (not supported). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerGroupProfileRevisionResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("ContainerGroupProfileRevisionResource is no longer available. Use CGProfileResource instead.");

        /// <inheritdoc/>
        ContainerGroupProfileData IJsonModel<ContainerGroupProfileData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        void IJsonModel<ContainerGroupProfileData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        ContainerGroupProfileData IPersistableModel<ContainerGroupProfileData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        string IPersistableModel<ContainerGroupProfileData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <inheritdoc/>
        BinaryData IPersistableModel<ContainerGroupProfileData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
    }
}
