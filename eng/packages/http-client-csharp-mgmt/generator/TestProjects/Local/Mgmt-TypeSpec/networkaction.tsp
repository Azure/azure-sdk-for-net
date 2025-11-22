import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";

using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/**
 * Network sibling set information returned by the query operation.
 * This is a non-resource model used in a provider-level LRO operation.
 */
model NetworkSiblingSet {
  /** Unique identifier for the sibling set */
  id: string;

  /** Name of the sibling set */
  name: string;

  /** Type of the resource */
  @visibility(Lifecycle.Read)
  type?: string;

  /** Properties of the network sibling set */
  properties?: NetworkSiblingSetProperties;
}

/**
 * Properties of the network sibling set
 */
model NetworkSiblingSetProperties {
  /** List of network siblings */
  siblings?: NetworkSibling[];

  /** Status of the query */
  @visibility(Lifecycle.Read)
  status?: string;
}

/**
 * Information about a network sibling
 */
model NetworkSibling {
  /** Subscription ID */
  subscriptionId?: string;

  /** Resource group name */
  resourceGroupName?: string;

  /** Network interface ID */
  networkInterfaceId?: string;
}

/**
 * Request for querying network sibling set
 */
model QueryNetworkSiblingSetRequest {
  /** Location to query */
  location: string;

  /** Subscription ID to query */
  subscriptionId?: string;
}

/**
 * Provider-level operations for network actions.
 * This demonstrates a non-resource LRO operation.
 */
interface NetworkProviderActions {
  /**
   * Query network sibling set - a provider-level async action.
   * This is a non-resource LRO operation that returns NetworkSiblingSet.
   */
  @action("queryNetworkSiblingSet")
  queryNetworkSiblingSet is ArmProviderActionAsync<
    QueryNetworkSiblingSetRequest,
    NetworkSiblingSet
  >;
}
