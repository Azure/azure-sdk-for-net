// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    /// <summary>
    /// Because we don't own the code for <see cref="Azure.Core.ConnectionString"/>, these tests are to verify expected behavior.
    /// </summary>
    public class ConnectionStringTests
    {
        [Fact]
        public void TestParse()
        {
            var test = Azure.Core.ConnectionString.Parse("key1=value1;key2=value2;key3=value3");

            Assert.Equal("value1", test.GetRequired("key1"));
            Assert.Equal("value2", test.GetRequired("key2"));
            Assert.Equal("value3", test.GetRequired("key3"));
        }

        [Fact]
        public void TestParse_WithTrailingSemicolon()
        {
            var test = Azure.Core.ConnectionString.Parse("key1=value1;key2=value2;key3=value3;");

            Assert.Equal("value1", test.GetRequired("key1"));
            Assert.Equal("value2", test.GetRequired("key2"));
            Assert.Equal("value3", test.GetRequired("key3"));
        }

        [Fact]
        public void TestParse_WithExtraSpaces()
        {
            var test = Azure.Core.ConnectionString.Parse(" key1 =  value1   ; key2 = value2 ; key3    =value3   ");

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
            var test = Azure.Core.ConnectionString.Parse("UPPERCASE=value1;lowercase=value2;MixedCase=value3");

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
            Assert.Throws<NullReferenceException>(() => Azure.Core.ConnectionString.Parse(null));
        }

        [Fact]
        public void TestParse_WithEmptyString()
        {
            Assert.Throws<InvalidOperationException>(() => Azure.Core.ConnectionString.Parse(string.Empty));
        }

        [Fact]
        public void TestParse_WithDuplaceKeys()
        {
            Assert.Throws<InvalidOperationException>(() => Azure.Core.ConnectionString.Parse("key1=value1;key1=value2"));
        }

        [Fact]
        public void TestParse_WithDuplaceKeysWithSpaces()
        {
            Assert.Throws<InvalidOperationException>(() => Azure.Core.ConnectionString.Parse("key1=value1;key1  =value2"));
        }

        [Fact]
        public void TestParse_WithInvalidDelimiters()
        {
            Assert.Throws<InvalidOperationException>(() => Azure.Core.ConnectionString.Parse("key1;key2=value2"));
        }
    }
}
