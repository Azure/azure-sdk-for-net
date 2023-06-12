// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal interface IModelSerializable : IModel
    {
        void Serialize(Utf8JsonWriter writer, SerializableOptions? options = default);
    }
}
