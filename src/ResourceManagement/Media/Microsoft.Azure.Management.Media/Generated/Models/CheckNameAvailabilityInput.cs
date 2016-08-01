
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
    /// The request body for CheckNameAvailability API.
    /// </summary>
    public partial class CheckNameAvailabilityInput
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityInput class.
        /// </summary>
        public CheckNameAvailabilityInput() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityInput class.
        /// </summary>
        public CheckNameAvailabilityInput(string name = default(string), string type = default(string))
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// The name of the resource. A name must be globally unique.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Name != null)
            {
                if (this.Name.Length > 24)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Name", 24);
                }
                if (this.Name.Length < 3)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Name", 3);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Name, "^[a-z0-9]"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Name", "^[a-z0-9]");
                }
            }
        }
    }
}
