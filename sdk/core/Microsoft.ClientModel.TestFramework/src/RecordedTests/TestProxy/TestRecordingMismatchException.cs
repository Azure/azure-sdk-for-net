// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// The exception that is thrown when there is a mismatch between the expected test recording
/// and the actual network requests made during test playback.
/// </summary>
/// <remarks>
/// <para>
/// This exception occurs during test playback when the test framework cannot find a matching
/// recorded HTTP request/response pair for an actual network request made by the test.
/// This typically happens when:
/// </para>
/// <list type="bullet">
/// <item>The test code has changed and makes different network requests than what was recorded</item>
/// <item>The test recording is outdated or missing</item>
/// <item>The request matching logic cannot find a suitable recorded response</item>
/// <item>There are differences in request headers, parameters, or body content</item>
/// </list>
/// <para>
/// To resolve this exception, you typically need to re-record the test by running it in
/// Record mode to capture the updated network interactions.
/// </para>
/// </remarks>
public class TestRecordingMismatchException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestRecordingMismatchException"/> class
    /// with a default error message.
    /// </summary>
    public TestRecordingMismatchException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRecordingMismatchException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The message that describes the recording mismatch error.
    /// </param>
    public TestRecordingMismatchException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRecordingMismatchException"/> class
    /// with a specified error message and a reference to the inner exception that is the
    /// cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The message that describes the recording mismatch error.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or <see langword="null"/>
    /// if no inner exception is specified.
    /// </param>
    public TestRecordingMismatchException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
