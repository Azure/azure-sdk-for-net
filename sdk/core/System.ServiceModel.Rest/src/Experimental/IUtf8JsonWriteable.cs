﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ServiceModel.Rest.Internal;

public interface IUtf8JsonWriteable
{
    void Write(Utf8JsonWriter writer);
}
