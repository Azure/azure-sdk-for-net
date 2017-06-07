using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "OSVirtualHardDisk", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class OSVirtualHardDisk : AzureDataContractBase
    {
        private OSVirtualHardDisk() { }

        public static OSVirtualHardDisk OSDiskFromVirtualDisk(string diskName, OperatingSystemType osType, string label = null, HostCaching caching = HostCaching.ReadWrite)
        {
            return new OSVirtualHardDisk
            {
                HostCaching = caching,
                DiskLabel = label,
                DiskName = diskName,
                OSType = osType
            };
        }

        public static OSVirtualHardDisk OSDiskFromImage(string imageName, OperatingSystemType osType, Uri targetBlob, string label = null, HostCaching caching = HostCaching.ReadWrite)
        {
            return new OSVirtualHardDisk
            {
                HostCaching = caching,
                DiskLabel = label,
                SourceImageName = imageName,
                OSType = osType,
                MediaLink = targetBlob
            };
        }

        public static OSVirtualHardDisk OSDiskFromLink(Uri mediaLink, OperatingSystemType osType, string label = null, HostCaching caching = HostCaching.ReadWrite)
        {
            return new OSVirtualHardDisk
            {
                HostCaching = caching,
                DiskLabel = label,
                MediaLink = mediaLink,
                OSType = osType
            };
        }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public HostCaching HostCaching { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string DiskLabel { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public string DiskName { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public Uri MediaLink { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public string SourceImageName { get; private set; }

        [DataMember(Name="OS", Order = 5, IsRequired=true)]
        public OperatingSystemType OSType { get; private set; }
    }
}
