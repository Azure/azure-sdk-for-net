namespace Azure.ResourceManager.Foundations {
  // extended-location
  alias ExtendedLocation = CommonTypes.ExtendedLocation;
  alias ExtendedLocationType = CommonTypes.ExtendedLocationType;

  // managed-identities
  alias ManagedServiceIdentity = CommonTypes.ManagedServiceIdentity;
  #suppress "deprecated" "Need for back compatibility in common-types"
  alias UserAssignedIdentities = CommonTypes.UserAssignedIdentities;
  alias SystemAssignedServiceIdentity = CommonTypes.SystemAssignedServiceIdentity;
  alias UserAssignedIdentity = CommonTypes.UserAssignedIdentity;
  alias ManagedServiceIdentityType = CommonTypes.ManagedServiceIdentityType;
  alias SystemAssignedServiceIdentityType = CommonTypes.SystemAssignedServiceIdentityType;
  alias ManagedSystemIdentityType = SystemAssignedServiceIdentityType;

  // types
  alias Resource = CommonTypes.Resource;
  alias AzureEntityResource = CommonTypes.AzureEntityResource;
  alias TrackedResource = CommonTypes.TrackedResource;
  alias ProxyResource = CommonTypes.ProxyResource;
  alias ExtensionResource = CommonTypes.ExtensionResource;
  alias Sku = CommonTypes.Sku;
  alias SkuTier = CommonTypes.SkuTier;
  alias OperationListResult = CommonTypes.OperationListResult;
  alias Operation = CommonTypes.Operation;
  alias OperationDisplay = CommonTypes.OperationDisplay;
  alias OperationStatusResult = CommonTypes.OperationStatusResult;
  alias OperationIdParameter = CommonTypes.OperationIdParameter;
  alias ActionType = CommonTypes.ActionType;
  alias Origin = CommonTypes.Origin;
  alias ErrorDetail = CommonTypes.ErrorDetail;
  alias ErrorAdditionalInfo = CommonTypes.ErrorAdditionalInfo;
  alias SystemData = CommonTypes.SystemData;
  alias createdByType = CommonTypes.createdByType;
  alias Plan = CommonTypes.Plan;
  alias CheckNameAvailabilityRequest = CommonTypes.CheckNameAvailabilityRequest;
  alias CheckNameAvailabilityResponse = CommonTypes.CheckNameAvailabilityResponse;
  alias CheckNameAvailabilityReason = CommonTypes.CheckNameAvailabilityReason;
}
