// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    public partial class ImportJob : IUtf8JsonSerializable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeErrorValue(Utf8JsonWriter writer)
        {
            writer.WriteObjectValue(Error);
        }
    }
}
