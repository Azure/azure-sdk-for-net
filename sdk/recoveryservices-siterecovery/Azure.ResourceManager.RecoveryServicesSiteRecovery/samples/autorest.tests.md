# Generated code configuration

Run `dotnet build /t:GenerateTests` to generate code.

# Azure.ResourceManager.ShortName.Tests

> see https://aka.ms/autorest
``` yaml
require: ../src/autorest.md
include-x-ms-examples-original-file: true
testgen:
  sample: true
  skipped-operations:
    # The discriminator value is incorrect
    - ReplicationFabrics_Create 
    - ReplicationProtectionContainers_Create
    - ReplicationProtectedItems_Delete
    - ReplicationProtectionContainerMappings_Create
    # Missing requried parameter
    - ReplicationJobs_Export
```