# Use `WebPubSubTrigger` to get service notifications

This sample demonstrates how to work with `WebPubSubContextInput` to get service notification. This is useful when work with Static Web Apps which supports `HttpTrigger` functions only. When work with `WebPubSubContextInput`, the event handler settings in the Web PubSub service should be like `https://<FUNCTIONAPP_NAME>.azurewebsites.net/api/{event}}`. The reserved `{event}` is service defined events, and should be mapped to the function's name. See [How to configure event handler](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-eventhandler) for details.

This sample is listen to the abuse protection event, that to validate the upstream is a valid one. When the Web PubSub service is configured with `api/{event}`, it'll send to `api/validate` of this request as the first call to validate it.

```C# Snippet:WebPubSubContextInputFunction
// validate method when upstream set as http://<func-host>/api/{event}
[Function("validate")]
public static HttpResponseData Validate(
    [HttpTrigger(AuthorizationLevel.Anonymous, "options")] HttpRequestData req,
    [WebPubSubContextInput] WebPubSubContext wpsReq)
{
    return BuildHttpResponseData(req, wpsReq.Response);
}

// Respond AbuseProtection to put header correctly.
private static HttpResponseData BuildHttpResponseData(HttpRequestData request, SimpleResponse wpsResponse)
{
    var response = request.CreateResponse();
    response.StatusCode = (HttpStatusCode)wpsResponse.Status;
    response.Body = response.Body;
    foreach (var header in wpsResponse.Headers)
    {
        response.Headers.Add(header.Key, header.Value);
    }
    return response;
}
```