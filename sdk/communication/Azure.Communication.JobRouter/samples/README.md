---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication-services
name: Azure.Communication.JobRouter samples for .NET
description: Samples for the Azure.Communication.JobRouter client library
---

# Azure Communication JobRouter client SDK Samples

- Crud operations
  - [Classification Policy][classificationPolicyCrudOps]([async version][classificationPolicyCrudOpsAsync])
  - [Distribution Policy][distributionPolicyCrudOps]([async version][distributionPolicyCrudOpsAsync])
  - [Exception Policy][exceptionPolicyCrudOps]([async version][exceptionPolicyCrudOpsAsync])
  - [Job Queue][jobQueueCrudOps]([async version][jobQueueCrudOpsAsync])
  - [Router Worker][routerWorkerCrudOps]([async version][routerWorkerCrudOpsAsync])
  - [Router Job][routerJobCrudOps]([async version][routerJobCrudOpsAsync])

- Routing Scenarios
  - Basic Scenario
    - [Create Distribution Policy, Queue, Worker and Job | Accept Job Offer | Close and Complete job][basicScenario]([async version][basicScenarioAsync])
    - [Requested worker selectors with job][requestedWorkerSelectorWithJobAsync]
  - Using Classification Policy
    - [Queue selection with QueueSelectors][queueSelectionWithClassificationPolicyAsync]
    - [Dynamically assigning priority to job][prioritizationWithClassificationPolicyAsync]
    - [Dynamically attach WorkerSelectors to job][attachedWorkerSelectorWithClassificationPolicyAsync]
  - Using Distribution Policy
    - [Basic Scenario][distributingOffersSimpleAsync]
    - [Multiple offers for a job][distributingOffersAdvancedAsync]
  - Using Exception Policy
    - [Trigger exception with WaitTimeExceptionTrigger][waitTimeExceptionTriggerAsync]
    - [Trigger exception with QueueLengthExceptionTrigger][queueLengthExceptionTriggerAsync]

<!-- LINKS -->
[classificationPolicyCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/ClassificationPolicyCrud.md
[classificationPolicyCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/ClassificationPolicyCrudAsync.md
[distributionPolicyCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/DistributionPolicyCrud.md
[distributionPolicyCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/DistributionPolicyCrudAsync.md
[exceptionPolicyCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/ExceptionPolicyCrud.md
[exceptionPolicyCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/ExceptionPolicyCrudAsync.md
[jobQueueCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/JobQueueCrud.md
[jobQueueCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/JobQueueCrudAsync.md
[routerWorkerCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/RouterWorkerCrud.md
[routerWorkerCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/RouterWorkerCrudAsync.md
[routerJobCrudOps]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/RouterJobCrud.md
[routerJobCrudOpsAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/RouterJobCrudAsync.md
[basicScenario]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample1_HelloWorld.md
[basicScenarioAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample1_HelloWorldAsync.md
[requestedWorkerSelectorWithJobAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample1_RequestedWorkerSelectorAsync.md
[queueSelectionWithClassificationPolicyAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample2_ClassificationWithQueueSelectorAsync.md
[prioritizationWithClassificationPolicyAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample2_ClassificationWithPriorityRuleAsync.md
[attachedWorkerSelectorWithClassificationPolicyAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample2_ClassificationWithWorkerSelectorAsync.md
[distributingOffersSimpleAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample3_SimpleDistributionAsync.md
[distributingOffersAdvancedAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample3_AdvancedDistributionAsync.md
[waitTimeExceptionTriggerAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample4_WaitTimeExceptionAsync.md
[queueLengthExceptionTriggerAsync]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/samples/Sample4_QueueLengthExceptionTriggerAsync.md
