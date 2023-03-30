// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class HashHelperTests
    {
        [Theory]
        [InlineData("testValue", "8476d0ba402fb342ab72f4758a7fad4c1d344bbb374901cdb502b814b17cc1fc")]
        [InlineData("ab844fde-29f0-498a-9dda-cd819861364c", "4b24448c9b37421c4771ad471b8ce8d772e100672cc1037f19ee64a665d6f5fc")]
        public void Verify_Sha256(string input, string expected)
        {
            Assert.Equal(expected, HashHelper.GetSHA256Hash(input));
        }
    }
}
