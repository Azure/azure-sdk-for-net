// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using CoreWCF;

namespace Azure.Storage.CoreWCF.Channels
{
    internal static class AzureQueueStorageChannelHelpers
    {
        /// <summary>
        /// The Channel layer normalizes exceptions thrown by the underlying networking implementations
        /// into subclasses of CommunicationException, so that Channels can be used polymorphically from
        /// an exception handling perspective.
        /// </summary>
        internal static CommunicationException ConvertTransferException(Exception e)
        {
            return new CommunicationException(
                string.Format(CultureInfo.CurrentCulture,
                "An error ({0}) occurred while transmitting message.", e.Message),
                e);
        }

        internal static void ThrowIfDisposedOrNotOpen(object state)
        {
            switch (state)
            {
                case CommunicationState.Created:
                case CommunicationState.Opening:
                case CommunicationState.Closing:
                case CommunicationState.Closed:
                case CommunicationState.Faulted:
                    throw new CommunicationException("ThrowIfDisposedOrNotOpen: Communicate object not in open state. Current state: " + state.ToString());
                default:
                    throw new CommunicationException("ThrowIfDisposedOrNotOpen: Unknown CommunicationObject.state");
                case CommunicationState.Opened:
                    break;
            }
        }

        internal static void ValidateTimeout(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(timeout), timeout, "Timeout must be greater than or equal to TimeSpan.Zero. To disable timeout, specify TimeSpan.MaxValue.");
            }
        }
    }
}
