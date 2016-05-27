
namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Regenerate key parameters.
    /// </summary>
    public partial class RegenerateKeyParameters
    {
        /// <summary>
        /// Initializes a new instance of the RegenerateKeyParameters class.
        /// </summary>
        public RegenerateKeyParameters() { }

        /// <summary>
        /// Initializes a new instance of the RegenerateKeyParameters class.
        /// </summary>
        public RegenerateKeyParameters(KeyName? keyName = default(KeyName?))
        {
            KeyName = keyName;
        }

        /// <summary>
        /// key name to generate (Key1|Key2). Possible values include: 'Key1',
        /// 'Key2'
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public KeyName? KeyName { get; set; }

    }
}
