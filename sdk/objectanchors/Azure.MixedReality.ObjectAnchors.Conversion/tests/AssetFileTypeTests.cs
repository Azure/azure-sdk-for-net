// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    public class AssetFileTypeTests
    {
        [Test]
        public void ConstructorParameters()
        {
            _ = new AssetFileType(".foo");
            Assert.Throws<ArgumentNullException>(() => new AssetFileType(null));
            Assert.Throws<ArgumentException>(() => new AssetFileType(string.Empty));
            Assert.Throws<ArgumentException>(() => new AssetFileType(" "));
            Assert.Throws<ArgumentException>(() => new AssetFileType("foo"));
        }

        [Test]
        public void Equality()
        {
            Assert.True(new AssetFileType(".foo").Equals(new AssetFileType(".FOO")));
            Assert.False(new AssetFileType(".foo").Equals(new AssetFileType(".bar")));
            Assert.False(new AssetFileType(".foo").Equals(".bar"));
        }

        [Test]
        public void GetHashCodeFromDefault()
        {
            // Arrange
            AssetFileType assetFileType = default;

            // Act
            int actualHashCode = assetFileType.GetHashCode();

            // Assert
            Assert.AreEqual(string.Empty.GetHashCode(), actualHashCode);
        }
    }
}
