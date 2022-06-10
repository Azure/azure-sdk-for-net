// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class AzureFunctionRuleTests
    {
        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [Parallelizable(ParallelScope.All)]
        public void EmptyFunctionUrlThrowsException(string input)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var rule = new AzureFunctionRule(input);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var rule = new AzureFunctionRule(input, new AzureFunctionRuleCredential("functionKey"));
            });
        }

        [Test]
        [TestCase(null)]
        [Parallelizable(ParallelScope.All)]
        public void NullFunctionUrlThrowsException(string input)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var rule = new AzureFunctionRule(input);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var rule = new AzureFunctionRule(input, new AzureFunctionRuleCredential("functionKey"));
            });
        }

        [Test]
        [TestCase("I am invalid function url")]
        [Parallelizable(ParallelScope.All)]
        public void InvalidFunctionUrlThrowsException(string input)
        {
            Assert.Throws<UriFormatException>(() =>
            {
                var rule = new AzureFunctionRule(input);
            });

            Assert.Throws<UriFormatException>(() =>
            {
                var rule = new AzureFunctionRule(input, new AzureFunctionRuleCredential("functionKey"));
            });
        }
    }
}
