// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;

namespace Azure.Core.TestFramework
{
    [Serializable]
    public class TestTimeoutException : Exception
    {
        public TestTimeoutException()
        {
        }

        public TestTimeoutException(string message) : base(message)
        {
        }

        public TestTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
