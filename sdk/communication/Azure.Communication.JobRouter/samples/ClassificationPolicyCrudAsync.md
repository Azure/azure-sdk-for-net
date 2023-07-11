# Azure.Communication.JobRouter Samples - Classification Policy CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateClassificationPolicy_Async
string classificationPolicyId = "my-classification-policy";

Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
    options: new CreateClassificationPolicyOptions(classificationPolicyId)
    {
        Name = "Sample classification policy",
        PrioritizationRule = new StaticRouterRule(new LabelValue(10)),
        QueueSelectors =
        {
            new StaticQueueSelectorAttachment(new RouterQueueSelector("Region", LabelOperator.Equal, new LabelValue("NA"))),
            new ConditionalQueueSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                queueSelectors: new List<RouterQueueSelector>()
                {
                    new RouterQueueSelector("Product", LabelOperator.Equal, new LabelValue("O365")),
                    new RouterQueueSelector("QGroup", LabelOperator.Equal, new LabelValue("NA_O365"))
                }),
        },
        WorkerSelectors =
        {
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                workerSelectors: new List<RouterWorkerSelector>()
                {
                    new RouterWorkerSelector("Skill_O365", LabelOperator.Equal, new LabelValue(true)),
                    new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(1))
                }),
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.HighPriority = \"true\", true, false)"),
                workerSelectors: new List<RouterWorkerSelector>()
                {
                    new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanEqual, new LabelValue(10))
                })
        }
    });

Console.WriteLine($"Classification Policy successfully created with id: {classificationPolicy.Value.Id}");
```

*NOTE: it is not necessary to specify all the properties when creating a classification policy. Router provides the flexibility to pick and choose whichever functionality of the classification process someone may use.

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
        PrioritizationRule = new ExpressionRouterRule("If(job.HighPriority = \"true\", 50, 10)")
    });

Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");
```

*NOTE: It is not possible to update a single QueueSelectorAttachment or WorkerSelectorAttachment. In order to add QueueSelectorAttachment to an already existing set of QueueSelectorAttachment(s), either specify all the QueueSelectorAttachment(s) again OR perform a Get operation first to retrieve the current value of the classification policy (preferred).

## Remove from classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateClassificationPolicyRemoveProp_Async
Response updatedClassificationPolicyWithoutName = await routerAdministrationClient.UpdateClassificationPolicyAsync(classificationPolicyId,
    RequestContent.Create(new { Name = (string?)null }));

Response<ClassificationPolicy> queriedClassificationPolicyWithoutName = await routerAdministrationClient.GetClassificationPolicyAsync(classificationPolicyId);

Console.WriteLine($"Classification policy successfully updated: 'Name' has been removed. Status: {string.IsNullOrWhiteSpace(queriedClassificationPolicyWithoutName.Value.Name)}");
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
