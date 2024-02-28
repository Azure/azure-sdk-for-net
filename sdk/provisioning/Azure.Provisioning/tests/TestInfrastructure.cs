// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Tests
{
    internal class TestInfrastructure : Infrastructure
    {
        public TestInfrastructure(Guid? subscriptionId = null, ConstructScope scope = ConstructScope.Subscription, bool useAnonymousResourceGroup = false)
            : base(scope, Guid.Empty, subscriptionId, "TEST", useAnonymousResourceGroup: useAnonymousResourceGroup)
        {
        }
    }
}
