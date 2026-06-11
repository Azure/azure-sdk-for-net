// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// The MPG C# generator currently emits the reflection-based
// ModelReaderWriter.Read<T>(BinaryData) overload for a small set of action
// operations that return either OperationStatusResult or an open
// IDictionary<string, BinaryData> body. The AOT/trim-friendly overload that
// accepts a ModelReaderWriterContext is used everywhere else in this assembly.
// Until the generator is updated to emit the context-aware overload for these
// shapes too, suppress IL2026/IL3050 on exactly the four affected methods
// (sync + async pairs). Suppression is scoped per-method so the assembly's
// overall trim/AOT posture is unaffected.

[assembly: UnconditionalSuppressMessage(
    "Trimming",
    "IL2026:Members attributed with RequiresUnreferencedCode may break when trimming",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.Mocking.MockableApiManagementSubscriptionResource.GetOperationStatusAsync(Azure.Core.AzureLocation,System.String,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<OperationStatusResult>. Awaiting generator fix to use the ModelReaderWriterContext overload.")]
[assembly: UnconditionalSuppressMessage(
    "AOT",
    "IL3050:Calling members attributed with RequiresDynamicCode may break native AOT applications",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.Mocking.MockableApiManagementSubscriptionResource.GetOperationStatusAsync(Azure.Core.AzureLocation,System.String,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<OperationStatusResult>. Awaiting generator fix to use the ModelReaderWriterContext overload.")]

[assembly: UnconditionalSuppressMessage(
    "Trimming",
    "IL2026:Members attributed with RequiresUnreferencedCode may break when trimming",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.Mocking.MockableApiManagementSubscriptionResource.GetOperationStatus(Azure.Core.AzureLocation,System.String,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<OperationStatusResult>. Awaiting generator fix to use the ModelReaderWriterContext overload.")]
[assembly: UnconditionalSuppressMessage(
    "AOT",
    "IL3050:Calling members attributed with RequiresDynamicCode may break native AOT applications",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.Mocking.MockableApiManagementSubscriptionResource.GetOperationStatus(Azure.Core.AzureLocation,System.String,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<OperationStatusResult>. Awaiting generator fix to use the ModelReaderWriterContext overload.")]

[assembly: UnconditionalSuppressMessage(
    "Trimming",
    "IL2026:Members attributed with RequiresUnreferencedCode may break when trimming",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.ApiGatewayResource.GetTraceAsync(Azure.ResourceManager.ApiManagement.Models.GatewayListTraceContract,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<IDictionary<string, BinaryData>>. Awaiting generator fix for open-dictionary action response bodies.")]
[assembly: UnconditionalSuppressMessage(
    "AOT",
    "IL3050:Calling members attributed with RequiresDynamicCode may break native AOT applications",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.ApiGatewayResource.GetTraceAsync(Azure.ResourceManager.ApiManagement.Models.GatewayListTraceContract,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<IDictionary<string, BinaryData>>. Awaiting generator fix for open-dictionary action response bodies.")]

[assembly: UnconditionalSuppressMessage(
    "Trimming",
    "IL2026:Members attributed with RequiresUnreferencedCode may break when trimming",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.ApiGatewayResource.GetTrace(Azure.ResourceManager.ApiManagement.Models.GatewayListTraceContract,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<IDictionary<string, BinaryData>>. Awaiting generator fix for open-dictionary action response bodies.")]
[assembly: UnconditionalSuppressMessage(
    "AOT",
    "IL3050:Calling members attributed with RequiresDynamicCode may break native AOT applications",
    Scope = "member",
    Target = "M:Azure.ResourceManager.ApiManagement.ApiGatewayResource.GetTrace(Azure.ResourceManager.ApiManagement.Models.GatewayListTraceContract,System.Threading.CancellationToken)",
    Justification = "Generator-emitted reflection overload of ModelReaderWriter.Read<IDictionary<string, BinaryData>>. Awaiting generator fix for open-dictionary action response bodies.")]
