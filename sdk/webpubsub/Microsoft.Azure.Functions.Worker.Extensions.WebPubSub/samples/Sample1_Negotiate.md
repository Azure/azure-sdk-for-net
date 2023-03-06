# Use `WebPubSubConnectionInput` to build negotiate URL for the client

This sample demonstrates how to work with `WebPubSubConnectionInput` binding to build the negotiate client URL. You can get the Web PubSub connection string from Azure Portal and set it in the `local.settings.json` with a preferred `web_pubsub_connection_name`. Then replace it with the `Connection` parameter in the binding attribute. Then when this function is triggered by clients, it will get a response with the Web PubSub service negotiate URL to start a new client connection.

```C# Snippet:WebPubSubConnectionInputFunction
[Function("Negotiate")]
public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
[WebPubSubConnectionInput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")] WebPubSubConnection connectionInfo)
{
    var response = req.CreateResponse(HttpStatusCode.OK);
    response.WriteAsJsonAsync(connectionInfo);
    return response;
}
```