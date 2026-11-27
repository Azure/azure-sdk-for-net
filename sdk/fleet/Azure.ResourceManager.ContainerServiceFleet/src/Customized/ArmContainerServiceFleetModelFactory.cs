// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    [CodeGenSuppress("ContainerServiceFleetUpdateGroup", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<ContainerServiceFleetGateConfiguration>), typeof(IEnumerable<ContainerServiceFleetGateConfiguration>))]
    [CodeGenSuppress("ContainerServiceFleetUpdateStage", typeof(string), typeof(IEnumerable<ContainerServiceFleetUpdateGroup>), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(IEnumerable<ContainerServiceFleetGateConfiguration>), typeof(IEnumerable<ContainerServiceFleetGateConfiguration>))]
    [CodeGenSuppress("ContainerServiceFleetUpdateGroupStatus", typeof(ContainerServiceFleetUpdateStatus), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<MemberUpdateStatus>), typeof(IEnumerable<ContainerServiceFleetUpdateRunGateStatus>), typeof(IEnumerable<ContainerServiceFleetUpdateRunGateStatus>))]
    [CodeGenSuppress("ContainerServiceFleetUpdateStageStatus", typeof(ContainerServiceFleetUpdateStatus), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<ContainerServiceFleetUpdateGroupStatus>), typeof(IEnumerable<ContainerServiceFleetUpdateRunGateStatus>), typeof(IEnumerable<ContainerServiceFleetUpdateRunGateStatus>), typeof(ContainerServiceFleetWaitStatus))]
    public static partial class ArmContainerServiceFleetModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="eTag"> If eTag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. </param>
        /// <param name="provisioningState"> The provisioning state of the AutoUpgradeProfile resource. </param>
        /// <param name="updateStrategyId"> The resource id of the UpdateStrategy resource to reference. If not specified, the auto upgrade will run on all clusters which are members of the fleet. </param>
        /// <param name="channel"> Configures how auto-upgrade will be run. </param>
        /// <param name="selectionType"> The node image upgrade to be applied to the target clusters in auto upgrade. </param>
        /// <param name="disabled">
        /// If set to False: the auto upgrade has effect - target managed clusters will be upgraded on schedule.
        /// If set to True: the auto upgrade has no effect - no upgrade will be run on the target managed clusters.
        /// This is a boolean and not an enum because enabled/disabled are all available states of the auto upgrade profile.
        /// By default, this is set to False.
        /// </param>
        /// <param name="autoUpgradeProfileStatus"> The status of the auto upgrade profile. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutoUpgradeProfileData AutoUpgradeProfileData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? eTag = default, AutoUpgradeProfileProvisioningState? provisioningState = default, ResourceIdentifier updateStrategyId = null, ContainerServiceFleetUpgradeChannel? channel = default, AutoUpgradeNodeImageSelectionType? selectionType = default, bool? disabled = default, AutoUpgradeProfileStatus autoUpgradeProfileStatus = null)
        {
            return new AutoUpgradeProfileData(id, name, resourceType, systemData, new AutoUpgradeProfileProperties(provisioningState, updateStrategyId, channel, nodeImageSelection: default, disabled, autoUpgradeProfileStatus, targetKubernetesVersion: default, isLongTermSupport: default, additionalBinaryDataProperties: default), eTag, additionalBinaryDataProperties: null);
        }

        // Keep new optional parameters after the released 1.3.0 parameters so positional calls retain their meaning.

        /// <summary> A group to be updated. </summary>
        /// <param name="name"> Name of the group. </param>
        /// <param name="maxConcurrency"> The max number of upgrades that can run concurrently in this specific group. </param>
        /// <param name="memberSelectorByLabel"> Kubernetes-style label selector for selecting Fleet members. </param>
        /// <param name="beforeGates"> A list of Gates that will be created before this Group is executed. </param>
        /// <param name="afterGates"> A list of Gates that will be created after this Group is executed. </param>
        /// <param name="maxAllowedFailures"> The maximum number or percentage of failures allowed in the group. </param>
        /// <returns> A new <see cref="Models.ContainerServiceFleetUpdateGroup"/> instance for mocking. </returns>
        public static ContainerServiceFleetUpdateGroup ContainerServiceFleetUpdateGroup(string name = default, string maxConcurrency = default, string memberSelectorByLabel = default, IEnumerable<ContainerServiceFleetGateConfiguration> beforeGates = default, IEnumerable<ContainerServiceFleetGateConfiguration> afterGates = default, string maxAllowedFailures = default)
        {
            return new ContainerServiceFleetUpdateGroup(
                name,
                maxAllowedFailures,
                maxConcurrency,
                memberSelectorByLabel is null ? default : new MemberSelector(memberSelectorByLabel, default),
                (beforeGates ?? new ChangeTrackingList<ContainerServiceFleetGateConfiguration>()).ToList(),
                (afterGates ?? new ChangeTrackingList<ContainerServiceFleetGateConfiguration>()).ToList(),
                default);
        }

        /// <summary> A stage within an update run. </summary>
        /// <param name="name"> The name of the stage. </param>
        /// <param name="groups"> A list of group names that compose the stage. </param>
        /// <param name="memberSelectorByLabel"> Kubernetes-style label selector for selecting Fleet members. </param>
        /// <param name="afterStageWaitInSeconds"> The time in seconds to wait at the end of this stage before starting the next one. </param>
        /// <param name="maxConcurrency"> The max number of upgrades that can run concurrently across all groups in this stage. </param>
        /// <param name="beforeGates"> A list of Gates that will be created before this Stage is executed. </param>
        /// <param name="afterGates"> A list of Gates that will be created after this Stage is executed. </param>
        /// <param name="maxAllowedFailures"> The maximum number or percentage of failures allowed in the stage. </param>
        /// <returns> A new <see cref="Models.ContainerServiceFleetUpdateStage"/> instance for mocking. </returns>
        public static ContainerServiceFleetUpdateStage ContainerServiceFleetUpdateStage(string name = default, IEnumerable<ContainerServiceFleetUpdateGroup> groups = default, string memberSelectorByLabel = default, int? afterStageWaitInSeconds = default, string maxConcurrency = default, IEnumerable<ContainerServiceFleetGateConfiguration> beforeGates = default, IEnumerable<ContainerServiceFleetGateConfiguration> afterGates = default, string maxAllowedFailures = default)
        {
            return new ContainerServiceFleetUpdateStage(
                name,
                (groups ?? new ChangeTrackingList<ContainerServiceFleetUpdateGroup>()).ToList(),
                memberSelectorByLabel is null ? default : new MemberSelector(memberSelectorByLabel, default),
                afterStageWaitInSeconds,
                maxAllowedFailures,
                maxConcurrency,
                (beforeGates ?? new ChangeTrackingList<ContainerServiceFleetGateConfiguration>()).ToList(),
                (afterGates ?? new ChangeTrackingList<ContainerServiceFleetGateConfiguration>()).ToList(),
                default);
        }

        /// <summary> The status of a UpdateStage. </summary>
        /// <param name="status"> The status of the UpdateStage. </param>
        /// <param name="name"> The name of the UpdateStage. </param>
        /// <param name="maxConcurrency"> The max number of upgrades that can run concurrently across all groups in this stage. </param>
        /// <param name="groups"> The list of groups to be updated as part of this UpdateStage. </param>
        /// <param name="beforeGates"> The list of Gates that will run before this UpdateStage. </param>
        /// <param name="afterGates"> The list of Gates that will run after this UpdateStage. </param>
        /// <param name="afterStageWaitStatus"> The status of the wait period configured on the UpdateStage. </param>
        /// <param name="failureCount"> The number of failed members in the stage. </param>
        /// <param name="maxAllowedFailures"> The resolved maximum number of failures allowed in the stage. </param>
        /// <returns> A new <see cref="Models.ContainerServiceFleetUpdateStageStatus"/> instance for mocking. </returns>
        public static ContainerServiceFleetUpdateStageStatus ContainerServiceFleetUpdateStageStatus(ContainerServiceFleetUpdateStatus status = default, string name = default, int? maxConcurrency = default, IEnumerable<ContainerServiceFleetUpdateGroupStatus> groups = default, IEnumerable<ContainerServiceFleetUpdateRunGateStatus> beforeGates = default, IEnumerable<ContainerServiceFleetUpdateRunGateStatus> afterGates = default, ContainerServiceFleetWaitStatus afterStageWaitStatus = default, int? failureCount = default, int? maxAllowedFailures = default)
        {
            return new ContainerServiceFleetUpdateStageStatus(
                status,
                name,
                failureCount,
                maxAllowedFailures,
                maxConcurrency,
                (groups ?? new ChangeTrackingList<ContainerServiceFleetUpdateGroupStatus>()).ToList(),
                (beforeGates ?? new ChangeTrackingList<ContainerServiceFleetUpdateRunGateStatus>()).ToList(),
                (afterGates ?? new ChangeTrackingList<ContainerServiceFleetUpdateRunGateStatus>()).ToList(),
                afterStageWaitStatus,
                default);
        }

        /// <summary> The status of a UpdateGroup. </summary>
        /// <param name="status"> The status of the UpdateGroup. </param>
        /// <param name="name"> The name of the UpdateGroup. </param>
        /// <param name="maxConcurrency"> The max number of upgrades that can run concurrently in this group. </param>
        /// <param name="members"> The list of member this UpdateGroup updates. </param>
        /// <param name="beforeGates"> The list of Gates that will run before this UpdateGroup. </param>
        /// <param name="afterGates"> The list of Gates that will run after this UpdateGroup. </param>
        /// <param name="failureCount"> The number of failed members in the group. </param>
        /// <param name="maxAllowedFailures"> The resolved maximum number of failures allowed in the group. </param>
        /// <returns> A new <see cref="Models.ContainerServiceFleetUpdateGroupStatus"/> instance for mocking. </returns>
        public static ContainerServiceFleetUpdateGroupStatus ContainerServiceFleetUpdateGroupStatus(ContainerServiceFleetUpdateStatus status = default, string name = default, int? maxConcurrency = default, IEnumerable<MemberUpdateStatus> members = default, IEnumerable<ContainerServiceFleetUpdateRunGateStatus> beforeGates = default, IEnumerable<ContainerServiceFleetUpdateRunGateStatus> afterGates = default, int? failureCount = default, int? maxAllowedFailures = default)
        {
            return new ContainerServiceFleetUpdateGroupStatus(
                status,
                name,
                failureCount,
                maxAllowedFailures,
                maxConcurrency,
                (members ?? new ChangeTrackingList<MemberUpdateStatus>()).ToList(),
                (beforeGates ?? new ChangeTrackingList<ContainerServiceFleetUpdateRunGateStatus>()).ToList(),
                (afterGates ?? new ChangeTrackingList<ContainerServiceFleetUpdateRunGateStatus>()).ToList(),
                default);
        }
    }
}
