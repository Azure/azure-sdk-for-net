# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47b551f58ee1b24f4783c2e927b1673b39d87348/specification/webpubsub/resource-manager/readme.md
tag: package-2021-10-01
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.WebPubSub
modelerfour:
  lenient-model-deduplication: true
  naming:
    override:
      ACLAction: AclAction
      networkACLs: networkAcls
      NetworkACL: NetworkAcl
      PrivateEndpointACL: PrivateEndpointAcl
      WebPubSubNetworkACLs: WebPubSubNetworkAcls
      SharedPrivateLinkResourceStatus: SharedPrivateLinkStatus
      PrivateLinkResource: PrivateLink
      PrivateLinkResourceList: PrivateLinkList
      PrivateLinkResourceProperties: PrivateLinkProperties
      shareablePrivateLinkResourceTypes: shareablePrivateLinkTypes
      ShareablePrivateLinkResourceType: ShareablePrivateLinkType
      ShareablePrivateLinkResourceProperties: ShareablePrivateLinkProperties
      ResourceSku: WebPubSubSku
model-namespace: false
no-property-type-replacement: PrivateEndpoint
list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}/eventHandlers/eventHandlerName
directive:
  # Change SharedPrivateLinkResource to SharedPrivateLink
  ## rename models
  - rename-model:
      from: SharedPrivateLinkResource
      to: SharedPrivateLink
  - rename-model:
      from: SharedPrivateLinkResourceList
      to: SharedPrivateLinkList 
  - rename-model:
      from: SharedPrivateLinkResourceProperties
      to: SharedPrivateLinkProperties 
  # - rename-model:
  #     from: SharedPrivateLinkResourceStatus
  #     to: SharedPrivateLinkStatus 
  - rename-model:
      from: sharedPrivateLinkResources
      to: sharedPrivateLinks 
  - from: swagger-document
    where: $.definitions.SharedPrivateLink
    transform: $.properties.properties.$ref = "#/definitions/SharedPrivateLinkProperties"
  - from: swagger-document
    where: $.definitions.SharedPrivateLinkList
    transform: $.properties.value.items.$ref = "#/definitions/SharedPrivateLink" 
  # - from: swagger-document
  #   where: $.definitions.SharedPrivateLinkProperties
  #   transform: $.properties.status.$ref = "#/definitions/SharedPrivateLinkStatus" 
  # - from: swagger-document
  #   where: $.definitions.SharedPrivateLinkStatus
  #   transform: $.x-ms-enum.name = "SharedPrivateLinkStatus" 

  ## rename paths
  - from: swagger-document
    where: $.paths
    transform: >
      for (var key in $) {
          const newKey = key.replace('sharedPrivateLinkResourceName', 'sharedPrivateLinkName');
          if (newKey !== key) {
              $[newKey] = $[key]
              delete $[key]
          }
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources'].get
    transform: $.operationId = "WebPubSubSharedPrivateLinks_List"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources'].get.responses.200.schema
    transform: $.$ref = "#/definitions/SharedPrivateLinkList"

  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].get
    transform: $.operationId = "WebPubSubSharedPrivateLinks_Get"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].get.parameters
    transform: >
        $[0] = {
            "name": "sharedPrivateLinkName",
            "in": "path",
            "description": "The name of the shared private link",
            "required": true,
            "type": "string"
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].get.responses.200.schema
    transform: $.$ref = "#/definitions/SharedPrivateLink"

  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put
    transform: $.operationId = "WebPubSubSharedPrivateLinks_CreateOrUpdate"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put
    transform: $.parameters[0].name = "sharedPrivateLinkName"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put.parameters
    transform:  >
        $[0] = {
            "name": "sharedPrivateLinkName",
            "in": "path",
            "description": "The name of the shared private link",
            "required": true,
            "type": "string"
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put.parameters
    transform:  >
        $[1] = {
            "name": "parameters",
            "in": "body",
            "description": "The shared private link",
            "required": true,
            "schema": {
              "$ref": "#/definitions/SharedPrivateLink"
            }
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put.responses.200.schema
    transform: $.$ref = "#/definitions/SharedPrivateLink"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put.responses.201.schema
    transform: $.$ref = "#/definitions/SharedPrivateLink"

  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].delete
    transform: $.operationId = "WebPubSubSharedPrivateLinks_Delete"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].delete
    transform: $.parameters[0].name = "sharedPrivateLinkName"

  # Change WebPubSubResource to WebPubSub
  - rename-model:
      from: WebPubSubResource
      to: WebPubSub
  - rename-model:
      from: WebPubSubResourceList
      to: WebPubSubList
  - from: swagger-document
    where: $.definitions.WebPubSubList
    transform: $.properties.value.items.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.SignalRService/webPubSub'].get.responses.200.schema
    transform: $.$ref = "#/definitions/WebPubSubList"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub'].get.responses.200.schema
    transform: $.$ref = "#/definitions/WebPubSubList"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].get.responses.200.schema
    transform: $.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].put
    transform: $.parameters[0].schema.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].put.responses.200.schema
    transform: $.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].put.responses.201.schema
    transform: $.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].patch
    transform: $.parameters[0].schema.$ref = "#/definitions/WebPubSub"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}'].patch.responses.200.schema
    transform: $.$ref = "#/definitions/WebPubSub"

  # Change NetworkACL to NetworkAcl
  - from: swagger-document
    where: $.definitions.WebPubSubProperties.properties.networkACLs
    transform: $.description = "Network Acls"

  # Delete LRO [WebPubSub] prefix
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources'].get
    transform: $.operationId = "SharedPrivateLinks_List"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].get
    transform: $.operationId = "SharedPrivateLinks_Get"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].put
    transform: $.operationId = "SharedPrivateLinks_CreateOrUpdate"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkName}'].delete
    transform: $.operationId = "SharedPrivateLinks_Delete"
```
