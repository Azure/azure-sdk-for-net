using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Rest.ClientRuntime.Tests.Resources.PolymorphicJsonConverterTest
{
    [JsonObject("Pet")]
    public class Pet
    {
        /// <summary>
        /// Initializes a new instance of the Pet class.
        /// </summary>
        public Pet() { }

        /// <summary>
        /// Initializes a new instance of the Pet class.
        /// </summary>
        public Pet(string name = default(string))
        {
            Name = name;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
