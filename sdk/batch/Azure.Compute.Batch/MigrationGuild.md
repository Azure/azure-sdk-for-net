# Guide for migrating to `Azure.Compute.Batch` from `Microsoft.Azure.Batch`

This guide is intended to assist customers in migrating to `Azure.Compute.Batch` from the legacy `Microsoft.Azure.Batch` package. It will focus on side-by-side comparisons of similar operations between the two packages.

Familiarity with the legacy client library is assumed. For those new to the Azure Batch client library, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/batch/Azure.Compute.Batch/samples) of `@Azure.Compute.Batch` instead of this guide.

## Table of Contents

- [Migration Benefits](#migration-benefits)
- [Overview](#overview)
  - [Migration Benefits](#migration-benefits)
  - [Azure.Compute.Batch Differences](#azurecomputebatch-differences)
- [Constructing the Clients](#constructing-the-clients)
  - [Authenticate with Microsoft Entra ID](#authenticate-with-microsoft-entra-id)
  - [Authenticate with Shared Key Credentials](#authenticate-with-shared-key-credentials)
- [Error Handling](#error-handling)
- [Operations Examples](#operations-examples)
  - [Pool Operations](#pool-operations)
      - [CreatePool](#createpool)
      - [GetPool](#getpool)
      - [ListPools](#listpools)
      - [DeletePool](#deletepool)
      - [PatchPool](#patchpool)
      - [UpdatePool](#patchpool)
      - [Resize](#resizepool)
      - [StopResize](#stopresizepool)
      - [EnableAutoScale](#enableautoscalepool)
      - [DisableAutoScale](#disableautoscalepool)
      - [EvaluateAutoScale](#evaluateautoscalepool)
      - [ListPoolNodeCounts](#listpoolnodecounts)
      - [ListPoolUsageMetrics](#listpoolusagemetrics)
  - [Create Jobs](#create-jobs)
  - [Submit Tasks](#submit-tasks)

## Overview

### Migration Benefits

> Note: `Microsoft.Azure.Batch` has been [deprecated]. Please upgrade to `Azure.Compute.Batch` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be.  As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem.  One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure.  Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, including Batch, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services.  A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries.  Further details are available in the guidelines for those interested.

The new Batch library `Azure.Compute.Batch` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new Azure.Identity library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries.

We strongly encourage moving to `Azure.Compute.Batch`. It is important to be aware the legacy `Microsoft.Azure.Batch` package have been officially deprecated. Though they will continue to be supported with critical security and bug fixes, they are no longer under active development and will not receive new features or minor fixes. There is no guarantee of feature parity between the and legacy client library versions.

### `Azure.Compute.Batch` Differences

Developing a batch workflow against `Azure.Compute.Batch` differes from developing a batch workflow against `Microsoft.Azure.Batch` in a couple of key ways.  

- **Name Changes**: Many of the objects and operations names have changed in `Azure.Compute.Batch`.  This guide below should highlight these but expect such differences as object names changing from `CloudPool` to `BatchPool` and operations such as `batchClient.JobOperations.ListTasks()` to `batchClient.GetTasks()`
- **API location**: In `Microsoft.Azure.Batch` all operations are groupped into operation classes where as in `Azure.Compute.Batch` all operations are under the BatchClient.  For example in `Microsoft.Azure.Batch` all pool operations are under a PoolOperations class, Job operations are under a JobOperations class, and so on.  For example in `Microsoft.Azure.Batch` the method to create a pool would be under PoolOperations `batchClient.PoolOperations.CreatePool()` where as in `Azure.Compute.Batch` the operation is under the client `batchClient.CreatePool()`.  In addition `Microsoft.Azure.Batch` allowed operations off of objects such as the case below where the user would retrieve a CloudPool object, modify it, then issue a `.Commit()` to update it.

``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool(poolId);
IList<MetadataItem> changedMDI = new List<MetadataItem> { new MetadataItem("name", "value") };
boundPool.Metadata = changedMDI;

boundPool.Commit();
```

where as in `Azure.Compute.Batch` all commands are under the client so you would issue an UpdatePool command from the client. 

``` C#
BatchPoolUpdateContent updateContent = new BatchPoolUpdateContent();
updateContent.Metadata.Add(new MetadataItem("name", "value"));
               
Response response = await batchClient.UpdatePoolAsync(poolID, updateContent);
```

- **Bound Object**: In `Microsoft.Azure.Batch` there is a concept of Batch Objects being Bound vs Unbound   For example in the following code the call to CreatePool creates an unbound pool object, in other words the pool has yet to be created in Azure.  Once the user calls pool.Commit() the the command is issued to create the pool in Azure.
``` C#
VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                        ubuntuImageDetails.ImageReference,
                        nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

CloudPool pool = batchClient.PoolOperations.CreatePool(
                 poolId,
                 PoolFixture.VMSize,
                 virtualMachineConfiguration,
                 targetDedicatedComputeNodes: 0);

await pool.CommitAsync().ConfigureAwait(false);
```

where as with `Azure.Compute.Batch` when you call CreatePool the pool is created in Azure immediately.

``` C# Snippet:Batch_Readme_PoolCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

ImageReference imageReference = new ImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
poolID, "STANDARD_D1_v2")
{
    VirtualMachineConfiguration = virtualMachineConfiguration,
    TargetDedicatedNodes = 2,
};

// create pool
batchClient.CreatePool(batchPoolCreateOptions);
```


## Constructing the Clients

We strongly recommend using Microsoft Entra ID for Batch account authentication. Some Batch capabilities require this method of authentication, including many of the security-related features discussed here. The service API authentication mechanism for a Batch account can be restricted to only Microsoft Entra ID using the [allowedAuthenticationModes](https://learn.microsoft.com/rest/api/batchmanagement/batch-account/create?view=rest-batchmanagement-2024-02-01&tabs=HTTP) property. When this property is set, API calls using Shared Key authentication will be rejected.


### Authenticate with Microsoft Entra ID

`Azure.Compute.Batch` provides integration with Microsoft Entra ID for identity-based authentication of requests. With Azure AD, you can use role-based access control (RBAC) to grant access to your Azure Batch resources to users, groups, or applications. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides easy Microsoft Entra ID support for authentication.


``` C# Snippet:Batch_Readme_EntraIDCredential
var credential = new DefaultAzureCredential();
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), credential);
```

Previously in `Microsoft.Azure.Batch`, it supported Microsoft Entra ID by acquiring an auth token. The following example calls MSAL to authenticate a user who's interacting with the application. The MSAL IConfidentialClientApplication.AcquireTokenByAuthorizationCode method prompts the user for their credentials. The application proceeds once the user provides credentials.

``` C#

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.Identity.Client;

public static void PerformBatchOperations()
{
    Func<Task<string>> tokenProvider = () => GetTokenUsingAuthorizationCode();

    using (var batchClient = BatchClient.Open(new BatchTokenCredentials(BatchAccountUrl, tokenProvider)))
    {
        batchClient.JobOperations.ListJobs();
    }
}

public static async Task<string> GetTokenUsingAuthorizationCode(string authorizationCode, string redirectUri, string[] scopes)
{
    var app = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithAuthority(AuthorityUri)
                .WithRedirectUri(RedirectUri)
                .Build();

    var authResult = await app.AcquireTokenByAuthorizationCode(scopes, authorizationCode).ExecuteAsync();
    return authResult.AccessToken;
}

```

### Authenticate with Shared Key Credentials

In `Azure.Compute.Batch` you can use AzureNamedKeyCredential with your Batch account access keys to authenticate Azure commands for the Batch service.  You can find your batch account shared keys in the portal under the "keys" section or you can run the following [CLI command](https://learn.microsoft.com/cli/azure/batch/account/keys?view=azure-cli-latest) 

```bash
az batch account keys list --name <your-batch-account> --resource-group <your-resource-group-name>
```

``` C# Snippet:Batch_Readme_AzureNameKeyCredential
var credential = new AzureNamedKeyCredential("<your account>", "BatchAccountKey");
BatchClient batchClient = new BatchClient(
    new Uri("https://<your account>.eastus.batch.azure.com"),
    credential);
```

Previously in `Microsoft.Azure.Batch`, you could use the `BatchSharedKeyCredentials` class to construct a shared key credential, then pass the credential and account endpoint to the `BatchClient` constructor to create a client instance.

``` C#
var cred = new BatchSharedKeyCredentials(BatchAccountUrl, BatchAccountName, BatchAccountKey);
using BatchClient batchClient = BatchClient.Open(cred);
```


## Error Handling

In `Azure.Compute.Batch` when a command fails due to an error on the server side an exception of type RequestFailedException will be thrown.  Inside that exception will be the rest response json from the Batch Service which contains the details about the error.  This json conforms to the structure of the BatchError object found under the Generated folder.  You can  

``` C#
try
{
    response = await batchClient.ResizePoolAsync("fakepool", resizeContent);
}
catch (Azure.RequestFailedException e)
{
    BatchError err = BatchError.ExtractBatchErrorFromExeception(e);
    if(err.Code == BatchErrorCodeStrings.PoolNotFound)
    {
      // do something
    }
}
```

Previously in `Microsoft.Azure.Batch` failed commands would throw a BatchException

``` C#
try
{
   // Create the pool on the Batch Service
   await pool.CommitAsync().ConfigureAwait(continueOnCapturedContext: false);

}
catch (BatchException e)
{
   // Swallow the specific error code PoolExists since that is expected if the pool already exists
   if (e.RequestInformation?.BatchError?.Code == BatchErrorCodeStrings.PoolExists)
   {
       // do somethingh
   }
   
}

```
## Operations Examples

> Note: Both `Microsoft.Azure.Batch` and `Azure.Compute.Batch` support async and sync batch operations, all the examples below will be show the sync versions. 

### Pool Operations

#### CreatePool

Previously in `Microsoft.Azure.Batch` to create a pool you would call the `CreatePool` method from the PoolOperations object and then follow up with a call to .Commit() to finalize the creation of the pool in Azure.

``` C#
CloudPool unboundPool =
        batchClient.PoolOperations.CreatePool(
            poolId: poolId,
            virtualMachineSize: "standard_d2_v3",
            virtualMachineConfiguration: new VirtualMachineConfiguration(
            imageReference: new ImageReference(
                    publisher: "MicrosoftWindowsServer",
                    offer: "WindowsServer",
                    sku: "2016-Datacenter-smalldisk",
                    version: "latest"
            ),
        nodeAgentSkuId: "batch.node.windows amd64"),
        targetDedicatedComputeNodes: nodeCount);
unboundPool.Commit();
```

Going forward there are two options. Azure batch has two sdk, [`Azure.Compute.Batch`](https://learn.microsoft.com/dotnet/api/azure.compute.batch?view=azure-dotnet-preview&viewFallbackFrom=azure-dotnet) which interacts directly the azure batch service, and [`Azure.ResourceManager.Batch`](https://learn.microsoft.com/dotnet/api/overview/azure/resourcemanager.batch-readme?view=azure-dotnet) which interacts with the Azure Resource Manager.  Both of these SDK's support batch pool opertionas such as create/get/update/list etc but only the `Azure.ResourceManager.Batch` sdk can create a pool with managed identies and for that reason its the recommend way to create a pool.  

`Azure.ResourceManager.Batch` [pool create](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.batch.batchaccountpoolcollection.createorupdate?view=azure-dotnet) with managed identity.  You create a pool by getting a reference to the batch account then issuing a `CreateOrUpdate` call from the GetBatchAccountPools() collection.
``` C#
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
```


``` C#
var credential = new DefaultAzureCredential();
ArmClient _armClient = new ArmClient(credential);
        
var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");   
BatchAccountResource batchAccount = _armClient.GetBatchAccountResource(batchAccountIdentifier);

var poolName = "HelloWorldPool";
var imageReference = new BatchImageReference()
{
    Publisher = "canonical",
    Offer = "0001-com-ubuntu-server-jammy",
    Sku = "22_04-lts",
    Version = "latest"
};
string nodeAgentSku = "batch.node.ubuntu 22.04";

var batchAccountPoolData = new BatchAccountPoolData()
{
    VmSize = "Standard_DS1_v2",
    DeploymentConfiguration = new BatchDeploymentConfiguration()
    {
        VmConfiguration = new BatchVmConfiguration(imageReference, nodeAgentSku)
    },
    ScaleSettings = new BatchAccountPoolScaleSettings()
    {
        FixedScale = new BatchAccountFixedScaleSettings()
        {
            TargetDedicatedNodes = 1
        }
    },
    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
    {
        UserAssignedIdentities = {
            [new ResourceIdentifier("Your Identity Azure Resource Manager ResourceId")] = new UserAssignedIdentity(),
        },
    }
};

ArmOperation<BatchAccountPoolResource> armOperation = batchAccount.GetBatchAccountPools().CreateOrUpdate(
    WaitUntil.Completed, poolName, batchAccountPoolData);
BatchAccountPoolResource pool = armOperation.Value;
```

As metioned you can create a pool using `Azure.Compute.Batch` [pool create](https://learn.microsoft.com/dotnet/api/azure.compute.batch.batchclient.createpool) just without support for managed identies.  First you create a batch client with your credentials then you issue a `CreatePool` call directly from the batch client.
``` C# Snippet:Batch_Readme_PoolCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

ImageReference imageReference = new ImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
poolID, "STANDARD_D1_v2")
{
    VirtualMachineConfiguration = virtualMachineConfiguration,
    TargetDedicatedNodes = 2,
};

// create pool
batchClient.CreatePool(batchPoolCreateOptions);
```

#### GetPool
Previously in `Microsoft.Azure.Batch` to get a pool you could call the `GetPool` method from the PoolOperations object
``` C#
CloudPool pool = batchClient.PoolOperations.GetPool(poolId);
```
Additionally you could refresh an existing clould pool object to issue a get pool command in the background and get a updaed version of it. 
``` C#
pool.Refresh()
```


With `Azure.Compute.Batch` call `GetPool`
``` C#
BatchPool orginalPool = batchClient.GetPool(poolID);

```
#### ListPools 
Previously in `Microsoft.Azure.Batch` to get a list of pools you could call the `ListPools` method from the PoolOperations object
``` C#
List<CloudPool> pools = new List<CloudPool>(batchClient.PoolOperations.ListPools());

foreach (CloudPool curPool in pools)
{
    if (curPool.Id.Equals(poolToCreateId))
    {
        // do some action
    }
}
```
With `Azure.Compute.Batch` call `GetPools`
``` C#
foreach (BatchPool item in batchClient.GetPools())
{
    // do some action
}
```

#### DeletePool
Previously in `Microsoft.Azure.Batch` to delete a pool you could call the `DeletePool` method from the PoolOperations object
``` C#
batchClient.PoolOperations.DeletePool(PoolId);

```
With `Azure.Compute.Batch` call `DeletePool`
``` C#
batchClient.DeletePool(poolID);
```

#### PatchPool

Previously in `Microsoft.Azure.Batch` to patch a pool would first have to have a bound pool, i.e. a pool that exists, then update its properties then call  `Commit`
``` C#
CloudJob refreshableJob = batchClient.JobOperations.GetJob(jobId);
refreshableJob.NetworkConfiguration = new JobNetworkConfiguration("0.0.0.0", false);
refreshableJob.CommitChanges();
```

With `Azure.Compute.Batch` call `UpdatePool`
``` C#
BatchPoolUpdateContent updateContent = new BatchPoolUpdateContent();
updateContent.Metadata.Add(new MetadataItem("name", "value"));

batchClient.UpdatePool(poolID, updateContent);
```

#### UpdatePool

Previously in `Microsoft.Azure.Batch` to update a pool would first have to have a bound pool, i.e. a pool that exists, then update its properties then call  `Commit`
``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool(poolId);
IList<MetadataItem> changedMDI = new List<MetadataItem> { new MetadataItem("name", "value") };
boundPool.Metadata = changedMDI;
boundPool.Commit();
```

With `Azure.Compute.Batch` call `ReplacePoolProperties`
``` C#
MetadataItem[] metadataIems = new MetadataItem[] {
              new MetadataItem("name", "value")};

BatchPoolReplaceContent replaceContent = new BatchPoolReplaceContent(batchApplicationPackageReferences, metadataIems);
batchClient.ReplacePoolProperties(poolID, replaceContent);
```
#### ResizePool

Previously in `Microsoft.Azure.Batch` to resize a pool would first have to have a bound pool, i.e. a pool that exists, then call `Resize`
``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool(poolId);
boundPool.Resize(
             targetDedicatedComputeNodes: targetDedicated,
             targetLowPriorityComputeNodes: targetLowPriority,
             resizeTimeout: TimeSpan.FromMinutes(10));
```

With `Azure.Compute.Batch` call `ResizePool`
``` C#
BatchPoolResizeContent resizeContent = new BatchPoolResizeContent()
{
    TargetDedicatedNodes = 1,
    ResizeTimeout = TimeSpan.FromMinutes(10),
};

batchClient.ResizePool(poolID, resizeContent);
```
                    
#### StopResizePool

Previously in `Microsoft.Azure.Batch` to stop resizing a pool you could call the `StopResize` method from the PoolOperations object
``` C#
//Resize the pool
boundPool.Resize(newTargetDedicated, 0);

boundPool.Refresh();
Assert.Equal(AllocationState.Resizing, boundPool.AllocationState);

boundPool.StopResize();
```

With `Azure.Compute.Batch` call `StopPoolResize`
``` C#
batchClient.StopPoolResize(poolID);
```

#### EnableAutoScalePool

Previously in `Microsoft.Azure.Batch` to enable auto scale in a pool you could call the `EnableAutoScale` method from the PoolOperations object
``` C#
string autoscaleFormula1 = "$TargetDedicatedNodes=0;$TargetLowPriorityNodes=0;$NodeDeallocationOption=requeue";
boundPool.EnableAutoScale(autoscaleFormula1);
```

With `Azure.Compute.Batch` call `EnablePoolAutoScale` and pass in a BatchPoolEnableAutoScaleContent object
``` C#
BatchPoolEnableAutoScaleContent batchPoolEnableAutoScaleContent = new BatchPoolEnableAutoScaleContent()
        {
            AutoScaleEvaluationInterval = newEvalInterval,
            AutoScaleFormula = poolASFormulaNew,
        };

batchClient.EnablePoolAutoScale(poolId, batchPoolEnableAutoScaleContent);
```

#### DisableAutoScalePool

Previously in `Microsoft.Azure.Batch` to disable auto scale in a pool you could call the `DisableAutoScale` method from the PoolOperations object
``` C#
boundPool.DisableAutoScale();
```

With `Azure.Compute.Batch` call `DisablePoolAutoScale` and pass in a `BatchPoolEnableAutoScaleContent` object
``` C#
batchClient.DisablePoolAutoScale(poolId);
```

#### EvaluateAutoScalePool

Previously in `Microsoft.Azure.Batch` to evaluate an auto scale formula in a pool you could call the `EvaluateAutoScale` method from the PoolOperations object
``` C#
const string poolASFormula2 = "$TargetDedicatedNodes=1;";
AutoScaleRun eval = boundPool.EvaluateAutoScale(poolASFormula2);
```

With `Azure.Compute.Batch` call `EvaluatePoolAutoScale` and pass in a `BatchPoolEvaluateAutoScaleContent` object
``` C#
string poolASFormulaNew = "$TargetDedicated = 1;";
BatchPoolEvaluateAutoScaleContent batchPoolEvaluateAutoScaleContent = new BatchPoolEvaluateAutoScaleContent(poolASFormulaNew);
AutoScaleRun eval = batchClient.EvaluatePoolAutoScale(poolId, batchPoolEvaluateAutoScaleContent);
```

#### ListPoolNodeCounts

Previously in `Microsoft.Azure.Batch` to list pool node counts you could call the `ListPoolNodeCounts` method from the PoolOperations object
``` C#             
foreach (var poolNodeCount in batchClient.PoolOperations.ListPoolNodeCounts())
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetPoolNodeCounts`
``` C#
foreach (BatchPoolNodeCounts item in batchClient.GetPoolNodeCounts())
{
    // do something
}
```

#### ListPoolUsageMetrics

Previously in `Microsoft.Azure.Batch` to list pool usage metrics you could call the `ListPoolUsageMetrics` method from the PoolOperations object
``` C#             
foreach (PoolUsageMetrics int in batchClient.PoolOperations.ListPoolUsageMetrics(DateTime.Now - TimeSpan.FromDays(1)))
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetPoolUsageMetricsAsync`
``` C#
foreach (BatchPoolUsageMetrics item in batchClient.GetPoolUsageMetrics())
{
    // do something
}
```



### Job Operations
#### Create Job
#### Delete Job
#### Disable Job
#### Enable Job
#### Get Job
#### Get Jobs
#### Get Job Preparation and Release Task Statuse
#### Get Job Task counts
#### Replace Job
#### Terminate Job
#### Update Job

### Job Schedule Operations
#### Create Job Schedule
#### Delete Job Schedule
#### Disable Job Schedule
#### Enable Job Schedule
#### Get Job Schedule
#### Get Job Schedules
#### Job Schedule Exists
#### Replace Job Schedule
#### Terminate Job Schedule
#### Update Job Schedule

### Node Operations
#### Create Node User
#### Delete Node User
#### Delete Node File
#### Get Node 
#### Get Nodes 
#### Get Node Extension
#### Get Node Extensions
#### Get Node File
#### Get Node Files
#### Get Node File Properties
#### Get Node Remote Login Settings
#### Reboot Node 
#### Remove Nodes 
#### Remove Node User
#### Update Node Logs


#### Enable Node Schedululing
#### Disable Node Schedululing

### Task Operations
#### Create Task
#### Get Task
#### Get Tasks
#### Delete Task
#### Create Task Collection
#### Delete Task File
#### Get Task File
#### Get Task Files
#### Get Task File Properties
#### Get Sub Tasks
#### Reactivate Task
#### Replace Task
#### Terminate Task


### Application Operations
#### Get Application
#### Get Applications

#### Get Supported Images




