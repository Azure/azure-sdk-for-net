// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture]
    public class AzureNamedKeyCredentialTests
    {
        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        public void ConstructorValidatesTheName(string name, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => new AzureNamedKeyCredential(name, "key"));
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        public void ConstructorValidatesTheKey(string key, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => new AzureNamedKeyCredential("name", key));
        }

        [Test]
        public void AttributesCanBeReadWithDeconstruction()
        {
            var expectedName = "real-name";
            var expectedKey = "real-key";
            var credential = new AzureNamedKeyCredential(expectedName, expectedKey);
            var (name, key) = credential;

            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(key, Is.EqualTo(expectedKey));
        }

        [Test]
        public void NameCanBeReadFromTheProperty()
        {
            var expectedName = "real-name";
            var expectedKey = "real-key";
            var credential = new AzureNamedKeyCredential(expectedName, expectedKey);

            Assert.That(credential.Name, Is.EqualTo(expectedName));
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        public void UpdateValidatesTheName(string name, Type expectedExceptionType)
        {
            var credential = new AzureNamedKeyCredential("initial-name", "initial-key");
            Assert.Throws(expectedExceptionType, () => credential.Update(name, "key"));
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        public void UpdateValidatesTheKey(string key, Type expectedExceptionType)
        {
            var credential = new AzureNamedKeyCredential("initial-name", "initial-key");
            Assert.Throws(expectedExceptionType, () => credential.Update("name", key));
        }

        [Test]
        public void UpdateCanBePerformed()
        {
            var expectedName = "expect_name";
            var expectedKey = "expect_key";

            #region Snippet:AzureNamedKeyCredential_Deconstruct
            var credential = new AzureNamedKeyCredential("SomeName", "SomeKey");

#if !SNIPPET
            credential.Update(expectedName, expectedKey);
#endif
            (string name, string key) = credential;
            #endregion

            Assert.That(credential.Name, Is.EqualTo(expectedName));
            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(key, Is.EqualTo(expectedKey));
        }

        [Test]
        public void MultipleUpdatesCanBePerformed()
        {
            var expectedName = "expect_name";
            var expectedKey = "expect_key";

            var credential = new AzureNamedKeyCredential("<< Name >>", "<< Key >>");
            credential.Update("interimname", "interimkey");
            credential.Update(expectedName, expectedKey);

            var (name, key) = credential;

            Assert.That(credential.Name, Is.EqualTo(expectedName));
            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(key, Is.EqualTo(expectedKey));
        }
    }
}
