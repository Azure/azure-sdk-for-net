# Provisioning generator feature fixture

This TypeSpec project exercises provisioning-specific generator behavior. The
tests compile the generated APIs into Bicep and compare the complete output.

| Fixture | Generator feature | Bicep coverage |
| --- | --- | --- |
| `configurationStore.tsp` | Tracked resources, enum wire names, and scalar formats | `ConfigurationStoreTests` |
| `backupPolicy.tsp` | Discriminated models | `DiscriminatorTests` |
| `item.tsp` | Model inheritance, flattened properties, nullable values, and create-body settable analysis | `ItemTests` |
| `keyValue.tsp` | Parent and child resources | `ResourceTests.ChildResource` |
| `profileRevision.tsp` | One input model shared by distinct resources | `ResourceTests.SharedModelResources` |
| `extensionAssignment.tsp` | Extension resource scope | `ResourceTests.ExtensionResource` |
| `singletonSetting.tsp` | Fixed singleton resource names | `ResourceTests.SingletonResource` |
| `main.tsp` | Per-resource API versions, known collection types, and RBAC role helpers | Generated API plus `ResourceTests.RoleAssignment` |
| `privateLinkResource.tsp` | Read-only resources | Generated API shape |
| `resourceModelProperty.tsp` | Resource models used as model properties | Generated API shape |

The read-only cases are covered by generated API compilation rather than Bicep
input because they cannot be assigned when defining infrastructure.
