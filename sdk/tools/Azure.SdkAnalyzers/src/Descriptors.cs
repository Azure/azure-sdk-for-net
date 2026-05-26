// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    internal class Descriptors
    {
        public static readonly DiagnosticDescriptor AZC0101 = new(
            nameof(AZC0101),
            "Use ConfigureAwait(false) instead of ConfigureAwait(true).",
            "Use ConfigureAwait(false) instead of ConfigureAwait(true).",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Calls to ConfigureAwait should use false rather than true to avoid unnecessarily capturing the synchronization context.",
            "https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tools/Azure.SdkAnalyzers/docs/AZC0101.md");

        public static readonly DiagnosticDescriptor AZC0012 = new(
            nameof(AZC0012),
            "Avoid single word type names",
            "Type name '{0}' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: {1}",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Single word type names are too generic and have high chance of collision with BCL types or types from other libraries.");

        public static readonly DiagnosticDescriptor AZC0020 = new(
            nameof(AZC0020),
            "Propagate CancellationToken to RequestContext",
            "Method '{0}' accepts a CancellationToken but does not propagate it to the RequestContext. Set RequestContext.CancellationToken to ensure proper cancellation support.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Methods that accept a CancellationToken should propagate it to RequestContext parameters in Azure SDK method calls to ensure proper cancellation support.");
    }
}
