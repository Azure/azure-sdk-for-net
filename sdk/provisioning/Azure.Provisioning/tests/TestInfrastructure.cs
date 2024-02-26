// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Tests
{
    internal class TestInfrastructure : Infrastructure
    {
        public TestInfrastructure(Guid? subscriptionId = null)
            : base(ConstructScope.Subscription, Guid.Empty, subscriptionId, "TEST")
        {
        }
    }
}
