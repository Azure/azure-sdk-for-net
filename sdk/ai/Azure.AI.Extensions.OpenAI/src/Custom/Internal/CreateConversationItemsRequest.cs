// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

internal partial class CreateConversationItemsRequest
{
    /// <summary> The items to add to the conversation. You may add up to 20 items at a time. </summary>
    [CodeGenMember("Items")]
    public IList<ResponseItem> Items { get; }
}
