# Generated code configuration

Run `dotnet build /t:GenerateTests` to generate code.

# Azure.ResourceManager.EventGrid.Tests

> see https://aka.ms/autorest
``` yaml
require: ../src/autorest.md
include-x-ms-examples-original-file: true
testgen:
  sample: true
  skipped-operations:
  - Topics_ListEventTypes # because we use customized code to rewrite this operation
  - EventSubscriptions_ListGlobalBySubscriptionForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListGlobalByResourceGroupForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalByResourceGroupForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalBySubscriptionForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalByResourceGroup # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalBySubscription # because we use customized code to rewrite this operation
```
