// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    public class LazyDictionaryTest
    {
        [Fact]
        public void LazyByDefaultTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.False(initialized);
        }

        [Fact]
        public void LazyAddTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            lazyDictionary.Add("key", "value");
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.True(initialized);
        }

        [Fact]
        public void LazyKeyAddTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            lazyDictionary["key"] = "value";
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.True(initialized);
        }
    }
}
