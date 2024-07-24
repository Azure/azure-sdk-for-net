// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Exception thrown when the test recording does not match during playback.
/// </summary>
[Serializable]
public class TestRecordingMismatchException : Exception
{
    /// <summary>
    /// Creates a new instance
    /// </summary>
    public TestRecordingMismatchException()
    {
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public TestRecordingMismatchException(string message) : base(AppendReminder(message))
    {
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    public TestRecordingMismatchException(string? message, Exception? innerException = null) : base(AppendReminder(message), innerException)
    {
    }

    /// <inheritdoc />
    protected TestRecordingMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    private static string? AppendReminder(string? message)
    {
        const string Reminder = "If this is a new recording, make sure you have pushed the recordings to the assets repository. For instructions, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#recording";

        return TestEnvironment.IsRunningInCI
            ? Reminder + Environment.NewLine + Environment.NewLine + message
            : message;
    }
}
