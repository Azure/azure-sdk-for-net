// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using System;
using System.Collections.Generic;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatMessageContextAllRetrievedDocumentsFilterReason")]
[Experimental("AOAI001")]
public readonly partial struct ChatDocumentFilterReason
{
}
