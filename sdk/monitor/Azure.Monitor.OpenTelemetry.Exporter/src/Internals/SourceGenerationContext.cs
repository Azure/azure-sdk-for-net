// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using System.Text.Json.Serialization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

#if NET6_0_OR_GREATER
// "Source Generation" is a mitigation for AOT IL3050:RequiresDynamicCode and IL2026:RequiresUnreferencedCode
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation
[JsonSerializable(typeof(VmMetadataResponse))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(IngestionResponseHelper.ResponseObject))]
[JsonSerializable(typeof(IngestionResponseHelper.ErrorObject))]
[JsonSerializable(typeof(int))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
#endif
