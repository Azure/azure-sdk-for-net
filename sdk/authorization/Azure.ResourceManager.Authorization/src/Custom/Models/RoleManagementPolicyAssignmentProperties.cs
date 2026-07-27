// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Authorization.Models
{
    // The contextual TypeSpec name now generates this model directly. Keep the ResourceData base
    // shipped by the GA model, and expose internal serialization bridges for its old-name wrapper.
    public partial class RoleManagementPolicyAssignmentProperties : ResourceData
    {
        internal ResourceData CreateCompatibilityModel(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        internal void WriteCompatibilityModel(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        internal ResourceData CreateCompatibilityModel(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        internal BinaryData WriteCompatibilityModel(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
