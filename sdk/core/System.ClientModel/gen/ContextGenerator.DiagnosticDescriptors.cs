// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
    public sealed partial class ContextGenerator
    {
        internal static class DiagnosticDescriptors
        {
            public static readonly DiagnosticDescriptor MultipleContextsNotSupported = new(
                id: "SCM0001",
                title: "Multiple contexts are not supported",
                messageFormat: "Multiple contexts are not supported",
                category: "ContextGenerator",
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public static readonly DiagnosticDescriptor ContextMustBePartial = new(
                id: "SCM0002",
                title: "Classes that inherit from ModelReaderWriterContext must have the partial modifier",
                messageFormat: "Classes that inherit from ModelReaderWriterContext must have the partial modifier",
                category: "ContextGenerator",
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);
        }
    }
}
