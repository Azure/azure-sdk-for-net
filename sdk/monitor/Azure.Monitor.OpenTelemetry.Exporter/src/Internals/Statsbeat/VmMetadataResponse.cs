// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal class VmMetadataResponse
    {
        public string? osType { get; set; }

        public string? subscriptionId { get; set; }

        public string? vmId { get; set; }
    }

//#if NET6_0_OR_GREATER
//    // THIS IS NOT AVAILABLE IN NET STANDARD 2.0
//    // Exploring "Source Generation" as a mitigation for AOT IL3050:RequiresDynamicCodeAttribute
//    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation
//    [JsonSerializable(typeof(VmMetadataResponse))]
//    [JsonSerializable(typeof(string))]
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<Pending>")]
//    internal partial class SourceGenerationContext : JsonSerializerContext
//    {
//    }
//#endif
}
