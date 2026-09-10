// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary> A class representing an Automation account resource. </summary>
    public partial class AutomationAccountResource
    {
        // Workaround for https://github.com/Azure/typespec-azure/issues/4729:
        // Legacy.markAsPageable cannot currently specify the page item property. The
        // listKeys response returns items under "keys" instead of "value", so these
        // methods preserve the existing pageable API until TypeSpec can model this.
        /// <summary>
        /// Retrieve the automation keys for an account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/listKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Keys_ListByAutomationAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-22</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AutomationKey"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AutomationKey> GetAutomationAccountKeysAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _keysRestClient.CreateGetAutomationAccountKeysInternalRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, ParseAutomationKeys, _keysClientDiagnostics, Pipeline, "AutomationAccountResource.GetAutomationAccountKeys", context);
        }

        /// <summary>
        /// Retrieve the automation keys for an account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/listKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Keys_ListByAutomationAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-22</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationKey"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AutomationKey> GetAutomationAccountKeys(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _keysRestClient.CreateGetAutomationAccountKeysInternalRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, ParseAutomationKeys, _keysClientDiagnostics, Pipeline, "AutomationAccountResource.GetAutomationAccountKeys", context);
        }

        private static (List<AutomationKey> Values, string NextLink) ParseAutomationKeys(Response response)
        {
            AutomationKeyListResult result = AutomationKeyListResult.FromResponse(response);
            return (new List<AutomationKey>(result.Keys), null);
        }

        /// <summary>
        /// Retrieve the Dsc configuration compilation job identified by job id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{compilationJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscCompilationJobResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="compilationJobName"> The DSC configuration Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        [ForwardsClientCalls]
        public virtual Response<DscCompilationJobResource> GetDscCompilationJob(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve the Dsc configuration compilation job identified by job id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{compilationJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscCompilationJobResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="compilationJobName"> The DSC configuration Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        [ForwardsClientCalls]
        public virtual Task<Response<DscCompilationJobResource>> GetDscCompilationJobAsync(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets a collection of DscCompilationJobResources in the AutomationAccount. </summary>
        /// <returns> An object representing collection of DscCompilationJobResources and their operations over a DscCompilationJobResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual DscCompilationJobCollection GetDscCompilationJobs()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve all the job streams for the compilation Job.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJobStream_ListByJob</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationJobStream"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Pageable<AutomationJobStream> GetDscCompilationJobStreams(Guid jobId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve all the job streams for the compilation Job.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJobStream_ListByJob</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AutomationJobStream"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual AsyncPageable<AutomationJobStream> GetDscCompilationJobStreamsAsync(Guid jobId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve the job stream identified by job stream id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams/{jobStreamId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_GetStream</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscCompilationJobResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="jobStreamId"> The job stream id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="jobStreamId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="jobStreamId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<AutomationJobStream> GetStreamDscCompilationJob(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve the job stream identified by job stream id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{jobId}/streams/{jobStreamId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_GetStream</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-01-13-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DscCompilationJobResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job id. </param>
        /// <param name="jobStreamId"> The job stream id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="jobStreamId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="jobStreamId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<AutomationJobStream>> GetStreamDscCompilationJobAsync(Guid jobId, string jobStreamId, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
