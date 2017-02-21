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
    /// Input values.
    /// </summary>
    public partial class OperationInputs
    {
        /// <summary>
        /// Initializes a new instance of the OperationInputs class.
        /// </summary>
        public OperationInputs() { }

        /// <summary>
        /// Initializes a new instance of the OperationInputs class.
        /// </summary>
        public OperationInputs(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the IoT hub to check.
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
        }
    }
}
