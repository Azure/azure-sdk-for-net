// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Provides data for <see cref="SearchIndexingBufferedSender{T}.ActionAdded"/>
    /// and <see cref="SearchIndexingBufferedSender{T}.ActionSent"/> events.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this type
    /// can be retrieved as documents from the index.  You can use
    /// <see cref="SearchDocument"/> for dynamic documents.
    /// </typeparam>
    public class IndexActionEventArgs<T> : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="SearchIndexingBufferedSender{T}"/> raising the
        /// event.
        /// </summary>
        public SearchIndexingBufferedSender<T> Sender { get; }

        /// <summary>
        /// Gets the <see cref="IndexDocumentsAction{T}"/> that was added,
        /// sent, completed, or failed.
        /// </summary>
        public IndexDocumentsAction<T> Action { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexActionEventArgs{T}"/>
        /// class.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="SearchIndexingBufferedSender{T}"/> raising the event.
        /// </param>
        /// <param name="action">
        /// The <see cref="IndexDocumentsAction{T}"/> that was added, sent,
        /// completed, or failed.
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="sender"/> or <paramref name="action"/>
        /// are null.
        /// </exception>
        public IndexActionEventArgs(
            SearchIndexingBufferedSender<T> sender,
            IndexDocumentsAction<T> action,
            bool isRunningSynchronously,
            CancellationToken cancellationToken = default)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(sender, nameof(sender));
            Argument.AssertNotNull(action, nameof(action));
            Sender = sender;
            Action = action;
        }
    }
}
