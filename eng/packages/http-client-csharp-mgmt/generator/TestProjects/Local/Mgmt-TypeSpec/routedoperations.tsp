import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

// This file tests the RoutedOperations pattern with dynamic parent types.
// The PrivateEndpointConnection resource uses {parentType}/{parentName} in its path,
// where parentType is an enum that gets expanded into concrete resources per value.

/** Parent event grid topic resource */
model EventGridTopic is TrackedResource<EventGridTopicProperties> {
  ...ResourceNameParameter<
    Resource = EventGridTopic,
    KeyName = "topicName",
    SegmentName = "eventGridTopics"
  >;
}

/** EventGrid topic properties */
model EventGridTopicProperties {
  /** Topic endpoint */
  endpoint?: string;
}

/** Parent event grid domain resource */
model EventGridDomain is TrackedResource<EventGridDomainProperties> {
  ...ResourceNameParameter<
    Resource = EventGridDomain,
    KeyName = "domainName",
    SegmentName = "eventGridDomains"
  >;
}

/** EventGrid domain properties */
model EventGridDomainProperties {
  /** Domain endpoint */
  endpoint?: string;
}

/** Enum for parent type of the EventGrid private endpoint connection */
union EventGridPrivateEndpointConnectionParentType {
  string,
  /** Topics */
  eventGridTopics: "eventGridTopics",
  /** Domains */
  eventGridDomains: "eventGridDomains",
}

/** EventGrid private endpoint connection model */
model EventGridPrivateEndpointConnection
  is ProxyResource<EventGridPrivateEndpointConnectionProperties> {
  ...ResourceNameParameter<EventGridPrivateEndpointConnection>;
}

/** Private endpoint connection properties */
model EventGridPrivateEndpointConnectionProperties {
  /** Connection status */
  status?: string;
  /** Description */
  description?: string;
}

@armResourceOperations
interface EventGridTopics {
  get is ArmResourceRead<EventGridTopic>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<EventGridTopic>;
  delete is ArmResourceDeleteWithoutOkAsync<EventGridTopic>;
  listByResourceGroup is ArmResourceListByParent<EventGridTopic>;
}

@armResourceOperations
interface EventGridDomains {
  get is ArmResourceRead<EventGridDomain>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<EventGridDomain>;
  delete is ArmResourceDeleteWithoutOkAsync<EventGridDomain>;
  listByResourceGroup is ArmResourceListByParent<EventGridDomain>;
}

@armResourceOperations
interface EventGridPrivateEndpointConnectionOps
  extends Azure.ResourceManager.Legacy.RoutedOperations<
      {
        ...ApiVersionParameter,
        ...SubscriptionIdParameter,
        ...ResourceGroupParameter,
        @path parentType: EventGridPrivateEndpointConnectionParentType,
        @path parentName: string,
      },
      {
        @path eventGridPrivateEndpointConnectionName: string,
      },
      ResourceRoute = #{
        route: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/{parentType}/{parentName}",
      }
    > {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "RoutedOperations pattern"
@armResourceOperations(#{ allowStaticRoutes: true })
interface EventGridPrivateEndpointConnections {
  @get
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/{parentType}/{parentName}/eventGridPrivateEndpointConnections/{eventGridPrivateEndpointConnectionName}")
  get is EventGridPrivateEndpointConnectionOps.ActionSync<
    EventGridPrivateEndpointConnection,
    void,
    EventGridPrivateEndpointConnection
  >;

  @put
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/{parentType}/{parentName}/eventGridPrivateEndpointConnections/{eventGridPrivateEndpointConnectionName}")
  update is EventGridPrivateEndpointConnectionOps.ActionSync<
    EventGridPrivateEndpointConnection,
    EventGridPrivateEndpointConnection,
    EventGridPrivateEndpointConnection
  >;

  @delete
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/{parentType}/{parentName}/eventGridPrivateEndpointConnections/{eventGridPrivateEndpointConnectionName}")
  delete is EventGridPrivateEndpointConnectionOps.ActionAsync<
    EventGridPrivateEndpointConnection,
    void,
    void
  >;
}
