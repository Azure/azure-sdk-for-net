// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using System.Text.Json.Serialization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

#if NET6_0_OR_GREATER
// "Source Generation" is feature added to System.Text.Json in .NET 6.0.
// This is a performance optimization that avoids runtime reflection when performing serialization.
// Serialization metadata will be computed at compile-time and included in the assembly.
// https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation-modes
// https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation
// https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
[JsonSerializable(typeof(VmMetadataResponse))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(IngestionResponseHelper.ResponseObject))]
[JsonSerializable(typeof(IngestionResponseHelper.ErrorObject))]
[JsonSerializable(typeof(int))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
#endif
