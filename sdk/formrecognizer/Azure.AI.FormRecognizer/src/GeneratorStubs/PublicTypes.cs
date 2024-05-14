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
    [CodeGenModel("DocumentAnalysisFeature")]
    public partial struct DocumentAnalysisFeature { }

    [CodeGenModel("FontStyle")]
    public partial struct DocumentFontStyle { }

    [CodeGenModel("FontWeight")]
    public partial struct DocumentFontWeight { }

    [CodeGenModel("OperationKind")]
    public partial struct DocumentOperationKind { }
}

namespace Azure.AI.FormRecognizer
{
    [CodeGenModel("Language")]
    public partial struct FormRecognizerLanguage { }

    [CodeGenModel("Locale")]
    public partial struct FormRecognizerLocale { }
}

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("TextStyle")]
    public partial struct TextStyleName { }
}

#pragma warning restore SA1402 // File may only contain a single type
