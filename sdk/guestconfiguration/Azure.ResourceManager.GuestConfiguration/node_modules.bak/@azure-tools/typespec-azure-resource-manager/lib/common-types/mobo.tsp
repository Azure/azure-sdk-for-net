using Azure.Core;
using Versioning;

namespace Azure.ResourceManager.CommonTypes;

/** Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages those resources on behalf of the resource owner. */
@added(Versions.v5)
model ManagedOnBehalfOfConfiguration {
  /** Managed-On-Behalf-Of broker resources */
  @visibility(Lifecycle.Read)
  moboBrokerResources?: MoboBrokerResource[];
}

/** Managed-On-Behalf-Of broker resource. This resource is created by the Resource Provider to manage some resources on behalf of the user. */
@added(Versions.v5)
model MoboBrokerResource {
  /** Resource identifier of a Managed-On-Behalf-Of broker resource */
  id?: Azure.Core.armResourceIdentifier;
}
