
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Output of check name availability API.
    /// </summary>
    public partial class CheckNameAvailabilityOutput
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityOutput
        /// class.
        /// </summary>
        public CheckNameAvailabilityOutput() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityOutput
        /// class.
        /// </summary>
        /// <param name="nameAvailable">Indicates whether the name is
        /// available.</param>
        /// <param name="reason">The reason why the name is not
        /// available.</param>
        /// <param name="message">The detailed error message describing why
        /// the name is not available.</param>
        public CheckNameAvailabilityOutput(bool? nameAvailable = default(bool?), string reason = default(string), string message = default(string))
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }

        /// <summary>
        /// Gets or sets indicates whether the name is available.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "NameAvailable")]
        public bool? NameAvailable { get; set; }

        /// <summary>
        /// Gets or sets the reason why the name is not available.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the detailed error message describing why the name is
        /// not available.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

    }
}
