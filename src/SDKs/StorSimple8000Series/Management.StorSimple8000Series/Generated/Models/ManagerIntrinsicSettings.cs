
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Intrinsic settings which refers to the type of the Storsimple Manager.
    /// </summary>
    public partial class ManagerIntrinsicSettings
    {
        /// <summary>
        /// Initializes a new instance of the ManagerIntrinsicSettings class.
        /// </summary>
        public ManagerIntrinsicSettings() { }

        /// <summary>
        /// Initializes a new instance of the ManagerIntrinsicSettings class.
        /// </summary>
        /// <param name="type">The type of StorSimple Manager. Possible values
        /// include: 'GardaV1', 'HelsinkiV1'</param>
        public ManagerIntrinsicSettings(ManagerType type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the type of StorSimple Manager. Possible values
        /// include: 'GardaV1', 'HelsinkiV1'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ManagerType Type { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

