// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class FunctionRuleCredentialTests
    {
        [Test]
        [TestCase(null)]
        [Parallelizable(ParallelScope.All)]
        public void NullFunctionKeyThrowsException(string functionKey)
        {
            ClassicAssert.Throws<ArgumentNullException>(() => new FunctionRouterRuleCredential(functionKey));
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [Parallelizable(ParallelScope.All)]
        public void EmptyFunctionKeyThrowsException(string functionKey)
        {
            ClassicAssert.Throws<ArgumentException>(() => new FunctionRouterRuleCredential(functionKey));
        }

        [Test]
        public void NonEmptyFunctionKeyDoesNotThrowsException()
        {
            ClassicAssert.DoesNotThrow(() =>
            {
                var funcCredential = new FunctionRouterRuleCredential("functionKey");
                ClassicAssert.AreEqual("functionKey", funcCredential.FunctionKey);
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
            ClassicAssert.Throws<ArgumentException>(() => new FunctionRouterRuleCredential(appKey, clientId));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "nonnull")]
        [TestCase("nonnull", null)]
        [Parallelizable(ParallelScope.All)]
        public void NullAppKeyAndClientIdThrowsException(string appKey, string clientId)
        {
            ClassicAssert.Throws<ArgumentNullException>(() => new FunctionRouterRuleCredential(appKey, clientId));
        }
    }
}
