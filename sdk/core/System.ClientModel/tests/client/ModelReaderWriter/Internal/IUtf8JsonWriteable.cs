// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json;

namespace System.ClientModel.Internal
{
    internal interface IUtf8JsonWriteable
    {
        void Write(Utf8JsonWriter writer);
    }
}
