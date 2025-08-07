# Authenticate the client

This sample demonstrates how to authenticate the `ServiceBusClient`, which is the starting point for all interactions with the Service Bus client library.

## Authenticate with a connection string

The simplest way to authenticate with Service Bus is to use a connection string, which is created automatically when creating a Service Bus namespace. If you aren't familiar with connection strings in Service Bus, you may wish to follow the step-by-step guide to [get a Service Bus connection string](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-topics-subscriptions-portal#get-the-connection-string). For production scenarios, we recommend using Azure.Identity authentication as it provides [role-based access control](https://learn.microsoft.com/azure/role-based-access-control/overview) without the need to manage connection strings or shared access keys.

```C# Snippet:ServiceBusAuthConnString
// Create a ServiceBusClient that will authenticate using a connection string
string connectionString = "<connection_string>";
await using ServiceBusClient client = new(connectionString);
```

## Authenticate with Azure.Identity
The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides [role-based access control](https://learn.microsoft.com/azure/role-based-access-control/overview) support for authentication using Azure Active Directory.In order to leverage role-based access control for Service Bus, please refer to the [role-based access control documentation](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-role-based-access-control). The simplest way to get started using the `Azure.Identity` `library is to use the [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

```C# Snippet:ServiceBusAuthAAD
// Create a ServiceBusClient that will authenticate through Active Directory
string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
```

## Authenticate with a Shared Access Key Credential

Shared access keys for Service Bus authorization are generated when access policies are created for a Service Bus namespace. Since these keys are most often used in association with a connection string, the article providing instructions to [get a Service Bus connection string](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-topics-subscriptions-portal#get-the-connection-string) is the best source of information on generating and accessing them. One of the key benefits to using a shared access key credential over a connection string is that the credential allows support for updating the key without creating a new client. In step 3 of the article, the policy that you select will be the name of your shared access key when used for credential authorization. You'll want to copy the "Primary key" rather than connection string.


```C# Snippet:ServiceBusAuthNamedKey
var credential = new AzureNamedKeyCredential("<name>", "<key>");
await using ServiceBusClient client = new("yournamespace.servicebus.windows.net", credential);
```

## Authenticate with a Shared Access Signature Credential

Shared access signatures (SAS) are recommended over shared access keys when [RBAC](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-role-based-access-control) cannot be used. A shared access signature allows for granular and time-limited access to Service Bus resources. The authoritative documentation on generating Service Bus SAS tokens can be found [here](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-sas#generate-a-shared-access-signature-token).

```C# Snippet:ServiceBusAuthSasKey
string keyName = "<key_name>";
string key = "<key>";
string fullyQualifiedNamespace = "<yournamespace.servicebus.windows.net>";
string queueName = "<queue_name>";
using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(key));
UriBuilder builder = new(fullyQualifiedNamespace)
{
    Scheme = "amqps",
    // scope our SAS token to the queue that is being used to adhere to the principle of least privilege
    Path = queueName
};

string url = WebUtility.UrlEncode(builder.Uri.AbsoluteUri);
long exp = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds();
string sig = WebUtility.UrlEncode(Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(url + "\n" + exp))));

string sasToken = $"SharedAccessSignature sr={url}&sig={sig}&se={exp}&skn={keyName}";

AzureSasCredential credential = new(sasToken);
await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);
```
