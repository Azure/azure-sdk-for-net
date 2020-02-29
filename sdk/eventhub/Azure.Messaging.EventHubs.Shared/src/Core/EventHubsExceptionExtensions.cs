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
        ///   The key to fetch the data FailureData value from the exception Data property.
        /// </summary>
        private const string FailureDataKey = "FailureData";

        /// <summary>
        ///   The key to fetch the data FailureOperation value from the exception Data property.
        /// </summary>
        private const string FailureOperationKey = "FailureOperation";

        /// <summary>
        ///   Gets the data value related to the exception <see cref="EventHubsException.FailureReason" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The Data value or null.</returns>
        ///
        public static T GetFailureData<T>(this EventHubsException instance) where T : class =>
            instance.Data.Contains(FailureDataKey) ?
                instance.Data[FailureDataKey] as T :
                null;

        /// <summary>
        ///   Gets the failed operation name related to the exception.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The failed operation name.</returns>
        ///
        public static string GetFailureOperation(this EventHubsException instance) =>
            instance.Data.Contains(FailureOperationKey) ?
                instance.Data[FailureOperationKey] as string :
                string.Empty;

        /// <summary>
        ///   Sets the data value related to the exception.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="data">The value to store in the Exception Data.</param>
        ///
        public static void SetFailureData<T>(this EventHubsException instance, T data) where T : class =>
            instance.Data[FailureDataKey] = data;

        /// <summary>
        ///   Sets the failed operation name related to the exception.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="operationName">The failed operation name.</param>
        ///
        public static void SetFailureOperation(this EventHubsException instance, string operationName) =>
            instance.Data[FailureOperationKey] = operationName;
    }
}
