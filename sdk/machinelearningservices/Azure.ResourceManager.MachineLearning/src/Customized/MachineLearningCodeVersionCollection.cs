// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningCodeVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningCodeVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningCodeContainerResource" />.
    /// To get a <see cref="MachineLearningCodeVersionCollection" /> instance call the GetMachineLearningCodeVersions method from an instance of <see cref="MachineLearningCodeContainerResource" />.
    /// </summary>
    public partial class MachineLearningCodeVersionCollection : ArmCollection, IEnumerable<MachineLearningCodeVersionResource>, IAsyncEnumerable<MachineLearningCodeVersionResource>
    {
        /// <summary>
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/codes/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CodeVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningCodeVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningCodeVersionResource> GetAllAsync(string orderBy, int? top, string skip, CancellationToken cancellationToken) => GetAllAsync(orderBy, top, skip, null, null, cancellationToken);

        /// <summary>
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/codes/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CodeVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningCodeVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningCodeVersionResource> GetAll(string orderBy, int? top, string skip, CancellationToken cancellationToken) => GetAll(orderBy, top, skip, null, null, cancellationToken);
    }
}
