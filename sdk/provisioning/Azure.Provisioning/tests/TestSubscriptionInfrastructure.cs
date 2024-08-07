// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Tests
{
    public class TestSubscriptionInfrastructure : Infrastructure
    {
        public TestSubscriptionInfrastructure()
            : base(ConstructScope.Tenant, Guid.Empty, Guid.Empty, "TEST")
        {
        }
    }
}
