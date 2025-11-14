// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// The exception that is thrown when a test operation exceeds its allowed time limit.
/// </summary>
public class TestTimeoutException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestTimeoutException"/> class
    /// with a default error message.
    /// </summary>
    public TestTimeoutException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestTimeoutException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The message that describes the timeout error, typically including information
    /// about what operation timed out and the duration that was exceeded.
    /// </param>
    public TestTimeoutException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestTimeoutException"/> class
    /// with a specified error message and a reference to the inner exception that is the
    /// cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The message that describes the timeout error, typically including information
    /// about what operation timed out and the duration that was exceeded.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or <see langword="null"/>
    /// if no inner exception is specified. This might be a network timeout exception
    /// or other underlying cause of the timeout.
    /// </param>
    public TestTimeoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
