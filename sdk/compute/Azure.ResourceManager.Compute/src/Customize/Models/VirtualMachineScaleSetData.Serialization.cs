// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetData : IModelSerializable
    {
        void IModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ((IUtf8JsonSerializable)this).Write(writer);
        }
    }
}
