// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationTasksState
    {
        internal static ConversationTasksState DeserializeConversationTasksState(JsonElement element)
        {
            ConversationTasksStateTasks tasks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tasks"))
                {
                    tasks = ConversationTasksStateTasks.DeserializeConversationTasksStateTasks(property.Value);
                    continue;
                }
            }
            return new ConversationTasksState(tasks);
        }
    }
}
