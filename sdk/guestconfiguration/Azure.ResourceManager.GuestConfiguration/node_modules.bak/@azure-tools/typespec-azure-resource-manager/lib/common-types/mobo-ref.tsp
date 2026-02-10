import "./mobo.tsp";
using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

/** This configuration exists for the resources where a resource provider manages those resources on behalf of the resource owner. */
@@armCommonDefinition(ManagedOnBehalfOfConfiguration,
  "ManagedOnBehalfOfConfiguration",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "mobo.json"
);
@@armCommonDefinition(ManagedOnBehalfOfConfiguration,
  "ManagedOnBehalfOfConfiguration",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "mobo.json"
);

/** This resource is created by the Resource Provider to manage some resources on behalf of the user. */
@@armCommonDefinition(MoboBrokerResource,
  "MoboBrokerResource",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "mobo.json"
);
@@armCommonDefinition(MoboBrokerResource,
  "MoboBrokerResource",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "mobo.json"
);
