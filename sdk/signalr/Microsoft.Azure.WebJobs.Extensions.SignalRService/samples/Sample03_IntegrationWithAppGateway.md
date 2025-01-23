# Integrate with Application Gateway

When you hide your SignalR service instance behind an gateway, you cannot access it at its original endpoint "<SIGNALR_RESOURCE_NAME>.service.signalr.net". In this situation, you should customize the "client endpoint" and "server endpoint", corresponding to the endpoint where the clients access the SignalR service and the endpoint where the servers access the SignalR service, respectively. You can customize one of them or both of them on your own demand. If not specify, then the default value is the original endpoint. There are several ways to do this.

## Option 1: Connection String
This way works if you want to auth with access key or managed identity. Just append `;ServerEndpoint=https://<url_to_app_gateway>;ClientEndpoint=https://<url_to_app_gateway>;` to your original connection string. Again, you could specify only one of them. The following string is a connection string with access key which contains the client endpoint and server endpoint.

`Endpoint=https://<SIGNALR_RESOURCE_NAME>.service.signalr.net;AccessKey=<access_key>;ServerEndpoint=https://<url_to_app_gateway>;ClientEndpoint=https://<url_to_app_gateway>;Version=1.0;`

To see more about connection string , go [here](https://learn.microsoft.com/azure/azure-signalr/concept-connection-string).

## Option 2: Identity-based Connection

Identity-based connection allows you to auth with multiple types of azure credentials including managed identity credentials.

Here is a sample to configure the identity-based connection when your [connectionStringSetting](https://learn.microsoft.com/azure/azure-functions/functions-bindings-signalr-service-trigger?tabs=in-process&pivots=programming-language-csharp#attributes) has the default value `AzureSignalRConnectionString`.

```properties
AzureSignalRConnectionString__serviceUri = https://<SIGNALR_RESOURCE_NAME>.service.signalr.net
AzureSignalRConnectionString__serverEndpoint = https://<url_to_app_gateway>
AzureSignalRConnectionString__clientEndpoint = https://<url_to_app_gateway>
```

Related docs:
* [Azure Application Identity](https://learn.microsoft.com/azure/azure-signalr/signalr-howto-authorize-application#azure-functions-signalr-bindings)
* [Managed identity](https://learn.microsoft.com/azure/azure-signalr/signalr-howto-authorize-managed-identity#azure-functions-signalr-bindings)

## Option 3: Dependency injection (In-Process Model Runtime Only)
This is the most flexible way for C# in-process model functions. Configure `SignalROptions.ServiceEndpoints` in your startup class as follows:

```C# Snippet:AppGatewayIntegration
public class AppGatewayStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.Configure<SignalROptions>(o => o.ServiceEndpoints.Add(
            new ServiceEndpoint(new Uri(""),
                                    new DefaultAzureCredential(),
                                    serverEndpoint: new Uri("https://<url-to-app-gateway>"),
                                    clientEndpoint: new Uri("https://<url-to-app-gateway>"))));
    }
}
```
