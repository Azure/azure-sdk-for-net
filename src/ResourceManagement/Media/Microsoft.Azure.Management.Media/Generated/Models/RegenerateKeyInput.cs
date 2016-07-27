
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
    /// The request body for a RegenerateKey API.
    /// </summary>
    public partial class RegenerateKeyInput
    {
        /// <summary>
        /// Initializes a new instance of the RegenerateKeyInput class.
        /// </summary>
        public RegenerateKeyInput() { }

        /// <summary>
        /// Initializes a new instance of the RegenerateKeyInput class.
        /// </summary>
        public RegenerateKeyInput(KeyType? keyType = default(KeyType?))
        {
            KeyType = keyType;
        }

        /// <summary>
        /// The keyType indicating which key you want to regenerate, Primary
        /// or Secondary. Possible values include: 'Primary', 'Secondary'
        /// </summary>
        [JsonProperty(PropertyName = "keyType")]
        public KeyType? KeyType { get; set; }

    }
}
