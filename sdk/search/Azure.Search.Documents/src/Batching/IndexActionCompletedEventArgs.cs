// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Provides data for <see cref="SearchIndexingBufferedSender{T}.ActionCompleted"/>
    /// event.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this type
    /// can be retrieved as documents from the index.  You can use
    /// <see cref="SearchDocument"/> for dynamic documents.
    /// </typeparam>
    public class IndexActionCompletedEventArgs<T> : IndexActionEventArgs<T>
    {
        /// <summary>
        /// Gets the <see cref="IndexingResult"/> of an action that was
        /// successfully completed.
        /// </summary>
        public IndexingResult Result { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="IndexActionCompletedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="SearchIndexingBufferedSender{T}"/> raising the event.
        /// </param>
        /// <param name="action">
        /// The <see cref="IndexDocumentsAction{T}"/> that was completed.
        /// </param>
        /// <param name="result">
        /// The <see cref="IndexingResult"/> of an action that was successfully
        /// completed.
        /// </param>
        /// <param name="isRunningSynchronously">
        /// A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token related to the original operation that raised
        /// the event.  It's important for your handler to pass this token
        /// along to any asynchronous or long-running synchronous operations
        /// that take a token so cancellation will correctly propagate.  The
        /// default value is <see cref="CancellationToken.None"/>.
        /// </param>
        /// <exception cref = "System.ArgumentNullException" >
        /// Thrown if <paramref name="sender"/>, <paramref name="action"/>, or
        /// <paramref name="result"/> are null.
        /// </exception>
        public IndexActionCompletedEventArgs(
            SearchIndexingBufferedSender<T> sender,
            IndexDocumentsAction<T> action,
            IndexingResult result,
            bool isRunningSynchronously,
            CancellationToken cancellationToken = default)
            : base(sender, action, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(result, nameof(result));
            Result = result;
        }
    }
}
