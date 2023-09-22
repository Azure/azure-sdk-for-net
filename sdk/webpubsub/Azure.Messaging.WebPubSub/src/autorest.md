# Azure.Messaging.WebPubSub Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest Configuration
> see https://aka.ms/autorest

## Swagger Source(s)
``` yaml
title: WebPubSubServiceClient
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/1735a92bdc79b446385a36ba063ea5235680709f/specification/webpubsub/data-plane/WebPubSub/stable/2022-11-01/webpubsub.json
credential-types: AzureKeyCredential
credential-header-name: Ocp-Apim-Subscription-Key
keep-non-overloadable-protocol-signature: true
```

### Make WebPubSubPermission a regular enum
``` yaml
directive:
- from: swagger-document
  where: $..[?(@.name=="WebPubSubPermission")]
  transform: $.modelAsString = false;
```

### GenerateClientTokenImpl
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:generateToken"].post.operationId
  transform: return "WebPubSubService_GenerateClientTokenImpl";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:generateToken"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:generateToken"].post
  transform: $["x-accessibility"] = "internal"
```

### SendToAll
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:send"].post.operationId
  transform: return "WebPubSubService_SendToAll";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:send"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### ConnectionExistsImpl
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}"].head.operationId
  transform: return "WebPubSubService_ConnectionExistsImpl";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}"].head.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}"].head
  transform: $["x-accessibility"] = "internal"
```

### CloseConnection
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}"].delete.operationId
  transform: return "WebPubSubService_CloseConnection";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### SendToConnection
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}/:send"].post.operationId
  transform: return "WebPubSubService_SendToConnection";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}/:send"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### GroupExistsImpl
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}"].head.operationId
  transform: return "WebPubSubService_GroupExistsImpl";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}"].head.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}"].head
  transform: $["x-accessibility"] = "internal"
```

### SendToGroup
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/:send"].post.operationId
  transform: return "WebPubSubService_SendToGroup";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/:send"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### AddConnectionToGroup
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/connections/{connectionId}"].put.operationId
  transform: return "WebPubSubService_AddConnectionToGroup";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/connections/{connectionId}"].put.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### RemoveConnectionFromGroup
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/connections/{connectionId}"].delete.operationId
  transform: return "WebPubSubService_RemoveConnectionFromGroup";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/connections/{connectionId}"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### UserExistsImpl
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}"].head.operationId
  transform: return "WebPubSubService_UserExistsImpl";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}"].head.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}"].head
  transform: $["x-accessibility"] = "internal"
```

### SendToUser
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/:send"].post.operationId
  transform: return "WebPubSubService_SendToUser";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/:send"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### AddUserToGroup
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups/{group}"].put.operationId
  transform: return "WebPubSubService_AddUserToGroup";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups/{group}"].put.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### RemoveUserFromGroup
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups/{group}"].delete.operationId
  transform: return "WebPubSubService_RemoveUserFromGroup";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups/{group}"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### RemoveUserFromAllGroups
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups"].delete.operationId
  transform: return "WebPubSubService_RemoveUserFromAllGroups";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/groups"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### GrantPermission
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].put.operationId
  transform: return "WebPubSubService_GrantPermission";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].put.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].put.parameters["3"].description
  transform: return "Optional. If not set, grant the permission to all the targets. If set, grant the permission to the specific target. The meaning of the target depends on the specific permission.";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].put
  transform: $["x-accessibility"] = "internal"
```

### RevokePermission
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].delete.operationId
  transform: return "WebPubSubService_RevokePermission";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].delete.parameters["3"].description
  transform: return "Optional. If not set, revoke the permission for all targets. If set, revoke the permission for the specific target. The meaning of the target depends on the specific permission.";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].delete
  transform: $["x-accessibility"] = "internal"
```

### CheckPermission
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].head.operationId
  transform: return "WebPubSubService_CheckPermission";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].head.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].head.parameters["3"].description
  transform: return "Optional. If not set, get the permission for all targets. If set, get the permission for the specific target. The meaning of the target depends on the specific permission.";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/permissions/{permission}/connections/{connectionId}"].head
  transform: $["x-accessibility"] = "internal"
```

### CloseAllConnections
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:closeConnections"].post.operationId
  transform: return "WebPubSubService_CloseAllConnections";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/:closeConnections"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### CloseGroupConnections
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/:closeConnections"].post.operationId
  transform: return "WebPubSubService_CloseGroupConnections";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/groups/{group}/:closeConnections"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### CloseUserConnections
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/:closeConnections"].post.operationId
  transform: return "WebPubSubService_CloseUserConnections";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/users/{userId}/:closeConnections"].post.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```

### RemoveConnectionFromAllGroups
``` yaml
directive:
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}/groups"].delete.operationId
  transform: return "WebPubSubService_RemoveConnectionFromAllGroups";
- from: swagger-document
  where: $.paths["/api/hubs/{hub}/connections/{connectionId}/groups"].delete.parameters["0"]
  transform: $["x-ms-parameter-location"] = "client"
```
