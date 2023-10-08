// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningJobResource" /> and their operations.
    /// Each <see cref="MachineLearningJobResource" /> in the collection will belong to the same instance of <see cref="MachineLearningWorkspaceResource" />.
    /// To get a <see cref="MachineLearningJobCollection" /> instance call the GetMachineLearningJobs method from an instance of <see cref="MachineLearningWorkspaceResource" />.
    /// </summary>
    public partial class MachineLearningJobCollection : ArmCollection, IEnumerable<MachineLearningJobResource>, IAsyncEnumerable<MachineLearningJobResource>
    {
        /// <summary>
        /// Lists Jobs in the workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/jobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Jobs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="jobType"> Type of job to be returned. </param>
        /// <param name="tag"> Jobs returned will have this tag key. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningJobResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningJobResource> GetAllAsync(string skip, string jobType, string tag, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAllAsync(new MachineLearningJobCollectionGetAllOptions() { Skip = skip, JobType = jobType, Tag = tag, ListViewType = listViewType, AssetName = null, Scheduled = null, ScheduleId = null }, cancellationToken);

        /// <summary>
        /// Lists Jobs in the workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/jobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Jobs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="jobType"> Type of job to be returned. </param>
        /// <param name="tag"> Jobs returned will have this tag key. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningJobResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningJobResource> GetAll(string skip, string jobType, string tag, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAll(new MachineLearningJobCollectionGetAllOptions() { Skip = skip, JobType = jobType, Tag = tag, ListViewType = listViewType, AssetName = null, Scheduled = null, ScheduleId = null }, cancellationToken);
    }
}
