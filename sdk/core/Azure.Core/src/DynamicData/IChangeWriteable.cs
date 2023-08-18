// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable AZC0014 // No STJ in public APIs
    public interface IChangeWriteable
    {
        void Write(Utf8JsonWriter writer);
    }
#pragma warning restore AZC0014
#pragma warning restore CS1591
}
