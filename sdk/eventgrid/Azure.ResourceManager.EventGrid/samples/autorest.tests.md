# Generated code configuration

Run `dotnet build /t:GenerateTest` to generate code.

# Azure.ResourceManager.EventGrid.Tests

> see https://aka.ms/autorest
``` yaml
require: ../src/autorest.md
include-x-ms-examples-original-file: true
testgen:
  sample: true
  skipped-operations:
  - EventSubscriptions_ListGlobalBySubscriptionForTopicType
  - EventSubscriptions_ListGlobalByResourceGroupForTopicType
  - EventSubscriptions_ListRegionalBySubscription
  - EventSubscriptions_ListRegionalByResourceGroup
  - EventSubscriptions_ListRegionalByResourceGroupForTopicType
  - EventSubscriptions_ListRegionalBySubscriptionForTopicType
  - Topics_ListEventTypes
```