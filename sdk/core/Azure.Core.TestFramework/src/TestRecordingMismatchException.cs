// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;

namespace Azure.Core.TestFramework
{
    [Serializable]
    public class TestRecordingMismatchException : Exception
    {
        public TestRecordingMismatchException()
        {
        }

        public TestRecordingMismatchException(string message) : base(AppendReminder(message))
        {
        }

        public TestRecordingMismatchException(string message, Exception innerException) : base(AppendReminder(message), innerException)
        {
        }

        private static string AppendReminder(string message)
        {
            const string Reminder = "If this is a new recording, make sure you have pushed the recordings to the assets repository. For instructions, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#recording";

            return TestEnvironment.GlobalIsRunningInCI
                ? Reminder + Environment.NewLine + Environment.NewLine + message
                : message;
        }
    }
}
