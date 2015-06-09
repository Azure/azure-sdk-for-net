using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Storage.Models
{
    /// <summary>
    /// </summary>
    public partial class StorageAccountRegenerateKeyParameters
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public string KeyName { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
