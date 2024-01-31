

namespace Microsoft.Azure.Management.Compute.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Disk update resource.
    /// </summary>
    public partial class SupportedCapabilities
    {

        public SupportedCapabilities(bool? acceleratedNetwork , string architecture = default(string))
        {
            AcceleratedNetwork = acceleratedNetwork;
            Architecture = architecture;
            CustomInit();
        }

    }
}
