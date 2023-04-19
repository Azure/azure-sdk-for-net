// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class HashHelperTests
    {
        [Fact]
        public void Verify_Sha256()
        {
            var input = "testValue";
            var expected = "8476d0ba402fb342ab72f4758a7fad4c1d344bbb374901cdb502b814b17cc1fc";

            Assert.Equal(expected, HashHelper.GetSHA256Hash(input));
        }
    }
}
