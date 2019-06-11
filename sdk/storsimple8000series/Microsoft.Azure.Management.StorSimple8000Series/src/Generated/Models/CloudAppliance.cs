
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The cloud appliance.
    /// </summary>
    public partial class CloudAppliance
    {
        /// <summary>
        /// Initializes a new instance of the CloudAppliance class.
        /// </summary>
        public CloudAppliance() { }

        /// <summary>
        /// Initializes a new instance of the CloudAppliance class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vnetRegion">The virtual network region.</param>
        /// <param name="vnetName">The name of the virtual network.</param>
        /// <param name="isVnetDnsConfigured">Indicates whether virtual network
        /// used is configured with DNS or not.</param>
        /// <param name="isVnetExpressConfigured">Indicates whether virtual
        /// network used is configured with express route or not.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <param name="storageAccountName">The name of the storage
        /// account.</param>
        /// <param name="storageAccountType">The type of the storage
        /// account.</param>
        /// <param name="vmType">The type of the virtual machine.</param>
        /// <param name="vmImageName">The name of the virtual machine
        /// image.</param>
        /// <param name="modelNumber">The model number.</param>
        public CloudAppliance(string name, string vnetRegion, string vnetName = default(string), bool? isVnetDnsConfigured = default(bool?), bool? isVnetExpressConfigured = default(bool?), string subnetName = default(string), string storageAccountName = default(string), string storageAccountType = default(string), string vmType = default(string), string vmImageName = default(string), string modelNumber = default(string))
        {
            Name = name;
            VnetName = vnetName;
            VnetRegion = vnetRegion;
            IsVnetDnsConfigured = isVnetDnsConfigured;
            IsVnetExpressConfigured = isVnetExpressConfigured;
            SubnetName = subnetName;
            StorageAccountName = storageAccountName;
            StorageAccountType = storageAccountType;
            VmType = vmType;
            VmImageName = vmImageName;
            ModelNumber = modelNumber;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the virtual network.
        /// </summary>
        [JsonProperty(PropertyName = "vnetName")]
        public string VnetName { get; set; }

        /// <summary>
        /// Gets or sets the virtual network region.
        /// </summary>
        [JsonProperty(PropertyName = "vnetRegion")]
        public string VnetRegion { get; set; }

        /// <summary>
        /// Gets or sets indicates whether virtual network used is configured
        /// with DNS or not.
        /// </summary>
        [JsonProperty(PropertyName = "isVnetDnsConfigured")]
        public bool? IsVnetDnsConfigured { get; set; }

        /// <summary>
        /// Gets or sets indicates whether virtual network used is configured
        /// with express route or not.
        /// </summary>
        [JsonProperty(PropertyName = "isVnetExpressConfigured")]
        public bool? IsVnetExpressConfigured { get; set; }

        /// <summary>
        /// Gets or sets the name of the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "subnetName")]
        public string SubnetName { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "storageAccountName")]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the type of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "storageAccountType")]
        public string StorageAccountType { get; set; }

        /// <summary>
        /// Gets or sets the type of the virtual machine.
        /// </summary>
        [JsonProperty(PropertyName = "vmType")]
        public string VmType { get; set; }

        /// <summary>
        /// Gets or sets the name of the virtual machine image.
        /// </summary>
        [JsonProperty(PropertyName = "vmImageName")]
        public string VmImageName { get; set; }

        /// <summary>
        /// Gets or sets the model number.
        /// </summary>
        [JsonProperty(PropertyName = "modelNumber")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (VnetRegion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VnetRegion");
            }
        }
    }
}

