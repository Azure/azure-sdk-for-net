# Azure WebJobs SignalR Service client library for .NET

This extension provides functionality for accessing [Azure SignalR Service](https://aka.ms/signalr_service) from an Azure Function.

## Getting started

### Install the package

Install the SignalR Service client with [NuGet](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.SignalRService/):

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.SignalRService
```

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure SignalR Service, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Azure SignalR resource:** To use SignalR Service client library you'll also need a Azure SignalR resource. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for creating a SignalR resource using the Azure portal. There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create a SignalR resource.

    To quickly create the needed SignalR resource in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

    [![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3a%2f%2fraw.githubusercontent.com%2fAzure%2fazure-quickstart-templates%2fmaster%2fquickstarts%2fmicrosoft.signalrservice%2fsignalr%2fazuredeploy.json)

    After the instance is deployed, open it in the portal and locate its Settings page. Change the Service Mode setting to *Serverless*.

    ![SignalR Service mode setting](images/signalr-service-mode.png)

### Authenticate the client

In order for SignalR Service client to access SignalR resource, it will need to understand how to authenticate with it. The easiest means for doing so is to use a connection string which can be found in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) / [Azure PowerShell](https://learn.microsoft.com/powershell/azure/) snippet below.

Azure CLI snippet:
```bash
az signalr key list -n <your-resource-name> -g <your-resource-group-name> --query primaryKey -o tsv
```

Azure PowerShell snippet:
```Powershell
Get-AzSignalRKey -ResourceGroupName <your-resource-name> -Name <your-resource-name>
```

The `ConnectionStringSetting` property of SignalR bindings (including `SignalRAttribute`, `SignalRConnectionInfoAttribute`, `SignalRTriggerAttribute` etc.) is used to specify the configuration property that stores the connection string. If not specified, the property `AzureSignalRConnectionString` is expected to contain the connection string.

For local development, use the `local.settings.json` file to store the connection string:

```json
{
  "Values": {
    "<connection_name>": "<connection-string>"
  }
}
```

When deployed, use the [application settings](https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to set the connection string.

<!--TODO#### Identity-based Will reference a ms doc link once it is ready-->

## Key concepts

### SignalR **Service** client vs SignalR client
SignalR **Service** client
: It means this library. It provides *SignalR server* functionalities in a serverless style.

SignalR client
: An opposite concept of *SignalR server*. See [ASP.NET Core SignalR clients](https://learn.microsoft.com/aspnet/core/signalr/client-features) for more information.

### SignalR connection info input binding

`SignalRConnectionInfo` input binding makes it easy to generate the token required for SignalR clients to initiate a connection to Azure SignalR Service.

Please follow the [Azure SignalR Connection Info input binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-signalr-service-input?tabs=csharp) to learn more about SignalR Connection Info input binding.

### SignalR output binding

`SignalR` output binding allows :
* send messages to all connections, to a connection, to a user, to a group.
* add/remove connections/users in a group.

Please follow the [Azure SignalR output binding](https://learn.microsoft.com/azure/azure-functions/functions-bindings-signalr-service-output?tabs=csharp) to learn more about SignalR output binding.

### SignalR trigger

The SignalR trigger allows a function to be executed when a message is sent to Azure SignalR Service.

Please follow the [Azure SignalR trigger](https://learn.microsoft.com/azure/azure-functions/functions-bindings-signalr-service-trigger?tabs=csharp) to learn more about SignalR trigger.

## Supported scenarios
- Negotiate for a SignalR client.
- Manage group like add/remove a single user/connection in a group.
- Send messages to a single user/connection, to a group, to all users/connections.
- Use multiple Azure SignalR Service instances for resiliency and disaster recovery in Azure Functions. See details in [Multiple Azure SignalR Service Instances Support in Azure Functions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Microsoft.Azure.WebJobs.Extensions.SignalRService/docs/sharding.md).

## Examples

### Negotiation for SignalR client

In order for a client to connect to SignalR, it needs to obtain the SignalR client hub URL and an access token. We call the process as "negotiation".

```C# Snippet:BasicNegotiate
[FunctionName("Negotiate")]
public static SignalRConnectionInfo Negotiate(
    [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
    [SignalRConnectionInfo(HubName = "<hub_name>", UserId = "<user_id>")] SignalRConnectionInfo connectionInfo)
{
    return connectionInfo;
}
```

### Broadcast individual messages

To broadcast messages to all the connections in a hub from a single Azure Function invocation you can apply the `SignalR` attribute to the function return value. The return value should be of type `SignalRMessage`.

```C# Snippet:SendMessageWithReturnValueBinding
[FunctionName("sendOneMessageWithReturnValueBinding")]
[return: SignalR(HubName = "<hub_name>")]
public static SignalRMessage SendMessage(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
{
    return new SignalRMessage
    {
        Target = "<target>",
        Arguments = new[] { "<here_can_be_multiple_objects>" }
    };
}
```

You can also use an `out` parameter of type `SignalRMessage`.
```C# Snippet:SendMessageWithOutParameterBinding
[FunctionName("messages")]
public static void SendMessage(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req, [SignalR(HubName = "<hub_name>")] out SignalRMessage message)
{
    message = new SignalRMessage
    {
        Target = "<target>",
        Arguments = new[] { "<here_can_be_multiple_objects>" }
    };
}
```
### Broadcast multiple messages

To broadcast multiple messages to all the connections in a hub from a single Azure Function invocation you can apply the `SignalR` attribute to the `IAsyncCollector<SignalRMessage>` parameter.

```C# Snippet:SendMessageWithAsyncCollector
[FunctionName("messages")]
public static Task SendMessage(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
    [SignalR(HubName = "<hub_name>")] IAsyncCollector<SignalRMessage> signalRMessages)
{
    return signalRMessages.AddAsync(
    new SignalRMessage
    {
        Target = "<target>",
        Arguments = new[] { "<here_can_be_multiple_objects>" }
    });
}
```

### Sending messages to a connection, user or group

To send messages to a connection, user or group, the function is similar to broadcasting messages above, except that you specify `ConnectionId`, `UserId` or `GroupName` in the properties of `SignalRMessage`.

Here is an example to send messages to a user using return value binding.

```C# Snippet:SendMessageToUser
[FunctionName("messages")]
[return: SignalR(HubName = "<hub_name>")]
public static SignalRMessage SendMessageToUser(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
{
    return new SignalRMessage
    {
        UserId = "<user_id>",
        Target = "<target>",
        Arguments = new[] { "<here_can_be_multiple_objects>" }
    };
}
```
### SignalR client connection trigger

To trigger a function when a SignalR client gets connected or disconnected, you can apply the `SignalRTrigger` attribute to the `InvocationContext` parameter.

Here is an example to log the connection ID when a SignalR client is connected. Make sure the second paramater of `SignalRTrigger` constructor is `connections`, which stands for the category of the trigger is connections. The third
```C# Snippet:ConnectedTrigger
[FunctionName("SignalRTest")]
public static void Run([SignalRTrigger("<hubName>", "connections", "connected")] InvocationContext invocationContext, ILogger logger)
{
    logger.LogInformation($"{invocationContext.ConnectionId} was connected.");
}
```

### SignalR client message trigger

To trigger a function when a SignalR client sends a message, you can apply the `SignalRTrigger` attribute to the `InvocationContext` parameter, apply the `SignalRParameter` attribute to each parameter whose name matches the parameter name in your message.

Here is an example to log the message content when a SignalR client sends a message with target "SendMessage".
```C# Snippet:MessageTrigger
[FunctionName("SignalRTest")]
public static void Run([SignalRTrigger("SignalRTest", "messages", "SendMessage")] InvocationContext invocationContext, [SignalRParameter] string message, ILogger logger)
{
    logger.LogInformation($"Receive {message} from {invocationContext.ConnectionId}.");
}
```

## Troubleshooting

* Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for function troubleshooting guidance.
* [Troubleshooting guide for Azure SignalR Service](https://learn.microsoft.com/azure/azure-signalr/signalr-howto-troubleshoot-guide)

## Next steps

Read the [introduction to Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function)

## Contributing

See our [CONTRIBUTING.md][contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
