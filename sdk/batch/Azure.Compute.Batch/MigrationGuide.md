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
      - [Get Supported Images](#get-supported-images)
  - [Job Operations](#job-operations)
      - [CreateJob](#createjob)
      - [GetJob](#getjob)
      - [ListJobs](#listjobs)
      - [DeleteJob](#deletejob)
      - [Replace](#replace-job)
      - [Update](#update-job)
      - [Disable](#disable-job)
      - [Enable](#enable-job)
      - [ListJobPreparationAndReleaseTaskStatus](#listjobpreparationandreleasetaskstatus)
      - [GetJobTaskCounts](#getjobtaskcounts)
      - [Terminate](#terminate-job)
  - [Job Schedule Operations](#job-schedule-operations)
      - [CreateJobSchedule](#createjobschedule)
      - [GetJobSchedule](#getjobschedule)
      - [ListJobSchedules](#listjobschedules)
      - [DeleteJobSchedule](#deletejobschedule)
      - [Replace](#replace-job-schedule)
      - [Update](#update-job-schedule)
      - [Disable](#disable-job-schedule)
      - [Enable](#enable-job-schedule)
      - [Terminate](#terminate-job-schedule)
  - [Task Operations](#task-operations)
      - [AddTask](#addtask)
      - [GetTask](#gettask)
      - [ListTasks](#listtasks)
      - [Delete](#delete-task)
      - [Replace](#replace-task)
      - [Reactivate](#reactivate-task)
      - [Terminate](#terminate-task)
  - [Node Operations](#node-operations)
      - [GetComputeNode](#getcomputenode)
      - [ListComputeNodes](#listcomputenodes)
      - [Reboot](#reboot-node)
      - [CreateComputeNodeUser](#createcomputenodeuser)
      - [DeleteComputeNodeUser](#deletecomputenodeuser)
      - [GetNodeFile](#getnodefile)
      - [ListNodeFiles](#listnodefiles)
      - [DeleteNodeFile](#deletenodefile)
      - [File Properties](#get-node-file-properties)
      - [GetRemoteLoginSettings](#getremoteloginsettings)
      - [UploadComputeNodeBatchServiceLogs](#uploadcomputenodebatchservicelogs)
  - [Certificate Operations](#certificate-operations)
      - [CreateCertificateFromCer](#createcertificatefromcer)
      - [CreateCertificateFromPfx](#createcertificatefrompfx)
      - [GetCertificate](#getcertificate)
      - [ListCertificates](#listcertificates)
      - [DeleteCertificate](#deletecertificate)
      - [CancelDeleteCertificate](#canceldeletecertificate)
  - [Application Operations](#application-operations)
      - [GetApplicationSummary](#getapplicationsummary)
      - [ListApplicationSummaries](#listapplicationsummaries)

## Overview

### Migration Benefits

> Note: `Microsoft.Azure.Batch` has been [deprecated]. Please upgrade to `Azure.Compute.Batch` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, including Batch, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Batch library `Azure.Compute.Batch` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new Azure.Identity library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries.

We strongly encourage moving to `Azure.Compute.Batch`. It is important to be aware the legacy `Microsoft.Azure.Batch` package has been officially deprecated. Though they will continue to be supported with critical security and bug fixes, they are no longer under active development and will not receive new features or minor fixes. There is no guarantee of feature parity between the and legacy client library versions.

### `Azure.Compute.Batch` Differences

Developing a batch workflow against `Azure.Compute.Batch` differs from developing a batch workflow against `Microsoft.Azure.Batch` in a couple of key ways.

- **Name Changes**: Many of the objects and operations names have changed in `Azure.Compute.Batch`. This guide below should highlight these but expect such differences as object names changing from `CloudPool` to `BatchPool` and operations such as `batchClient.JobOperations.ListTasks()` to `batchClient.GetTasks()`
- **API location**: In `Microsoft.Azure.Batch` all operations are grouped into operation classes whereas in `Azure.Compute.Batch` all operations are under the BatchClient. For example, in `Microsoft.Azure.Batch` all pool operations are under a PoolOperations class, Job operations are under a JobOperations class, and so on. For example, in `Microsoft.Azure.Batch` the method to create a pool would be under PoolOperations `batchClient.PoolOperations.CreatePool()` whereas in `Azure.Compute.Batch` the operation is under the client `batchClient.CreatePool()`. In addition, `Microsoft.Azure.Batch` allowed operations off of objects such as the case below where the user would retrieve a CloudPool object, modify it, then issue a `.Commit()` to update it.

``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool("poolId");
IList<MetadataItem> changedMDI = new List<MetadataItem> { new MetadataItem("name", "value") };
boundPool.Metadata = changedMDI;

boundPool.Commit();
```

whereas in `Azure.Compute.Batch` all commands are under the client so you would issue an UpdatePool command from the client.

``` C#
BatchPoolUpdateContent updateContent = new BatchPoolUpdateContent();
updateContent.Metadata.Add(new MetadataItem("name", "value"));

Response response = await batchClient.UpdatePoolAsync(poolID, updateContent);
```

- **Bound Object**: In `Microsoft.Azure.Batch` there is a concept of Batch Objects being Bound vs Unbound. For example, in the following code the call to CreatePool creates an unbound pool object, in other words, the pool has yet to be created in Azure. Once the user calls pool.Commit() the command is issued to create the pool in Azure.
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

whereas with `Azure.Compute.Batch` when you call CreatePool the pool is created in Azure immediately.

```C# Snippet:Batch_Readme_PoolCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

BatchVmImageReference imageReference = new BatchVmImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(
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


```C# Snippet:Batch_Readme_EntraIDCredential
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

```C# Snippet:Batch_Readme_AzureNameKeyCredential
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

In `Azure.Compute.Batch` when a command fails due to an error on the server side an exception of type RequestFailedException will be thrown.  Inside that exception will an "ErrorCode" property which is a string representation of the error, a "Status" property which represents the HTTP status code, a "Message" which provides a summary of the error, and in some cases their will be additional information in the "Data" Dictionary.  

```C# Snippet:Batch_Migration_Exception
try
{
    batchClient.ResizePool("fakepool", resizeOptions);
}
catch (Azure.RequestFailedException e)
{
    if ((e.ErrorCode == BatchErrorCode.PoolNotFound) &&
        (e.Status == 404))
    {
        // write out the summary message
        Console.WriteLine(e.Message);

        // additional message details
        foreach (DictionaryEntry item in e.Data)
        {
            Console.WriteLine(item.Key);
            Console.WriteLine(item.Value);
        }
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

> Note: Both `Microsoft.Azure.Batch` and `Azure.Compute.Batch` support async and sync batch operations, all the examples below will show the sync versions. 

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

Going forward there are two options. Azure batch has two sdk, [`Azure.Compute.Batch`](https://learn.microsoft.com/dotnet/api/azure.compute.batch?view=azure-dotnet-preview&viewFallbackFrom=azure-dotnet) which interacts directly the azure batch service, and [`Azure.ResourceManager.Batch`](https://learn.microsoft.com/dotnet/api/overview/azure/resourcemanager.batch-readme?view=azure-dotnet) which interacts with the Azure Resource Manager.  Both of these SDK's support batch pool operations such as create/get/update/list etc but only the `Azure.ResourceManager.Batch` sdk can create a pool with managed identities and for that reason its the recommend way to create a pool.  

`Azure.ResourceManager.Batch` [pool create](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.batch.batchaccountpoolcollection.createorupdate?view=azure-dotnet) with managed identity.  You create a pool by getting a reference to the batch account then issuing a `CreateOrUpdate` call from the GetBatchAccountPools() collection.
``` C#
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
```


```C# Snippet:Batch_Migration_PoolCreateManagementPlane
    var credential = new DefaultAzureCredential();
    ArmClient _armClient = new ArmClient(credential);

    var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
    BatchAccountResource batchAccount = _armClient.GetBatchAccountResource(batchAccountIdentifier);

    var poolName = "HelloWorldPool";
    var imageReference = new Azure.ResourceManager.Batch.Models.BatchImageReference()
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
    [new ResourceIdentifier("Your Identity Azure Resource Manager ResourceId")] = new Azure.ResourceManager.Models.UserAssignedIdentity(),
},
        }
    };

    ArmOperation<BatchAccountPoolResource> armOperation = batchAccount.GetBatchAccountPools().CreateOrUpdate(
        WaitUntil.Completed, poolName, batchAccountPoolData);
    BatchAccountPoolResource pool = armOperation.Value;
```

As mentioned you can create a pool using `Azure.Compute.Batch` [pool create](https://learn.microsoft.com/dotnet/api/azure.compute.batch.batchclient.createpool) just without support for managed identities.  First you create a batch client with your credentials then you issue a `CreatePool` call directly from the batch client.

```C# Snippet:Batch_Readme_PoolCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

BatchVmImageReference imageReference = new BatchVmImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(
poolID, "STANDARD_D1_v2")
{
    VirtualMachineConfiguration = virtualMachineConfiguration,
    TargetDedicatedNodes = 2,
};

// create pool
batchClient.CreatePool(batchPoolCreateOptions);
```

#### GetPool
Previously in `Microsoft.Azure.Batch` to get a pool you could call the `GetPool` method from the PoolOperations object.

``` C#
CloudPool pool = batchClient.PoolOperations.GetPool("poolId");
```
Additionally you could refresh an existing clould pool object to issue a get pool command in the background and get a updaed version of it. 
``` C#
pool.Refresh()
```


With `Azure.Compute.Batch` call `GetPool`.

```C# Snippet:Batch_Readme_PoolRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPool batchPool = batchClient.GetPool("poolID");

Console.WriteLine(batchPool.Id);
Console.WriteLine(batchPool.Uri);
Console.WriteLine(batchPool.AllocationState);
```
#### ListPools 
Previously in `Microsoft.Azure.Batch` to get a list of pools you could call the `ListPools` method from the PoolOperations object.

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
With `Azure.Compute.Batch` call `GetPools`.

```C# Snippet:Batch_Readme_ListPools
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPool item in batchClient.GetPools())
{
    Console.WriteLine(item.Id);
}
```

#### DeletePool
Previously in `Microsoft.Azure.Batch` to delete a pool you could call the `DeletePool` method from the PoolOperations object.

``` C#
batchClient.PoolOperations.DeletePool("poolID");

```
With `Azure.Compute.Batch` call `DeletePool`.

```C# Snippet:Batch_Migration_DeletePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeletePool("poolID");
```
Optionally you can use the returned `DeletePoolOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_DeletePool_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

DeletePoolOperation operation = batchClient.DeletePool("poolID");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```

#### PatchPool

Previously in `Microsoft.Azure.Batch` to patch a pool would first have to have a bound pool, i.e. a pool that exists, then update its properties then call  `Commit`.

``` C#
CloudJob refreshableJob = batchClient.JobOperations.GetJob("jobID");
refreshableJob.NetworkConfiguration = new JobNetworkConfiguration("0.0.0.0", false);
refreshableJob.CommitChanges();
```

With `Azure.Compute.Batch` call `UpdatePool`.

```C# Snippet:Batch_Migration_PatchPool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPoolUpdateOptions updateOptions = new BatchPoolUpdateOptions();
updateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdatePool("poolID", updateOptions);
```

#### UpdatePool

Previously in `Microsoft.Azure.Batch` to update a pool would first have to have a bound pool, i.e. a pool that exists, then update its properties then call `Commit`.

``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool("poolId");
IList<MetadataItem> changedMDI = new List<MetadataItem> { new MetadataItem("name", "value") };
boundPool.Metadata = changedMDI;
boundPool.Commit();
```

With `Azure.Compute.Batch` call `ReplacePoolProperties`.

```C# Snippet:Batch_Migration_UpdatePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchMetadataItem[] metadataItems = new BatchMetadataItem[] {
  new BatchMetadataItem("name", "value")};

BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
        new BatchApplicationPackageReference("applicationPackage")
        {
            Version = "1"
        }
    };

BatchCertificateReference[] certificateReferences = new BatchCertificateReference[] {
        new BatchCertificateReference("thumbprint","thumbprintAlgorithm")
        {
            StoreLocation = "storeLocation",
            StoreName = "storeName"
        }
};

BatchPoolReplaceOptions replaceOptions = new BatchPoolReplaceOptions(certificateReferences, batchApplicationPackageReferences, metadataItems);
batchClient.ReplacePoolProperties("poolID", replaceOptions);
```
#### ResizePool

Previously in `Microsoft.Azure.Batch` to resize a pool would first have to have a bound pool, i.e. a pool that exists, then call `Resize`.

``` C#
CloudPool boundPool = batchClient.PoolOperations.GetPool("poolId");
boundPool.Resize(
             targetDedicatedComputeNodes: targetDedicated,
             targetLowPriorityComputeNodes: targetLowPriority,
             resizeTimeout: TimeSpan.FromMinutes(10));
```

With `Azure.Compute.Batch` call `ResizePool`.

```C# Snippet:Batch_Migration_ResizePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPoolResizeOptions resizeOptions = new BatchPoolResizeOptions()
{
    TargetDedicatedNodes = 1,
    ResizeTimeout = TimeSpan.FromMinutes(10),
};

batchClient.ResizePool("poolID", resizeOptions);
```
                    
#### StopResizePool

Previously in `Microsoft.Azure.Batch` to stop resizing a pool you could call the `StopResize` method from the PoolOperations object.

``` C#
//Resize the pool
boundPool.Resize(newTargetDedicated, 0);

boundPool.Refresh();
Assert.Equal(AllocationState.Resizing, boundPool.AllocationState);

boundPool.StopResize();
```

With `Azure.Compute.Batch` call `StopPoolResize`.

```C# Snippet:Batch_Migration_StopResizePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.StopPoolResize("poolId");
```

#### EnableAutoScalePool

Previously in `Microsoft.Azure.Batch` to enable auto scale in a pool you could call the `EnableAutoScale` method from the PoolOperations object.

``` C#
string autoscaleFormula1 = "$TargetDedicatedNodes=0;$TargetLowPriorityNodes=0;$NodeDeallocationOption=requeue";
boundPool.EnableAutoScale(autoscaleFormula1);
```

With `Azure.Compute.Batch` call `EnablePoolAutoScale` and pass in a `BatchPoolEnableAutoScaleOptions` object.

```C# Snippet:Batch_Migration_EnableAutoScalePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
TimeSpan evalInterval = TimeSpan.FromMinutes(6);
string poolASFormulaNew = "$TargetDedicated = 1;";

BatchPoolEnableAutoScaleOptions batchPoolEnableAutoScaleOptions = new BatchPoolEnableAutoScaleOptions()
{
    AutoScaleEvaluationInterval = evalInterval,
    AutoScaleFormula = poolASFormulaNew,
};

batchClient.EnablePoolAutoScale("poolId", batchPoolEnableAutoScaleOptions);
```

#### DisableAutoScalePool

Previously in `Microsoft.Azure.Batch` to disable auto scale in a pool you could call the `DisableAutoScale` method from the PoolOperations object.

``` C#
boundPool.DisableAutoScale();
```

With `Azure.Compute.Batch` call `DisablePoolAutoScale`.

```C# Snippet:Batch_Migration_DisableAutoScalePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DisablePoolAutoScale("poolId");
```

#### EvaluateAutoScalePool

Previously in `Microsoft.Azure.Batch` to evaluate an auto scale formula in a pool you could call the `EvaluateAutoScale` method from the PoolOperations object.

``` C#
const string poolASFormula2 = "$TargetDedicatedNodes=1;";
AutoScaleRun eval = boundPool.EvaluateAutoScale(poolASFormula2);
```

With `Azure.Compute.Batch` call `EvaluatePoolAutoScale` and pass in a `BatchPoolEvaluateAutoScaleOptions` object.

```C# Snippet:Batch_Migration_EvaluatePoolAutoScale
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolASFormulaNew = "$TargetDedicated = 1;";
BatchPoolEvaluateAutoScaleOptions batchPoolEvaluateAutoScaleOptions = new BatchPoolEvaluateAutoScaleOptions(poolASFormulaNew);
AutoScaleRun eval = batchClient.EvaluatePoolAutoScale("poolId", batchPoolEvaluateAutoScaleOptions);
```

#### ListPoolNodeCounts

Previously in `Microsoft.Azure.Batch` to list pool node counts you could call the `ListPoolNodeCounts` method from the PoolOperations object.

``` C#
foreach (var poolNodeCount in batchClient.PoolOperations.ListPoolNodeCounts())
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetPoolNodeCounts`.

```C# Snippet:Batch_Migration_GetPoolNodeCounts
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPoolNodeCounts item in batchClient.GetPoolNodeCounts())
{
    // do something
}
```

#### ListPoolUsageMetrics

Previously in `Microsoft.Azure.Batch` to list pool usage metrics you could call the `ListPoolUsageMetrics` method from the PoolOperations object.

``` C#
foreach (PoolUsageMetrics int in batchClient.PoolOperations.ListPoolUsageMetrics(DateTime.Now - TimeSpan.FromDays(1)))
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetPoolUsageMetricsAsync`.

```C# Snippet:Batch_Migration_GetPoolUsageMetrics
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPoolUsageMetrics item in batchClient.GetPoolUsageMetrics())
{
    // do something
}
```

#### Get Supported Images

Previously in `Microsoft.Azure.Batch` to get a list of supported images ou could call the `ListSupportedImages` method from the PoolOperations object.

``` C#
var supportedImages = batchCli.PoolOperations.ListSupportedImages().ToList();

foreach (ImageInformation imageInfo in supportedImages)
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetSupportedImagesAsync`.

```C# Snippet:Batch_Migration_GetSupportedImages
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchSupportedImage item in batchClient.GetSupportedImages())
{
    // do something
}
```

### Job Operations

#### CreateJob

Previously in `Microsoft.Azure.Batch` to create a job you could call the `CreateJob` method from the JobOperations object followed by a Commit to create a job.

``` C#
CloudJob unboundJob = batchClient.JobOperations.CreateJob();
unboundJob.Id = "JobID";
unboundJob.PoolInformation = new PoolInformation() { PoolId = "poolID" };

// Commit Job to create it in the service
unboundJob.Commit();
```

With `Azure.Compute.Batch` call `CreateJob` with a parameter of type `BatchJobCreateOptions`.

```C# Snippet:Batch_Readme_JobCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CreateJob(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
```

#### GetJob

Previously in `Microsoft.Azure.Batch` to get a job you could call the `GetJob` method from the JobOperations object.

``` C#
CloudJob updatedJob = batchClient.JobOperations.GetJob("jobID");
```

With `Azure.Compute.Batch` call `GetJob`.

```C# Snippet:Batch_Readme_JobRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJob batchJob = batchClient.GetJob("jobID");
Console.WriteLine(batchJob.Id);
Console.WriteLine(batchJob.State);
```

#### ListJobs

Previously in `Microsoft.Azure.Batch` to get a list of jobs you could call the `ListJobs` method from the JobOperations object.

``` C#
List<CloudJob> jobs = new List<CloudJob>(batchClient.JobOperations.ListJobs());
 
foreach (CloudJob curJob in jobs)
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetJobs`.

```C# Snippet:Batch_Readme_ListJobs
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJob item in batchClient.GetJobs())
{
    Console.WriteLine(item.Id);
}
```

#### DeleteJob

Previously in `Microsoft.Azure.Batch` to delete a job you could call the `DeleteJob` method from the JobOperations object.

``` C#
batchClient.JobOperations.DeleteJob("jobID");
```

With `Azure.Compute.Batch` call `DeleteJob`. 

```C# Snippet:Batch_Migration_DeleteJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteJob("jobID");
```
Optionally you can use the returned `DeleteJobOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_DeleteJob_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

DeleteJobOperation operation = batchClient.DeleteJob("jobID");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```
#### Replace Job

Previously in `Microsoft.Azure.Batch` to replace a job you could call the `Commit` method from the JobOperations object on a modified `CloudJob`.

``` C#
CloudJob refreshableJob = batchClient.JobOperations.GetJob("jobID");
JobConstraints newJobConstraints = new JobConstraints(TimeSpan.FromSeconds(200), 19);
refreshableJob.Constraints = newJobConstraints;
refreshableJob.Commit();
```

With `Azure.Compute.Batch` call `ReplaceJob`.

```C# Snippet:Batch_Migration_ReplaceJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJob job = batchClient.GetJob("jobID");
job.AllTasksCompleteMode = BatchAllTasksCompleteMode.TerminateJob;
batchClient.ReplaceJob("jobID", job);
```

#### Update Job

Previously in `Microsoft.Azure.Batch` to update a job you could call the `CommitChanges` method directly from a modified CloudJob object.

``` C#
CloudJob refreshableJob = batchClient.JobOperations.GetJob("jobID");
refreshableJob.NetworkConfiguration = new JobNetworkConfiguration("0.0.0.0", false);
refreshableJob.CommitChanges();
```

With `Azure.Compute.Batch` call `UpdateJob` with a parameter of type `BatchJobUpdateOptions`.

```C# Snippet:Batch_Migration_UpdateJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobUpdateOptions batchUpdateOptions = new BatchJobUpdateOptions();
batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdateJob("jobID", batchUpdateOptions);
```

#### Disable Job

Previously in `Microsoft.Azure.Batch` to disable a job you could call the `Disable` method directly from the CloudJob object.

``` C#
CloudJob updatedJob = batchClient.JobOperations.GetJob("jobID");
updatedJob.Disable(DisableJobOption.Terminate);
```

With `Azure.Compute.Batch` call `DisableJob` with a parameter of type `BatchJobDisableOptions`. 

```C# Snippet:Batch_Migration_DisableJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobDisableOptions options = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
batchClient.DisableJob("jobID", options);
```
Optionally you can use the returned `DisableJobOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_DisableJob_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobDisableOptions options = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
DisableJobOperation operation = batchClient.DisableJob("jobID", options);

// Optional, wait for operation to complete
operation.WaitForCompletion();
```

#### Enable Job

Previously in `Microsoft.Azure.Batch` to enable a job you could call the `Enable` method directly from the CloudJob object.

``` C# 
CloudJob updatedJob = batchClient.JobOperations.GetJob("jobID");
updatedJob.Enable();
```

With `Azure.Compute.Batch` call `EnableJob`. 

```C# Snippet:Batch_Migration_EnableJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.EnableJob("jobID");
```
Optionally you can use the returned `EnableJobOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_EnableJob_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

EnableJobOperation operation = batchClient.EnableJob("jobID");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```

#### ListJobPreparationAndReleaseTaskStatus

Previously in `Microsoft.Azure.Batch` to get a list of job preparation and release task status you could call the `ListJobPreparationAndReleaseTaskStatus` method from the JobOperations object.

``` C#
List<JobPreparationAndReleaseTaskExecutionInformation> jobPrepStatus = new List<JobPreparationAndReleaseTaskExecutionInformation>(batchClient.JobOperations.ListJobPreparationAndReleaseTaskStatus("jobID"));
 
foreach (JobPreparationAndReleaseTaskExecutionInformation item in jobPrepStatus)
{
    // do something
}        
```

With `Azure.Compute.Batch` call `GetJobPreparationAndReleaseTaskStatuses`.

```C# Snippet:Batch_Migration_GetJobPreparationAndReleaseTaskStatuses
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJobPreparationAndReleaseTaskStatus item in batchClient.GetJobPreparationAndReleaseTaskStatuses("jobID"))
{
    // do something
}
```

#### GetJobTaskCounts

Previously in `Microsoft.Azure.Batch` to get a job task count you could call the `GetJobTaskCounts` method from the JobOperations object.

``` C#
TaskCountsResult taskCount = batchClient.JobOperations.GetJobTaskCounts("jobID");
```

With `Azure.Compute.Batch` call `GetJobTaskCounts`.

```C# Snippet:Batch_Migration_GetJobTaskCounts
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTaskCountsResult batchTaskCountsResult = batchClient.GetJobTaskCounts("jobID");
```

#### Terminate Job

Previously in `Microsoft.Azure.Batch` to terminate a job you could call the `Terminate` method from the JobOperations object.

``` C#
CloudJob job = batchClient.JobOperations.GetJob("jobID");       
job.Terminate("need some reason");
```

With `Azure.Compute.Batch` call `TerminateJob`. 

```C# Snippet:Batch_Migration_TerminateJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateJob("jobID");
```
Optionally you can use the returned `TerminateJobOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_TerminateJob_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

TerminateJobOperation operation = batchClient.TerminateJob("jobID");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```

### Job Schedule Operations

#### CreateJobSchedule

Previously in `Microsoft.Azure.Batch` to create a job schedule you could call the `CreateJobSchedule` method from the JobScheduleOperations object followed by a Commit to create a job.

``` C#
CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);
TimeSpan firstRecurrenceInterval = TimeSpan.FromMinutes(2);
jobSchedule.Schedule = new Schedule() { RecurrenceInterval = firstRecurrenceInterval };
PoolInformation poolInfo = new PoolInformation()
{
    PoolId = poolFixture.PoolId
};

jobSchedule.JobSpecification = new JobSpecification(poolInfo)
{
    Priority = jobSchedulePriority,
    JobManagerTask = new JobManagerTask(jobManagerId, jobManagerCommandLine)
};

jobSchedule.Metadata = metadata;
jobSchedule.Commit();
```

With `Azure.Compute.Batch` call `CreateJobSchedule` with a parameter of type `BatchJobScheduleCreateOptions`.

```C# Snippet:Batch_Migration_CreateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration();

BatchPoolInfo poolInfo = new BatchPoolInfo()
{
    PoolId = "poolID",
};
BatchJobManagerTask batchJobManagerTask = new BatchJobManagerTask("task1", "cmd / c echo Hello World");

BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo)
{
    JobManagerTask = batchJobManagerTask,
};

BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions("jobScheduleId", schedule, jobSpecification);

batchClient.CreateJobSchedule(jobSchedule);
```

#### GetJobSchedule

Previously in `Microsoft.Azure.Batch` to get a job schedule you could call the `GetJobSchedule` method from JobScheduleOperations which returns a `CloudJobSchedule` object.

``` C#
CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.GetJobSchedule("jobScheduleId");
```

With `Azure.Compute.Batch` call `GetJobSchedule` which returns a `BatchJobSchedule` object.

```C# Snippet:Batch_Migration_GetJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");
```

#### ListJobSchedules

Previously in `Microsoft.Azure.Batch` to get a list of job schedule you could call the `ListJobSchedules` method from the JobScheduleOperations object.

``` C#
List<CloudJobSchedule> jobSchedules = new List<CloudJobSchedule>(batchClient.JobScheduleOperations.ListJobSchedules());
 
foreach (CloudJobSchedule item in jobSchedules)
{
    // do something
}     

```

With `Azure.Compute.Batch` call `GetJobSchedules`.

```C# Snippet:Batch_Migration_GetJobSchedules
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJobSchedule item in batchClient.GetJobSchedules())
{
    // do something
}
```

#### DeleteJobSchedule

Previously in `Microsoft.Azure.Batch` to delete a job schedule you could call the `DeleteJobSchedule` method from JobScheduleOperations.

``` C#
batchClient.JobScheduleOperations.DeleteJobSchedule("jobScheduleId");
```

With `Azure.Compute.Batch` call `DeleteJobSchedule`. 

```C# Snippet:Batch_Migration_DeleteJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteJobSchedule("jobScheduleId");
```
Optionally you can use the returned `DeleteJobScheduleOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_DeleteJobSchedule_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

DeleteJobScheduleOperation operation = batchClient.DeleteJobSchedule("jobScheduleId");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```

#### Replace Job Schedule

Previously in `Microsoft.Azure.Batch` to replace a job schedule you could call the `Commit` method from the JobScheduleOperations object on a modified `CloudJobSchedule`.

``` C#
CloudJobSchedule refreshableJobSchedule = batchClient.JobScheduleOperations.GetJobSchedule("jobScheduleId");
TimeSpan recurrenceInterval = TimeSpan.FromMinutes(5);
refreshableJobSchedule.Schedule = new Schedule()
{
    RecurrenceInterval = recurrenceInterval
};
boundJobSchrefreshableJobScheduleedule.Commit();
```

With `Azure.Compute.Batch` call `ReplaceJobSchedule`.

```C# Snippet:Batch_Migration_ReplaceJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");

DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");
batchJobSchedule.Schedule = new BatchJobScheduleConfiguration()
{
    DoNotRunUntil = unboundDNRU,
};
batchClient.ReplaceJobSchedule("jobScheduleId", batchJobSchedule);
```

#### Update Job Schedule

Previously in `Microsoft.Azure.Batch` to update a job schedule you could call the `CommitChanges` method from the JobScheduleOperations object on a modified `CloudJobSchedule`.

``` C#
CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.GetJobSchedule("jobScheduleId");
jobSchedule.JobSpecification.JobManagerTask.CommandLine = newJobManagerCommandLine;
jobSchedule.Metadata = new List<MetadataItem>()
    {
        new MetadataItem(metadataKey, metadataValue)
    };

jobSchedule.CommitChanges();
```

With `Azure.Compute.Batch` call `UpdateJobSchedule` with a parameter of type `BatchJobScheduleUpdateOptions`.

```C# Snippet:Batch_Migration_UpdateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobScheduleUpdateOptions batchUpdateOptions = new BatchJobScheduleUpdateOptions();
batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdateJobSchedule("jobID", batchUpdateOptions);
```

#### Disable Job Schedule

Previously in `Microsoft.Azure.Batch` to disable a job schedule you could call the `Disable` method directly from the CloudJobSchedule object.

``` C#
CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.GetJobSchedule("jobScheduleId");
jobSchedule.Disable();
```

With `Azure.Compute.Batch` call `DisableJobSchedule`.

```C# Snippet:Batch_Migration_DisableJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DisableJobSchedule("jobScheduleId");
```

#### Enable Job Schedule

Previously in `Microsoft.Azure.Batch` to enable a job schedule you could call the `Enable` method directly from the CloudJobSchedule object.

``` C#
CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.GetJobSchedule("jobScheduleId");
jobSchedule.Enable();
```

With `Azure.Compute.Batch` call `EnableJobSchedule`.

```C# Snippet:Batch_Migration_EnableJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.EnableJobSchedule("jobScheduleId");
```

#### Terminate Job Schedule

Previously in `Microsoft.Azure.Batch` to termainate a job schedule you could call the `TerminateJobSchedule` method directly from JobScheduleOperations.

``` C#
batchClient.JobScheduleOperations.TerminateJobSchedule("jobScheduleId");
```

With `Azure.Compute.Batch` call `TerminateJobSchedule`. 

```C# Snippet:Batch_Migration_TerminateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateJobSchedule("jobScheduleId");
```
Optionally you can use the returned `TerminateJobScheduleOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_TerminateJobSchedule_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

TerminateJobScheduleOperation operation = batchClient.TerminateJobSchedule("jobScheduleId");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```
### Task Operations

#### AddTask

Previously in `Microsoft.Azure.Batch` to there were two ways to add a task to a job.

You could call the `AddTask` method from JobOperations with a parameter of type `CloudTask` to add a single task

``` C#

CloudTask unboundTask = new CloudTask("taskId", "echo test")
    {
        OutputFiles = new List<OutputFile>
            {
                new OutputFile(@"../*.txt", destination, uploadOptions)
            }
    };

batchClient.JobOperations.AddTask("jobId", unboundTask);
```

or you could call the `AddTask` method with a collection of `CloudTask`.  Note this method is a utility method that would break up the list 
of tasks passed in and repeatly call the /jobs/{jobId}/addtaskcollection api with 100 tasks at a time.  This utility method allowed the user
to select the number of parallel calls to /addtaskcollection.

``` C#
 var tasksToAdd = new List<CloudTask>
    {
        new CloudTask("foo", "bar"),
        new CloudTask(failingTaskId, "qux")
    };

batchClient.JobOperations.AddTask("jobId", tasksToAdd);
```

With `Azure.Compute.Batch` there are three ways to add a task to a job.

You can call `CreateTask` with a parameter of type `BatchTaskCreateOptions` to create a single task
```C# Snippet:Batch_Readme_TaskCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CreateTask("jobId", new BatchTaskCreateOptions("taskId", $"echo Hello world"));
```

You can call `CreateTaskCollection` with a `BatchTaskGroup` param to create up to 100 tasks.  This method represents the /jobs/{jobId}/addtaskcollection api
```C# Snippet:Batch_Migration_CreateTaskCollection
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTaskGroup taskCollection = new BatchTaskGroup(
    new BatchTaskCreateOptions[]
    {
        new BatchTaskCreateOptions("task1", "cmd / c echo Hello World"),
        new BatchTaskCreateOptions("task2", "cmd / c echo Hello World")
    });

BatchCreateTaskCollectionResult batchCreateTaskCollectionResult = batchClient.CreateTaskCollection("jobID", taskCollection);
```
Lastly you can call `CreateTasks` which has no limit to the number of tasks.  This method will package up the list of `BatchTaskCreateOptions` tasks passed in and repeatly call the `batchClient.CreateTaskCollection()` with groups of tasks bundled into `BatchTaskGroup` objects.  This utility method allows you to select the number of parallel calls to `batchClient.CreateTaskCollection()`. See [Creating multiple Task](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples/Sample2_Creating_Multiple_Tasks.md)

```C# Snippet:Batch_Sample02_CreateTasks_Default
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create 1000 tasks in a single request using the default settings
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks);

// Print the results
Console.WriteLine("{0} Tasks Passed, {1} Failed.", result.PassCount, result.FailCount);
```

#### GetTask

Previously in `Microsoft.Azure.Batch` to get a task you could call the `GetTask` method from JobOperations which would retun a`CloudTask`.

``` C#
CloudTask boundTask = batchClient.JobOperations.GetTask("jobId", "taskId");
```

With `Azure.Compute.Batch` call `GetTask` which would retun a`BatchTask`.

```C# Snippet:Batch_Readme_TaskRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTask batchTask = batchClient.GetTask("<jobId>", "<taskId>");
Console.WriteLine(batchTask.Id);
Console.WriteLine(batchTask.State);
```

#### ListTasks

Previously in `Microsoft.Azure.Batch` to get a list of tasks in a job you could call the `ListTasks` method directly from the `CloudJob` object.

``` C# 
CloudJob boundJob = batchCli.JobOperations.GetJob("jobId");
foreach (CloudTask curTask in boundJob.ListTasks())
{
    // do something
}    
```

With `Azure.Compute.Batch` call `GetTasks`.

```C# Snippet:Batch_Readme_ListTasks
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchTask t in batchClient.GetTasks("jobId"))
{
    // do something with the task
}
```

#### Delete Task

Previously in `Microsoft.Azure.Batch` to get a delete a task in a job you could call the `Delete` method directly from the `CloudTask` object.

``` C#
CloudTask boundTask = batchClient.JobOperations.GetTask("jobId", "taskId");
boundTask.Delete();
```

With `Azure.Compute.Batch` call `DeleteTask`.

```C# Snippet:Batch_Migration_DeleteTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteTask("jobId", "taskId");
```

#### Replace Task

Previously in `Microsoft.Azure.Batch` to replace a task in a job you could call the `Commit` method directly from a modified `CloudTask` object.

``` C#
CloudTask boundTask = batchClient.JobOperations.GetTask("jobId", "taskId");

TimeSpan maxWallClockTime = TimeSpan.FromHours(1);
TimeSpan dataRetentionTime = TimeSpan.FromHours(2);
const int maxRetryCount = 1;
boundTask.Constraints = new TaskConstraints(maxWallClockTime, dataRetentionTime, maxRetryCount);

boundTask.Commit();
```

With `Azure.Compute.Batch` call `ReplaceTask` with a `BatchTaskConstraints` parameter.

```C# Snippet:Batch_Migration_ReplaceTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTask task = batchClient.GetTask("jobId", "taskId");
BatchTaskConstraints batchTaskConstraints = new BatchTaskConstraints()
{
    MaxTaskRetryCount = 3,
};

task.Constraints = batchTaskConstraints;
batchClient.ReplaceTask("jobID", "taskID", task);
```

#### Reactivate Task

Previously in `Microsoft.Azure.Batch` to reactive a task you could call the `Reactivate` method directly from a modified `CloudTask` object.

``` C#
CloudTask boundTask = batchClient.JobOperations.GetTask("jobId", "taskId");
boundTask.Reactivate()
```

With `Azure.Compute.Batch` call `ReactivateTask`.

```C# Snippet:Batch_Migration_ReactivateTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.ReactivateTask("jobID", "taskID");
```

#### Terminate Task

Previously in `Microsoft.Azure.Batch` to terminate a task you could call the `Terminate` method directly from a modified `CloudTask` object.

``` C#
CloudTask boundTask = batchClient.JobOperations.GetTask("jobId", "taskId");
boundTask.Terminate()
```

With `Azure.Compute.Batch` call `TerminateTask`.

```C# Snippet:Batch_Migration_TerminateTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateTask("jobID", "taskID");
```

### Node Operations

#### GetComputeNode 

Previously in `Microsoft.Azure.Batch` to get a node you could call the `GetComputeNode` method from PoolOperations which would retun a`ComputeNode`.

``` C#
ComputeNode computeNodeFromManager = batchClient.PoolOperations.GetComputeNode("poolId", "computeNodeId");
```

With `Azure.Compute.Batch` call `GetTask` which would retun a`BatchNode`.

```C# Snippet:Batch_Readme_NodeRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNode batchNode = batchClient.GetNode("<poolId>", "<nodeId>");
Console.WriteLine(batchNode.Id);
Console.WriteLine(batchNode.Uri);
Console.WriteLine(batchNode.State);
```

#### ListComputeNodes 

Previously in `Microsoft.Azure.Batch` to get a list of nodes you could call the `ListComputeNodes` method directly from a `CloudPool` object.

``` C#
CloudPool pool = batchClient.PoolOperations.GetPool(poolFixture.PoolId);

foreach (ComputeNode curComputeNode in pool.ListComputeNodes())
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetNodes`.

```C# Snippet:Batch_Readme_ListNodes
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchNode item in batchClient.GetNodes("poolID"))
{
    Console.WriteLine(item.Id);
}
```

#### Reboot Node

Previously in `Microsoft.Azure.Batch` to reboot a node you could call the `Reboot` method directly from a `ComputeNode` object.

``` C#
ComputeNode computeNode = batchClient.PoolOperations.GetComputeNode("poolId", "computeNodeId");
computeNode.Reboot();
```

With `Azure.Compute.Batch` call `RebootNode`. 

```C# Snippet:Batch_Migration_RebootNode
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.RebootNode("poolId", "computeNodeId");
```
Optionally you can use the returned `RebootNodeOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_RebootNode_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

RebootNodeOperation operation = batchClient.RebootNode("poolId", "computeNodeId");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```
#### CreateComputeNodeUser

Previously in `Microsoft.Azure.Batch` to create a node user you could call the `CreateComputeNodeUser` method from `PoolOperations`.

``` C#
ComputeNodeUser bob = batchClient.PoolOperations.CreateComputeNodeUser("poolID", "batchNodeID");
```

With `Azure.Compute.Batch` call `CreateNodeUserAsync` with a `BatchNodeUserCreateOptions` param.

```C# Snippet:Batch_Migration_CreateNodeUser
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNodeUserCreateOptions user = new BatchNodeUserCreateOptions("userName")
{
    Password = "userPassWord"
};
batchClient.CreateNodeUser("poolID", "batchNodeID", user);
```

#### DeleteComputeNodeUser

Previously in `Microsoft.Azure.Batch` to delete a node user you could call the `DeleteComputeNodeUser` method directly from a `ComputeNode` object.

``` C#
ComputeNode computeNode = batchClient.PoolOperations.GetComputeNode("poolId", "computeNodeId");
computeNode.DeleteComputeNodeUser("curCNUName");
```

With `Azure.Compute.Batch` call `DeleteNodeUser`.

```C# Snippet:Batch_Migration_DeleteNodeUser
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteNodeUser("poolID", "batchNodeID", "userName");
```

#### GetNodeFile

Previously in `Microsoft.Azure.Batch` to get a file from a node you could call the `GetNodeFile` method directly from a `ComputeNode` object.

``` C#
ComputeNode computeNode = batchClient.PoolOperations.GetComputeNode("poolId", "computeNodeId");
NodeFile sharedTextFile = computeNode.GetNodeFile("filePath");
```

With `Azure.Compute.Batch` call `GetNodeFile`.

```C# Snippet:Batch_Migration_GetNodeFile
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BinaryData fileContents = batchClient.GetNodeFile("poolId", "computeNodeId", "filePath");
```

#### ListNodeFiles

Previously in `Microsoft.Azure.Batch` to get a list of files from a node you could call the `ListNodeFiles` method from `JobOperations`.

``` C#
List<NodeFile> nodeFiles = new List<NodeFile>(batchClient.JobOperations.ListNodeFiles("jobId", "taskId"));

foreach (NodeFile nodeFile in nodeFiles)
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetNodeFiles`.

```C# Snippet:Batch_Migration_GetNodeFiles
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchNodeFile item in batchClient.GetNodeFiles("jobId", "nodeId"))
{
    // do something
}
```

#### DeleteNodeFile

Previously in `Microsoft.Azure.Batch` to delete a file from a node you could call the `DeleteNodeFile` method from `JobOperations`.

``` C#
batchClient.JobOperations.DeleteNodeFile("jobId", "taskId", "filePath");
```

With `Azure.Compute.Batch` call `DeleteNodeFile`.

```C# Snippet:Batch_Migration_DeleteNodeFile
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteNodeFile("jobId", "taskId", "filePath");
```

#### Get Node File Properties

Previously in `Microsoft.Azure.Batch` to get the properties of a file from a node you could call the `GetNodeFile` method from `JobOperations` then look at the Properties field.

``` C#
NodeFile file = batchClient.JobOperations.GetNodeFile("jobID", "taskId", "filePath");
file.Properties;
```

With `Azure.Compute.Batch` call `GetNodeFileProperties`.

```C# Snippet:Batch_Migration_GetNodeFileProperties
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchFileProperties batchFileProperties = batchClient.GetNodeFileProperties("poolId", "nodeId", "filePath");
```
#### GetRemoteLoginSettings

Previously in `Microsoft.Azure.Batch` to get the remote loging settings of a node you could call the `GetRemoteLoginSettings` method from `PoolOperations`.

``` C#
RemoteLoginSettings rlsViaPoolOps = batchClient.PoolOperations.GetRemoteLoginSettings("poolId", "computeNodeId");
```

With `Azure.Compute.Batch` call `GetNodeRemoteLoginSettings`.

```C# Snippet:Batch_Migration_GetNodeRemoteLoginSettings
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNodeRemoteLoginSettings batchNodeRemoteLoginSettings = batchClient.GetNodeRemoteLoginSettings("poolId", "computeNodeId");
```

#### UploadComputeNodeBatchServiceLogs

Previously in `Microsoft.Azure.Batch` to upload logs to a node you could call the `UploadComputeNodeBatchServiceLogs` method from `PoolOperations`.

``` C#
UploadBatchServiceLogsResult results = batchClient.PoolOperations.UploadComputeNodeBatchServiceLogs("poolId", "computeNodeId","containerUrl");
```

With `Azure.Compute.Batch` call `UploadNodeLogs` with a param of type `UploadBatchServiceLogsOptions`.

```C# Snippet:Batch_Migration_UploadNodeLogs
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

UploadBatchServiceLogsOptions uploadBatchServiceLogsOptions = new UploadBatchServiceLogsOptions(new Uri("containerUrl"), DateTimeOffset.Parse("2026-05-01T00:00:00.0000000Z"));

UploadBatchServiceLogsResult uploadBatchServiceLogsResult = batchClient.UploadNodeLogs("poolId", "computeNodeId", uploadBatchServiceLogsOptions);
```

### Certificate Operations

> Note: Certificates has been [deprecated].

#### CreateCertificateFromCer

Previously in `Microsoft.Azure.Batch` to create a Certificate from an existing cert you could call the `CreateCertificateFromCer` method with the path to the cert.

``` C#
Certificate cerCertificate = batchClient.CertificateOperations.CreateCertificateFromCer("cerFilePath");
```

With `Azure.Compute.Batch` call `CreateCertificate` with a `BatchCertificate` param to create a cert

```C# Snippet:Batch_Migration_CreateCerCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
byte[] certData = File.ReadAllBytes("certPath");
BatchCertificate cerCertificate = new BatchCertificate("Thumbprint", "ThumbprintAlgorithm", BinaryData.FromBytes(certData))
{
    CertificateFormat = BatchCertificateFormat.Cer,
    Password = "",
};

Response response = batchClient.CreateCertificate(cerCertificate);
```

#### CreateCertificateFromPfx

Previously in `Microsoft.Azure.Batch` to create a Certificate from an existing pfx cert you could call the `CreateCertificateFromPfx` method with the path to the cert.

``` C#
Certificate pfxCertificate = batchClient.CertificateOperations.CreateCertificateFromPfx("pfxFilePath", "CertificatePassword");
```

With `Azure.Compute.Batch` call `CreateCertificate` with a `BatchCertificate` param to create a cert

```C# Snippet:Batch_Migration_CreatePfxCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

byte[] certData = File.ReadAllBytes("certPath");
BatchCertificate cerCertificate = new BatchCertificate("Thumbprint", "ThumbprintAlgorithm", BinaryData.FromBytes(certData))
{
    CertificateFormat = BatchCertificateFormat.Pfx,
    Password = "password",
};

Response response = batchClient.CreateCertificate(cerCertificate);
```

#### GetCertificate

Previously in `Microsoft.Azure.Batch` to get a Certificate you could call the `GetCertificate` method from `CertificateOperations`.

``` C#
Certificate boundCert = batchClient.CertificateOperations.GetCertificate( "ThumbprintAlgorithm", "Thumbprint")
```

With `Azure.Compute.Batch` call `GetCertificate` to get the certificate which will return a `GetCertificateResponse`.

```C# Snippet:Batch_Migration_GetCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchCertificate cerCertificateResponse = batchClient.GetCertificate("ThumbprintAlgorithm", "Thumbprint");
```

#### ListCertificates

Previously in `Microsoft.Azure.Batch` to get a list of Certificates you could call the `ListCertificates` method from `CertificateOperations`.

``` C#
foreach (Certificate curCert in batchClient.CertificateOperations.ListCertificates())
{
    // do something
}
```

With `Azure.Compute.Batch` call `GetCertificates` to get a list of certificates.

```C# Snippet:Batch_Migration_ListCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchCertificate item in batchClient.GetCertificates())
{
    // do something
}
```

#### DeleteCertificate

Previously in `Microsoft.Azure.Batch` to delete a Certificate you could call the `DeleteCertificate` method from `CertificateOperations`.

``` C#
batchClient.CertificateOperations.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");
```

With `Azure.Compute.Batch` call `DeleteCertificate` to delete a certificate. 

```C# Snippet:Batch_Migration_DeleteCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");
```
Optionally you can use the returned `DeleteCertificateOperation` object to wait for the operation to complete.

```C# Snippet:Batch_Migration_DeleteCertificate_Operation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

DeleteCertificateOperation operation = batchClient.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");

// Optional, wait for operation to complete
operation.WaitForCompletion();
```
#### CancelDeleteCertificate

Previously in `Microsoft.Azure.Batch` to cancel a delete of a Certificate you could call the `CancelDeleteCertificate` method from `CertificateOperations`.

``` C#
batchClient.CertificateOperations.CancelDeleteCertificate("ThumbprintAlgorithm", "Thumbprint");
```

With `Azure.Compute.Batch` call `CancelCertificateDeletion` to cancel a delete of a certificate.

```C# Snippet:Batch_Migration_CancelDeleteCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CancelCertificateDeletion("ThumbprintAlgorithm", "Thumbprint");
```

### Application Operations

#### GetApplicationSummary

Previously in `Microsoft.Azure.Batch` to get an application you could call the `GetApplicationSummary` method from the ApplicationOperations object.

``` C#
ApplicationSummary applicationSummary = client.ApplicationOperations.GetApplicationSummary("appID");
```

With `Azure.Compute.Batch` call `GetApplication`.

```C# Snippet:Batch_Migration_GetApplication
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchApplication application = batchClient.GetApplication("appID");
```

#### ListApplicationSummaries

Previously in `Microsoft.Azure.Batch` to get a list of applications you could call the `ListApplicationSummaries` method from the ApplicationOperations object..

``` C#
List<ApplicationSummary> jobPrepStatus = new List<ApplicationSummary>(batchClient.ApplicationOperations.ListApplicationSummaries());
 
foreach (ApplicationSummary item in jobPrepStatus)
{
    // do something
} 
```

With `Azure.Compute.Batch` call `GetApplications`.

```C# Snippet:Batch_Migration_GetApplications
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchApplication item in batchClient.GetApplications())
{
    // do something
}
```
