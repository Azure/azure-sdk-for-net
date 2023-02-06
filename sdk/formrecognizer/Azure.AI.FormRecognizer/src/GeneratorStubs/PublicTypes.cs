// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
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
