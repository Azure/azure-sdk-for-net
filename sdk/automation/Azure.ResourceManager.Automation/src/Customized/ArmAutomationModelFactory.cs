// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Automation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated webhook create/update content now stores these values inside WebhookCreateOrUpdateProperties.
    // Keep the GA model factory overload that accepts the flattened webhook fields.
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobCreateOrUpdateContent DscCompilationJobCreateOrUpdateContent(string name = null, AzureLocation? location = default, IDictionary<string, string> tags = null, string configurationName = null, IDictionary<string, string> parameters = null, bool? isIncrementNodeConfigurationBuildRequired = default)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobData DscCompilationJobData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string configurationName = null, string startedBy = null, Guid? jobId = default, DateTimeOffset? createdOn = default, JobProvisioningState? provisioningState = default, string runOn = null, AutomationJobStatus? status = default, string statusDetails = null, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, string exception = null, DateTimeOffset? lastModifiedOn = default, DateTimeOffset? lastStatusModifiedOn = default, IDictionary<string, string> parameters = null)
        {
            throw Azure.ResourceManager.Automation.DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
