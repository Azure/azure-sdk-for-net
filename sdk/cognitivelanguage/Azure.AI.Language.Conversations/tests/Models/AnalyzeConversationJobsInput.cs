// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationJobsInput
    {
        public RequestContent AsRequestContent()
        {
            Utf8JsonRequestContent content = new();
            content.JsonWriter.WriteObjectValue(this);

            return content;
        }
    }
}
