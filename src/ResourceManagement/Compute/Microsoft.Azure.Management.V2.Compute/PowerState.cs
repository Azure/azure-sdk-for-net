using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public enum PowerState
    {
        [EnumName("PowerState/running")]
        RUNNING,
        [EnumName("PowerState/deallocating")]
        DEALLOCATING,
        [EnumName("PowerState/deallocated")]
        DEALLOCATED,
        [EnumName("PowerState/starting")]
        STARTING
    }
}
