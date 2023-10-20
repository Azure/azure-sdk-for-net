public static partial class ArmDesktopVirtualizationModelFactory
{
    /// <param name="id"> The id. </param>
    /// <param name="name"> The name. </param>
    /// <param name="resourceType"> The resourceType. </param>
    /// <param name="systemData"> The systemData. </param>
    /// <param name="tags"> The tags. </param>
    /// <param name="location"> The location. </param>
    /// <param name="objectId"> ObjectId of HostPool. (internal use). </param>
    /// <param name="friendlyName"> Friendly name of HostPool. </param>
    /// <param name="description"> Description of HostPool. </param>
    /// <param name="hostPoolType"> HostPool type for desktop. </param>
    /// <param name="personalDesktopAssignmentType"> PersonalDesktopAssignment type for HostPool. </param>
    /// <param name="customRdpProperty"> Custom rdp property of HostPool. </param>
    /// <param name="maxSessionLimit"> The max session limit of HostPool. </param>
    /// <param name="loadBalancerType"> The type of the load balancer. </param>
    /// <param name="ring"> The ring number of HostPool. </param>
    /// <param name="isValidationEnvironment"> Is validation environment. </param>
    /// <param name="registrationInfo"> The registration info of HostPool. </param>
    /// <param name="vmTemplate"> VM template for sessionhosts configuration within hostpool. </param>
    /// <param name="applicationGroupReferences"> List of applicationGroup links. </param>
    /// <param name="ssoAdfsAuthority"> URL to customer ADFS server for signing WVD SSO certificates. </param>
    /// <param name="ssoClientId"> ClientId for the registered Relying Party used to issue WVD SSO certificates. </param>
    /// <param name="ssoClientSecretKeyVaultPath"> Path to Azure KeyVault storing the secret used for communication to ADFS. </param>
    /// <param name="ssoSecretType"> The type of single sign on Secret Type. </param>
    /// <param name="preferredAppGroupType"> The type of preferred application group type, default to Desktop Application Group. </param>
    /// <param name="startVmOnConnect"> The flag to turn on/off StartVMOnConnect feature. </param>
    /// <param name="isCloudPCResource"> Is cloud pc resource. </param>
    /// <param name="agentUpdate"> The session host configuration for updating agent, monitoring agent, and stack component. </param>
    /// <param name="managedBy"> The fully qualified resource ID of the resource that manages this resource. Indicates if this resource is managed by another Azure resource. If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource. </param>
    /// <param name="kind"> Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value. </param>
    /// <param name="etag"> The etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. </param>
    /// <param name="identity"> Gets or sets the identity. Current supported identity types: SystemAssigned. </param>
    /// <param name="sku"> The resource model definition representing SKU. </param>
    /// <param name="plan"> Gets or sets the plan. </param>
    public static HostPoolData HostPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string objectId, string friendlyName, string description, HostPoolType hostPoolType, PersonalDesktopAssignmentType? personalDesktopAssignmentType, string customRdpProperty, int? maxSessionLimit, HostPoolLoadBalancerType loadBalancerType, int? ring, bool? isValidationEnvironment, HostPoolRegistrationInfo registrationInfo, string vmTemplate, IReadOnlyList<string> applicationGroupReferences, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, HostPoolSsoSecretType? ssoSecretType, PreferredAppGroupType preferredAppGroupType, bool? startVmOnConnect, bool? isCloudPCResource, SessionHostAgentUpdateProperties agentUpdate, ResourceIdentifier managedBy, string kind, ETag? etag, ManagedServiceIdentity identity, DesktopVirtualizationSku sku, ArmPlan plan) : base(id, name, resourceType, systemData, tags, location)
        => HostPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string objectId, string friendlyName, string description, HostPoolType hostPoolType, PersonalDesktopAssignmentType? personalDesktopAssignmentType, string customRdpProperty, int? maxSessionLimit, HostPoolLoadBalancerType loadBalancerType, int? ring, bool? isValidationEnvironment, HostPoolRegistrationInfo registrationInfo, string vmTemplate, IReadOnlyList<string> applicationGroupReferences, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, HostPoolSsoSecretType? ssoSecretType, PreferredAppGroupType preferredAppGroupType, bool? startVmOnConnect, bool? isCloudPCResource, default, SessionHostAgentUpdateProperties agentUpdate, default, ResourceIdentifier managedBy, string kind, ETag? etag, ManagedServiceIdentity identity, DesktopVirtualizationSku sku, ArmPlan plan) : base(id, name, resourceType, systemData, tags, location);

    /// <summary> Initializes a new instance of HostPoolPatch. </summary>
    /// <param name="id"> The id. </param>
    /// <param name="name"> The name. </param>
    /// <param name="resourceType"> The resourceType. </param>
    /// <param name="systemData"> The systemData. </param>
    /// <param name="tags"> tags to be updated. </param>
    /// <param name="friendlyName"> Friendly name of HostPool. </param>
    /// <param name="description"> Description of HostPool. </param>
    /// <param name="customRdpProperty"> Custom rdp property of HostPool. </param>
    /// <param name="maxSessionLimit"> The max session limit of HostPool. </param>
    /// <param name="personalDesktopAssignmentType"> PersonalDesktopAssignment type for HostPool. </param>
    /// <param name="loadBalancerType"> The type of the load balancer. </param>
    /// <param name="ring"> The ring number of HostPool. </param>
    /// <param name="isValidationEnvironment"> Is validation environment. </param>
    /// <param name="registrationInfo"> The registration info of HostPool. </param>
    /// <param name="vmTemplate"> VM template for sessionhosts configuration within hostpool. </param>
    /// <param name="ssoAdfsAuthority"> URL to customer ADFS server for signing WVD SSO certificates. </param>
    /// <param name="ssoClientId"> ClientId for the registered Relying Party used to issue WVD SSO certificates. </param>
    /// <param name="ssoClientSecretKeyVaultPath"> Path to Azure KeyVault storing the secret used for communication to ADFS. </param>
    /// <param name="ssoSecretType"> The type of single sign on Secret Type. </param>
    /// <param name="preferredAppGroupType"> The type of preferred application group type, default to Desktop Application Group. </param>
    /// <param name="startVmOnConnect"> The flag to turn on/off StartVMOnConnect feature. </param>
    /// <param name="agentUpdate"> The session host configuration for updating agent, monitoring agent, and stack component. </param>
    public static HostPoolPatch HostPoolPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, string friendlyName, string description, string customRdpProperty, int? maxSessionLimit, PersonalDesktopAssignmentType? personalDesktopAssignmentType, HostPoolLoadBalancerType? loadBalancerType, int? ring, bool? isValidationEnvironment, HostPoolRegistrationInfoPatch registrationInfo, string vmTemplate, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, HostPoolSsoSecretType? ssoSecretType, PreferredAppGroupType? preferredAppGroupType, bool? startVmOnConnect, SessionHostAgentUpdatePatchProperties agentUpdate) : base(id, name, resourceType, systemData)
        => HostPoolPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, string friendlyName, string description, string customRdpProperty, int? maxSessionLimit, PersonalDesktopAssignmentType? personalDesktopAssignmentType, HostPoolLoadBalancerType? loadBalancerType, int? ring, bool? isValidationEnvironment, HostPoolRegistrationInfoPatch registrationInfo, string vmTemplate, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, HostPoolSsoSecretType? ssoSecretType, PreferredAppGroupType? preferredAppGroupType, bool? startVmOnConnect, default, SessionHostAgentUpdatePatchProperties agentUpdate)
}
