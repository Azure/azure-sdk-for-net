// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureChatMessageContextAllRetrievedDocuments")]
[Experimental("AOAI001")]
public partial class ChatRetrievedDocument
{
    /// <summary> The file path for the citation. </summary>
    [CodeGenMember("Filepath")]
    public string FilePath { get; }
}
