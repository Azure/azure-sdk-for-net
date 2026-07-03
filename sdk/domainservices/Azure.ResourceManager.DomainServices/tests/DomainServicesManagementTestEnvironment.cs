// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.DomainServices.Tests
{
    public class DomainServicesManagementTestEnvironment : TestEnvironment
    {
        // Azure AD Domain Services requires an existing virtual-network subnet to deploy into.
        // Live runs must provide the ARM resource id of a prepared subnet via this variable.
        public string SubnetId => GetRecordedOptionalVariable("DOMAINSERVICES_SUBNET_ID");
    }
}
