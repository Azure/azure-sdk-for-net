// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

// This file contains only empty declarations used to overwrite the default behavior
// of the .NET code generator. We use them for two reasons:
// - Overwriting the type's default access modifier.
// - Renaming a type with the 'CodeGenModel' attribute.
//
// If there's any logic or members to be added to the partial declaration, a separate
// file should be created for it.

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    internal partial class AnalyzeDocumentRequest { }

    internal partial class AuthorizeCopyRequest { }

    internal partial class BuildDocumentClassifierRequest { }

    internal partial class BuildDocumentModelRequest { }

    internal partial class ClassifyDocumentRequest { }

    internal partial class ComponentDocumentModelDetails { }

    internal partial class ComposeDocumentModelRequest { }

    internal partial class CustomDocumentModelsDetails { }

    [CodeGenModel("DocumentAnalysisRestClient")]
    internal partial class DocumentAnalysisRestClient { }

    internal partial class Error { }

    internal partial class InnerError { }

    [CodeGenModel("ResourceDetails")]
    internal partial class ServiceResourceDetails { }

    internal partial struct StringIndexType { }

    internal partial struct V3LengthUnit { }

    internal partial struct V3SelectionMarkState { }
}

namespace Azure.AI.FormRecognizer.Models
{
    internal partial struct FieldValueSelectionMark { }
}

#pragma warning restore SA1402 // File may only contain a single type
