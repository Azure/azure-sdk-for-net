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

        public static readonly DiagnosticDescriptor AZC0034 = new(
            nameof(AZC0034),
            "Avoid duplicate type names",
            "Type name '{0}' conflicts with '{1}'. {2}",
            DiagnosticCategory.Naming,
            DiagnosticSeverity.Warning,
            true,
            "Type names should not conflict with other SDK and .NET platform types.");

        public static readonly DiagnosticDescriptor AZC0035 = new(
            nameof(AZC0035),
            "Output model type should have a corresponding model factory method",
            "Output model type '{0}' should have a corresponding method in a model factory class. Add a static method that returns '{0}' to a class ending with 'ModelFactory'.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Output model types returned from client methods should have corresponding model factory methods for mocking support.");

        public static readonly DiagnosticDescriptor AZC0040 = new(
            nameof(AZC0040),
            "Do not expose Apache.Arrow types on the public API surface",
            "Public API '{0}' exposes Apache.Arrow type '{1}'. Apache.Arrow types must not be exposed on the public API surface.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Exposing types from the Apache.Arrow library on the public API surface couples consumers to a third-party dependency whose versioning is outside the SDK's control. Keep Apache.Arrow types internal and expose abstractions owned by the SDK instead.",
            "https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tools/Azure.SdkAnalyzers/docs/AZC0040.md");
    }
}
