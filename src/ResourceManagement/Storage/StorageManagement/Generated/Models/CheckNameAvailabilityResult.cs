namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The CheckNameAvailability operation response.
    /// </summary>
    public partial class CheckNameAvailabilityResult
    {
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available
        /// for you to use. If true, the name is available. If false, the
        /// name has already been taken or invalid and cannot be used.
        /// </summary>
        [JsonProperty(PropertyName = "nameAvailable")]
        public bool? NameAvailable { get; set; }

        /// <summary>
        /// Gets the reason that a storage account name could not be used. The
        /// Reason element is only returned if NameAvailable is false.
        /// Possible values for this property include: 'AccountNameInvalid',
        /// 'AlreadyExists'
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public Reason? Reason { get; set; }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
