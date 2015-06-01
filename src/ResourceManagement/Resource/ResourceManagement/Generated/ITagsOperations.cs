using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// </summary>
    public partial interface ITagsOperations
    {
        /// <summary>
        /// Delete a subscription resource tag value.
        /// </summary>
        /// <param name='tagName'>
        /// The name of the tag.
        /// </param>
        /// <param name='tagValue'>
        /// The value of the tag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteValueWithOperationResponseAsync(string tagName, string tagValue, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a subscription resource tag value.
        /// </summary>
        /// <param name='tagName'>
        /// The name of the tag.
        /// </param>
        /// <param name='tagValue'>
        /// The value of the tag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<TagValue>> CreateOrUpdateValueWithOperationResponseAsync(string tagName, string tagValue, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a subscription resource tag.
        /// </summary>
        /// <param name='tagName'>
        /// The name of the tag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<TagDetails>> CreateOrUpdateWithOperationResponseAsync(string tagName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a subscription resource tag.
        /// </summary>
        /// <param name='tagName'>
        /// The name of the tag.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string tagName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of subscription resource tags.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<TagsListResult>> ListWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of subscription resource tags.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<TagsListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
