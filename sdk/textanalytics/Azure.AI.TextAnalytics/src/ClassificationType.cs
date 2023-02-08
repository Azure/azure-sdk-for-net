// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Specifies either one or multiple categories per document. Defaults to multi classification which may return more than one class for each document.
    /// </summary>
    [CodeGenModel("ClassificationType")]
    public readonly partial struct ClassificationType
    {
    }
}
