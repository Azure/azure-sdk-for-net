# Provisioning generator feature fixture

This TypeSpec project exercises provisioning-specific generator behavior. The
tests compile the generated APIs into Bicep and compare the complete output.

| Fixture | Generator feature | Bicep coverage |
| --- | --- | --- |
| `trackedResource.tsp` | Tracked resources, enum wire names, and scalar formats | `ConfigurationStoreTests` |
| `discriminatedModel.tsp` | Discriminated models | `DiscriminatorTests` |
| `createBodyResource.tsp` | Model inheritance, flattened properties, nullable values, and create-body settable analysis | `ItemTests` |
| `childResource.tsp` | Parent and child resources | `ResourceTests.ResourceKinds` |
| `sharedModelResource.tsp` | One input model shared by distinct resources | `ResourceTests.ResourceKinds` |
| `extensionResource.tsp` | Extension resource scope | `ResourceTests.ResourceKinds` |
| `singletonResource.tsp` | Decorator and legacy-operation singleton shapes | `SingletonResourceTests` |
| `main.tsp` | Per-resource API versions, known collection types, and RBAC role helpers | Generated API plus `ResourceTests.RoleAssignment` |
| `readOnlyResource.tsp` | Read-only resources | Generated API shape |
| `resourceModelAsProperty.tsp` | Resource models used as model properties | Generated API shape |

The read-only cases are covered by generated API compilation rather than Bicep
input because they cannot be assigned when defining infrastructure.

## Resource cases

| Resource | Provisioning generator behavior |
| --- | --- |
| `ConfigurationStore` | Tracked resource envelope and resource-level properties |
| `KeyValue` | Child resource with a generated typed parent |
| `Item` | Writable properties discovered from a separate create body |
| `Profile` and `ProfileRevision` | Distinct resources generated from one input model |
| `ResourceProfile` | Resource models exposed as model properties |
| `DiscriminatedResourceProfile` and `SpecializedResourceProfile` | Resource inheritance with a discriminator |
| `ResourceProfileRevision` | Read-only child resource used as a model property |
| `ExtensionAssignment` | Extension resource with a generic scope |
| `SingletonSetting` | `@singleton` resource with an immediate generated parent |
| `LegacySingleton` | Top-level singleton inferred from a legacy fixed route |
| `OrphanedSingleton` | Two-layer singleton resource type without a generated parent |
| `ConfigurationStorePrivateLinkResource` | Resource with no writable operations |
