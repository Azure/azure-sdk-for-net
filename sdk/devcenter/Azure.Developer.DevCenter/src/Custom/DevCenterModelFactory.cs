// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    [CodeGenClient("DeveloperDevCenterModelFactory")]
    public static partial class DevCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DevCenterProject"/>. </summary>
        /// <param name="name"> Name of the project. </param>
        /// <param name="description"> Description of the project. </param>
        /// <param name="maxDevBoxesPerUser">
        /// When specified, indicates the maximum number of Dev Boxes a single user can
        /// create across all pools in the project.
        /// </param>
        /// <returns> A new <see cref="Models.DevCenterProject"/> instance for mocking. </returns>
        public static DevCenterProject DevCenterProject(string name = null, string description = null, int? maxDevBoxesPerUser = null)
        {
            return DevCenterProject(
                null,
                name,
                description,
                maxDevBoxesPerUser,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevBoxPool"/>. </summary>
        /// <param name="name"> Pool name. </param>
        /// <param name="location"> Azure region where Dev Boxes in the pool are located. </param>
        /// <param name="osType"> The operating system type of Dev Boxes in this pool. </param>
        /// <param name="hardwareProfile"> Hardware settings for the Dev Boxes created in this pool. </param>
        /// <param name="hibernateSupport"> Indicates whether hibernate is enabled/disabled or unknown. </param>
        /// <param name="storageProfile"> Storage settings for Dev Box created in this pool. </param>
        /// <param name="imageReference"> Image settings for Dev Boxes create in this pool. </param>
        /// <param name="localAdministratorStatus">
        /// Indicates whether owners of Dev Boxes in this pool are local administrators on
        /// the Dev Boxes.
        /// </param>
        /// <param name="stopOnDisconnect"> Stop on disconnect configuration settings for Dev Boxes created in this pool. </param>
        /// <param name="healthStatus">
        /// Overall health status of the Pool. Indicates whether or not the Pool is
        /// available to create Dev Boxes.
        /// </param>
        /// <returns> A new <see cref="Models.DevBoxPool"/> instance for mocking. </returns>
        public static DevBoxPool DevBoxPool(string name = null, AzureLocation location = default, DevBoxOSType? osType = null, DevBoxHardwareProfile hardwareProfile = null, HibernateSupport? hibernateSupport = null, DevBoxStorageProfile storageProfile = null, DevBoxImageReference imageReference = null, LocalAdministratorStatus? localAdministratorStatus = null, StopOnDisconnectConfiguration stopOnDisconnect = null, PoolHealthStatus healthStatus = default)
        {
            return DevBoxPool(
                null,
                name,
                location,
                osType,
                hardwareProfile,
                hibernateSupport,
                storageProfile,
                imageReference,
                localAdministratorStatus,
                stopOnDisconnect,
                healthStatus,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevBox"/>. </summary>
        /// <param name="name"> Display name for the Dev Box. </param>
        /// <param name="projectName"> Name of the project this Dev Box belongs to. </param>
        /// <param name="poolName"> The name of the Dev Box pool this machine belongs to. </param>
        /// <param name="hibernateSupport"> Indicates whether hibernate is enabled/disabled or unknown. </param>
        /// <param name="provisioningState"> The current provisioning state of the Dev Box. </param>
        /// <param name="actionState">
        /// The current action state of the Dev Box. This is state is based on previous
        /// action performed by user.
        /// </param>
        /// <param name="powerState"> The current power state of the Dev Box. </param>
        /// <param name="uniqueId">
        /// A unique identifier for the Dev Box. This is a GUID-formatted string (e.g.
        /// 00000000-0000-0000-0000-000000000000).
        /// </param>
        /// <param name="error"> Provisioning or action error details. Populated only for error states. </param>
        /// <param name="location">
        /// Azure region where this Dev Box is located. This will be the same region as the
        /// Virtual Network it is attached to.
        /// </param>
        /// <param name="osType"> The operating system type of this Dev Box. </param>
        /// <param name="userId"> The AAD object id of the user this Dev Box is assigned to. </param>
        /// <param name="hardwareProfile"> Information about the Dev Box's hardware resources. </param>
        /// <param name="storageProfile"> Storage settings for this Dev Box. </param>
        /// <param name="imageReference"> Information about the image used for this Dev Box. </param>
        /// <param name="createdTime"> Creation time of this Dev Box. </param>
        /// <param name="localAdministratorStatus"> Indicates whether the owner of the Dev Box is a local administrator. </param>
        /// <returns> A new <see cref="Models.DevBox"/> instance for mocking. </returns>
        public static DevBox DevBox(string name = null, string projectName = null, string poolName = null, HibernateSupport? hibernateSupport = null, DevBoxProvisioningState? provisioningState = null, string actionState = null, PowerState? powerState = null, Guid? uniqueId = null, ResponseError error = null, AzureLocation? location = null, DevBoxOSType? osType = null, Guid? userId = null, DevBoxHardwareProfile hardwareProfile = null, DevBoxStorageProfile storageProfile = null, DevBoxImageReference imageReference = null, DateTimeOffset? createdTime = null, LocalAdministratorStatus? localAdministratorStatus = null)
        {
            return DevBox(
                null,
                name,
                projectName,
                poolName,
                hibernateSupport,
                provisioningState,
                actionState,
                powerState,
                uniqueId,
                error,
                location,
                osType,
                userId,
                hardwareProfile,
                storageProfile,
                imageReference,
                createdTime,
                localAdministratorStatus);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevBoxAction"/>. </summary>
        /// <param name="name"> The name of the action. </param>
        /// <param name="actionType"> The action that will be taken. </param>
        /// <param name="sourceId"> The id of the resource which triggered this action. </param>
        /// <param name="suspendedUntil"> The earliest time that the action could occur (UTC). </param>
        /// <param name="nextAction"> Details about the next run of this action. </param>
        /// <returns> A new <see cref="Models.DevBoxAction"/> instance for mocking. </returns>
        public static DevBoxAction DevBoxAction(string name = null, DevBoxActionType actionType = default, string sourceId = null, DateTimeOffset? suspendedUntil = null, DevBoxNextAction nextAction = null)
        {
            return DevBoxAction(
                null,
                name,
                actionType,
                sourceId,
                null,
                null,
                suspendedUntil,
                nextAction);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevBoxActionDelayResult"/>. </summary>
        /// <param name="actionName"> The name of the action. </param>
        /// <param name="delayStatus"> The result of the delay operation on this action. </param>
        /// <param name="action"> The delayed action. </param>
        /// <param name="error"> Information about the error that occurred. Only populated on error. </param>
        /// <returns> A new <see cref="Models.DevBoxActionDelayResult"/> instance for mocking. </returns>
        public static DevBoxActionDelayResult DevBoxActionDelayResult(string actionName = null, DevBoxActionDelayStatus delayStatus = default, DevBoxAction action = null, ResponseError error = null)
        {
            return DevBoxActionDelayResult(
                null,
                actionName,
                delayStatus,
                action,
                error);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevBoxSchedule"/>. </summary>
        /// <param name="name"> Display name for the Schedule. </param>
        /// <param name="scheduleType"> Supported type this scheduled task represents. </param>
        /// <param name="scheduleFrequency"> The frequency of this scheduled task. </param>
        /// <param name="time"> The target time to trigger the action. The format is HH:MM. </param>
        /// <param name="timeZone"> The IANA timezone id at which the schedule should execute. </param>
        /// <returns> A new <see cref="Models.DevBoxSchedule"/> instance for mocking. </returns>
        public static DevBoxSchedule DevBoxSchedule(string name = null, ScheduleType scheduleType = default, ScheduleFrequency scheduleFrequency = default, string time = null, string timeZone = null)
        {
            return DevBoxSchedule(
                null,
                name,
                null,
                null,
                scheduleType,
                scheduleFrequency,
                time,
                timeZone);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevCenterCatalog"/>. </summary>
        /// <param name="name"> Name of the catalog. </param>
        /// <returns> A new <see cref="Models.DevCenterCatalog"/> instance for mocking. </returns>
        public static DevCenterCatalog DevCenterCatalog(string name = null)
        {
            return DevCenterCatalog(null, name);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevCenterEnvironment"/>. </summary>
        /// <param name="parameters"> Parameters object for the environment. </param>
        /// <param name="name"> Environment name. </param>
        /// <param name="environmentTypeName"> Environment type. </param>
        /// <param name="userId"> The AAD object id of the owner of this Environment. </param>
        /// <param name="provisioningState"> The provisioning state of the environment. </param>
        /// <param name="resourceGroupId"> The identifier of the resource group containing the environment's resources. </param>
        /// <param name="catalogName"> Name of the catalog. </param>
        /// <param name="environmentDefinitionName"> Name of the environment definition. </param>
        /// <param name="error"> Provisioning error details. Populated only for error states. </param>
        /// <returns> A new <see cref="Models.DevCenterEnvironment"/> instance for mocking. </returns>
        public static DevCenterEnvironment DevCenterEnvironment(IDictionary<string, BinaryData> parameters = null, string name = null, string environmentTypeName = null, Guid? userId = null, EnvironmentProvisioningState? provisioningState = null, ResourceIdentifier resourceGroupId = null, string catalogName = null, string environmentDefinitionName = null, ResponseError error = null)
        {
            parameters ??= new Dictionary<string, BinaryData>();

            return DevCenterEnvironment(
                null,
                parameters,
                null,
                name,
                environmentTypeName,
                userId,
                provisioningState,
                resourceGroupId,
                catalogName,
                environmentDefinitionName,
                error);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DevCenterEnvironmentType"/>. </summary>
        /// <param name="name"> Name of the environment type. </param>
        /// <param name="deploymentTargetId">
        /// Id of a subscription or management group that the environment type will be
        /// mapped to. The environment's resources will be deployed into this subscription
        /// or management group.
        /// </param>
        /// <param name="status"> Indicates whether this environment type is enabled for use in this project. </param>
        /// <returns> A new <see cref="Models.DevCenterEnvironmentType"/> instance for mocking. </returns>
        public static DevCenterEnvironmentType DevCenterEnvironmentType(string name = null, ResourceIdentifier deploymentTargetId = null, EnvironmentTypeStatus status = default)
        {
            return DevCenterEnvironmentType(
                null,
                name,
                deploymentTargetId,
                status,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EnvironmentDefinition"/>. </summary>
        /// <param name="id"> The ID of the environment definition. </param>
        /// <param name="name"> Name of the environment definition. </param>
        /// <param name="catalogName"> Name of the catalog. </param>
        /// <param name="description"> A short description of the environment definition. </param>
        /// <param name="parameters"> Input parameters passed to an environment. </param>
        /// <param name="parametersSchema"> JSON schema defining the parameters object passed to an environment. </param>
        /// <param name="templatePath"> Path to the Environment Definition entrypoint file. </param>
        /// <returns> A new <see cref="Models.EnvironmentDefinition"/> instance for mocking. </returns>
        public static EnvironmentDefinition EnvironmentDefinition(string id = null, string name = null, string catalogName = null, string description = null, IEnumerable<EnvironmentDefinitionParameter> parameters = null, string parametersSchema = null, string templatePath = null)
        {
            parameters ??= new List<EnvironmentDefinitionParameter>();

            return EnvironmentDefinition(
                null,
                id,
                name,
                catalogName,
                description,
                parameters?.ToList(),
                parametersSchema,
                templatePath);
        }
    }
}
