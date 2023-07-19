# Use `WebPubSubTrigger` to get service notifications

This sample demonstrates how to work with `WebPubSubTrigger` to get service notification. When work with `WebPubSubTrigger`, the event handler settings in the Web PubSub service should be like `https://<FUNCTIONAPP_NAME>.azurewebsites.net/runtime/webhooks/webpubsub?code=<APP_KEY>`. The `code` is required for an Azure Functions App but optional for a local Functions App. See [How to configure event handler](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-eventhandler) for details.

This sample below is a function to listen to the user event messages, that whenever a client send a message through the client websocket connection to the Web PubSub service, this configured Function App will be triggered. And with the `UserEventResponse` returned here, the caller client will get an ack with content as the function replied `[SYSTEM ACK] Received.`.

```C# Snippet:WebPubSubTriggerUserEventFunction
[Function("Broadcast")]
public static UserEventResponse Run(
[WebPubSubTrigger("<web_pubsub_hub>", WebPubSubEventType.User, "message")] UserEventRequest request)
{
    return new UserEventResponse("[SYSTEM ACK] Received.");
}
```