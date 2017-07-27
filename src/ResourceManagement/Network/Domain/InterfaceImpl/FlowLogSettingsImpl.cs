// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    internal partial class FlowLogSettingsImpl 
    {
        /// <summary>
        /// Specifies the storage account to use for storing log.
        /// </summary>
        /// <param name="storageId">Id of the storage account.</param>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithStorageAccount.WithStorageAccount(string storageId)
        {
            return this.WithStorageAccount(storageId) as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        FlowLogSettings.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<FlowLogSettings.Update.IUpdate>.Update()
        {
            return this.Update() as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ApplyAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings>.Apply()
        {
            return this.Apply() as Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.INetworkWatcher;
            }
        }

        /// <summary>
        /// Gets the index key.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable.Key
        {
            get
            {
                return this.Key();
            }
        }

        /// <summary>
        /// Gets the number of days to retain flow log records.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.RetentionDays
        {
            get
            {
                return this.RetentionDays();
            }
        }

        /// <summary>
        /// Gets true if logging is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Gets network security group id these flow log settings apply to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        /// <summary>
        /// Gets true if retention policy enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.IsRetentionEnabled
        {
            get
            {
                return this.IsRetentionEnabled();
            }
        }

        /// <summary>
        /// Gets the ID of the resource to configure for flow logging.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.TargetResourceId
        {
            get
            {
                return this.TargetResourceId();
            }
        }

        /// <summary>
        /// Gets the id of the storage account used to store the flow log.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings.StorageId
        {
            get
            {
                return this.StorageId();
            }
        }

        /// <summary>
        /// Disable flow logging.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithEnabled.WithoutLogging()
        {
            return this.WithoutLogging() as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Enable flow logging.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithEnabled.WithLogging()
        {
            return this.WithLogging() as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Set the number of days to store flow log.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithRetentionPolicy.WithRetentionPolicyDays(int days)
        {
            return this.WithRetentionPolicyDays(days) as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Disable retention policy.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithRetentionPolicy.WithRetentionPolicyDisabled()
        {
            return this.WithRetentionPolicyDisabled() as FlowLogSettings.Update.IUpdate;
        }

        /// <summary>
        /// Enable retention policy.
        /// </summary>
        /// <return>The next stage of the flow log information update.</return>
        FlowLogSettings.Update.IUpdate FlowLogSettings.Update.IWithRetentionPolicy.WithRetentionPolicyEnabled()
        {
            return this.WithRetentionPolicyEnabled() as FlowLogSettings.Update.IUpdate;
        }
    }
}