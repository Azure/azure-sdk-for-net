# Azure.Communication.JobRouter Samples - Classification Policy CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async
string classificationPolicyId = "my-classification-policy";

Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
    options: new CreateClassificationPolicyOptions(classificationPolicyId)
    {
        Name = "Sample classification policy",
        PrioritizationRule = new StaticRule(new LabelValue(10)),
        QueueSelectors = new List<QueueSelectorAttachment>()
        {
            new StaticQueueSelectorAttachment(new QueueSelector("Region", LabelOperator.Equal, new LabelValue("NA"))),
            new ConditionalQueueSelectorAttachment(
                condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                labelSelectors: new List<QueueSelector>()
                {
                    new QueueSelector("Product", LabelOperator.Equal, new LabelValue("O365")),
                    new QueueSelector("QGroup", LabelOperator.Equal, new LabelValue("NA_O365"))
                }),
        },
        WorkerSelectors = new List<WorkerSelectorAttachment>()
        {
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                labelSelectors: new List<WorkerSelector>()
                {
                    new WorkerSelector("Skill_O365", LabelOperator.Equal, new LabelValue(true)),
                    new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(1))
                }),
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRule("If(job.HighPriority = \"true\", true, false)"),
                labelSelectors: new List<WorkerSelector>()
                {
                    new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(10))
                })
        }
    });

Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");

/*
// NOTE: it is not necessary to specify all the properties when creating a classification policy
// Router provides the flexibility to pick and choose whichever functionality of the classification process someone may use
// For e.g., it is possible to use the classification policy to assign
// 1. A priority to the job
// 2. A specified set of worker selectors
// In this scenario, the queue selectors are not specified. Therefore, any job using this classification policy will
// be expected to have a `queueId` pre-assigned to itself.
var classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
    options: new CreateClassificationPolicyOptions(classificationPolicyId)
    {
        PrioritizationRule = new StaticRule(10),
        WorkerSelectors = new List<WorkerSelectorAttachment>()
        {
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
                labelSelectors: new List<WorkerSelector>()
                {
                    new WorkerSelector("Skill_O365", LabelOperator.Equal, true),
                    new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 1)
                }),
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRule("If(job.HighPriority = \"true\", true, false)"),
                labelSelectors: new List<WorkerSelector>()
                {
                    new WorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, 10)
                })
        }
    });
    */
```

## Get a classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicy_Async
Response<ClassificationPolicy> queriedClassificationPolicy = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);

Console.WriteLine($"Successfully fetched classification policy with id: {queriedClassificationPolicy.Value.Id}");
```

## Update a classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicy_Async
Response<ClassificationPolicy> updatedClassificationPolicy = await routerAdministrationClient.UpdateClassificationPolicyAsync(
    new UpdateClassificationPolicyOptions(classificationPolicyId)
    {
        PrioritizationRule = new ExpressionRule("If(job.HighPriority = \"true\", 50, 10)")
    });

Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");

/*
// NOTE: It is not possible to update a single QueueSelectorAttachment or WorkerSelectorAttachment.
// For e.g., the following update with result in the classification policy with a single QueueSelectorAttachment.
// All previous QueueSelectorAttachment(s) which was specified during creating will be removed.

var updatedClassificationPolicy = await routerAdministrationClient.UpdateClassificationPolicyAsync(
    new UpdateClassificationPolicyOptions(classificationPolicyId)
    {
        QueueSelectors = new List<QueueSelectorAttachment>()
        {
            new StaticQueueSelectorAttachment(new QueueSelector("Id", LabelOperator.Equal, new LabelValue("NA_O365_EN_1")))
        }
    });

// In order to add QueueSelectorAttachment to an already existing set of QueueSelectorAttachment(s), either
// 1. Specify all the QueueSelectorAttachment(s) again, OR
// 2. Perform a Get operation first to retrieve the current value of the classification policy (preferred)

var existingClassificationPolicy = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);
var existingQueueSelectors = existingClassificationPolicy.Value.QueueSelectors.ToList();

// Add a new QueueSelectorAttachment
existingQueueSelectors.Add(new StaticQueueSelectorAttachment(new QueueSelector("Id", LabelOperator.Equal, new LabelValue("NA_O365_EN_1"))));

var updatedClassificationPolicy = await routerAdministrationClient.UpdateClassificationPolicyAsync(
    new UpdateClassificationPolicyOptions(classificationPolicyId)
    {
        QueueSelectors = existingQueueSelectors
    });
    */
```

## List classification policies

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async
AsyncPageable<ClassificationPolicyItem> classificationPolicies = routerAdministrationClient.GetClassificationPoliciesAsync();
await foreach (Page<ClassificationPolicyItem> asPage in classificationPolicies.AsPages(pageSizeHint: 10))
{
    foreach (ClassificationPolicyItem? policy in asPage.Values)
    {
        Console.WriteLine($"Listing classification policy with id: {policy.ClassificationPolicy.Id}");
    }
}
```

## Delete classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async
_ = await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId);
```
