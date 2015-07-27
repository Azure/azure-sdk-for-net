namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The response body contains the status of the specified asynchronous
    /// operation, indicating whether it has succeeded, is inprogress, or has
    /// failed. Note that this status is distinct from the HTTP status code
    /// returned for the Get Operation Status operation itself. If the
    /// asynchronous operation succeeded, the response body includes the HTTP
    /// status code for the successful request. If the asynchronous operation
    /// failed, the response body includes the HTTP status code for the
    /// failed request and error information regarding the failure.
    /// </summary>
    public partial class AzureAsyncOperationResult
    {
        /// <summary>
        /// Status of the AzureAsuncOperation. Possible values for this
        /// property include: 'InProgress', 'Succeeded', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public OperationStatus? Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

    }
}
