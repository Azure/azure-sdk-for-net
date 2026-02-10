import "./private-links.tsp";

using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

/** The private endpoint */
@@armCommonDefinition(PrivateEndpoint,
  "PrivateEndpoint",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpoint,
  "PrivateEndpoint",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpoint,
  "PrivateEndpoint",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpoint,
  "PrivateEndpoint",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** The private endpoint resource */
@@armCommonDefinition(PrivateLinkResource,
  "PrivateLinkResource",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResource,
  "PrivateLinkResource",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResource,
  "PrivateLinkResource",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResource,
  "PrivateLinkResource",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** PrivateEndpointConnection */
@@armCommonDefinition(PrivateEndpointConnection,
  "PrivateEndpointConnection",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnection,
  "PrivateEndpointConnection",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnection,
  "PrivateEndpointConnection",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnection,
  "PrivateEndpointConnection",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** Properties of he private endpoint connection resource */
@@armCommonDefinition(PrivateEndpointConnectionProperties,
  "PrivateEndpointConnectionProperties",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionProperties,
  "PrivateEndpointConnectionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionProperties,
  "PrivateEndpointConnectionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionProperties,
  "PrivateEndpointConnectionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** A collection of information about the state of the connection between service consumer and provider. */
@@armCommonDefinition(PrivateLinkServiceConnectionState,
  "PrivateLinkServiceConnectionState",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkServiceConnectionState,
  "PrivateLinkServiceConnectionState",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkServiceConnectionState,
  "PrivateLinkServiceConnectionState",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkServiceConnectionState,
  "PrivateLinkServiceConnectionState",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** Properties of a private link resource. */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-provisioning-state" "Matches current common code"
@@armCommonDefinition(PrivateLinkResourceProperties,
  "PrivateLinkResourceProperties",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceProperties,
  "PrivateLinkResourceProperties",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceProperties,
  "PrivateLinkResourceProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceProperties,
  "PrivateLinkResourceProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** PrivateEndpointConnectionListResult */
@@armCommonDefinition(PrivateEndpointConnectionListResultV5,
  "PrivateEndpointConnectionListResult",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionListResultV5,
  "PrivateEndpointConnectionListResult",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionListResultV5,
  "PrivateEndpointConnectionListResult",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionListResult,
  "PrivateEndpointConnectionListResult",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

/** PrivateLinkResourceListResult */
@@armCommonDefinition(PrivateLinkResourceListResultV5,
  "PrivateLinkResourceListResult",
  Azure.ResourceManager.CommonTypes.Versions.v3,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceListResultV5,
  "PrivateLinkResourceListResult",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceListResultV5,
  "PrivateLinkResourceListResult",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateLinkResourceListResult,
  "PrivateLinkResourceListResult",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);

// PrivateEndpointServiceConnectionStatus
@@armCommonDefinition(PrivateEndpointServiceConnectionStatus,
  "PrivateEndpointServiceConnectionStatus",
  Azure.ResourceManager.CommonTypes.Versions.v3,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointServiceConnectionStatus,
  "PrivateEndpointServiceConnectionStatus",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(PrivateEndpointServiceConnectionStatus,
  "PrivateEndpointServiceConnectionStatus",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(PrivateEndpointServiceConnectionStatus,
  "PrivateEndpointServiceConnectionStatus",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

// PrivateEndpointServiceConnectionStatus
@@armCommonDefinition(PrivateEndpointConnectionProvisioningState,
  "PrivateEndpointConnectionProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v3,
  "privatelinks.json"
);
@@armCommonDefinition(PrivateEndpointConnectionProvisioningState,
  "PrivateEndpointConnectionProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(PrivateEndpointConnectionProvisioningState,
  "PrivateEndpointConnectionProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(PrivateEndpointConnectionProvisioningState,
  "PrivateEndpointConnectionProvisioningState",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/** PrivateEndpointConnectionParameter */
@@CommonTypes.Private.armCommonParameter(PrivateEndpointConnectionParameter.name,
  "PrivateEndpointConnectionName",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "privatelinks.json"
);
@@CommonTypes.Private.armCommonParameter(PrivateEndpointConnectionParameter.name,
  "PrivateEndpointConnectionName",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "privatelinks.json"
);
@@CommonTypes.Private.armCommonParameter(PrivateEndpointConnectionParameter.name,
  "PrivateEndpointConnectionName",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "privatelinks.json"
);
@@CommonTypes.Private.armCommonParameter(PrivateEndpointConnectionParameter.name,
  "PrivateEndpointConnectionName",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "privatelinks.json"
);
