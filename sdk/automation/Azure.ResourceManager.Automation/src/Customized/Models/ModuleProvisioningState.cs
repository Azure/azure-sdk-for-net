// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Automation.Models
{
    // Keep the enum in customized folder to avoid breaking changes, this enum was changed to extensible enum which is the <see cref="AutomationModuleProvisioningState"/> in the generated folder.
    /// <summary> SDK-only compatibility fixed enum for the previous ModuleProvisioningState API. </summary>
    public enum ModuleProvisioningState
    {
        /// <summary> Created. </summary>
        Created,
        /// <summary> Creating. </summary>
        Creating,
        /// <summary> StartingImportModuleRunbook. </summary>
        StartingImportModuleRunbook,
        /// <summary> RunningImportModuleRunbook. </summary>
        RunningImportModuleRunbook,
        /// <summary> ContentRetrieved. </summary>
        ContentRetrieved,
        /// <summary> ContentDownloaded. </summary>
        ContentDownloaded,
        /// <summary> ContentValidated. </summary>
        ContentValidated,
        /// <summary> ConnectionTypeImported. </summary>
        ConnectionTypeImported,
        /// <summary> ContentStored. </summary>
        ContentStored,
        /// <summary> ModuleDataStored. </summary>
        ModuleDataStored,
        /// <summary> ActivitiesStored. </summary>
        ActivitiesStored,
        /// <summary> ModuleImportRunbookComplete. </summary>
        ModuleImportRunbookComplete,
        /// <summary> Succeeded. </summary>
        Succeeded,
        /// <summary> Failed. </summary>
        Failed,
        /// <summary> Cancelled. </summary>
        Cancelled,
        /// <summary> Updating. </summary>
        Updating
    }
}
