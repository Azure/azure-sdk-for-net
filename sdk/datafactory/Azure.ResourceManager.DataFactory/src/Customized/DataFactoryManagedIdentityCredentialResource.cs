// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores the DataFactoryManagedIdentityCredentialResource back-compat surface.
    //
    // Spec context: the ARM resource for credentials is `Microsoft.DataFactory/factories/credentials`
    // (single resource type; no `/managedIdentityCredentials/` sibling path in TypeSpec
    // CredentialResource.tsp, swagger, or Bicep). The pre-MPG AutoRest SDK projected the same REST endpoint
    // as two SDK-only "views": DataFactoryServiceCredentialResource and this specialized
    // DataFactoryManagedIdentityCredentialResource. Because the second view has no spec representation,
    // the MPG generator emits only the general resource. This partial reconstructs the specialized resource
    // as a thin delegating wrapper around DataFactoryServiceCredentialResource so all CRUD/LRO operations
    // hit the same REST endpoint while the published API surface is preserved.
    /// <summary>
    /// A Class representing a DataFactoryManagedIdentityCredential along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DataFactoryManagedIdentityCredentialResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetDataFactoryManagedIdentityCredentialResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataFactoryResource"/> using the GetDataFactoryManagedIdentityCredential method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataFactoryManagedIdentityCredentialResource : ArmResource, IJsonModel<DataFactoryManagedIdentityCredentialData>, IPersistableModel<DataFactoryManagedIdentityCredentialData>
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DataFactory/factories/credentials";

        private readonly DataFactoryServiceCredentialResource _inner;
        private readonly DataFactoryManagedIdentityCredentialData _data;

        /// <summary> Generate the resource identifier of a <see cref="DataFactoryManagedIdentityCredentialResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="factoryName"> The factoryName. </param>
        /// <param name="credentialName"> The credentialName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string credentialName)
        {
            return DataFactoryServiceCredentialResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, factoryName, credentialName);
        }

        /// <summary> Initializes a new instance of the <see cref="DataFactoryManagedIdentityCredentialResource"/> class for mocking. </summary>
        protected DataFactoryManagedIdentityCredentialResource()
        {
        }

        internal DataFactoryManagedIdentityCredentialResource(ArmClient client, DataFactoryManagedIdentityCredentialData data) : this(client, data?.Id)
        {
            HasData = true;
            _data = data;
        }

        internal DataFactoryManagedIdentityCredentialResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _inner = new DataFactoryServiceCredentialResource(client, id);
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual DataFactoryManagedIdentityCredentialData Data
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

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="ifNoneMatch"> ETag of the credential entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataFactoryManagedIdentityCredentialResource>> GetAsync(string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = await _inner.GetAsync(etag, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="ifNoneMatch"> ETag of the credential entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataFactoryManagedIdentityCredentialResource> Get(string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = _inner.Get(etag, cancellationToken);
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        /// <summary> Deletes a credential. </summary>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => _inner.DeleteAsync(waitUntil, cancellationToken);

        /// <summary> Deletes a credential. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => _inner.Delete(waitUntil, cancellationToken);

        /// <summary> Creates or updates a credential. </summary>
        public virtual async Task<ArmOperation<DataFactoryManagedIdentityCredentialResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            var etag = ifMatch != null ? new ETag(ifMatch) : (ETag?)null;
            var operation = await _inner.UpdateAsync(waitUntil, data.ToServiceCredentialData(), etag, cancellationToken).ConfigureAwait(false);
            return new DataFactoryManagedIdentityCredentialArmOperationWrapper(Client, operation);
        }

        /// <summary> Creates or updates a credential. </summary>
        public virtual ArmOperation<DataFactoryManagedIdentityCredentialResource> Update(WaitUntil waitUntil, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            var etag = ifMatch != null ? new ETag(ifMatch) : (ETag?)null;
            var operation = _inner.Update(waitUntil, data.ToServiceCredentialData(), etag, cancellationToken);
            return new DataFactoryManagedIdentityCredentialArmOperationWrapper(Client, operation);
        }

        DataFactoryManagedIdentityCredentialData IJsonModel<DataFactoryManagedIdentityCredentialData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<DataFactoryManagedIdentityCredentialData>)Data).Create(ref reader, options);

        void IJsonModel<DataFactoryManagedIdentityCredentialData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DataFactoryManagedIdentityCredentialData>)Data).Write(writer, options);

        DataFactoryManagedIdentityCredentialData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<DataFactoryManagedIdentityCredentialData>)Data).Create(data, options);

        string IPersistableModel<DataFactoryManagedIdentityCredentialData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<DataFactoryManagedIdentityCredentialData>)Data).GetFormatFromOptions(options);

        BinaryData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<DataFactoryManagedIdentityCredentialData>)Data).Write(options);
    }
}
