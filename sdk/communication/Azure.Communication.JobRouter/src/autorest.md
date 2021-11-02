# Azure.Ccap.Communication.Router

When a new version of the swagger needs to be updated:
1. Go to sdk\communication\Azure.Communication.JobRouter\src, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.JobRouter.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

> see [https://aka.ms/autorest](https://aka.ms/autorest)

## Configuration

```yaml
input-file: "./swagger/2021-04-07_ACSRouter.json"

use-extension:
  "@autorest/csharp": "3.0.0-beta.20210901.1"

csharp:
  azure-arm: true
  license-header: MICROSOFT_MIT_NO_VERSION
  payload-flattening-threshold: 1
  clear-output-folder: true
  client-side-validation: false
  namespace: Azure.Communication.JobRouter  

openapi-type: data-plane
tag: V2021_04_07_preview1

title:
  Azure Communication Services

directive:
  - from: swagger-document
    where: "$.definitions"
    transform: >
      $.UpsertDistributionPolicyRequest.properties.mode["$ref"] = "#/definitions/DistributionMode";
      $.UpsertDistributionPolicyResponse.properties.mode["$ref"] = "#/definitions/DistributionMode";
      $.DistributionPolicy.properties.mode["$ref"] = "#/definitions/DistributionMode";

      $.UpsertClassificationPolicyRequest.properties.queueSelector["$ref"] = "#/definitions/QueueSelector";
      $.UpsertClassificationPolicyRequest.properties.prioritizationRule["$ref"] = "#/definitions/RouterRule";
      $.UpsertClassificationPolicyRequest.properties.workerSelectors.items["$ref"] = "#/definitions/LabelSelectorAttachment";

      $.UpsertClassificationPolicyResponse.properties.queueSelector["$ref"] = "#/definitions/QueueSelector";
      $.UpsertClassificationPolicyResponse.properties.prioritizationRule["$ref"] = "#/definitions/RouterRule";
      $.UpsertClassificationPolicyResponse.properties.workerSelectors.items["$ref"] = "#/definitions/LabelSelectorAttachment";

      $.ClassificationPolicy.properties.queueSelector["$ref"] = "#/definitions/QueueSelector";
      $.ClassificationPolicy.properties.prioritizationRule["$ref"] = "#/definitions/RouterRule";
      $.ClassificationPolicy.properties.workerSelectors.items["$ref"] = "#/definitions/LabelSelectorAttachment";;

      $.ExceptionRule.properties.trigger["$ref"] = "#/definitions/JobExceptionTrigger";
      $.ExceptionRule.properties.actions.items["$ref"] = "#/definitions/ExceptionAction";

      $.BestWorkerMode.properties.scoringRule["$ref"] = "#/definitions/RouterRule";

      $.RuleLabelSelector.properties.rule["$ref"] = "#/definitions/RouterRule";
      $.ConditionalLabelSelector.properties.condition["$ref"] = "#/definitions/RouterRule";
            
      $.QueueLabelSelector.properties.labelSelectors.items["$ref"] = "#/definitions/LabelSelectorAttachment";
      $.QueueIdSelector.properties.rule["$ref"] = "#/definitions/RouterRule";
      $.NearestQueueLabelSelector.properties.rule["$ref"] = "#/definitions/RouterRule";
  
```

