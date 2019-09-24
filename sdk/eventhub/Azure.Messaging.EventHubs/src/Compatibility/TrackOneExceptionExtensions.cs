// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   The set of extension methods for exception types defined in the
    ///   Track One client library.
    /// </summary>
    ///
    internal static class TrackOneExceptionExtensions
    {
        /// <summary>
        ///   Maps a <see cref="TrackOne.EventHubsException" /> or a child of it to the equivalent
        ///   exception for the new API surface.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The equivalent exception type for the new API, wrapping the <paramref name="instance" /> as the inner exception.</returns>
        ///
        public static Errors.EventHubsException MapToTrackTwoException(this TrackOne.EventHubsException instance)
        {
            Argument.AssertNotNull(instance, nameof(instance));

            return instance switch
            {
                TrackOne.EventHubsCommunicationException ex => new Errors.EventHubsCommunicationException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.EventHubsTimeoutException ex => new Errors.EventHubsTimeoutException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.MessagingEntityNotFoundException ex => new Errors.EventHubsResourceNotFoundException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.MessageSizeExceededException ex => new Errors.MessageSizeExceededException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.QuotaExceededException ex => new Errors.QuotaExceededException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.ReceiverDisconnectedException ex => new Errors.ConsumerDisconnectedException(ex.EventHubsNamespace, ex.RawMessage, ex),

                TrackOne.ServerBusyException ex => new Errors.ServiceBusyException(ex.EventHubsNamespace, ex.RawMessage, ex),

                _ => new Errors.EventHubsException(instance.IsTransient, instance.EventHubsNamespace, instance.RawMessage, instance),
            };
        }
    }
}
