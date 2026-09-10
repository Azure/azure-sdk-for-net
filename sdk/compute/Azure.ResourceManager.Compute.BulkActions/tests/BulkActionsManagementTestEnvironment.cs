// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.Compute.BulkActions.Tests
{
    public class BulkActionsManagementTestEnvironment : TestEnvironment
    {
        // eastus2euap is the only region serving the BulkActions API at the time of recording.
        public string TestLocation => GetRecordedOptionalVariable("LOCATION") ?? "eastus2euap";

        // Resource group that hosts the pre-created VMs used by the bulk-action tests.
        public string TestResourceGroup => GetRecordedOptionalVariable("RESOURCE_GROUP") ?? "krnx-sparvatikar-sdkrecording";

        // Prefer Azure CLI for local-dev auth so recordings can run headless without the Windows broker.
        protected override TokenCredential CreateDeveloperCredential()
            => new ChainedTokenCredential(new AzureCliCredential(), new AzurePowerShellCredential());
    }
}
