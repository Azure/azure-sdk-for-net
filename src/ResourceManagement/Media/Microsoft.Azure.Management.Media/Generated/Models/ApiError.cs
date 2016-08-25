
namespace Microsoft.Azure.Management.Media.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The error returned from a failed Media Services REST API call.
    /// </summary>
    public partial class ApiError
    {
        /// <summary>
        /// Initializes a new instance of the ApiError class.
        /// </summary>
        public ApiError() { }

        /// <summary>
        /// Initializes a new instance of the ApiError class.
        /// </summary>
        public ApiError(string code = default(string), string message = default(string))
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
