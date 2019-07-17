// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;

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
            Guard.ArgumentNotNull(nameof(instance), instance);

            switch (instance)
            {
                case TrackOne.EventHubsCommunicationException ex:
                    return new Errors.EventHubsCommunicationException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.EventHubsTimeoutException ex:
                    return new Errors.EventHubsTimeoutException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.MessagingEntityNotFoundException ex:
                    return new Errors.EventHubsResourceNotFoundException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.MessageSizeExceededException ex:
                    return new Errors.MessageSizeExceededException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.QuotaExceededException ex:
                    return new Errors.QuotaExceededException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.ReceiverDisconnectedException ex:
                    return new Errors.ConsumerDisconnectedException(ex.EventHubsNamespace, ex.RawMessage, ex);

                case TrackOne.ServerBusyException ex:
                    return new Errors.ServiceBusyException(ex.EventHubsNamespace, ex.RawMessage, ex);

                default:
                    return new Errors.EventHubsException(instance.IsTransient, instance.EventHubsNamespace, instance.RawMessage, instance);
            }
        }
    }
}
