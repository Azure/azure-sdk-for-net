
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
    /// The list of cognitive services accounts operation response.
    /// </summary>
    public partial class CognitiveServicesAccountEnumerateSkusResult
    {
        /// <summary>
        /// Initializes a new instance of the
        /// CognitiveServicesAccountEnumerateSkusResult class.
        /// </summary>
        public CognitiveServicesAccountEnumerateSkusResult() { }

        /// <summary>
        /// Initializes a new instance of the
        /// CognitiveServicesAccountEnumerateSkusResult class.
        /// </summary>
        public CognitiveServicesAccountEnumerateSkusResult(IList<CognitiveServicesResourceAndSku> value = default(IList<CognitiveServicesResourceAndSku>))
        {
            Value = value;
        }

        /// <summary>
        /// Gets the list of Cognitive Services accounts and their properties.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<CognitiveServicesResourceAndSku> Value { get; private set; }

    }
}
