// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Compute.Batch
{
    [CodeGenType("BatchModelFactory")]
    [CodeGenSuppress("BatchNode", typeof(string), typeof(Uri), typeof(BatchNodeState), typeof(SchedulingState?), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IPAddress), typeof(IPAddress), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<BatchTaskInfo>), typeof(BatchStartTask), typeof(BatchStartTaskInfo), typeof(IEnumerable<BatchNodeError>), typeof(bool?), typeof(BatchNodeEndpointConfiguration), typeof(BatchNodeAgentInfo), typeof(VirtualMachineInfo))]
    [CodeGenSuppress("BatchPoolCreateOptions", typeof(string), typeof(string), typeof(string), typeof(VirtualMachineConfiguration), typeof(VirtualMachineSkuProfile), typeof(TimeSpan?), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(TimeSpan?), typeof(bool?), typeof(NetworkConfiguration), typeof(BatchStartTask), typeof(IEnumerable<BatchApplicationPackageReference>), typeof(int?), typeof(BatchTaskSchedulingPolicy), typeof(IEnumerable<UserAccount>), typeof(IEnumerable<BatchMetadataItem>), typeof(IEnumerable<MountConfiguration>), typeof(UpgradePolicy))]
    [CodeGenSuppress("BatchPool", typeof(string), typeof(string), typeof(Uri), typeof(ETag), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(BatchPoolState), typeof(DateTimeOffset), typeof(AllocationState?), typeof(DateTimeOffset?), typeof(string), typeof(VirtualMachineConfiguration), typeof(VirtualMachineSkuProfile), typeof(TimeSpan?), typeof(IEnumerable<ResizeError>), typeof(int), typeof(int), typeof(int?), typeof(int?), typeof(bool?), typeof(string), typeof(TimeSpan?), typeof(AutoScaleRun), typeof(bool?), typeof(NetworkConfiguration), typeof(BatchStartTask), typeof(IEnumerable<BatchApplicationPackageReference>), typeof(int?), typeof(BatchTaskSchedulingPolicy), typeof(IEnumerable<UserAccount>), typeof(IEnumerable<BatchMetadataItem>), typeof(BatchPoolStatistics), typeof(IEnumerable<MountConfiguration>), typeof(BatchPoolIdentity), typeof(UpgradePolicy))]
    [CodeGenSuppress("BatchPoolUpdateOptions", typeof(string), typeof(string), typeof(bool?), typeof(BatchStartTask), typeof(IEnumerable<BatchApplicationPackageReference>), typeof(IEnumerable<BatchMetadataItem>), typeof(VirtualMachineConfiguration), typeof(VirtualMachineSkuProfile), typeof(int?), typeof(BatchTaskSchedulingPolicy), typeof(NetworkConfiguration), typeof(IEnumerable<UserAccount>), typeof(IEnumerable<MountConfiguration>), typeof(UpgradePolicy))]
    public partial class ComputeBatchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.Compute.Batch.BatchFileProperties"/> for mocking. </summary>
        /// <param name="isDirectory"> Whether the object represents a directory. </param>
        /// <param name="mode"> The file mode attribute in octal format. </param>
        /// <param name="fileUri"> The URL of the file. </param>
        /// <param name="creationTime"> The file creation time. </param>
        /// <returns> A new <see cref="Azure.Compute.Batch.BatchFileProperties"/> instance for mocking. </returns>
        public static BatchFileProperties BatchFileProperties(bool isDirectory = default, string mode = default, Uri fileUri = default, DateTime creationTime = default)
            => new BatchFileProperties(isDirectory, mode, fileUri, creationTime);

        /// <summary> Parameters for creating an Azure Batch Pool. </summary>
        /// <param name="id"> A string that uniquely identifies the Pool within the Account. The ID can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 64 characters. The ID is case-preserving and case-insensitive (that is, you may not have two Pool IDs within an Account that differ only by case). </param>
        /// <param name="displayName"> The display name for the Pool. The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024. </param>
        /// <param name="vmSize"> The size of virtual machines in the Pool. All virtual machines in a Pool are the same size. For information about available VM sizes for Pools using Images from the Virtual Machines Marketplace (pools created with virtualMachineConfiguration), see Sizes for Virtual Machines in Azure (https://learn.microsoft.com/azure/virtual-machines/sizes/overview). Batch supports all Azure VM sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series). </param>
        /// <param name="virtualMachineConfiguration"> The virtual machine configuration for the Pool. This property must be specified. </param>
        /// <param name="vmSkuProfile"> Specifies the profile of VM sizes and the allocation strategy used to allocate Compute Nodes for an Instance Mix Pool. When specified, vmSize must be 'Mix'. This property can only be changed while the Pool has no Compute Nodes. </param>
        /// <param name="resizeTimeout"> The timeout for allocation of Compute Nodes to the Pool. This timeout applies only to manual scaling; it has no effect when enableAutoScale is set to true. The default value is 15 minutes. The minimum value is 5 minutes. If you specify a value less than 5 minutes, the Batch service returns an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request). The time duration is specified in ISO 8601 format. </param>
        /// <param name="targetDedicatedNodes"> The desired number of dedicated Compute Nodes in the Pool. This property must not be specified if enableAutoScale is set to true. If enableAutoScale is set to false, then you must set either targetDedicatedNodes, targetLowPriorityNodes, or both. </param>
        /// <param name="targetLowPriorityNodes"> The desired number of Spot/Low-priority Compute Nodes in the Pool. This property must not be specified if enableAutoScale is set to true. If enableAutoScale is set to false, then you must set either targetDedicatedNodes, targetLowPriorityNodes, or both. </param>
        /// <param name="enableAutoScale"> Whether the Pool size should automatically adjust over time. If false, at least one of targetDedicatedNodes and targetLowPriorityNodes must be specified. If true, the autoScaleFormula property is required and the Pool automatically resizes according to the formula. The default value is false. </param>
        /// <param name="autoScaleFormula"> A formula for the desired number of Compute Nodes in the Pool. This property must not be specified if enableAutoScale is set to false. It is required if enableAutoScale is set to true. The formula is checked for validity before the Pool is created. If the formula is not valid, the Batch service rejects the request with detailed error information. For more information about specifying this formula, see 'Automatically scale Compute Nodes in an Azure Batch Pool' (https://learn.microsoft.com/azure/batch/batch-automatic-scaling). </param>
        /// <param name="autoScaleEvaluationInterval"> The time interval at which to automatically adjust the Pool size according to the autoscale formula. The default value is 15 minutes. The minimum and maximum value are 5 minutes and 168 hours respectively. If you specify a value less than 5 minutes or greater than 168 hours, the Batch service returns an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request). The time duration is specified in ISO 8601 format. </param>
        /// <param name="enableInterNodeCommunication"> Whether the Pool permits direct communication between Compute Nodes. Enabling inter-node communication limits the maximum size of the Pool due to deployment restrictions on the Compute Nodes of the Pool. This may result in the Pool not reaching its desired size. The default value is false. </param>
        /// <param name="networkConfiguration"> The network configuration for the Pool. </param>
        /// <param name="startTask"> A Task specified to run on each Compute Node as it joins the Pool. The Task runs when the Compute Node is added to the Pool or when the Compute Node is restarted. </param>
        /// <param name="applicationPackageReferences"> The list of Packages to be installed on each Compute Node in the Pool. When creating a pool, the package's application ID must be fully qualified (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}). Changes to Package references affect all new Nodes joining the Pool, but do not affect Compute Nodes that are already in the Pool until they are rebooted or reimaged. There is a maximum of 10 Package references on any given Pool. </param>
        /// <param name="taskSlotsPerNode"> The number of task slots that can be used to run concurrent tasks on a single compute node in the pool. The default value is 1. The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256. </param>
        /// <param name="taskSchedulingPolicy"> How Tasks are distributed across Compute Nodes in a Pool. If not specified, the default is spread. </param>
        /// <param name="userAccounts"> The list of user Accounts to be created on each Compute Node in the Pool. </param>
        /// <param name="metadata"> A list of name-value pairs associated with the Pool as metadata. The Batch service does not assign any meaning to metadata; it is solely for the use of user code. </param>
        /// <param name="mountConfiguration"> Mount storage using specified file system for the entire lifetime of the pool. Mount the storage using Azure fileshare, NFS, CIFS or Blobfuse based file system. </param>
        /// <param name="upgradePolicy"> The upgrade policy for the Pool. Describes an upgrade policy - automatic, manual, or rolling. </param>
        /// <returns> A new <see cref="Batch.BatchPoolCreateOptions"/> instance for mocking. </returns>
        public static BatchPoolCreateOptions BatchPoolCreateOptions(string id = default, string displayName = default, string vmSize = default, VirtualMachineConfiguration virtualMachineConfiguration = default, TimeSpan? resizeTimeout = default, int? targetDedicatedNodes = default, int? targetLowPriorityNodes = default, bool? enableAutoScale = default, string autoScaleFormula = default, TimeSpan? autoScaleEvaluationInterval = default, bool? enableInterNodeCommunication = default, NetworkConfiguration networkConfiguration = default, BatchStartTask startTask = default, IEnumerable<BatchApplicationPackageReference> applicationPackageReferences = default, int? taskSlotsPerNode = default, BatchTaskSchedulingPolicy taskSchedulingPolicy = default, IEnumerable<UserAccount> userAccounts = default, IEnumerable<BatchMetadataItem> metadata = default, IEnumerable<MountConfiguration> mountConfiguration = default, UpgradePolicy upgradePolicy = default, VirtualMachineSkuProfile vmSkuProfile = default)
        {
            applicationPackageReferences ??= new ChangeTrackingList<BatchApplicationPackageReference>();
            userAccounts ??= new ChangeTrackingList<UserAccount>();
            metadata ??= new ChangeTrackingList<BatchMetadataItem>();
            mountConfiguration ??= new ChangeTrackingList<MountConfiguration>();

            return new BatchPoolCreateOptions(
                id,
                displayName,
                vmSize,
                virtualMachineConfiguration,
                vmSkuProfile,
                resizeTimeout,
                targetDedicatedNodes,
                targetLowPriorityNodes,
                enableAutoScale,
                autoScaleFormula,
                autoScaleEvaluationInterval,
                enableInterNodeCommunication,
                networkConfiguration,
                startTask,
                applicationPackageReferences.ToList(),
                taskSlotsPerNode,
                taskSchedulingPolicy,
                userAccounts.ToList(),
                metadata.ToList(),
                mountConfiguration.ToList(),
                upgradePolicy,
                additionalBinaryDataProperties: null);
        }

        /// <summary> A Pool in the Azure Batch service. </summary>
        /// <param name="id"> A string that uniquely identifies the Pool within the Account. The ID can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 64 characters. The ID is case-preserving and case-insensitive (that is, you may not have two IDs within an Account that differ only by case). </param>
        /// <param name="displayName"> The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024. </param>
        /// <param name="uri"> The URL of the Pool. </param>
        /// <param name="eTag"> The ETag of the Pool. This is an opaque string. You can use it to detect whether the Pool has changed between requests. In particular, you can be pass the ETag when updating a Pool to specify that your changes should take effect only if nobody else has modified the Pool in the meantime. </param>
        /// <param name="lastModified"> The last modified time of the Pool. This is the last time at which the Pool level data, such as the targetDedicatedNodes or enableAutoscale settings, changed. It does not factor in node-level changes such as a Compute Node changing state. </param>
        /// <param name="creationTime"> The creation time of the Pool. </param>
        /// <param name="state"> The current state of the Pool. </param>
        /// <param name="stateTransitionTime"> The time at which the Pool entered its current state. </param>
        /// <param name="allocationState"> Whether the Pool is resizing. </param>
        /// <param name="allocationStateTransitionTime"> The time at which the Pool entered its current allocation state. </param>
        /// <param name="vmSize"> The size of virtual machines in the Pool. All virtual machines in a Pool are the same size. For information about available sizes of virtual machines in Pools, see Choose a VM size for Compute Nodes in an Azure Batch Pool (https://learn.microsoft.com/azure/batch/batch-pool-vm-sizes). </param>
        /// <param name="virtualMachineConfiguration"> The virtual machine configuration for the Pool. This property must be specified. </param>
        /// <param name="vmSkuProfile"> Specifies the profile of VM sizes and the allocation strategy used to allocate Compute Nodes for an Instance Mix Pool. When specified, vmSize must be 'Mix'. This property can only be changed while the Pool has no Compute Nodes. </param>
        /// <param name="resizeTimeout"> The timeout for allocation of Compute Nodes to the Pool. This is the timeout for the most recent resize operation. (The initial sizing when the Pool is created counts as a resize.) The default value is 15 minutes. The time duration is specified in ISO 8601 format. </param>
        /// <param name="resizeErrors"> A list of errors encountered while performing the last resize on the Pool. This property is set only if one or more errors occurred during the last Pool resize, and only when the Pool allocationState is Steady. </param>
        /// <param name="currentDedicatedNodes"> The number of dedicated Compute Nodes currently in the Pool. </param>
        /// <param name="currentLowPriorityNodes"> The number of Spot/Low-priority Compute Nodes currently in the Pool. Spot/Low-priority Compute Nodes which have been preempted are included in this count. </param>
        /// <param name="targetDedicatedNodes"> The desired number of dedicated Compute Nodes in the Pool. </param>
        /// <param name="targetLowPriorityNodes"> The desired number of Spot/Low-priority Compute Nodes in the Pool. </param>
        /// <param name="enableAutoScale"> Whether the Pool size should automatically adjust over time. If false, at least one of targetDedicatedNodes and targetLowPriorityNodes must be specified. If true, the autoScaleFormula property is required and the Pool automatically resizes according to the formula. The default value is false. </param>
        /// <param name="autoScaleFormula"> A formula for the desired number of Compute Nodes in the Pool. This property is set only if the Pool automatically scales, i.e. enableAutoScale is true. </param>
        /// <param name="autoScaleEvaluationInterval"> The time interval at which to automatically adjust the Pool size according to the autoscale formula. This property is set only if the Pool automatically scales, i.e. enableAutoScale is true. The time duration is specified in ISO 8601 format. </param>
        /// <param name="autoScaleRun"> The results and errors from the last execution of the autoscale formula. This property is set only if the Pool automatically scales, i.e. enableAutoScale is true. </param>
        /// <param name="enableInterNodeCommunication"> Whether the Pool permits direct communication between Compute Nodes. Enabling inter-node communication limits the maximum size of the Pool due to deployment restrictions on the Compute Nodes of the Pool. This may result in the Pool not reaching its desired size. The default value is false. </param>
        /// <param name="networkConfiguration"> The network configuration for the Pool. </param>
        /// <param name="startTask"> A Task specified to run on each Compute Node as it joins the Pool. </param>
        /// <param name="applicationPackageReferences"> The list of Packages to be installed on each Compute Node in the Pool. Changes to Package references affect all new Nodes joining the Pool, but do not affect Compute Nodes that are already in the Pool until they are rebooted or reimaged. There is a maximum of 10 Package references on any given Pool. </param>
        /// <param name="taskSlotsPerNode"> The number of task slots that can be used to run concurrent tasks on a single compute node in the pool. The default value is 1. The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256. </param>
        /// <param name="taskSchedulingPolicy"> How Tasks are distributed across Compute Nodes in a Pool. If not specified, the default is spread. </param>
        /// <param name="userAccounts"> The list of user Accounts to be created on each Compute Node in the Pool. </param>
        /// <param name="metadata"> A list of name-value pairs associated with the Pool as metadata. </param>
        /// <param name="poolStatistics"> Utilization and resource usage statistics for the entire lifetime of the Pool. This property is populated only if the BatchPool was retrieved with an expand clause including the 'stats' attribute; otherwise it is null. The statistics may not be immediately available. The Batch service performs periodic roll-up of statistics. The typical delay is about 30 minutes. </param>
        /// <param name="mountConfiguration"> Mount storage using specified file system for the entire lifetime of the pool. Mount the storage using Azure fileshare, NFS, CIFS or Blobfuse based file system. </param>
        /// <param name="identity"> The identity of the Batch pool, if configured. The list of user identities associated with the Batch pool. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </param>
        /// <param name="upgradePolicy"> The upgrade policy for the Pool. Describes an upgrade policy - automatic, manual, or rolling. </param>
        /// <returns> A new <see cref="Batch.BatchPool"/> instance for mocking. </returns>
        public static BatchPool BatchPool(string id = default, string displayName = default, Uri uri = default, ETag eTag = default, DateTimeOffset lastModified = default, DateTimeOffset creationTime = default, BatchPoolState state = default, DateTimeOffset stateTransitionTime = default, AllocationState? allocationState = default, DateTimeOffset? allocationStateTransitionTime = default, string vmSize = default, VirtualMachineConfiguration virtualMachineConfiguration = default, TimeSpan? resizeTimeout = default, IEnumerable<ResizeError> resizeErrors = default, int currentDedicatedNodes = default, int currentLowPriorityNodes = default, int? targetDedicatedNodes = default, int? targetLowPriorityNodes = default, bool? enableAutoScale = default, string autoScaleFormula = default, TimeSpan? autoScaleEvaluationInterval = default, AutoScaleRun autoScaleRun = default, bool? enableInterNodeCommunication = default, NetworkConfiguration networkConfiguration = default, BatchStartTask startTask = default, IEnumerable<BatchApplicationPackageReference> applicationPackageReferences = default, int? taskSlotsPerNode = default, BatchTaskSchedulingPolicy taskSchedulingPolicy = default, IEnumerable<UserAccount> userAccounts = default, IEnumerable<BatchMetadataItem> metadata = default, BatchPoolStatistics poolStatistics = default, IEnumerable<MountConfiguration> mountConfiguration = default, BatchPoolIdentity identity = default, UpgradePolicy upgradePolicy = default, VirtualMachineSkuProfile vmSkuProfile = default)
        {
            resizeErrors ??= new ChangeTrackingList<ResizeError>();
            applicationPackageReferences ??= new ChangeTrackingList<BatchApplicationPackageReference>();
            userAccounts ??= new ChangeTrackingList<UserAccount>();
            metadata ??= new ChangeTrackingList<BatchMetadataItem>();
            mountConfiguration ??= new ChangeTrackingList<MountConfiguration>();

            return new BatchPool(
                id,
                displayName,
                uri,
                eTag,
                lastModified,
                creationTime,
                state,
                stateTransitionTime,
                allocationState,
                allocationStateTransitionTime,
                vmSize,
                virtualMachineConfiguration,
                vmSkuProfile,
                resizeTimeout,
                resizeErrors.ToList(),
                currentDedicatedNodes,
                currentLowPriorityNodes,
                targetDedicatedNodes,
                targetLowPriorityNodes,
                enableAutoScale,
                autoScaleFormula,
                autoScaleEvaluationInterval,
                autoScaleRun,
                enableInterNodeCommunication,
                networkConfiguration,
                startTask,
                applicationPackageReferences.ToList(),
                taskSlotsPerNode,
                taskSchedulingPolicy,
                userAccounts.ToList(),
                metadata.ToList(),
                poolStatistics,
                mountConfiguration.ToList(),
                identity,
                upgradePolicy,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Parameters for updating an Azure Batch Pool. </summary>
        /// <param name="displayName"> The display name for the Pool. The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024. This field can be updated only when the pool is empty. </param>
        /// <param name="vmSize"> The size of virtual machines in the Pool. For information about available sizes of virtual machines in Pools, see Choose a VM size for Compute Nodes in an Azure Batch Pool (https://learn.microsoft.com/azure/batch/batch-pool-vm-sizes).&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="enableInterNodeCommunication"> Whether the Pool permits direct communication between Compute Nodes. Enabling inter-node communication limits the maximum size of the Pool due to deployment restrictions on the Compute Nodes of the Pool. This may result in the Pool not reaching its desired size. The default value is false.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="startTask"> A Task to run on each Compute Node as it joins the Pool. The Task runs when the Compute Node is added to the Pool or when the Compute Node is restarted. If this element is present, it overwrites any existing StartTask. If omitted, any existing StartTask is left unchanged. </param>
        /// <param name="applicationPackageReferences"> A list of Packages to be installed on each Compute Node in the Pool. Changes to Package references affect all new Nodes joining the Pool, but do not affect Compute Nodes that are already in the Pool until they are rebooted or reimaged. If this element is present, it replaces any existing Package references. If you specify an empty collection, then all Package references are removed from the Pool. If omitted, any existing Package references are left unchanged. </param>
        /// <param name="metadata"> A list of name-value pairs associated with the Pool as metadata. If this element is present, it replaces any existing metadata configured on the Pool. If you specify an empty collection, any metadata is removed from the Pool. If omitted, any existing metadata is left unchanged. </param>
        /// <param name="virtualMachineConfiguration"> The virtual machine configuration for the Pool. This property must be specified.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="vmSkuProfile"> Specifies the profile of VM sizes and the allocation strategy used to allocate Compute Nodes for an Instance Mix Pool. When specified, vmSize must be 'Mix'.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="taskSlotsPerNode"> The number of task slots that can be used to run concurrent tasks on a single compute node in the pool. The default value is 1. The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="taskSchedulingPolicy"> How Tasks are distributed across Compute Nodes in a Pool. If not specified, the default is spread.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="networkConfiguration"> The network configuration for the Pool. This field can be updated only when the pool is empty. </param>
        /// <param name="userAccounts"> The list of user Accounts to be created on each Compute Node in the Pool. This field can be updated only when the pool is empty. </param>
        /// <param name="mountConfiguration"> Mount storage using specified file system for the entire lifetime of the pool. Mount the storage using Azure fileshare, NFS, CIFS or Blobfuse based file system.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <param name="upgradePolicy"> The upgrade policy for the Pool. Describes an upgrade policy - automatic, manual, or rolling.&lt;br /&gt;&lt;br /&gt;This field can be updated only when the pool is empty. </param>
        /// <returns> A new <see cref="Batch.BatchPoolUpdateOptions"/> instance for mocking. </returns>
        public static BatchPoolUpdateOptions BatchPoolUpdateOptions(string displayName = default, string vmSize = default, bool? enableInterNodeCommunication = default, BatchStartTask startTask = default, IEnumerable<BatchApplicationPackageReference> applicationPackageReferences = default, IEnumerable<BatchMetadataItem> metadata = default, VirtualMachineConfiguration virtualMachineConfiguration = default, int? taskSlotsPerNode = default, BatchTaskSchedulingPolicy taskSchedulingPolicy = default, NetworkConfiguration networkConfiguration = default, IEnumerable<UserAccount> userAccounts = default, IEnumerable<MountConfiguration> mountConfiguration = default, UpgradePolicy upgradePolicy = default, VirtualMachineSkuProfile vmSkuProfile = default)
        {
            applicationPackageReferences ??= new ChangeTrackingList<BatchApplicationPackageReference>();
            metadata ??= new ChangeTrackingList<BatchMetadataItem>();
            userAccounts ??= new ChangeTrackingList<UserAccount>();
            mountConfiguration ??= new ChangeTrackingList<MountConfiguration>();

            return new BatchPoolUpdateOptions(
                displayName,
                vmSize,
                enableInterNodeCommunication,
                startTask,
                applicationPackageReferences.ToList(),
                metadata.ToList(),
                virtualMachineConfiguration,
                vmSkuProfile,
                taskSlotsPerNode,
                taskSchedulingPolicy,
                networkConfiguration,
                userAccounts.ToList(),
                mountConfiguration.ToList(),
                upgradePolicy,
                additionalBinaryDataProperties: null);
        }

        /// <summary> A Compute Node in the Batch service. </summary>
        /// <param name="id"> The ID of the Compute Node. Every Compute Node that is added to a Pool is assigned a unique ID. Whenever a Compute Node is removed from a Pool, all of its local files are deleted, and the ID is reclaimed and could be reused for new Compute Nodes. </param>
        /// <param name="uri"> The URL of the Compute Node. </param>
        /// <param name="state"> The current state of the Compute Node. </param>
        /// <param name="schedulingState"> Whether the Compute Node is available for Task scheduling. </param>
        /// <param name="stateTransitionTime"> The time at which the Compute Node entered its current state. </param>
        /// <param name="lastBootTime"> The last time at which the Compute Node was started. This property may not be present if the Compute Node state is unusable. </param>
        /// <param name="allocationTime"> The time at which this Compute Node was allocated to the Pool. This is the time when the Compute Node was initially allocated and doesn't change once set. It is not updated when the Compute Node is service healed or preempted. </param>
        /// <param name="ipAddress"> The IP address that other Nodes can use to communicate with this Compute Node. Every Compute Node that is added to a Pool is assigned a unique IP address. Whenever a Compute Node is removed from a Pool, all of its local files are deleted, and the IP address is reclaimed and could be reused for new Compute Nodes. </param>
        /// <param name="ipv6Address"> The IPv6 address that other Nodes can use to communicate with this Compute Node. Every Compute Node that is added to a Pool is assigned a unique IP address. Whenever a Compute Node is removed from a Pool, all of its local files are deleted, and the IP address is reclaimed and could be reused for new Compute Nodes. This property will not be present if the Pool is not configured for IPv6. </param>
        /// <param name="publicIPAddress"> The public IPv4 address (load balancer front-end VIP) used to reach this Compute Node from outside the virtual network. For Pools that use the Batch-managed or User-managed public load balancer, this is the load balancer's front-end public IPv4 address. The value is present regardless of whether SSH or RDP remote access is enabled, so callers can perform IP-based validation even when remote login is disabled. The property is omitted when the Pool is configured with no public IP addresses (for example, private link or BYO VNet with NoPublicIPAddresses). </param>
        /// <param name="publicIPv6Address"> The public IPv6 address (load balancer front-end VIP) used to reach this Compute Node from outside the virtual network. Populated only when the Pool is configured for IPv6 / dual-stack public networking. The property is omitted otherwise. </param>
        /// <param name="affinityId"> An identifier which can be passed when adding a Task to request that the Task be scheduled on this Compute Node. Note that this is just a soft affinity. If the target Compute Node is busy or unavailable at the time the Task is scheduled, then the Task will be scheduled elsewhere. </param>
        /// <param name="vmSize"> The size of the virtual machine hosting the Compute Node. For information about available sizes of virtual machines in Pools, see Choose a VM size for Compute Nodes in an Azure Batch Pool (https://learn.microsoft.com/azure/batch/batch-pool-vm-sizes). </param>
        /// <param name="totalTasksRun"> The total number of Job Tasks completed on the Compute Node. This includes Job Manager Tasks and normal Tasks, but not Job Preparation, Job Release or Start Tasks. </param>
        /// <param name="runningTasksCount"> The total number of currently running Job Tasks on the Compute Node. This includes Job Manager Tasks and normal Tasks, but not Job Preparation, Job Release or Start Tasks. </param>
        /// <param name="runningTaskSlotsCount"> The total number of scheduling slots used by currently running Job Tasks on the Compute Node. This includes Job Manager Tasks and normal Tasks, but not Job Preparation, Job Release or Start Tasks. </param>
        /// <param name="totalTasksSucceeded"> The total number of Job Tasks which completed successfully (with exitCode 0) on the Compute Node. This includes Job Manager Tasks and normal Tasks, but not Job Preparation, Job Release or Start Tasks. </param>
        /// <param name="recentTasks"> A list of Tasks whose state has recently changed. This property is present only if at least one Task has run on this Compute Node since it was assigned to the Pool. </param>
        /// <param name="startTask"> The Task specified to run on the Compute Node as it joins the Pool. </param>
        /// <param name="startTaskInfo"> Runtime information about the execution of the StartTask on the Compute Node. </param>
        /// <param name="errors"> The list of errors that are currently being encountered by the Compute Node. </param>
        /// <param name="isDedicated"> Whether this Compute Node is a dedicated Compute Node. If false, the Compute Node is a Spot/Low-priority Compute Node. </param>
        /// <param name="endpointConfiguration"> The endpoint configuration for the Compute Node. </param>
        /// <param name="nodeAgentInfo"> Information about the Compute Node agent version and the time the Compute Node upgraded to a new version. </param>
        /// <param name="virtualMachineInfo"> Info about the current state of the virtual machine. </param>
        /// <returns> A new <see cref="Batch.BatchNode"/> instance for mocking. </returns>
        public static BatchNode BatchNode(string id = default, Uri uri = default, BatchNodeState state = default, SchedulingState? schedulingState = default, DateTimeOffset stateTransitionTime = default, DateTimeOffset lastBootTime = default, DateTimeOffset allocationTime = default, IPAddress ipAddress = default, IPAddress ipv6Address = default, string affinityId = default, string vmSize = default, int totalTasksRun = default, int? runningTasksCount = default, int? runningTaskSlotsCount = default, int? totalTasksSucceeded = default, IEnumerable<BatchTaskInfo> recentTasks = default, BatchStartTask startTask = default, BatchStartTaskInfo startTaskInfo = default, IEnumerable<BatchNodeError> errors = default, bool? isDedicated = default, BatchNodeEndpointConfiguration endpointConfiguration = default, BatchNodeAgentInfo nodeAgentInfo = default, VirtualMachineInfo virtualMachineInfo = default, string publicIPAddress = default, string publicIPv6Address = default)
        {
            recentTasks ??= new ChangeTrackingList<BatchTaskInfo>();
            errors ??= new ChangeTrackingList<BatchNodeError>();

            return new BatchNode(
                id,
                uri,
                state,
                schedulingState,
                stateTransitionTime,
                lastBootTime,
                allocationTime,
                ipAddress,
                ipv6Address,
                publicIPAddress,
                publicIPv6Address,
                affinityId,
                vmSize,
                totalTasksRun,
                runningTasksCount,
                runningTaskSlotsCount,
                totalTasksSucceeded,
                recentTasks.ToList(),
                startTask,
                startTaskInfo,
                errors.ToList(),
                isDedicated,
                endpointConfiguration,
                nodeAgentInfo,
                virtualMachineInfo,
                additionalBinaryDataProperties: null);
        }
    }
}
