//-----------------------------------------------------------------------
// <copyright file="QueueErrorCodeStrings.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the QueueErrorCodeStrings class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Provides error code strings that are specific to the Queue service.
    /// </summary>
    public static class QueueErrorCodeStrings
    {
        /// <summary>
        /// Error code that may be returned when the specified queue was not found.
        /// </summary>
        public const string QueueNotFound = "QueueNotFound";

        /// <summary>
        /// Error code that may be returned when the specified queue is disabled.
        /// </summary>
        public const string QueueDisabled = "QueueDisabled";

        /// <summary>
        /// Error code that may be returned when the specified queue already exists.
        /// </summary>
        public const string QueueAlreadyExists = "QueueAlreadyExists";

        /// <summary>
        /// Error code that may be returned when the specified queue is not empty.
        /// </summary>
        public const string QueueNotEmpty = "QueueNotEmpty";

        /// <summary>
        /// Error code that may be returned when the specified queue is being deleted.
        /// </summary>
        public const string QueueBeingDeleted = "QueueBeingDeleted";

        /// <summary>
        /// Error code that may be returned when the specified pop receipt does not match.
        /// </summary>
        public const string PopReceiptMismatch = "PopReceiptMismatch";

        /// <summary>
        /// Error code that may be returned when one or more request parameters are invalid.
        /// </summary>
        public const string InvalidParameter = "InvalidParameter";

        /// <summary>
        /// Error code that may be returned when the specified message was not found.
        /// </summary>
        public const string MessageNotFound = "MessageNotFound";

        /// <summary>
        /// Error code that may be returned when the specified message is too large.
        /// </summary>
        public const string MessageTooLarge = "MessageTooLarge";

        /// <summary>
        /// Error code that may be returned when the specified marker is invalid.
        /// </summary>
        public const string InvalidMarker = "InvalidMarker";
    }
}