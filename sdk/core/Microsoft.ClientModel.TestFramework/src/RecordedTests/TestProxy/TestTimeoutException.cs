// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class TestTimeoutException : Exception
{
    /// <summary>
    /// TODO.
    /// </summary>
    public TestTimeoutException()
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    public TestTimeoutException(string message) : base(message)
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public TestTimeoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
