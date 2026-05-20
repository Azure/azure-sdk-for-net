// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Constants used across Discovery SDK tests.
    /// Centralizes test data to avoid hardcoded strings.
    /// </summary>
    internal static class TestConstants
    {
        // ----- Investigations -----
        public const string CreateInvestigationName = "test-create-replace";
        public const string DeleteInvestigationName = "test-delete-inv";
        public const string InvestigationDescription = "Test investigation";
        public const string InvestigationDisplayName = "Test";
        public const string UpdatedDescription = "Updated description";

        // ----- Conversations -----
        public const string UpdatedConversationDisplayName = "Updated conversation";

        // ----- Tasks -----
        public const string TaskTitle = "Test Task Title";
        public const string TaskDescription = "Test task description";
        public const string UpdatedTaskTitle = "Updated task title";
        public const string CommentUser = "test-user";
        public const string CommentText = "Test comment";

        // ----- Knowledge Base Versions -----
        public const string CreateKBVersionName = "testv2";
        public const string KBVersionDescription = "Test KB version";
        public const string KBVersionCopilotInstruction = "Test instruction";
        public const string DeleteKBVersionName = "testdel";
    }
}
