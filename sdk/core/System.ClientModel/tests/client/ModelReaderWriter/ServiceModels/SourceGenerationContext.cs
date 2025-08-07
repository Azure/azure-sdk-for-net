// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Text.Json.Serialization;

namespace System.ClientModel.Tests.Client.Models
{
#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ResourceProviderData))]
    [JsonSerializable(typeof(AvailabilitySetData))]
    public partial class SourceGenerationContext : JsonSerializerContext
    {
    }
#endif
}
