using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract]
    public enum HostCaching
    {
        [EnumMember]
        None,

        [EnumMember]
        ReadOnly,

        [EnumMember]
        ReadWrite
    }
}
