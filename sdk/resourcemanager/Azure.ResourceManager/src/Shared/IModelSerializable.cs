// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.ResourceManager
{
    internal interface IModelSerializable : IModel
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
        void Serialize(Utf8JsonWriter writer, SerializableOptions? options = default);
    }
}
