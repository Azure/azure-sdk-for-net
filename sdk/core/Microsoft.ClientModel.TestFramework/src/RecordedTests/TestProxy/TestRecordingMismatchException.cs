// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.TestProxy;

/// <summary>
/// TODO.
/// </summary>
public class TestRecordingMismatchException : Exception
{
    /// <summary>
    /// TODO.
    /// </summary>
    public TestRecordingMismatchException()
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    public TestRecordingMismatchException(string message) : base(AppendReminder(message))
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public TestRecordingMismatchException(string message, Exception innerException) : base(AppendReminder(message), innerException)
    {
    }

    private static string AppendReminder(string message)
    {
        //const string Reminder = "If this is a new recording, make sure you have pushed the recordings to the assets repository. For instructions, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#recording";

        //return TestEnvironment.GlobalIsRunningInCI
        //    ? Reminder + Environment.NewLine + Environment.NewLine + message
        //    : message;
        return message;
    }
}
