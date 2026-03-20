// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;

// TODO: This is a temporary customization to add the RegenerateAdminKey operation, will be removed after https://github.com/Azure/azure-sdk-for-net/issues/57303 is resolved.
namespace Azure.ResourceManager.Search
{
    public partial class SearchServiceResource : ArmResource
    {
        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Search/searchServices/{searchServiceName}/regenerateAdminKey/{keyKind}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SearchServices_Regenerate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SearchServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="keyKind"> Specifies which key to regenerate. Valid values include 'primary' and 'secondary'. </param>
        /// <param name="searchManagementRequestOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchServiceAdminKeyResult>> RegenerateAdminKeyAsync(SearchServiceAdminKeyKind keyKind, SearchManagementRequestOptions searchManagementRequestOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _adminKeysClientDiagnostics.CreateScope("SearchServiceResource.RegenerateAdminKey");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _adminKeysRestClient.CreateRegenerateAdminKeyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, keyKind.ToSerialString(), default, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SearchServiceAdminKeyResult> response = Response.FromValue(SearchServiceAdminKeyResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Regenerates either the primary or secondary admin API key. You can only regenerate one key at a time.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Search/searchServices/{searchServiceName}/regenerateAdminKey/{keyKind}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SearchServices_Regenerate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SearchServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="keyKind"> Specifies which key to regenerate. Valid values include 'primary' and 'secondary'. </param>
        /// <param name="searchManagementRequestOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchServiceAdminKeyResult> RegenerateAdminKey(SearchServiceAdminKeyKind keyKind, SearchManagementRequestOptions searchManagementRequestOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _adminKeysClientDiagnostics.CreateScope("SearchServiceResource.RegenerateAdminKey");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _adminKeysRestClient.CreateRegenerateAdminKeyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, keyKind.ToSerialString(), default, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SearchServiceAdminKeyResult> response = Response.FromValue(SearchServiceAdminKeyResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
