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

        protected TestRecordingMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string AppendReminder(string message)
        {
            const string Reminder = "Have you forgotten to push recordings to the assets repository?";

            return TestEnvironment.GlobalIsRunningInCI
                ? Reminder + Environment.NewLine + Environment.NewLine + message
                : message;
        }
    }
}
