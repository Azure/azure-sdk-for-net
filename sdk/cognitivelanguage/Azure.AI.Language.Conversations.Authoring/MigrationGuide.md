# Migration Guide: Azure.AI.Language.Conversations.Authoring

This guide helps developers migrate between versions of the `Azure.AI.Language.Conversations.Authoring` client library.

## Table of contents

- [Migrating from 1.0.0-beta.2 to 1.0.0-beta.3](#migrating-from-100-beta2-to-100-beta3)
  - [Method renames for project resource operations](#method-renames-for-project-resource-operations)
  - [Parameter type changes](#parameter-type-changes)
  - [CreateProject now requires projectName in details](#createproject-now-requires-projectname-in-details)

---

## Migrating from 1.0.0-beta.2 to 1.0.0-beta.3

Version 1.0.0-beta.3 introduced several breaking API changes to align naming conventions with the concept of "project resources" rather than "deployment resources."

### Method renames for project resource operations

The following methods were renamed. Update all call sites to use the new method names:

| Old method name (beta.2) | New method name (beta.3) |
|---|---|
| `AssignDeploymentResources` | `AssignProjectResources` |
| `UnassignDeploymentResources` | `UnassignProjectResources` |
| `GetAssignDeploymentResourcesStatus` | `GetAssignProjectResourcesStatus` |
| `GetUnassignDeploymentResourcesStatus` | `GetUnassignProjectResourcesStatus` |

**Before (beta.2):**

```csharp
Operation operation = client.AssignDeploymentResources(
    WaitUntil.Started,
    projectName,
    assignDetails);
```

**After (beta.3):**

```csharp
Operation operation = client.AssignProjectResources(
    WaitUntil.Started,
    projectName,
    assignDetails);
```

### Parameter type changes

The following methods have changed their parameter or return types:

#### `DeleteDeploymentFromResources`

The parameter type changed from `ConversationAuthoringDeleteDeploymentDetails` to `ConversationAuthoringProjectResourceIds`, and the property name changed from `AssignedResourceIds` to `AzureResourceIds`.

**Before (beta.2):**

```csharp
var deleteDetails = new ConversationAuthoringDeleteDeploymentDetails(
    assignedResourceIds: new List<string> { "/subscriptions/.../accounts/myAccount" }
);

Operation operation = client.DeleteDeploymentFromResources(
    WaitUntil.Started,
    projectName,
    deploymentName,
    deleteDetails);
```

**After (beta.3):**

```csharp
var deleteDetails = new ConversationAuthoringProjectResourceIds(
    azureResourceIds: new List<string> { "/subscriptions/.../accounts/myAccount" }
);

Operation operation = client.DeleteDeploymentFromResources(
    WaitUntil.Started,
    projectName,
    deploymentName,
    deleteDetails);
```

#### `GetAssignProjectResourcesStatus` (formerly `GetAssignDeploymentResourcesStatus`)

The return type changed from `ConversationAuthoringDeploymentResourcesState` to `ConversationAuthoringProjectResourcesState`.

**Before (beta.2):**

```csharp
Response<ConversationAuthoringDeploymentResourcesState> response =
    client.GetAssignDeploymentResourcesStatus(projectName, jobId);
```

**After (beta.3):**

```csharp
Response<ConversationAuthoringDeploymentResourcesState> response =
    client.GetAssignProjectResourcesStatus(projectName, jobId);
```

#### `GetUnassignProjectResourcesStatus` (formerly `GetUnassignDeploymentResourcesStatus`)

The return type changed from `ConversationAuthoringDeploymentResourcesState` to `ConversationAuthoringProjectResourcesState`.

**Before (beta.2):**

```csharp
Response<ConversationAuthoringDeploymentResourcesState> response =
    client.GetUnassignDeploymentResourcesStatus(projectName, jobId);
```

**After (beta.3):**

```csharp
Response<ConversationAuthoringDeploymentResourcesState> response =
    client.GetUnassignProjectResourcesStatus(projectName, jobId);
```

#### `UnassignProjectResources` (formerly `UnassignDeploymentResources`)

The parameter type changed from `ConversationAuthoringUnassignDeploymentResourcesDetails` to `ConversationAuthoringProjectResourceIds`.

**Before (beta.2):**

```csharp
var unassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(
    assignedResourceIds: new List<string> { "/subscriptions/.../accounts/myAccount" }
);

Operation operation = client.UnassignDeploymentResources(
    WaitUntil.Started,
    projectName,
    unassignDetails);
```

**After (beta.3):**

```csharp
var unassignDetails = new ConversationAuthoringProjectResourceIds(
    azureResourceIds: new List<string> { "/subscriptions/.../accounts/myAccount" }
);

Operation operation = client.UnassignProjectResources(
    WaitUntil.Started,
    projectName,
    unassignDetails);
```

### CreateProject now requires projectName in details

`ConversationAuthoringCreateProjectDetails` now requires the `projectName` as a constructor parameter. It must match the `projectName` parameter passed to `CreateProject`.

**Before (beta.2):**

```csharp
ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
    projectKind: "Conversation",
    language: "en-us"
);

client.CreateProject(projectName, RequestContent.Create(projectData));
```

**After (beta.3):**

```csharp
ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
    projectKind: "Conversation",
    projectName: projectName,
    language: "en-us"
);

using RequestContent content = RequestContent.Create(projectData);
client.CreateProject(projectName, content);
```

---

## Additional resources

- [Azure.AI.Language.Conversations.Authoring README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md)
- [Azure.AI.Language.Conversations.Authoring samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples)
- [CHANGELOG](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/CHANGELOG.md)
