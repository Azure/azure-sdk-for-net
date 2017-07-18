// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the flow log information update allowing to configure retention policy.
    /// </summary>
    public interface IWithRetentionPolicy 
    {
        /// <summary>
        /// Disable retention policy.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithRetentionPolicyDisabled();

        /// <summary>
        /// Set the number of days to store flow log.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithRetentionPolicyDays(int days);

        /// <summary>
        /// Enable retention policy.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithRetentionPolicyEnabled();
    }

    /// <summary>
    /// The template for a flow log information update operation, containing all the settings that
    /// can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings>,
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IWithEnabled,
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IWithStorageAccount,
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IWithRetentionPolicy
    {
    }

    /// <summary>
    /// The stage of the flow log information update allowing to specify storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies the storage account to use for storing log.
        /// </summary>
        /// <param name="storageId">Id of the storage account.</param>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithStorageAccount(string storageId);
    }

    /// <summary>
    /// The stage of the flow log information update allowing to set enable/disable property.
    /// </summary>
    public interface IWithEnabled 
    {
        /// <summary>
        /// Enable flow logging.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithLogging();

        /// <summary>
        /// Disable flow logging.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update.IUpdate WithoutLogging();
    }
}