// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventHubsException" /> class.
    /// </summary>
    ///
    internal static class EventHubsExceptionExtensions
    {
        /// <summary>
        ///   Gets the data value related to the exception <see cref="EventHubsException.FailureReason" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The Data value or null.</returns>
        ///
        public static T GetFailureReasonData<T>(this EventHubsException instance) where T: class =>
            instance.Data.Contains(instance.Reason) ?
                instance.Data[instance.Reason] as T:
                null;

        /// <summary>
        ///   Sets the data value related to the exception <see cref="EventHubsException.FailureReason" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="data">The value to store in the Exception Data.</param>
        ///
        public static void SetFailureReasonData<T>(this EventHubsException instance, T data) where T: class =>
            instance.Data[instance.Reason] = data;
    }
}
