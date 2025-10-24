// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    internal class StringExtensionsTests
    {
        [TestCase("ETag", "etag")]
        [TestCase("ID", "id")]
        [TestCase("HTTP", "http")]
        [TestCase("XMLParser", "xmlParser")]
        [TestCase("HTTPClient", "httpClient")]
        [TestCase("Name", "name")]
        [TestCase("PropertyName", "propertyName")]
        [TestCase("A", "a")]
        [TestCase("AB", "ab")]
        [TestCase("ABC", "abc")]
        [TestCase("ABCDef", "abcDef")]
        [TestCase("", "")]
        [TestCase("alreadyLowerCase", "alreadyLowerCase")]
        [TestCase("singleWord", "singleWord")]
        public void FirstCharToLowerCase_ProperlyHandlesAcronyms(string input, string expected)
        {
            // Act
            var result = input.FirstCharToLowerCase();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FirstCharToLowerCase_NullInput_ReturnsNull()
        {
            // Arrange
            string? input = null;

            // Act
            var result = input!.FirstCharToLowerCase();

            // Assert
            Assert.IsNull(result);
        }
    }
}
