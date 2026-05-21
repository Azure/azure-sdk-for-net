// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization restores the DataFactoryManagedIdentityCredentialData back-compat surface
// that was present in the upstream (pre-MPG) generator. The MPG migration replaced this
// type with the generic DataFactoryServiceCredentialData (which uses the DataFactoryCredential
// base type for Properties). This wrapper preserves the upstream public API by holding an
// inner DataFactoryServiceCredentialData and projecting its Properties as the strongly-typed
// DataFactoryManagedIdentityCredentialProperties subclass.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// A class representing the DataFactoryManagedIdentityCredential data model.
    /// Credential resource type specialized for managed-identity credentials.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataFactoryManagedIdentityCredentialData : ResourceData, IJsonModel<DataFactoryManagedIdentityCredentialData>, IPersistableModel<DataFactoryManagedIdentityCredentialData>
    {
        private readonly DataFactoryServiceCredentialData _inner;

        /// <summary> Initializes a new instance of <see cref="DataFactoryManagedIdentityCredentialData"/>. </summary>
        /// <param name="properties"> Managed Identity Credential properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public DataFactoryManagedIdentityCredentialData(DataFactoryManagedIdentityCredentialProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            _inner = new DataFactoryServiceCredentialData(properties);
        }

        internal DataFactoryManagedIdentityCredentialData(DataFactoryServiceCredentialData inner)
            : base(inner?.Id, inner?.Name, inner?.ResourceType ?? default, inner?.SystemData)
        {
            _inner = inner ?? new DataFactoryServiceCredentialData(new DataFactoryManagedIdentityCredentialProperties());
        }

        internal DataFactoryServiceCredentialData ToServiceCredentialData() => _inner;

        /// <summary> Managed Identity Credential properties. </summary>
        public DataFactoryManagedIdentityCredentialProperties Properties
        {
            get => _inner.Properties as DataFactoryManagedIdentityCredentialProperties;
            set => _inner.Properties = value;
        }

        /// <summary> Etag identifies change in the resource. </summary>
        public ETag? ETag => _inner.ETag;

        DataFactoryManagedIdentityCredentialData IJsonModel<DataFactoryManagedIdentityCredentialData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var inner = ((IJsonModel<DataFactoryServiceCredentialData>)_inner).Create(ref reader, options);
            return new DataFactoryManagedIdentityCredentialData(inner);
        }

        void IJsonModel<DataFactoryManagedIdentityCredentialData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DataFactoryServiceCredentialData>)_inner).Write(writer, options);

        DataFactoryManagedIdentityCredentialData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var inner = ((IPersistableModel<DataFactoryServiceCredentialData>)_inner).Create(data, options);
            return new DataFactoryManagedIdentityCredentialData(inner);
        }

        string IPersistableModel<DataFactoryManagedIdentityCredentialData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<DataFactoryServiceCredentialData>)_inner).GetFormatFromOptions(options);

        BinaryData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<DataFactoryServiceCredentialData>)_inner).Write(options);
    }
}
