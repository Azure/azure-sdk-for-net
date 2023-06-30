// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    // TODO: This is just a stand-in.  If we're blocked on the serialization work
    // we can also migrate IUtf8JsonSerializable to Azure.Core, and it will work.
    internal interface IModelSerializable
    {
        void Serialize(Utf8JsonWriter writer);

        object Deserialize(JsonElement element);
    }
}
