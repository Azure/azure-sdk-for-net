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
    public TestRecordingMismatchException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    public TestRecordingMismatchException(string? message, Exception? innerException = null) : base(message, innerException)
    {
    }

#if !NET8_0_OR_GREATER
    /// <inheritdoc />
    protected TestRecordingMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
#endif
}
