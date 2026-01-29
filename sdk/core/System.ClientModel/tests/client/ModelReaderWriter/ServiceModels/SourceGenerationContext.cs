// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace System.ClientModel.Tests.Client.Models
{
#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ResourceProviderData))]
    [JsonSerializable(typeof(AvailabilitySetData))]
    [Experimental("SCM0001")]
    public partial class SourceGenerationContext : JsonSerializerContext
    {
    }
#endif
}
