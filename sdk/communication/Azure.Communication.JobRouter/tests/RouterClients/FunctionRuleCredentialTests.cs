// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class FunctionRuleCredentialTests
    {
        [Test]
        [TestCase(null)]
        [Parallelizable(ParallelScope.All)]
        public void NullFunctionKeyThrowsException(string functionKey)
        {
            Assert.Throws<ArgumentNullException>(() => new FunctionRuleCredential(functionKey));
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [Parallelizable(ParallelScope.All)]
        public void EmptyFunctionKeyThrowsException(string functionKey)
        {
            Assert.Throws<ArgumentException>(() => new FunctionRuleCredential(functionKey));
        }

        [Test]
        public void NonEmptyFunctionKeyDoesNotThrowsException()
        {
            Assert.DoesNotThrow(() =>
            {
                var funcCredential = new FunctionRuleCredential("functionKey");
                Assert.AreEqual("functionKey", funcCredential.FunctionKey);
            });
        }

        [Test]
        [TestCase("", "")]
        [TestCase("  ", "  ")]
        [TestCase("", "nonempty")]
        [TestCase("nonempty", "  ")]
        [Parallelizable(ParallelScope.All)]
        public void EmptyAppKeyAndClientIdThrowsException(string appKey, string clientId)
        {
            Assert.Throws<ArgumentException>(() => new FunctionRuleCredential(appKey, clientId));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "nonnull")]
        [TestCase("nonnull", null)]
        [Parallelizable(ParallelScope.All)]
        public void NullAppKeyAndClientIdThrowsException(string appKey, string clientId)
        {
            Assert.Throws<ArgumentNullException>(() => new FunctionRuleCredential(appKey, clientId));
        }
    }
}
