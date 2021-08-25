namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a Virtual Machine Image.
    /// </summary>
    public partial class VirtualMachineImage : VirtualMachineImageResource
    {

        /// <summary>
        /// Initializes a new instance of the VirtualMachineImage class.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="location">The supported Azure location of the
        /// resource.</param>
        /// <param name="id">Resource Id</param>
        /// <param name="tags">Specifies the tags that are assigned to the
        /// virtual machine. For more information about using tags, see [Using
        /// tags to organize your Azure
        /// resources](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-using-tags.md).</param>
        /// <param name="hyperVGeneration">Possible values include: 'V1',
        /// 'V2'</param>
        /// <param name="disallowed">Specifies disallowed configuration for the
        /// VirtualMachine created from the image</param>
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage, IList<DataDiskImage> dataDiskImages, AutomaticOSUpgradeProperties automaticOSUpgradeProperties, string hyperVGeneration, DisallowedConfiguration disallowed)
            : base(name, location, id, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            DataDiskImages = dataDiskImages;
            AutomaticOSUpgradeProperties = automaticOSUpgradeProperties;
            HyperVGeneration = hyperVGeneration;
            Disallowed = disallowed;
            CustomInit();
        }
        
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage, IList<DataDiskImage> dataDiskImages, AutomaticOSUpgradeProperties automaticOSUpgradeProperties, string hyperVGeneration)
            : base(name, location, id, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            DataDiskImages = dataDiskImages;
            AutomaticOSUpgradeProperties = automaticOSUpgradeProperties;
            HyperVGeneration = hyperVGeneration;
            CustomInit();
        }
        
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage, IList<DataDiskImage> dataDiskImages, AutomaticOSUpgradeProperties automaticOSUpgradeProperties)
            : base(name, location, id, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            DataDiskImages = dataDiskImages;
            AutomaticOSUpgradeProperties = automaticOSUpgradeProperties;
            CustomInit();
        }
        
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage, IList<DataDiskImage> dataDiskImages)
            : base(name, location, id, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            DataDiskImages = dataDiskImages;
            CustomInit();
        }
        
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage)
            : base(name, location, id, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            CustomInit();
        }
        
        public VirtualMachineImage(string name, string location, string id, IDictionary<string, string> tags, PurchasePlan plan)
            : base(name, location, id, tags)
        {
            Plan = plan;
            CustomInit();
        }
    }
}
