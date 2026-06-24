// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A Class representing a DscCompilationJob along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DscCompilationJobResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetDscCompilationJobResource method.
    /// Otherwise you can get one from its parent resource <see cref="AutomationAccountResource"/> using the GetDscCompilationJob method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
    public partial class DscCompilationJobResource : ArmResource, IJsonModel<DscCompilationJobData>, IPersistableModel<DscCompilationJobData>
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static readonly ResourceType ResourceType = "Microsoft.Automation/automationAccounts/compilationjobs";

        /// <summary> Initializes a new instance of the <see cref="DscCompilationJobResource"/> class for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        protected DscCompilationJobResource()
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual DscCompilationJobData Data => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Gets whether or not the current instance has data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual bool HasData => throw DscCompilationJobCompatibilityHelpers.CreateException();

        /// <summary> Generate the resource identifier of a <see cref="DscCompilationJobResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="automationAccountName"> The automationAccountName. </param>
        /// <param name="compilationJobName"> The compilationJobName. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string compilationJobName)
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Response<DscCompilationJobResource> Get(CancellationToken cancellationToken = default)
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<Response<DscCompilationJobResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobData IJsonModel<DscCompilationJobData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        void IJsonModel<DscCompilationJobData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        DscCompilationJobData IPersistableModel<DscCompilationJobData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        string IPersistableModel<DscCompilationJobData>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }

        BinaryData IPersistableModel<DscCompilationJobData>.Write(ModelReaderWriterOptions options)
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
        /// <param name="content"> The parameters supplied to the create compilation job operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual ArmOperation<DscCompilationJobResource> Update(WaitUntil waitUntil, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
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
        /// <param name="content"> The parameters supplied to the create compilation job operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual Task<ArmOperation<DscCompilationJobResource>> UpdateAsync(WaitUntil waitUntil, DscCompilationJobCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
