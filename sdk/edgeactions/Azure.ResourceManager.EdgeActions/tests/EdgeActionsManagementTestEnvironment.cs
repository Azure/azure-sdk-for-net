// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionsManagementTestEnvironment : TestEnvironment
    {
        protected override TokenCredential CreateDeveloperCredential()
        {
            return GetOptionalVariable("USE_AZURE_CLI") == "true"
                ? new AzureCliCredential()
                : base.CreateDeveloperCredential();
        }
    }
}
