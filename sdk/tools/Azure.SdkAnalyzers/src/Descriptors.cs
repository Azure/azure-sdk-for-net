// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    internal class Descriptors
    {
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

        public static DiagnosticDescriptor AZC0021 = new(
            nameof(AZC0021),
            "Inline analyzer suppression not allowed for this package",
            "Suppression of '{0}' is not allowed for package '{1}'. Remove the suppression or add an entry to eng/SuppressionAllowList.txt.",
            DiagnosticCategory.Usage,
            DiagnosticSeverity.Error,
            true,
            "Inline analyzer suppressions (#pragma warning disable, [SuppressMessage]) are not allowed unless the package is on the approved allow-list.",
            customTags: new[] { WellKnownDiagnosticTags.NotConfigurable });
    }
}
