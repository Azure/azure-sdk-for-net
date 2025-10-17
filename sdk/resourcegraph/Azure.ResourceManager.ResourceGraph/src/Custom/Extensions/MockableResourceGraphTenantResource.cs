// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ResourceGraph.Models;

namespace Azure.ResourceManager.ResourceGraph.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MockableResourceGraphTenantResource : ArmResource
    {
        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BinaryData>> GetResourceHistoryAsync(ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.");
        }

        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BinaryData> GetResourceHistory(ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.");
        }
    }
}
