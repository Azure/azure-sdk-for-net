// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppActiveDirectoryConfigResource : ArmResource, IJsonModel<NetAppActiveDirectoryConfigData>, IPersistableModel<NetAppActiveDirectoryConfigData>
    {
        public static readonly ResourceType ResourceType = "Microsoft.NetApp/activeDirectoryConfigs";

        private bool _hasData;
        private readonly NetAppActiveDirectoryConfigData _data;

        protected NetAppActiveDirectoryConfigResource()
        {
        }

        internal NetAppActiveDirectoryConfigResource(ArmClient client, NetAppActiveDirectoryConfigData data) : this(client, data.Id)
        {
            _hasData = true;
            _data = data;
        }

        internal NetAppActiveDirectoryConfigResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        public virtual bool HasData => _hasData;

        public virtual NetAppActiveDirectoryConfigData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }

                return _data;
            }
        }

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string activeDirectoryConfigName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/activeDirectoryConfigs/{activeDirectoryConfigName}";
            return new ResourceIdentifier(resourceId);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException($"Invalid resource type {id.ResourceType} expected {ResourceType}", nameof(id));
            }
        }

        public virtual Task<Response<NetAppActiveDirectoryConfigResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<NetAppActiveDirectoryConfigResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<ArmOperation<NetAppActiveDirectoryConfigResource>> UpdateAsync(WaitUntil waitUntil, NetAppActiveDirectoryConfigPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual ArmOperation<NetAppActiveDirectoryConfigResource> Update(WaitUntil waitUntil, NetAppActiveDirectoryConfigPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<Response<NetAppActiveDirectoryConfigResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<NetAppActiveDirectoryConfigResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<Response<NetAppActiveDirectoryConfigResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<NetAppActiveDirectoryConfigResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Task<Response<NetAppActiveDirectoryConfigResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public virtual Response<NetAppActiveDirectoryConfigResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        void IJsonModel<NetAppActiveDirectoryConfigData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<NetAppActiveDirectoryConfigData>)Data).Write(writer, options);

        NetAppActiveDirectoryConfigData IJsonModel<NetAppActiveDirectoryConfigData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<NetAppActiveDirectoryConfigData>)new NetAppActiveDirectoryConfigData()).Create(ref reader, options);

        BinaryData IPersistableModel<NetAppActiveDirectoryConfigData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetAppActiveDirectoryConfigData>)Data).Write(options);

        NetAppActiveDirectoryConfigData IPersistableModel<NetAppActiveDirectoryConfigData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<NetAppActiveDirectoryConfigData>)new NetAppActiveDirectoryConfigData()).Create(data, options);

        string IPersistableModel<NetAppActiveDirectoryConfigData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<NetAppActiveDirectoryConfigData>)new NetAppActiveDirectoryConfigData()).GetFormatFromOptions(options);
    }
}
