// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.StorageMover.Tests
{
    public class StorageMoverManagementTestEnvironment : TestEnvironment
    {
        // The default developer credential chain in TestEnvironment is broker WAM (silent
        // acquire scoped to the Microsoft test tenant) -> VisualStudioCodeCredential. Neither
        // works reliably for headless / detached `dotnet test` runs against a work tenant,
        // because the silent WAM call misses (wrong tenant) and the fallback tries to launch
        // an interactive browser. Prepend AzureCliCredential so a normal `az login` session
        // is used first when present.
        protected override TokenCredential CreateDeveloperCredential()
        {
            return new ChainedTokenCredential(
                new AzureCliCredential(),
                base.CreateDeveloperCredential());
        }
    }
}
