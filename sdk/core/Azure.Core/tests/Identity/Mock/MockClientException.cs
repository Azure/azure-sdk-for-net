// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Identity;
namespace Azure.Core.Tests.Identity.Mock
{
    public class MockClientException : Exception
    {
        public MockClientException(string message) : base(message)
        {
        }
    }
}
