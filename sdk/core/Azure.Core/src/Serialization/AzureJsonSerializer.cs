// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

#pragma warning disable CS1591, SA1649, SA1402

namespace Azure.Core.Serialization
{
    // For libraries that operate on opaque binary data (event hubs)
    public abstract class AzureObjectSerializerFactory
    {
        public abstract AzureObjectSerializer Create(Type type);
        // Async to allow to support scenarios where schema is retrieved from somewhere
        public abstract ValueTask<AzureObjectSerializer> CreateAsync(Type type);
    }

    // For libraries that need to have json specific features (tables, search)
    public abstract class AzureJsonSerializerFactory: AzureObjectSerializerFactory
    {
        public abstract AzureJsonSerializer CreateJsonSerializer(Type type);
        public abstract ValueTask<AzureObjectSerializer> CreateJsonSerializerAsync(Type type);
    }

    // Represents a serializer/deserializer from any byte stream to an object
    public abstract class AzureObjectSerializer
    {
        public abstract void Serialize(object o, Stream stream);
        public abstract ValueTask SerializeAsync(object o, Stream stream);

        public abstract object Deserialize(Stream stream);
        public abstract ValueTask<object> DeserializeAsync(Stream stream);
    }

    // Represents a JSON specific serializer
    // Allows adding more JSON specific/optimized methods
    public abstract class AzureJsonSerializer: AzureObjectSerializer
    {
    }
}