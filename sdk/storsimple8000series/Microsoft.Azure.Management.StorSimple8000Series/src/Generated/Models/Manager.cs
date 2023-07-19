
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
    /// The StorSimple Manager.
    /// </summary>
    [JsonTransformation]
    public partial class Manager : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Manager class.
        /// </summary>
        public Manager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Manager class.
        /// </summary>
        /// <param name="location">The geo location of the resource.</param>
        /// <param name="id">The resource ID.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="type">The resource type.</param>
        /// <param name="tags">The tags attached to the resource.</param>
        /// <param name="cisIntrinsicSettings">Represents the type of
        /// StorSimple Manager.</param>
        /// <param name="provisioningState">Specifies the state of the resource
        /// as it is getting provisioned. Value of "Succeeded" means the
        /// Manager was successfully created.</param>
        /// <param name="etag">The etag of the manager.</param>
        public Manager(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), ManagerIntrinsicSettings cisIntrinsicSettings = default(ManagerIntrinsicSettings), string provisioningState = default(string), string etag = default(string))
            : base(location, id, name, type, tags)
        {
            CisIntrinsicSettings = cisIntrinsicSettings;
            ProvisioningState = provisioningState;
            Etag = etag;
        }
        /// <summary>
        /// Static constructor for Manager class.
        /// </summary>
        static Manager()
        {
            Sku = new ManagerSku();
        }

        /// <summary>
        /// Gets or sets represents the type of StorSimple Manager.
        /// </summary>
        [JsonProperty(PropertyName = "properties.cisIntrinsicSettings")]
        public ManagerIntrinsicSettings CisIntrinsicSettings { get; set; }

        /// <summary>
        /// Gets or sets specifies the state of the resource as it is getting
        /// provisioned. Value of "Succeeded" means the Manager was
        /// successfully created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the etag of the manager.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Specifies the Sku.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sku")]
        public static ManagerSku Sku { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (CisIntrinsicSettings != null)
            {
                CisIntrinsicSettings.Validate();
            }
        }
    }
}

