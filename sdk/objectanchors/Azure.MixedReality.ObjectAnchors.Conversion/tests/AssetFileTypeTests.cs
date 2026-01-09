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
            Assert.That(new AssetFileType(".foo"), Is.EqualTo(new AssetFileType(".FOO")));
            Assert.Multiple(() =>
            {
                Assert.That(new AssetFileType(".foo").Equals(new AssetFileType(".bar")), Is.False);
                Assert.That(new AssetFileType(".foo").Equals(".bar"), Is.False);
            });
        }

        [Test]
        public void GetHashCodeFromDefault()
        {
            // Arrange
            AssetFileType assetFileType = default;

            // Act
            int actualHashCode = assetFileType.GetHashCode();

            // Assert
            Assert.That(actualHashCode, Is.EqualTo(string.Empty.GetHashCode()));
        }
    }
}
