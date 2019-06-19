
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents the base class for all other ARM object models
    /// </summary>
    public partial class BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the BaseModel class.
        /// </summary>
        public BaseModel() { }

        /// <summary>
        /// Initializes a new instance of the BaseModel class.
        /// </summary>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public BaseModel(string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
        {
            Id = id;
            Name = name;
            Type = type;
            Kind = kind;
        }

        /// <summary>
        /// Gets the path ID that uniquely identifies the object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; protected set; }

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; protected set; }

        /// <summary>
        /// Gets the hierarchical type of the object.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }

        /// <summary>
        /// Gets or sets the Kind of the object. Currently only Series8000 is
        /// supported. Possible values include: 'Series8000'
        /// </summary>
        [JsonProperty(PropertyName = "kind")]
        public Kind? Kind { get; set; }

    }
}

