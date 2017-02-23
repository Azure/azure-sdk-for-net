using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Rest.ClientRuntime.Tests.Resources.PolymorphicJsonConverterTest
{
    public class Horse : Pet
    {
        /// <summary>
        /// Initializes a new instance of the Horse class.
        /// </summary>
        public Horse() { }

        /// <summary>
        /// Initializes a new instance of the Horse class.
        /// </summary>
        public Horse(string name = default(string), int? speed = default(int?))
            : base(name)
        {
            Speed = speed;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "speed")]
        public int? Speed { get; set; }
    }
}
