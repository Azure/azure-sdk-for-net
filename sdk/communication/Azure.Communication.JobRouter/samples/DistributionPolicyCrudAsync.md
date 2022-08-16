# Azure.Communication.JobRouter Samples - Distribution Policy CRUD operations (async)

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

## Create a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async
string distributionPolicyId = "my-distribution-policy";

Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(1),
        mode: new LongestIdleMode())
    {
        Name = "My distribution policy"
    }
);

Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");
```

## Get a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async
Response<DistributionPolicy> queriedDistributionPolicy = await routerAdministrationClient.GetDistributionPolicyAsync(distributionPolicyId);

Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");
```

## Update a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async
Response<DistributionPolicy> updatedDistributionPolicy = await routerAdministrationClient.UpdateDistributionPolicyAsync(
    new UpdateDistributionPolicyOptions(distributionPolicyId)
    {
        // you can update one or more properties of distribution policy
        Mode = new RoundRobinMode(),
    });

Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");
```

## List distribution policies

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async
AsyncPageable<DistributionPolicyItem> distributionPolicies = routerAdministrationClient.GetDistributionPoliciesAsync();
await foreach (Page<DistributionPolicyItem> asPage in distributionPolicies.AsPages(pageSizeHint: 10))
{
    foreach (DistributionPolicyItem? policy in asPage.Values)
    {
        Console.WriteLine($"Listing distribution policy with id: {policy.DistributionPolicy.Id}");
    }
}
```

## Delete distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async
_ = await routerAdministrationClient.DeleteDistributionPolicyAsync(distributionPolicyId);
```
