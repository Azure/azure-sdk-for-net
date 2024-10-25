// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Terraform.Tests
{
    public class TerraformManagementTestEnvironment : TestEnvironment
    {
        public string VNetName => GetRecordedVariable("VNET_NAME");
        public ResourceIdentifier VNetId => new(GetRecordedVariable("VNET_ID"));
    }
}
