// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests
{
    internal interface IUtf8JsonSerializable
    {
        void Write(Utf8JsonWriter writer, SerializableOptions options);
    }
}
