// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    internal class Descriptors
    {
        #region Async pattern rules (Error + NotConfigurable)

        public static DiagnosticDescriptor AZC0101 = new(
            nameof(AZC0101),
            "Use ConfigureAwait(false) instead of ConfigureAwait(true).",
            "Use ConfigureAwait(false) instead of ConfigureAwait(true).",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Error,
            true,
            customTags: new[] { WellKnownDiagnosticTags.NotConfigurable });

        public static DiagnosticDescriptor AZC0108 = new(
            nameof(AZC0108),
            "Incorrect 'async' parameter value.",
            "In {0} scope 'async' parameter for the '{1}' method call should {2}.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Error,
            true,
            customTags: new[] { WellKnownDiagnosticTags.NotConfigurable });

        public static DiagnosticDescriptor AZC0109 = new(
            nameof(AZC0109),
            "Misuse of 'async' parameter.",
            "'async' parameter in asynchronous method can't be changed and can only be used as an exclusive condition in '?:' operator or conditional statement.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Error,
            true,
            customTags: new[] { WellKnownDiagnosticTags.NotConfigurable });

        public static DiagnosticDescriptor AZC0111 = new(
            nameof(AZC0111),
            "DO NOT use EnsureCompleted in possibly asynchronous scope.",
            "Asynchronous method with `async` parameter can be called from both synchronous and asynchronous scopes. 'EnsureCompleted' extension method can be safely used on in guaranteed synchronous scope (i.e. `if (!async) {{...}}`).",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Error,
            true,
            customTags: new[] { WellKnownDiagnosticTags.NotConfigurable });

        #endregion

        public static DiagnosticDescriptor AZC0012 = new(
            nameof(AZC0012),
            "Avoid single word type names",
            "Type name '{0}' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: {1}",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Single word type names are too generic and have high chance of collision with BCL types or types from other libraries.");

        public static DiagnosticDescriptor AZC0020 = new(
            nameof(AZC0020),
            "Propagate CancellationToken to RequestContext",
            "Method '{0}' accepts a CancellationToken but does not propagate it to the RequestContext. Set RequestContext.CancellationToken to ensure proper cancellation support.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Warning,
            true,
            "Methods that accept a CancellationToken should propagate it to RequestContext parameters in Azure SDK method calls to ensure proper cancellation support.");
    }
}
