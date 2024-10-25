// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using System;
using System.Collections.Generic;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatMessageContextAllRetrievedDocuments")]
[Experimental("AOAI001")]
public partial class ChatRetrievedDocument
{
    /// <summary> The file path for the citation. </summary>
    [CodeGenMember("Filepath")]
    public string FilePath { get; }

    /// <summary> The location of the citation. </summary>
    [CodeGenMember("Url")]
    public Uri Uri { get; }
}
