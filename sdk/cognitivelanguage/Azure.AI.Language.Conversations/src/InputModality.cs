// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The modality (format) of ConversationItem (e.g., Text, Transcript). </summary>
    [CodeGenModel("Modality")]
    public readonly partial struct InputModality : IEquatable<InputModality>
    {
    }
}
