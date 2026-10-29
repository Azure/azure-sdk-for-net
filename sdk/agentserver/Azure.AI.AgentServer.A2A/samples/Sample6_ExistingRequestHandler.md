# Sample 6: Existing request handler

Host an already-constructed native `IA2ARequestHandler` without replacing its
configuration or storage.

## Construct and host the native handler

Use `CreateCard` from [getting started](Sample1_GettingStarted.md) and `TaskAgent`
from [tasks and artifacts](Sample2_TasksAndArtifacts.md).
The native `AddA2AAgent` extension is in `A2A.AspNetCore`; service registration
extensions are in `Microsoft.Extensions.DependencyInjection`.

```C# Snippet:A2A_Sample6_Start
var card = CreateCard();
var services = new ServiceCollection();
services.AddLogging();
services.AddSingleton<ITaskStore, InMemoryTaskStore>();
services.AddA2AAgent<TaskAgent>(card);

await using var nativeServices = services.BuildServiceProvider();
var requestHandler = nativeServices.GetRequiredService<IA2ARequestHandler>();
A2AAgentServer.Run(card, requestHandler);
```

The native provider owns the native request handler and its dependencies. The
`await using` scope remains open while the Foundry host runs, then disposes
the native provider asynchronously after the server stops.

If your application already has a request handler, use that instance directly
instead of constructing another provider.

## Verify the preserved storage

Send a `SendMessage` request as shown in the task sample, keep `result.task.id`,
and issue `GetTask` through the same endpoint. The completed artifact is returned
by the native handler's original task store.

`A2AAgentServer.Run(card, requestHandler)` does not install a replacement
`ITaskStore`. The application remains responsible for the lifetime of the
supplied handler. Do not dispose its dependencies while requests are in flight.

For builder-based hosting, pass the same card and handler to
`builder.AddA2A(card, requestHandler)`.
