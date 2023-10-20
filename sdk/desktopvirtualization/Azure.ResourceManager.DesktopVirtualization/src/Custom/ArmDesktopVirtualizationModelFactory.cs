public static partial class ArmDesktopVirtualizationModelFactory
{
    /// <summary> Initializes a new instance of HostPoolData. </summary>
    /// <param name="location"> The location. </param>
    /// <param name="hostPoolType"> HostPool type for desktop. </param>
    /// <param name="loadBalancerType"> The type of the load balancer. </param>
    /// <param name="preferredAppGroupType"> The type of preferred application group type, default to Desktop Application Group. </param>
    public static HostPoolData HostPoolData(AzureLocation location, HostPoolType hostPoolType, HostPoolLoadBalancerType loadBalancerType, PreferredAppGroupType preferredAppGroupType)
        => HostPoolData(AzureLocation location, HostPoolType hostPoolType, HostPoolLoadBalancerType loadBalancerType, PreferredAppGroupType preferredAppGroupType); redirect this method from old code to the method in new code, if there is any parameter missing, using `default` or `null`.
}
