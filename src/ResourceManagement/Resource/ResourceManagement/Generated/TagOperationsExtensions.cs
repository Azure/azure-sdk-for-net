using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    public static partial class TagOperationsExtensions
    {
            /// <summary>
            /// Delete a subscription resource tag value.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='tagValue'>
            /// The value of the tag.
            /// </param>
            public static void DeleteValue(this ITagOperations operations, string tagName, string tagValue)
            {
                Task.Factory.StartNew(s => ((ITagOperations)s).DeleteValueAsync(tagName, tagValue), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a subscription resource tag value.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='tagValue'>
            /// The value of the tag.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteValueAsync( this ITagOperations operations, string tagName, string tagValue, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteValueWithOperationResponseAsync(tagName, tagValue, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a subscription resource tag value.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='tagValue'>
            /// The value of the tag.
            /// </param>
            public static TagValue CreateOrUpdateValue(this ITagOperations operations, string tagName, string tagValue)
            {
                return Task.Factory.StartNew(s => ((ITagOperations)s).CreateOrUpdateValueAsync(tagName, tagValue), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a subscription resource tag value.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='tagValue'>
            /// The value of the tag.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<TagValue> CreateOrUpdateValueAsync( this ITagOperations operations, string tagName, string tagValue, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<TagValue> result = await operations.CreateOrUpdateValueWithOperationResponseAsync(tagName, tagValue, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Create a subscription resource tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            public static TagDetails CreateOrUpdate(this ITagOperations operations, string tagName)
            {
                return Task.Factory.StartNew(s => ((ITagOperations)s).CreateOrUpdateAsync(tagName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a subscription resource tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<TagDetails> CreateOrUpdateAsync( this ITagOperations operations, string tagName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<TagDetails> result = await operations.CreateOrUpdateWithOperationResponseAsync(tagName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Delete a subscription resource tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            public static void Delete(this ITagOperations operations, string tagName)
            {
                Task.Factory.StartNew(s => ((ITagOperations)s).DeleteAsync(tagName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a subscription resource tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='tagName'>
            /// The name of the tag.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this ITagOperations operations, string tagName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(tagName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get a list of subscription resource tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static TagsListResult List(this ITagOperations operations)
            {
                return Task.Factory.StartNew(s => ((ITagOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of subscription resource tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<TagsListResult> ListAsync( this ITagOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<TagsListResult> result = await operations.ListWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
