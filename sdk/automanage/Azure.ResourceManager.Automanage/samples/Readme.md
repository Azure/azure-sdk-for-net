# Azure.ResourceManager.Automanager Reference

These extension methods require these packages to be imported, and make creating an Automanage Assignment very easy.

```
using Azure.ResourceManager;
using Azure.ResourceManager.Automanage;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Resources;
```

## Creating an Assignment

To Automanage a device, one creates an assignment that links one or more ConfigurationProfiles to a specific device.  

This method extends the function of `Azure.ResourceManager.ArmClient` to make this operation a one-line method call.

```csharp
public static async Task<ConfigurationProfileAssignmentResource> CreateAssignment(this ArmClient client, ResourceIdentifier vmId, string profileId)
    {
        Console.WriteLine($"[AutoManage-Onboarding]--Onboarding with profile, {profileId}");

        var collection = client.GetConfigurationProfileAssignments(vmId);

        var data = new ConfigurationProfileAssignmentData();
        data.Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profileId };

        var assignment = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "default", data);

        return assignment.Value;
    }

```
## Waiting for an assignment to complete

Applying an Automanage profile to a device begins a process which typically takes ~five minutes to complete, involving at most three ARM Template Deployments.  This helpful method makes waiting for an assignment to complete a very simple one line process.

```csharp

public static async Task<ConfigurationProfileAssignmentResource?> WaitAssignmentCompleted(this ArmClient client, ResourceIdentifier vmId)
{
    var assignmentName = string.Concat(vmId, "/providers/Microsoft.Automanage/configurationProfileAssignments/default");
    var shouldWaitStates = new[] { "InProgress", "New" };

    Console.WriteLine($"[AutoManage-Onboarding]--Waiting for completed onboarding with profile, {vmId}");

    var collection = client.GetConfigurationProfileAssignments(vmId.Parent);
    var thisAssignment = collection.FirstOrDefault(x => x.Data.Id.ToString() == assignmentName);

    while (shouldWaitStates.Contains(thisAssignment?.GetStatus()))
    {
        Console.WriteLine($"--Status was {thisAssignment?.GetStatus()}, waiting for completed status");
        await Task.Delay(TimeSpan.FromSeconds(25));

        collection = client.GetConfigurationProfileAssignments(vmId.Parent);
        thisAssignment = collection.FirstOrDefault(x => x.Data.Id.ToString() == assignmentName);
    }

    Console.WriteLine($"[AutoManage-Onboarding]--Final assignment status for this VM was {thisAssignment?.GetStatus()}");

    return thisAssignment;
}

```

## Retrieving the Status of an Assignment

The Conformance field of an Assignment is a somewhat nested property, this extension method can be called from any assignment to retrieve the Conformance state more conveniently.

```csharp
public static string GetStatus(this ConfigurationProfileAssignmentResource resource) => resource.Data.Properties.Status;
```

# Putting it all together

Assuming a project with these `Azure.ResourceManager` namespaces imported.

```
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Automanage;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.HybridCompute;
using Azure.ResourceManager.Resources;
```

## Creating Virtual Machine Assignments

We can create an assignment for any Compute.VirtualMachine with the following.

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();

//best practices profile
string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";

ResourceIdentifier vm = VirtualMachineResource
    .CreateResourceIdentifier(
    subscriptionId: subscription.Id.Name,
    resourceGroupName: "someRg",
    vmName: "myTestVm");

var assignment = await armClient.CreateAssignment(vm, profileId);
var assignmentState = await armClient.WaitAssignmentCompleted(vm);
```

## Creating ARC HybridCompute Assignments

Automanage also fully supports HybridCompute ARC Machines.  This sample will enroll and wait for completion of an ARC Machine.

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();

//best practices profile
string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";

ResourceIdentifier arcMachine = HybridComputeMachineResource
    .CreateResourceIdentifier(
    subscriptionId: subscription.Id.Name,
    resourceGroupName: "someRg",
    machineName: "myArcVm");

var arcAssignment = await armClient.CreateAssignment(arcMachine, profileId);
var arcAssignmentState = await armClient.WaitAssignmentCompleted(arcMachine);
```

