// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    // Names of containers used only by hosts (not directly part of the protocol with the dashboard, though other parts
    // may point to blobs stored here).
    internal static class HostContainerNames
    {
        // Note that sometimes this container name is used for the Storage account and sometimes for the Dasboard
        // account. These containers happen to be the same when the accounts are the same.
        public const string Hosts = "azure-webjobs-hosts";
    }
}
