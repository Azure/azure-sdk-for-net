namespace Azure.ResourceManager.Foundations;

#deprecated "Please use Foundations.Resource instead of Foundations.ArmResource"
alias ArmResource = Resource;

#deprecated "Please use Foundations.TrackedResource instead of Foundations.TrackedResourceBase"
alias TrackedResourceBase = TrackedResource;

#deprecated "Please use Foundations.ProxyResource instead of Foundations.ProxyResourceBase"
alias ProxyResourceBase = ProxyResource;

#deprecated "Please use Foundations.ProxyResource instead of Foundations.ExtensionResourceBase"
alias ExtensionResourceBase = ExtensionResource;

#deprecated "Please use Foundations.Sku instead of Foundations.ResourceSkuType"
alias ResourceSkuType = Sku;

#deprecated "Please use Foundations.Plan instead of Foundations.ResourcePlanType"
alias ResourcePlanType = Plan;

// managed-identity
#deprecated "Please change ManagedIdentityProperties to ManagedServiceIdentity."
alias ManagedIdentityProperties = ManagedServiceIdentity;

#deprecated "Please change ManagedSystemIdentityProperties to SystemAssignedServiceIdentity."
alias ManagedSystemIdentityProperties = SystemAssignedServiceIdentity;

/** Alias of ManagedServiceIdentityType for back compatability. Please change to ManagedServiceIdentityType. */
#deprecated "Please change to ManagedServiceIdentityType."
alias ManagedIdentityType = ManagedServiceIdentityType;
