// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventGridTopicPrivateLinkResource : ArmResource, IJsonModel<EventGridPrivateLinkResourceData>, IPersistableModel<EventGridPrivateLinkResourceData>
    {
        private readonly EventGridPrivateLinkResourceData _data;
        public static readonly ResourceType ResourceType = "Microsoft.EventGrid/topics/privateLinkResources";

        protected EventGridTopicPrivateLinkResource()
        {
        }

        internal EventGridTopicPrivateLinkResource(ArmClient client, EventGridPrivateLinkResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal EventGridTopicPrivateLinkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        public virtual bool HasData { get; }

        public virtual EventGridPrivateLinkResourceData Data => HasData ? _data : throw new InvalidOperationException("The current instance does not have data, you must call Get first.");

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}/privateLinkResources/{privateLinkResourceName}");

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        public virtual async Task<Response<EventGridTopicPrivateLinkResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName);
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, resourceGroupId);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = await resourceGroup.GetAsync("topics", Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToTopicResource(Client, response.Value));
        }

        public virtual Response<EventGridTopicPrivateLinkResource> Get(CancellationToken cancellationToken = default)
        {
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName);
            MockableEventGridResourceGroupResource resourceGroup = new MockableEventGridResourceGroupResource(Client, resourceGroupId);
            Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response = resourceGroup.Get("topics", Id.Parent.Name, Id.Name, cancellationToken);
            return PrivateLinkResourceCompat.Convert(response, PrivateLinkResourceCompat.ToTopicResource(Client, response.Value));
        }

        EventGridPrivateLinkResourceData IJsonModel<EventGridPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<EventGridPrivateLinkResourceData>)new EventGridPrivateLinkResourceData()).Create(ref reader, options);

        void IJsonModel<EventGridPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<EventGridPrivateLinkResourceData>)Data).Write(writer, options);

        EventGridPrivateLinkResourceData IPersistableModel<EventGridPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<EventGridPrivateLinkResourceData>)new EventGridPrivateLinkResourceData()).Create(data, options);

        string IPersistableModel<EventGridPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<EventGridPrivateLinkResourceData>)new EventGridPrivateLinkResourceData()).GetFormatFromOptions(options);

        BinaryData IPersistableModel<EventGridPrivateLinkResourceData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<EventGridPrivateLinkResourceData>)Data).Write(options);
    }
}
