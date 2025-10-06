# Manipulate Dev Box Actions

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_LongImports
using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

## Get a dev box action

Create a `DevBoxesClient` and issue a request to get the default schedule action of a dev box.

```C# Snippet:Azure_DevCenter_GetDevBoxAction_Scenario
// Create DevBox-es client
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();
var devBoxesClient = new DevBoxesClient(endpoint, credential);

//Dev Box properties
var projectName = "MyProject";
var devBoxName = "MyDevBox";
var user = "me";

//Get the default schedule action of a dev box
DevBoxAction action = await devBoxesClient.GetDevBoxActionAsync(
    projectName,
    user,
    devBoxName,
    "schedule-default");
```

## Delay a dev box action

Once knowing what is the action time, issue a request to delay the action.
```C# Snippet:Azure_DevCenter_DelayDevBoxAction_Scenario
//The time an action is scheduled to perform
DateTimeOffset actionTime = action.NextAction.ScheduledTime;

//Delay an action by 10 min
DateTimeOffset delayUntil = actionTime.AddMinutes(10);
DevBoxAction delayedAction = await devBoxesClient.DelayActionAsync(
    projectName,
    user,
    devBoxName,
    action.Name,
    delayUntil);

Console.WriteLine($"Action {action.Name} was delayed until {delayedAction.NextAction.ScheduledTime}.");
```

## List all actions of a dev box
List all actions of a dev box and determine what is the time of the action most in the future.
```C# Snippet:Azure_DevCenter_GetDevBoxActions_Scenario
//List all actions for a dev box
List<DevBoxAction> actions = await devBoxesClient.GetDevBoxActionsAsync(projectName, user, devBoxName).ToEnumerableAsync();

//Another way of getting a dev box action
action = actions.Where(x => x.Name == "schedule-default").FirstOrDefault();
Console.WriteLine($"Action {action.Name} is now schedule to {action.ActionType} at {action.NextAction.ScheduledTime}.");

//Get the time of the action most in the future
DateTimeOffset latestActionTime = actions.Max(x => x.NextAction.ScheduledTime);
```

## Delay all actions of a dev box
Issue a request to delay all actions of a dev box. Note that the delay of each action can succeed or fail independently. Use the `DevBoxActionDelayResult.DelayStatus` to see the status of each delay. 
```C# Snippet:Azure_DevCenter_DelayAllActions_Scenario
//Delay all actions
DateTimeOffset delayAllActionsUntil = latestActionTime.AddMinutes(10);
await foreach (DevBoxActionDelayResult actionDelayResult in devBoxesClient.DelayAllActionsAsync(projectName, user, devBoxName, delayAllActionsUntil))
{
    if (actionDelayResult.DelayStatus == DevBoxActionDelayStatus.Succeeded)
    {
        Console.WriteLine($"Action {actionDelayResult.ActionName} was successfully delayed until {actionDelayResult.Action.SuspendedUntil}");
    }
    else
    {
        Console.WriteLine($"Action {actionDelayResult.ActionName} failed to delay");
    }
}
```

## Skip an action
Issue a request to skip an action of a dev box.
```C# Snippet:Azure_DevCenter_SkipAction_Scenario
//Skip the default schedule action
Response skipActionResponse = await devBoxesClient.SkipActionAsync(
    projectName,
    user,
    devBoxName,
    "schedule-default");

Console.WriteLine($"Skip action finished with status {skipActionResponse.Status}.");
```
