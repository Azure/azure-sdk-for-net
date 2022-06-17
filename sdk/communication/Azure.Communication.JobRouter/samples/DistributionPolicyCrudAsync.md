# Azure.Communication.JobRouter Samples - Distribution Policy CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Create a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async
var distributionPolicyId = "my-distribution-policy";

var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
    id: distributionPolicyId,
    offerTtlSeconds: 60,
    mode: new LongestIdleMode(),
    new CreateDistributionPolicyOptions() // this is optional
    {
        Name = "My distribution policy"
    }
);

Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");
```

## Get a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async
var queriedDistributionPolicy = await routerClient.GetDistributionPolicyAsync(distributionPolicyId);

Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");
```

## Update a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async
var updatedDistributionPolicy = await routerClient.UpdateDistributionPolicyAsync(
    distributionPolicyId,
    new UpdateDistributionPolicyOptions()
    {
        // you can update one or more properties of distribution policy
        Mode = new RoundRobinMode(),
    });

Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");
```

## List distribution policies

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async
var distributionPolicies = routerClient.GetDistributionPoliciesAsync();
await foreach (var asPage in distributionPolicies.AsPages(pageSizeHint: 10))
{
    foreach (var policy in asPage.Values)
    {
        Console.WriteLine($"Listing distribution policy with id: {policy.Id}");
    }
}
```

## Delete distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async
_ = await routerClient.DeleteDistributionPolicyAsync(distributionPolicyId);
```
