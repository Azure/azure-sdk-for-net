// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetData : IModelSerializable
    {
        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            ((IUtf8JsonSerializable)this).Write(writer);
        }
    }
}
