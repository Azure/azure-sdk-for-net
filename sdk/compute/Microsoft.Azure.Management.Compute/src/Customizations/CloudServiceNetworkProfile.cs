namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CloudServiceNetworkProfile
    {
        public CloudServiceNetworkProfile(IList<LoadBalancerConfiguration> loadBalancerConfigurations, SubResource swappableCloudService)
        {
            LoadBalancerConfigurations = loadBalancerConfigurations;
            SwappableCloudService = swappableCloudService;
            CustomInit();
        }
    }
}