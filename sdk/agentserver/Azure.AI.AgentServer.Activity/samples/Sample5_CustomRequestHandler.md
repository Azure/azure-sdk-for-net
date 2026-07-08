# Sample 5: Custom Request Handler

For full control over the request pipeline, pass a `RequestDelegate` to `ActivityServer.Create(...)`. The Microsoft 365 Agents SDK is **not** initialized in this mode — `host.AgentApp` is unavailable and your delegate receives every inbound `POST /activity/messages` request directly.

Use this when you want to parse and respond to activities yourself rather than through the M365 `AgentApplication`.

```C# Snippet:Activity_Sample5_CustomHandler
// Own the request pipeline entirely: the Microsoft 365 Agents SDK is not initialized.
// The delegate receives each inbound POST /activity/messages request. The parsed
// activity is available at request.HttpContext for custom processing.
var host = ActivityServer.Create(async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync($"Received {body.Length} bytes.");
});

host.Run(args);
```

The host still stamps the platform response headers (session id) and correlation baggage around your handler, so you get the Foundry platform contract without the M365 stack.
