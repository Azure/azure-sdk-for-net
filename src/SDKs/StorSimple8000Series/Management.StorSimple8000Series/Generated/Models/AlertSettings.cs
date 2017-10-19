
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
    /// The alert settings.
    /// </summary>
    [JsonTransformation]
    public partial class AlertSettings : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the AlertSettings class.
        /// </summary>
        public AlertSettings() { }

        /// <summary>
        /// Initializes a new instance of the AlertSettings class.
        /// </summary>
        /// <param name="emailNotification">Indicates whether email
        /// notification enabled or not. Possible values include: 'Enabled',
        /// 'Disabled'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="alertNotificationCulture">The alert notification
        /// culture.</param>
        /// <param name="notificationToServiceOwners">The value indicating
        /// whether alert notification enabled for admin or not. Possible
        /// values include: 'Enabled', 'Disabled'</param>
        /// <param name="additionalRecipientEmailList">The alert notification
        /// email list.</param>
        public AlertSettings(AlertEmailNotificationStatus emailNotification, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), string alertNotificationCulture = default(string), AlertEmailNotificationStatus? notificationToServiceOwners = default(AlertEmailNotificationStatus?), IList<string> additionalRecipientEmailList = default(IList<string>))
            : base(id, name, type, kind)
        {
            EmailNotification = emailNotification;
            AlertNotificationCulture = alertNotificationCulture;
            NotificationToServiceOwners = notificationToServiceOwners;
            AdditionalRecipientEmailList = additionalRecipientEmailList;
        }

        /// <summary>
        /// Gets or sets indicates whether email notification enabled or not.
        /// Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.emailNotification")]
        public AlertEmailNotificationStatus EmailNotification { get; set; }

        /// <summary>
        /// Gets or sets the alert notification culture.
        /// </summary>
        [JsonProperty(PropertyName = "properties.alertNotificationCulture")]
        public string AlertNotificationCulture { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether alert notification
        /// enabled for admin or not. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.notificationToServiceOwners")]
        public AlertEmailNotificationStatus? NotificationToServiceOwners { get; set; }

        /// <summary>
        /// Gets or sets the alert notification email list.
        /// </summary>
        [JsonProperty(PropertyName = "properties.additionalRecipientEmailList")]
        public IList<string> AdditionalRecipientEmailList { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

