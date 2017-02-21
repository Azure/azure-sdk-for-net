// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Use to provide parameters when requesting an import of all devices in
    /// the hub.
    /// </summary>
    public partial class ImportDevicesRequest
    {
        /// <summary>
        /// Initializes a new instance of the ImportDevicesRequest class.
        /// </summary>
        public ImportDevicesRequest() { }

        /// <summary>
        /// Initializes a new instance of the ImportDevicesRequest class.
        /// </summary>
        public ImportDevicesRequest(string inputBlobContainerUri, string outputBlobContainerUri)
        {
            InputBlobContainerUri = inputBlobContainerUri;
            OutputBlobContainerUri = outputBlobContainerUri;
        }

        /// <summary>
        /// The input blob container URI.
        /// </summary>
        [JsonProperty(PropertyName = "InputBlobContainerUri")]
        public string InputBlobContainerUri { get; set; }

        /// <summary>
        /// The output blob container URI.
        /// </summary>
        [JsonProperty(PropertyName = "OutputBlobContainerUri")]
        public string OutputBlobContainerUri { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (InputBlobContainerUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "InputBlobContainerUri");
            }
            if (OutputBlobContainerUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "OutputBlobContainerUri");
            }
        }
    }
}
