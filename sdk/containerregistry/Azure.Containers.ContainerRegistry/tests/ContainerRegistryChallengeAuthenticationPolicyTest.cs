// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryChallengeAuthenticationPolicyTest : SyncAsyncPolicyTestBase
    {
        public ContainerRegistryChallengeAuthenticationPolicyTest(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task ChallengePolicySetsToken()
        {
            // TODO: understand how to handle REST calls that happen as part of the policy.
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope");
        }
    }
}
