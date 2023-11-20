// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace TestHelpers.Internal;

public interface IUtf8JsonContentWriteable
{
    void Write(Utf8JsonWriter writer);
}
