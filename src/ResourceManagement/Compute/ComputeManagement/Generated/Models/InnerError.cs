namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Inner error details.
    /// </summary>
    public partial class InnerError
    {
        /// <summary>
        /// Gets or sets the exception type.
        /// </summary>
        [JsonProperty(PropertyName = "exceptiontype")]
        public string Exceptiontype { get; set; }

        /// <summary>
        /// Gets or sets the internal error message or exception dump.
        /// </summary>
        [JsonProperty(PropertyName = "errordetail")]
        public string Errordetail { get; set; }

    }
}
