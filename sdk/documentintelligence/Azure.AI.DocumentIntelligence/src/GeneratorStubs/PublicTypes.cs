// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

// CUSTOM CODE NOTE: renaming models to suppress analyze errors. These should
// be moved to the spec.

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenModel("AnalyzeDocumentRequest")]
    public partial class AnalyzeDocumentContent { }

    [CodeGenModel("AuthorizeCopyRequest")]
    public partial class AuthorizeCopyContent { }

    [CodeGenModel("BuildDocumentClassifierRequest")]
    public partial class BuildDocumentClassifierContent { }

    [CodeGenModel("BuildDocumentModelRequest")]
    public partial class BuildDocumentModelContent { }

    [CodeGenModel("ClassifyDocumentRequest")]
    public partial class ClassifyDocumentContent { }

    [CodeGenModel("ComposeDocumentModelRequest")]
    public partial class ComposeDocumentModelContent { }
}

#pragma warning restore SA1402 // File may only contain a single type
