// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity.Tests.Mock
{
    public class MockClientException : Exception
    {
        public MockClientException(string message) : base(message)
        {
        }
    }
}
