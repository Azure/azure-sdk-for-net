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
    /// Use to provide parameters when requesting an export of all devices in
    /// the IoT hub.
    /// </summary>
    public partial class ExportDevicesRequest
    {
        /// <summary>
        /// Initializes a new instance of the ExportDevicesRequest class.
        /// </summary>
        public ExportDevicesRequest() { }

        /// <summary>
        /// Initializes a new instance of the ExportDevicesRequest class.
        /// </summary>
        public ExportDevicesRequest(string exportBlobContainerUri, bool excludeKeys)
        {
            ExportBlobContainerUri = exportBlobContainerUri;
            ExcludeKeys = excludeKeys;
        }

        /// <summary>
        /// The export blob container URI.
        /// </summary>
        [JsonProperty(PropertyName = "ExportBlobContainerUri")]
        public string ExportBlobContainerUri { get; set; }

        /// <summary>
        /// The value indicating whether keys should be excluded during export.
        /// </summary>
        [JsonProperty(PropertyName = "ExcludeKeys")]
        public bool ExcludeKeys { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (ExportBlobContainerUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ExportBlobContainerUri");
            }
        }
    }
}
