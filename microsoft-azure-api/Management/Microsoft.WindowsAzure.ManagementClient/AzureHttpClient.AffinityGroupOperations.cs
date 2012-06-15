//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.AffinityGroupOperations.cs" 
//            company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the AffinityGroup operations of AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    public partial class AzureHttpClient
    {
        /// <summary>
        /// Begins an asychronous operation to list the affinity groups 
        /// associated with the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns an <see cref="AffinityGroupCollection"/></returns>
        public Task<AffinityGroupCollection> ListAffinityGroupsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.AffinityGroups));

            return StartGetTask<AffinityGroupCollection>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to create an affinity group.
        /// </summary>
        /// <param name="name">A name for the affinity group that is unique to the subscription. Required.</param>
        /// <param name="label">The label for the affinity group, may be up to 100 characters in length. Required.</param>
        /// <param name="description">A description for the affinity group. May be up to 1024 characters in length. Optional, may be null.</param>
        /// <param name="location">A location for the affinity group. Valid values are returned from <see cref="AzureHttpClient.ListLocationsAsync"/>. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing CreateCloudServiceAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> CreateAffinityGroupAsync(string name, string label, string description, string location, CancellationToken token = default(CancellationToken))
        {
            CreateAffinityGroupInfo info = CreateAffinityGroupInfo.Create(name, label, description, location);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.AffinityGroups), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to delete an affinity group.
        /// </summary>
        /// <param name="affinityGroupName">The name of the affinity group to delete.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing DeleteAffinityGroupAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> DeleteAffinityGroupAsync(string affinityGroupName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(affinityGroupName, "affinityGroupName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.AffinityGroupsAndAffinityGroup, affinityGroupName));

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to get the properties of an affinity group.
        /// </summary>
        /// <param name="affinityGroupName">The name of the affinity group.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns an <see cref="AffinityGroup"/> object.</returns>
        public Task<AffinityGroup> GetAffinityGroupAsync(string affinityGroupName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(affinityGroupName, "affinityGroupName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.AffinityGroupsAndAffinityGroup, affinityGroupName));

            return StartGetTask<AffinityGroup>(message, token);
        }
    }
}
