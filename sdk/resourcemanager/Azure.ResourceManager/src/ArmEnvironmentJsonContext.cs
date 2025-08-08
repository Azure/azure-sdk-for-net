// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.ResourceManager
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(ArmEnvironment))]
    internal partial class ArmEnvironmentJsonContext : JsonSerializerContext
    {
    }
}
