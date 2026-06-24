// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A class representing a collection of <see cref="DscCompilationJobResource"/> and their operations.
    /// Each <see cref="DscCompilationJobResource"/> in the collection will belong to the same instance of <see cref="AutomationAccountResource"/>.
    /// To get a <see cref="DscCompilationJobCollection"/> instance call the GetDscCompilationJobs method from an instance of <see cref="AutomationAccountResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobCollection : ArmCollection, IAsyncEnumerable<DscCompilationJobResource>, IEnumerable<DscCompilationJobResource>, IEnumerable
    {
        /// <summary> Initializes a new instance of the <see cref="DscCompilationJobCollection"/> class for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        protected DscCompilationJobCollection()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Creates the Dsc compilation job of the configuration.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{compilationJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_Create</description>
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="compilationJobName"> The DSC configuration Id. </param>
        /// <param name="content"> The parameters supplied to the create compilation job operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual ArmOperation<DscCompilationJobResource> CreateOrUpdate(WaitUntil waitUntil, string compilationJobName, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Creates the Dsc compilation job of the configuration.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs/{compilationJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_Create</description>
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="compilationJobName"> The DSC configuration Id. </param>
        /// <param name="content"> The parameters supplied to the create compilation job operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<ArmOperation<DscCompilationJobResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string compilationJobName, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<bool> Exists(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<bool>> ExistsAsync(string compilationJobName, CancellationToken cancellationToken = default)
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<DscCompilationJobResource> Get(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve a list of dsc compilation jobs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_ListByAutomationAccount</description>
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
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscCompilationJobResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Pageable<DscCompilationJobResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Retrieve a list of dsc compilation jobs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationjobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DscCompilationJob_ListByAutomationAccount</description>
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
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscCompilationJobResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual AsyncPageable<DscCompilationJobResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<DscCompilationJobResource>> GetAsync(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual NullableResponse<DscCompilationJobResource> GetIfExists(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="compilationJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="compilationJobName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<NullableResponse<DscCompilationJobResource>> GetIfExistsAsync(string compilationJobName, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        IAsyncEnumerator<DscCompilationJobResource> IAsyncEnumerable<DscCompilationJobResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        IEnumerator<DscCompilationJobResource> IEnumerable<DscCompilationJobResource>.GetEnumerator()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
