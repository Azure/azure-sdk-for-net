// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER
using System;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests.IdentityBinding
{
    public class WorkloadIdentityBindingScenarioRunnerTests
    {
        [TestCase("AADSTS700212", true)]
        [TestCase("AADSTS700211", true)]
        [TestCase("AADSTS700016", false)]
        [TestCase("AADSTS7002120", false)]
        public void ClassifiesNestedFederationFailure(string code, bool expected)
        {
            var exception = new AuthenticationFailedException(
                "Workload identity authentication failed.",
                new InvalidOperationException($"{code}: Federation error."));

            Assert.That(WorkloadIdentityBindingScenarioRunner.IsExpectedFederationFailure(exception, out string errorCode), Is.EqualTo(expected));
            Assert.That(errorCode, Is.EqualTo(code));
        }
    }
}
#endif
