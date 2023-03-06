# Use `WebPubSubOutput` to invoke service to do actions

This sample demonstrates how to work with `WebPubSubOutput` to invoke service do operations including send messages and manage clients. You can get the Web PubSub connection string from Azure Portal and set it in the `local.settings.json` with a preferred `web_pubsub_connection_name`. Then replace it with the `Connection` parameter in the binding attribute. Then when this function is triggered, it will leverage data plane REST APIs to operate required actions.

## Single output

```C# Snippet:WebPubSubOutputFunction
[Function("Notification")]
[WebPubSubOutput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")]
public static WebPubSubAction Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
{
    return new SendToAllAction
    {
        Data = BinaryData.FromString($"Hello SendToAll."),
        DataType = WebPubSubDataType.Text
    };
}
```

## Multiple outputs

```C# Snippet:WebPubSubOutputFunction_Multiple
// multiple output
[Function("Notification1")]
public static MultipleActions MultipleActions([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
{
    return new MultipleActions
    {
        SendToAll = new SendToAllAction
        {
            Data = BinaryData.FromString($"Hello SendToAll."),
            DataType = WebPubSubDataType.Text
        },
        AddUserToGroup = new AddUserToGroupAction
        {
            UserId = "user A",
            Group = "group A"
        }
    };
}

public class MultipleActions
{
    [WebPubSubOutput(Hub = "<web_pubsub_hub>")]
    public SendToAllAction SendToAll { get; set; }
    [WebPubSubOutput(Hub = "<web_pubsub_hub>")]
    public AddUserToGroupAction AddUserToGroup { get; set; }
}
```