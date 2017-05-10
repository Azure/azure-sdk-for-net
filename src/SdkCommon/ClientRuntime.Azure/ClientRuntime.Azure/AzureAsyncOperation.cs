// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// The response body contains the status of the specified
    /// asynchronous operation, indicating whether it has succeeded, is in
    /// progress, or has failed. Note that this status is distinct from the
    /// HTTP status code returned for the Get Operation Status operation
    /// itself.  If the asynchronous operation succeeded, the response body
    /// includes the HTTP status code for the successful request.  If the
    /// asynchronous operation failed, the response body includes the HTTP
    /// status code for the failed request, and also includes error
    /// information regarding the failure.
    /// </summary>
    public class AzureAsyncOperation
    {
        /// <summary>
        /// Default delay in seconds for long running operations.
        /// </summary>
        public const int DefaultDelay = 30;

        /// <summary>
        /// Successful status for long running operations.
        /// </summary>
        public const string SuccessStatus = "Succeeded";

        /// <summary>
        /// In progress status for long running operations.
        /// </summary>
        public const string InProgressStatus = "InProgress";

        /// <summary>
        /// Failed status for long running operations.
        /// </summary>
        public const string FailedStatus = "Failed";

        /// <summary>
        /// Canceled status for long running operations.
        /// </summary>
        public const string CanceledStatus = "Canceled";
        
        /// <summary>
        /// Failed terminal statuses for long running operations.
        /// </summary>
        public static IEnumerable<string> FailedStatuses
        {
            get { return new[] { FailedStatus, CanceledStatus }; }   
        }

        /// <summary>
        /// Terminal statuses for long running operations.
        /// </summary>
        public static IEnumerable<string> TerminalStatuses
        {
            get { return FailedStatuses.Union(new []{ SuccessStatus }); }
        }

        /// <summary>
        /// The status of the asynchronous request.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// If the asynchronous operation failed, the response body includes
        /// the HTTP status code for the failed request, and also includes
        /// error information regarding the failure.
        /// </summary>
        public CloudError Error { get; set; }

        /// <summary>
        /// Gets or sets the delay in seconds that should be used when checking 
        /// for the status of the operation.  
        /// </summary>
        public int RetryAfter { get; set; }
     }
}
