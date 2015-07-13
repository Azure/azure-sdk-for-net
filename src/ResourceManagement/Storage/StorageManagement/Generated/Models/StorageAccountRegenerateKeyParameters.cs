namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class StorageAccountRegenerateKeyParameters
    {
        /// <summary>
        /// Possible values for this property include: 'key1', 'key2'
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public KeyName? KeyName { get; set; }

    }
}
