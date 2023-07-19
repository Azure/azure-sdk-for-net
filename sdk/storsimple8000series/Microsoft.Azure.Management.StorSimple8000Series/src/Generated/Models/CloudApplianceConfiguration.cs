
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
    /// The cloud appliance configuration
    /// </summary>
    [JsonTransformation]
    public partial class CloudApplianceConfiguration : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the CloudApplianceConfiguration
        /// class.
        /// </summary>
        public CloudApplianceConfiguration() { }

        /// <summary>
        /// Initializes a new instance of the CloudApplianceConfiguration
        /// class.
        /// </summary>
        /// <param name="modelNumber">The model number.</param>
        /// <param name="cloudPlatform">The cloud platform.</param>
        /// <param name="acsConfiguration">The ACS configuration.</param>
        /// <param name="supportedStorageAccountTypes">The supported storage
        /// account types.</param>
        /// <param name="supportedRegions">The supported regions.</param>
        /// <param name="supportedVmTypes">The supported virtual machine
        /// types.</param>
        /// <param name="supportedVmImages">The supported virtual machine
        /// images.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public CloudApplianceConfiguration(string modelNumber, string cloudPlatform, AcsConfiguration acsConfiguration, IList<string> supportedStorageAccountTypes, IList<string> supportedRegions, IList<string> supportedVmTypes, IList<VmImage> supportedVmImages, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
            : base(id, name, type, kind)
        {
            ModelNumber = modelNumber;
            CloudPlatform = cloudPlatform;
            AcsConfiguration = acsConfiguration;
            SupportedStorageAccountTypes = supportedStorageAccountTypes;
            SupportedRegions = supportedRegions;
            SupportedVmTypes = supportedVmTypes;
            SupportedVmImages = supportedVmImages;
        }

        /// <summary>
        /// Gets or sets the model number.
        /// </summary>
        [JsonProperty(PropertyName = "properties.modelNumber")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// Gets or sets the cloud platform.
        /// </summary>
        [JsonProperty(PropertyName = "properties.cloudPlatform")]
        public string CloudPlatform { get; set; }

        /// <summary>
        /// Gets or sets the ACS configuration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.acsConfiguration")]
        public AcsConfiguration AcsConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the supported storage account types.
        /// </summary>
        [JsonProperty(PropertyName = "properties.supportedStorageAccountTypes")]
        public IList<string> SupportedStorageAccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the supported regions.
        /// </summary>
        [JsonProperty(PropertyName = "properties.supportedRegions")]
        public IList<string> SupportedRegions { get; set; }

        /// <summary>
        /// Gets or sets the supported virtual machine types.
        /// </summary>
        [JsonProperty(PropertyName = "properties.supportedVmTypes")]
        public IList<string> SupportedVmTypes { get; set; }

        /// <summary>
        /// Gets or sets the supported virtual machine images.
        /// </summary>
        [JsonProperty(PropertyName = "properties.supportedVmImages")]
        public IList<VmImage> SupportedVmImages { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ModelNumber == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ModelNumber");
            }
            if (CloudPlatform == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CloudPlatform");
            }
            if (AcsConfiguration == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AcsConfiguration");
            }
            if (SupportedStorageAccountTypes == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SupportedStorageAccountTypes");
            }
            if (SupportedRegions == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SupportedRegions");
            }
            if (SupportedVmTypes == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SupportedVmTypes");
            }
            if (SupportedVmImages == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SupportedVmImages");
            }
            if (AcsConfiguration != null)
            {
                AcsConfiguration.Validate();
            }
            if (SupportedVmImages != null)
            {
                foreach (var element in SupportedVmImages)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}

