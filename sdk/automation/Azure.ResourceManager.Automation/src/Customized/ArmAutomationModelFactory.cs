// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Automation;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated webhook create/update content now stores these values inside WebhookCreateOrUpdateProperties.
    // Keep the GA model factory overload that accepts the flattened webhook fields.
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmAutomationModelFactory
    {
        /// <param name="name"> Gets or sets the name of the webhook. </param>
        /// <param name="isEnabled"> Gets or sets the value of the enabled flag of webhook. </param>
        /// <param name="uri"> Gets or sets the uri. </param>
        /// <param name="expireOn"> Gets or sets the expiry time. </param>
        /// <param name="parameters"> Gets or sets the parameters of the job. </param>
        /// <param name="runbookName"> Gets or sets the name of the runbook. </param>
        /// <param name="runOn"> Gets or sets the name of the hybrid worker group the webhook job will run on. </param>
        /// <returns> A new <see cref="Models.AutomationWebhookCreateOrUpdateContent"/> instance for mocking. </returns>
        public static AutomationWebhookCreateOrUpdateContent AutomationWebhookCreateOrUpdateContent(string name = default, bool? isEnabled = default, Uri uri = default, DateTimeOffset? expireOn = default, IDictionary<string, string> parameters = default, string runbookName = default, string runOn = default)
        {
            return new AutomationWebhookCreateOrUpdateContent(
                name,
                isEnabled is null && uri is null && expireOn is null && parameters is null && runbookName is null && runOn is null
                    ? default
                    : new WebhookCreateOrUpdateProperties(
                        isEnabled,
                        uri,
                        expireOn,
                        parameters ?? new ChangeTrackingDictionary<string, string>(),
                        runbookName is null ? default : new RunbookAssociationProperty(runbookName, default),
                        runOn,
                        default),
                default);
        }

        /// <param name="contentLink"> Gets or sets the module content link. </param>
        /// <param name="tags"> Gets or sets the tags attached to the resource. </param>
        /// <returns> A new <see cref="Models.AutomationAccountPython2PackageCreateOrUpdateContent"/> instance for mocking. </returns>
        public static AutomationAccountPython2PackageCreateOrUpdateContent AutomationAccountPython2PackageCreateOrUpdateContent(AutomationContentLink contentLink = default, IDictionary<string, string> tags = default)
        {
            return new AutomationAccountPython2PackageCreateOrUpdateContent(contentLink is null ? default : new PythonPackageCreateProperties(contentLink, default), tags ?? new ChangeTrackingDictionary<string, string>(), default);
        }

        /// <param name="tags"> Gets or sets the tags attached to the resource. </param>
        /// <returns> A new <see cref="Models.AutomationAccountPython2PackagePatch"/> instance for mocking. </returns>
        public static AutomationAccountPython2PackagePatch AutomationAccountPython2PackagePatch(IDictionary<string, string> tags = default)
        {
            return new AutomationAccountPython2PackagePatch(tags ?? new ChangeTrackingDictionary<string, string>(), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AutomationAccountPython2PackageCreateOrUpdateContent"/>. </summary>
        /// <param name="tags"> Gets or sets the tags attached to the resource. </param>
        /// <param name="contentLink"> Gets or sets the module content link. </param>
        /// <returns> A new <see cref="Models.AutomationAccountPython2PackageCreateOrUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutomationAccountPython2PackageCreateOrUpdateContent AutomationAccountPython2PackageCreateOrUpdateContent(IDictionary<string, string> tags = default, AutomationContentLink contentLink = default)
        {
            return new AutomationAccountPython2PackageCreateOrUpdateContent(contentLink is null ? default : new PythonPackageCreateProperties(contentLink, default), tags ?? new ChangeTrackingDictionary<string, string>(), default);
        }

        // DscCompilationJob was removed from the TypeSpec input; these GA compatibility factory overloads are intentionally unsupported.
    /// <summary> Initializes a new instance of <see cref="Models.DscCompilationJobCreateOrUpdateContent"/>. </summary>
    /// <param name="name"> Gets or sets name of the resource. </param>
    /// <param name="location"> Gets or sets the location of the resource. </param>
    /// <param name="tags"> Gets or sets the tags attached to the resource. </param>
    /// <param name="configurationName"> Gets or sets the configuration. </param>
    /// <param name="parameters"> Gets or sets the parameters of the job. </param>
    /// <param name="isIncrementNodeConfigurationBuildRequired"> If a new build version of NodeConfiguration is required. </param>
    /// <returns> A new <see cref="Models.DscCompilationJobCreateOrUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobCreateOrUpdateContent DscCompilationJobCreateOrUpdateContent(string name = null, AzureLocation? location = default, IDictionary<string, string> tags = null, string configurationName = null, IDictionary<string, string> parameters = null, bool? isIncrementNodeConfigurationBuildRequired = default)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Initializes a new instance of <see cref="Automation.DscCompilationJobData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource system data. </param>
        /// <param name="configurationName"> Gets or sets the configuration. </param>
        /// <param name="startedBy"> Gets the compilation job started by. </param>
        /// <param name="jobId"> Gets the id of the job. </param>
        /// <param name="createdOn"> Gets the creation time of the job. </param>
        /// <param name="provisioningState"> The current provisioning state of the job. </param>
        /// <param name="runOn"> Gets or sets the runOn which specifies the group name where the job is to be executed. </param>
        /// <param name="status"> Gets or sets the status of the job. </param>
        /// <param name="statusDetails"> Gets or sets the status details of the job. </param>
        /// <param name="startOn"> Gets the start time of the job. </param>
        /// <param name="endOn"> Gets the end time of the job. </param>
        /// <param name="exception"> Gets the exception of the job. </param>
        /// <param name="lastModifiedOn"> Gets the last modified time. </param>
        /// <param name="lastStatusModifiedOn"> Gets the last status modified time. </param>
        /// <param name="parameters"> Gets or sets the parameters of the job. </param>
        /// <returns> A new <see cref="Automation.DscCompilationJobData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobData DscCompilationJobData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string configurationName = null, string startedBy = null, Guid? jobId = default, DateTimeOffset? createdOn = default, JobProvisioningState? provisioningState = default, string runOn = null, AutomationJobStatus? status = default, string statusDetails = null, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, string exception = null, DateTimeOffset? lastModifiedOn = default, DateTimeOffset? lastStatusModifiedOn = default, IDictionary<string, string> parameters = null)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
