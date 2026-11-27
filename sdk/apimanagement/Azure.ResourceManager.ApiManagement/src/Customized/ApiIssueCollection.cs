// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiIssueCollection
    {
        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="issueId"> The resource identifier. </param>
        /// <param name="expandCommentsAttachments"> Whether to expand comment attachments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="issueId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="issueId"/> is empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Exists without a selector or GetIfExists to retrieve the resource with a selector.", false)]
        public virtual async Task<Response<bool>> ExistsAsync(string issueId, bool? expandCommentsAttachments, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(issueId, nameof(issueId));

            if (!expandCommentsAttachments.HasValue)
            {
                return await ExistsAsync(issueId, cancellationToken).ConfigureAwait(false);
            }

            using DiagnosticScope scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _apiIssueRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, expandCommentsAttachments, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response response = message.Response;
                if (response.Status == 404)
                {
                    return Response.FromValue(false, response);
                }
                if (response.Status == 200)
                {
                    return Response.FromValue(IssueContractData.FromResponse(response) != null, response);
                }
                throw new RequestFailedException(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="issueId"> The resource identifier. </param>
        /// <param name="expandCommentsAttachments"> Whether to expand comment attachments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="issueId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="issueId"/> is empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Exists without a selector or GetIfExists to retrieve the resource with a selector.", false)]
        public virtual Response<bool> Exists(string issueId, bool? expandCommentsAttachments, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(issueId, nameof(issueId));

            if (!expandCommentsAttachments.HasValue)
            {
                return Exists(issueId, cancellationToken);
            }

            using DiagnosticScope scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _apiIssueRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, issueId, expandCommentsAttachments, context);
                Pipeline.Send(message, context.CancellationToken);
                Response response = message.Response;
                if (response.Status == 404)
                {
                    return Response.FromValue(false, response);
                }
                if (response.Status == 200)
                {
                    return Response.FromValue(IssueContractData.FromResponse(response) != null, response);
                }
                throw new RequestFailedException(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
