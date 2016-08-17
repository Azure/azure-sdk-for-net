using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public enum KnownWindowsVirtualMachineImage
    {
        [EnumName("MicrosoftWindowsServer WindowsServer 2008-R2-SP1")]
        WINDOWS_SERVER_2008_R2_SP1,
        [EnumName("MicrosoftWindowsServer WindowsServer 2012-Datacenter")]
        WINDOWS_SERVER_2012_DATACENTER,
        [EnumName("MicrosoftWindowsServer WindowsServer 2012-R2-Datacenter")]
        WINDOWS_SERVER_2012_R2_DATACENTER,
        [EnumName("MicrosoftWindowsServer WindowsServer 2016-Technical-Preview-with-Containers")]
        WINDOWS_SERVER_2016_TECHNICAL_PREVIEW_WITH_CONTAINERS,
        [EnumName("MicrosoftWindowsServer WindowsServer Windows-Server-Technical-Preview")]
        WINDOWS_SERVER_TECHNICAL_PREVIEW
    }
}
