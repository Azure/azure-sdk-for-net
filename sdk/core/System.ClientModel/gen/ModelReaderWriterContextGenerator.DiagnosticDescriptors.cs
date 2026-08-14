// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal sealed partial class ModelReaderWriterContextGenerator
{
    internal static class DiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor MultipleContextsNotSupported = new(
            id: "SCM0001",
            title: "Multiple contexts are not supported",
            messageFormat: "Multiple contexts are not supported",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0001",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            customTags: [WellKnownDiagnosticTags.CompilationEnd]);

        public static readonly DiagnosticDescriptor ContextMustBePartial = new(
            id: "SCM0002",
            title: "Requires partial modifier",
            messageFormat: "Classes that inherit from ModelReaderWriterContext must have the partial modifier",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0002",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor BuildableAttributeRequiresContext = new(
            id: "SCM0003",
            title: "Only applicable to subclasses of ModelReaderWriterContext",
            messageFormat: "ModelReaderWriterBuildableAttribute can only be applied to classes that inherit from ModelReaderWriterContext",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0003",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor AbstractTypeWithoutProxy = new(
            id: "SCM0004",
            title: "Abstract type without a proxy",
            messageFormat: "Abstract type '{0}' must have a PersistableModelProxy defined",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0004",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor ParameterlessConstructor = new(
            id: "SCM0005",
            title: "Type must have a parameterless constructor",
            messageFormat: "Type '{0}' must have a parameterless constructor",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0005",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor MustImplementIPersistableModel = new(
            id: "SCM0006",
            title: "Type must implement IPersistableModel<T>",
            messageFormat: "Type '{0}' must implement IPersistableModel<T>",
            category: "ModelReaderWriterContextGenerator",
            helpLinkUri: "https://aka.ms/system-clientmodel/diagnostics#scm0006",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
    }
}
