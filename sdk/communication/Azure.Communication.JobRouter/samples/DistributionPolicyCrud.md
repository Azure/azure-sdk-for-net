# Azure.Communication.JobRouter Samples - Distribution Policy CRUD operations (sync)

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

## Create a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy
string distributionPolicyId = "my-distribution-policy";

Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerExpiresAfter: TimeSpan.FromMinutes(1),
        mode: new LongestIdleMode())
    {
        Name = "My distribution policy"
    }
);

Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");
```

## Get a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy
Response<DistributionPolicy> queriedDistributionPolicy = routerAdministrationClient.GetDistributionPolicy(distributionPolicyId);

Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");
```

## Update a distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy
Response<DistributionPolicy> updatedDistributionPolicy = routerAdministrationClient.UpdateDistributionPolicy(
    new DistributionPolicy(distributionPolicyId)
    {
        // you can update one or more properties of distribution policy
        Mode = new RoundRobinMode(),
    });

Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");
```

## List distribution policies

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies
Pageable<DistributionPolicy> distributionPolicies = routerAdministrationClient.GetDistributionPolicies(cancellationToken: default);
foreach (Page<DistributionPolicy> asPage in distributionPolicies.AsPages(pageSizeHint: 10))
{
    foreach (DistributionPolicy? policy in asPage.Values)
    {
        Console.WriteLine($"Listing distribution policy with id: {policy.Id}");
    }
}
```

## Delete distribution policy

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy
_ = routerAdministrationClient.DeleteDistributionPolicy(distributionPolicyId);
```
