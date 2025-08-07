// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.OnlineExperimentation.Tests
{
    public class OnlineExperimentationManagementTestEnvironment : TestEnvironment
    {
        public string OnlineExperimentationWorkspaceResourceId => GetRecordedVariable("ONLINEEXPERIMENTATION_RESOURCEID");

        public string CustomerManagedKeyUri => GetRecordedVariable("CUSTOMER_MANAGED_KEY_URI");
    }
}
