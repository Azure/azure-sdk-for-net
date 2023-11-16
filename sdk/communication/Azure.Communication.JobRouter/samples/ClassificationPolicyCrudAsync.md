# Azure.Communication.JobRouter Samples - Classification Policy CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
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
        PrioritizationRule = new StaticRouterRule(new RouterValue(10)),
        QueueSelectorAttachments =
        {
            new StaticQueueSelectorAttachment(new RouterQueueSelector("Region", LabelOperator.Equal, new RouterValue("NA"))),
            new ConditionalQueueSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                queueSelectors: new List<RouterQueueSelector>()
                {
                    new RouterQueueSelector("Product", LabelOperator.Equal, new RouterValue("O365")),
                    new RouterQueueSelector("QGroup", LabelOperator.Equal, new RouterValue("NA_O365"))
                }),
        },
        WorkerSelectorAttachments =
        {
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                workerSelectors: new List<RouterWorkerSelector>()
                {
                    new RouterWorkerSelector("Skill_O365", LabelOperator.Equal, new RouterValue(true)),
                    new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanOrEqual, new RouterValue(1))
                }),
            new ConditionalWorkerSelectorAttachment(
                condition: new ExpressionRouterRule("If(job.HighPriority = \"true\", true, false)"),
                workerSelectors: new List<RouterWorkerSelector>()
                {
                    new RouterWorkerSelector("Skill_O365_Lvl", LabelOperator.GreaterThanOrEqual, new RouterValue(10))
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
    new ClassificationPolicy(classificationPolicyId)
    {
        PrioritizationRule = new ExpressionRouterRule("If(job.HighPriority = \"true\", 50, 10)")
    });

Console.WriteLine($"Classification policy successfully update with new prioritization rule. RuleType: {updatedClassificationPolicy.Value.PrioritizationRule.Kind}");
```

*NOTE: It is not possible to update a single QueueSelectorAttachment or WorkerSelectorAttachment. In order to add QueueSelectorAttachment to an already existing set of QueueSelectorAttachment(s), either specify all the QueueSelectorAttachment(s) again OR perform a Get operation first to retrieve the current value of the classification policy (preferred).


## List classification policies

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetClassificationPolicies_Async
AsyncPageable<ClassificationPolicy> classificationPolicies = routerAdministrationClient.GetClassificationPoliciesAsync(cancellationToken: default);
await foreach (Page<ClassificationPolicy> asPage in classificationPolicies.AsPages(pageSizeHint: 10))
{
    foreach (ClassificationPolicy? policy in asPage.Values)
    {
        Console.WriteLine($"Listing classification policy with id: {policy.Id}");
    }
}
```

## Delete classification policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteClassificationPolicy_Async
_ = await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId);
```
