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
    internal partial class AuthorizeCopyRequest { }

    internal partial class AzureBlobContentSource { }

    internal partial class AzureBlobFileListSource { }

    internal partial class BuildDocumentClassifierRequest { }

    internal partial class BuildDocumentModelRequest { }

    internal partial class ClassifierDocumentTypeDetails { }

    internal partial class ClassifyDocumentRequest { }

    internal partial class ClassifyResult { }

    internal partial class ClassifyResultOperation { }

    internal partial class ComponentDocumentModelDetails { }

    internal partial class ComposeDocumentModelRequest { }

    internal partial class CustomDocumentModelsDetails { }

    [CodeGenModel("DocumentAnalysisFeature")]
    internal partial struct DocumentAnalysisFeature { }

    [CodeGenModel("DocumentAnalysisRestClient")]
    internal partial class DocumentAnalysisRestClient { }

    internal partial class DocumentAnnotation { }

    internal partial struct DocumentAnnotationKind { }

    internal partial class DocumentBarcode { }

    internal partial struct DocumentBarcodeKind { }

    internal partial class DocumentClassifierBuildOperationDetails { }

    internal partial class DocumentClassifierDetails { }

    internal partial class DocumentFormula { }

    internal partial struct DocumentFormulaKind { }

    internal partial class DocumentImage { }

    internal partial struct DocumentPageKind { }

    internal partial class Error { }

    internal partial struct FontFamily { }

    internal partial struct FontStyle { }

    internal partial struct FontWeight { }

    internal partial class InnerError { }

    internal partial class QuotaDetails { }

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
