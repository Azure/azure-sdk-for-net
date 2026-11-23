// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    public partial class ApiIssueCollection
    {
        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="issueId"> The resource identifier. </param>
        /// <param name="expandCommentsAttachments"> Whether to expand comment attachments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="issueId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="issueId"/> is empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string issueId, bool? expandCommentsAttachments = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issueId, nameof(issueId));

            return await CollectionExistsCompatibility.SendAsync(
                _apiIssueClientDiagnostics, Pipeline, "ApiIssueCollection.Exists",
                context => expandCommentsAttachments.HasValue
                    ? _apiIssueRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, expandCommentsAttachments, context)
                    : _apiIssueRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, context),
                !expandCommentsAttachments.HasValue, IssueContractData.FromResponse, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="issueId"> The resource identifier. </param>
        /// <param name="expandCommentsAttachments"> Whether to expand comment attachments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="issueId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="issueId"/> is empty. </exception>
        public virtual Response<bool> Exists(string issueId, bool? expandCommentsAttachments = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issueId, nameof(issueId));

            return CollectionExistsCompatibility.Send(
                _apiIssueClientDiagnostics, Pipeline, "ApiIssueCollection.Exists",
                context => expandCommentsAttachments.HasValue
                    ? _apiIssueRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, expandCommentsAttachments, context)
                    : _apiIssueRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, context),
                !expandCommentsAttachments.HasValue, IssueContractData.FromResponse, cancellationToken);
        }
    }
}
