// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests
{
    public class InfrastructureTests
    {
        [Test]
        public void ValidNames()
        {
            // Check null is invalid
            Assert.IsFalse(Infrastructure.IsValidBicepIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => Infrastructure.ValidateBicepIdentifier(null));
            Assert.Throws<ArgumentNullException>(() => new StorageAccount(null!));

            // Check invalid names
            List<string> invalid = ["", "my-storage", "my storage", "my:storage", "storage$", "1storage", "KforKelvin"];
            foreach (string name in invalid)
            {
                Assert.IsFalse(Infrastructure.IsValidBicepIdentifier(name));
                Assert.Throws<ArgumentException>(() => Infrastructure.ValidateBicepIdentifier(name));
                if (!string.IsNullOrEmpty(name))
                {
                    Assert.AreNotEqual(name, Infrastructure.NormalizeBicepIdentifier(name));
                }
                Assert.Throws<ArgumentException>(() => new StorageAccount(name));
            }

            // Check valid names
            List<string> valid = ["foo", "FOO", "Foo", "f", "_foo", "_", "foo123", "ABCdef123_"];
            foreach (string name in valid)
            {
                Assert.IsTrue(Infrastructure.IsValidBicepIdentifier(name));
                Assert.DoesNotThrow(() => Infrastructure.ValidateBicepIdentifier(name));
                Assert.AreEqual(name, Infrastructure.NormalizeBicepIdentifier(name));
                Assert.DoesNotThrow(() => new StorageAccount(name));
            }
        }
    }
}
