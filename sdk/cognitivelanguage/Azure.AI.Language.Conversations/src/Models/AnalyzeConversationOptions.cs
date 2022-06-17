// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationOptions
    {
        /// <summary> If true, the query will be kept by the service for customers to further review. </summary>
        public bool? IsLoggingEnabled { get; set; }
    }
}
