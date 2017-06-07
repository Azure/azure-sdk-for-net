//-----------------------------------------------------------------------
// <copyright file="DeploymentEnumerations.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the enumerations related to the Deployment 
//    and related classes.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// The slot with in a cloud service.
    /// </summary>
    [DataContract]
    public enum DeploymentSlot
    {
        /// <summary>
        /// Represents the Production slot.
        /// </summary>
        [EnumMember]
        Production,

        /// <summary>
        /// Represents the Staging slot.
        /// </summary>
        [EnumMember]
        Staging
    }

    /// <summary>
    /// Definition of the various states of a deployment.
    /// </summary>
    [DataContract(Name = "Status")]
    public enum DeploymentStatus
    {
        /// <summary>
        /// The deployment is unavailable.
        /// </summary>
        [EnumMember]
        Unavailable,

        /// <summary>
        /// The deployment is running.
        /// </summary>
        [EnumMember]
        Running,

        /// <summary>
        /// The deployment is suspended.
        /// </summary>
        [EnumMember]
        Suspended,

        /// <summary>
        /// The deployment is transitioning out of the running status.
        /// </summary>
        [EnumMember]
        RunningTransitioning,

        /// <summary>
        /// The deployment is transitioning out of the suspended status.
        /// </summary>
        [EnumMember]
        SuspendedTransistioning,

        /// <summary>
        /// The deployment is starting.
        /// </summary>
        [EnumMember]
        Starting,

        /// <summary>
        /// The deployment is suspending.
        /// </summary>
        [EnumMember]
        Suspending,

        /// <summary>
        /// The deployment is deploying.
        /// </summary>
        [EnumMember]
        Deploying,

        /// <summary>
        /// The deployment is being deleted.
        /// </summary>
        [EnumMember]
        Deleting,
    }

    /// <summary>
    /// Represents the status of a <see cref="RoleInstance" />.
    /// </summary>
    [DataContract]
    public enum InstanceStatus
    {
        /// <summary>
        /// The role status is unknown.
        /// </summary>
        [EnumMember(Value = "RoleStateUnknown")]
        Unknown,

        /// <summary>
        /// The VM is being created.
        /// </summary>
        [EnumMember]
        CreatingVM,

        /// <summary>
        /// The VM is starting.
        /// </summary>
        [EnumMember]
        StartingVM,

        /// <summary>
        /// The role is being created.
        /// </summary>
        [EnumMember]
        CreatingRole,

        /// <summary>
        /// The role is started.
        /// </summary>
        [EnumMember]
        StartingRole,

        /// <summary>
        /// The role is ready.
        /// </summary>
        [EnumMember]
        ReadyRole,

        /// <summary>
        /// The role is busy.
        /// </summary>
        [EnumMember]
        BusyRole,

        /// <summary>
        /// The role is stopping
        /// </summary>
        [EnumMember]
        StoppingRole,

        /// <summary>
        /// The VM is stopping.
        /// </summary>
        [EnumMember]
        StoppingVM,

        /// <summary>
        /// The VM is being deleted.
        /// </summary>
        [EnumMember]
        DeletingVM,

        /// <summary>
        /// The VM is stopped.
        /// </summary>
        [EnumMember]
        StoppedVM,

        /// <summary>
        /// The role is restarting.
        /// </summary>
        [EnumMember]
        RestartingRole,

        /// <summary>
        /// The role is being cycled.
        /// </summary>
        [EnumMember]
        CyclingRole,

        /// <summary>
        /// Starting the VM failed.
        /// </summary>
        [EnumMember]
        FailedStartingVM,

        /// <summary>
        /// The role is unresponsive.
        /// </summary>
        [EnumMember]
        UnresponsiveRole,

        /// <summary>
        /// The PersistentVMRole is provisioning.
        /// </summary>
        [EnumMember]
        Provisioning,

        /// <summary>
        /// The PersistentVMRole provisioning failed.
        /// </summary>
        [EnumMember]
        ProvisioningFailed,

        /// <summary>
        /// The role failed to start.
        /// </summary>
        [EnumMember]
        FailedStartingRole
    }

    /// <summary>
    /// Represents the VM size of a <see cref="RoleInstance"/>
    /// </summary>
    public enum InstanceSize
    {
        /// <summary>
        /// ExtraSmall VM size.
        /// </summary>
        ExtraSmall,

        /// <summary>
        /// Small VM size
        /// </summary>
        Small,

        /// <summary>
        /// Medium VM size
        /// </summary>
        Medium,

        /// <summary>
        /// Large VM size
        /// </summary>
        Large,

        /// <summary>
        /// ExtraLarge VM size.
        /// </summary>
        ExtraLarge
    }
    /// <summary>
    /// Represents the types of upgrade.
    /// </summary>
    [DataContract]
    public enum UpgradeType
    {
        /// <summary>
        /// Upgrade will happen automatically, with no further intervention.
        /// </summary>
        [EnumMember]
        Auto,

        /// <summary>
        /// Upgrade is manual, requiring calls to 
        /// <see cref="AzureHttpClient.WalkUpgradeDomainAsync" /> to continue.
        /// </summary>
        [EnumMember]
        Manual
    }

    /// <summary>
    /// Represents the current state of an ongoing upgrade.
    /// </summary>
    [DataContract]
    public enum UpgradeDomainState
    {
        /// <summary>
        /// Before the upgrade.
        /// </summary>
        [EnumMember]
        Before,

        /// <summary>
        /// During the upgrade.
        /// </summary>
        [EnumMember]
        During
    }

    /// <summary>
    /// Represents the power state of an Azure VM.
    /// </summary>
    [DataContract]
    public enum PowerState
    {
        /// <summary>
        /// The power state is unknown.
        /// </summary>
        [EnumMember]
        Unknown,

        /// <summary>
        /// The VM is starting.
        /// </summary>
        [EnumMember]
        Starting,

        /// <summary>
        /// The VM is started.
        /// </summary>
        [EnumMember]
        Started,

        /// <summary>
        /// The VM is starting.
        /// </summary>
        [EnumMember]
        Stopping,

        /// <summary>
        /// The VM is stopped.
        /// </summary>
        [EnumMember]
        Stopped
    }

}
