﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ServicePrincipalTests : AutomanageTestBase
    {
        public ServicePrincipalTests(bool async) : base(async) { }

        [TestCase]
        public void CanGetServicePrincipal()
        {
            var resourceId = ServicePrincipalResource.CreateResourceIdentifier(Subscription.Id.Name);
            var servicePrincipal = ArmClient.GetServicePrincipalResource(resourceId);
            Assert.IsNotNull(servicePrincipal);
        }
    }
}
