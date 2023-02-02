// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;

using Xunit;

// This alias is necessary because it will otherwise try to default to "Microsoft.Azure.Core" which doesn't exist.
using AzureCoreConnectionString = Azure.Core.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Because we don't own the code for <see cref="Azure.Core.ConnectionString"/>, these tests are to verify expected behavior.
    /// </summary>
    public class ConnectionStringTests
    {
        [Fact]
        public void TestParse()
        {
            var test = AzureCoreConnectionString.Parse("key1=value1;key2=value2;key3=value3");

            Assert.Equal("value1", test.GetRequired("key1"));
            Assert.Equal("value2", test.GetRequired("key2"));
            Assert.Equal("value3", test.GetRequired("key3"));
        }

        [Fact]
        public void TestParse_WithTrailingSemicolon()
        {
            var test = AzureCoreConnectionString.Parse("key1=value1;key2=value2;key3=value3;");

            Assert.Equal("value1", test.GetRequired("key1"));
            Assert.Equal("value2", test.GetRequired("key2"));
            Assert.Equal("value3", test.GetRequired("key3"));
        }

        [Fact]
        public void TestParse_WithExtraSpaces()
        {
            var test = AzureCoreConnectionString.Parse(" key1 =  value1   ; key2 = value2 ; key3    =value3   ");

            Assert.Equal("value1", test.GetRequired("key1"));
            Assert.Equal("value2", test.GetRequired("key2"));
            Assert.Equal("value3", test.GetRequired("key3"));
        }

        /// <summary>
        /// Users can input unexpected casing in their connection strings.
        /// Verify that we can fetch any value from the dictionary regardless of the casing.
        /// </summary>
        [Fact]
        public void TestParse_IsCaseInsensitive()
        {
            var test = AzureCoreConnectionString.Parse("UPPERCASE=value1;lowercase=value2;MixedCase=value3");

            Assert.Equal("value1", test.GetRequired("UPPERCASE"));
            Assert.Equal("value1", test.GetRequired("uppercase"));
            Assert.Equal("value2", test.GetRequired("LOWERCASE"));
            Assert.Equal("value2", test.GetRequired("lowercase"));
            Assert.Equal("value3", test.GetRequired("MIXEDCASE"));
            Assert.Equal("value3", test.GetRequired("mixedcase"));
        }

        [Fact]
        public void TestParse_WithNull()
        {
            Assert.Throws<NullReferenceException>(() => AzureCoreConnectionString.Parse(null));
        }

        [Fact]
        public void TestParse_WithEmptyString()
        {
            Assert.Throws<InvalidOperationException>(() => AzureCoreConnectionString.Parse(string.Empty));
        }

        [Fact]
        public void TestParse_WithDuplaceKeys()
        {
            Assert.Throws<InvalidOperationException>(() => AzureCoreConnectionString.Parse("key1=value1;key1=value2"));
        }

        [Fact]
        public void TestParse_WithDuplaceKeysWithSpaces()
        {
            Assert.Throws<InvalidOperationException>(() => AzureCoreConnectionString.Parse("key1=value1;key1  =value2"));
        }

        [Fact]
        public void TestParse_WithInvalidDelimiters()
        {
            Assert.Throws<InvalidOperationException>(() => AzureCoreConnectionString.Parse("key1;key2=value2"));
        }
    }
}
