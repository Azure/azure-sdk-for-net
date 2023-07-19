
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The alert.
    /// </summary>
    [JsonTransformation]
    public partial class Alert : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Alert class.
        /// </summary>
        public Alert() { }

        /// <summary>
        /// Initializes a new instance of the Alert class.
        /// </summary>
        /// <param name="title">The title of the alert</param>
        /// <param name="scope">The scope of the alert. Possible values
        /// include: 'Resource', 'Device'</param>
        /// <param name="alertType">The type of the alert</param>
        /// <param name="appearedAtTime">The UTC time at which the alert was
        /// raised</param>
        /// <param name="appearedAtSourceTime">The source time at which the
        /// alert was raised</param>
        /// <param name="source">The source at which the alert was
        /// raised</param>
        /// <param name="severity">The severity of the alert. Possible values
        /// include: 'Informational', 'Warning', 'Critical'</param>
        /// <param name="status">The current status of the alert. Possible
        /// values include: 'Active', 'Cleared'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="clearedAtTime">The UTC time at which the alert was
        /// cleared</param>
        /// <param name="clearedAtSourceTime">The source time at which the
        /// alert was cleared</param>
        /// <param name="recommendation">The recommended action for the issue
        /// raised in the alert</param>
        /// <param name="resolutionReason">The reason for resolving the
        /// alert</param>
        /// <param name="errorDetails">The details of the error for which the
        /// alert was raised</param>
        /// <param name="detailedInformation">More details about the
        /// alert</param>
        public Alert(string title, AlertScope scope, string alertType, System.DateTime appearedAtTime, System.DateTime appearedAtSourceTime, AlertSource source, AlertSeverity severity, AlertStatus status, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), System.DateTime? clearedAtTime = default(System.DateTime?), System.DateTime? clearedAtSourceTime = default(System.DateTime?), string recommendation = default(string), string resolutionReason = default(string), AlertErrorDetails errorDetails = default(AlertErrorDetails), IDictionary<string, string> detailedInformation = default(IDictionary<string, string>))
            : base(id, name, type, kind)
        {
            Title = title;
            Scope = scope;
            AlertType = alertType;
            AppearedAtTime = appearedAtTime;
            AppearedAtSourceTime = appearedAtSourceTime;
            ClearedAtTime = clearedAtTime;
            ClearedAtSourceTime = clearedAtSourceTime;
            Source = source;
            Recommendation = recommendation;
            ResolutionReason = resolutionReason;
            Severity = severity;
            Status = status;
            ErrorDetails = errorDetails;
            DetailedInformation = detailedInformation;
        }

        /// <summary>
        /// Gets or sets the title of the alert
        /// </summary>
        [JsonProperty(PropertyName = "properties.title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the scope of the alert. Possible values include:
        /// 'Resource', 'Device'
        /// </summary>
        [JsonProperty(PropertyName = "properties.scope")]
        public AlertScope Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the alert
        /// </summary>
        [JsonProperty(PropertyName = "properties.alertType")]
        public string AlertType { get; set; }

        /// <summary>
        /// Gets or sets the UTC time at which the alert was raised
        /// </summary>
        [JsonProperty(PropertyName = "properties.appearedAtTime")]
        public System.DateTime AppearedAtTime { get; set; }

        /// <summary>
        /// Gets or sets the source time at which the alert was raised
        /// </summary>
        [JsonProperty(PropertyName = "properties.appearedAtSourceTime")]
        public System.DateTime AppearedAtSourceTime { get; set; }

        /// <summary>
        /// Gets or sets the UTC time at which the alert was cleared
        /// </summary>
        [JsonProperty(PropertyName = "properties.clearedAtTime")]
        public System.DateTime? ClearedAtTime { get; set; }

        /// <summary>
        /// Gets or sets the source time at which the alert was cleared
        /// </summary>
        [JsonProperty(PropertyName = "properties.clearedAtSourceTime")]
        public System.DateTime? ClearedAtSourceTime { get; set; }

        /// <summary>
        /// Gets or sets the source at which the alert was raised
        /// </summary>
        [JsonProperty(PropertyName = "properties.source")]
        public AlertSource Source { get; set; }

        /// <summary>
        /// Gets or sets the recommended action for the issue raised in the
        /// alert
        /// </summary>
        [JsonProperty(PropertyName = "properties.recommendation")]
        public string Recommendation { get; set; }

        /// <summary>
        /// Gets or sets the reason for resolving the alert
        /// </summary>
        [JsonProperty(PropertyName = "properties.resolutionReason")]
        public string ResolutionReason { get; set; }

        /// <summary>
        /// Gets or sets the severity of the alert. Possible values include:
        /// 'Informational', 'Warning', 'Critical'
        /// </summary>
        [JsonProperty(PropertyName = "properties.severity")]
        public AlertSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the current status of the alert. Possible values
        /// include: 'Active', 'Cleared'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public AlertStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the details of the error for which the alert was
        /// raised
        /// </summary>
        [JsonProperty(PropertyName = "properties.errorDetails")]
        public AlertErrorDetails ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets more details about the alert
        /// </summary>
        [JsonProperty(PropertyName = "properties.detailedInformation")]
        public IDictionary<string, string> DetailedInformation { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Title == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Title");
            }
            if (AlertType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AlertType");
            }
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
        }
    }
}

