# Azure AI.AgentServer.Core client library for .NET
With hosted agents developers can deploy existing agents — whether built with supported agent
frameworks or custom code — into Microsoft AI Foundry with minimal effort.

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
```

## Key concepts

This is the core package for Azure AI Agent server. It hosts your agent as a container on the cloud.

You can talk to your agent using Azure.AI.Projects sdk.


## Examples

If your agent is not built using a supported framework such as Agent-framework, you can still make it compatible
with Microsoft AI Foundry by manually implementing the predefined interface.

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Responses.Invocation;

public class CustomizedAgentInvocation : IAgentInvocation
{
    public Task<Response> InvokeAsync(CreateResponseRequest request, AgentInvocationContext context,
        CancellationToken cancellationToken = default)
    {
        var inputText = GetInputText(request);

        var text = "I am a mock agent with no intelligence. You said: " + inputText;

        IList<ItemContent> contents =
            [new ItemContentOutputText(text: text, annotations: [])];

        IList<ItemResource> outputs =
        [
            new ResponsesAssistantMessageItemResource(
                id: Guid.NewGuid().ToString(),
                status: ResponsesMessageItemResourceStatus.Completed,
                content: contents
            )
        ];

        return Task.FromResult(ToResponse(request, context, output: outputs));
    }

    public async IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var seq = -1;

        #region response.*

        yield return new ResponseCreatedEvent(++seq,
            ToResponse(request, context, status: ResponseStatus.InProgress));

        #region response.output_item.*

        var itemId = context.IdGenerator.GenerateMessageId();
        yield return new ResponseOutputItemAddedEvent(++seq, 0,
            item: new ResponsesAssistantMessageItemResource(
                id: itemId,
                status: ResponsesMessageItemResourceStatus.InProgress,
                content: []
            )
        );

        #region response.content_part.*

        yield return new ResponseContentPartAddedEvent(++seq, itemId, 0, 0,
            new ItemContentOutputText(text: "", annotations: [])
        );

        #region response.output_text.*

        var inputText = GetInputText(request);
        var text = "I am a mock agent with no intelligence. You said: " + inputText;
        foreach (var part in text.Split(" "))
        {
            await Task.Delay(100, cancellationToken).ConfigureAwait(false);
            yield return new ResponseTextDeltaEvent(++seq, itemId, 0, 0, part + " ");
        }

        yield return new ResponseTextDoneEvent(++seq, itemId, 0, 0, text);

        #endregion response.output_text.*

        var content = new ItemContentOutputText(text: text, annotations: []);
        yield return new ResponseContentPartDoneEvent(++seq, itemId, 0, 0, content);

        #endregion response.content_part.*

        var item = new ResponsesAssistantMessageItemResource(id: itemId, ResponsesMessageItemResourceStatus.Completed,
            content: [content]);
        yield return new ResponseOutputItemDoneEvent(++seq, 0, item);

        #endregion response.output_item.*

        yield return new ResponseCompletedEvent(++seq,
            ToResponse(request, context, status: ResponseStatus.Completed, output: [item]));

        #endregion response.*
    }

    private static string GetInputText(CreateResponseRequest request)
    {
        var items = request.Input.ToObject<IList<ItemParam>>();
        if (items is { Count: > 0 })
        {
            return items.Select(item =>
                {
                    return item switch
                    {
                        ResponsesUserMessageItemParam userMessage => userMessage.Content
                            .ToObject<IList<ItemContentInputText>>()?
                            .FirstOrDefault()?
                            .Text ?? "",
                        _ => ""
                    };
                })
                .FirstOrDefault() ?? "";
        }

        // implicit user message of text input
        return request.Input.ToString();
    }

    private static Response ToResponse(CreateResponseRequest request, AgentInvocationContext context,
        ResponseStatus status = ResponseStatus.Completed,
        IEnumerable<ItemResource>? output = null)
    {
        return request.ToResponse(context: context, output: output, status: status);
    }
}

// Run Agent Server with customized agent invocation factory
// Use IServiceProvider.GetRequiredService<IAgentInvocation> as factory if you are using DI.
await AgentServerApplication.RunAsync(new ApplicationOptions(
    ConfigureServices: services => services.AddSingleton<IAgentInvocation, CustomizedAgentInvocation>()
)).ConfigureAwait(false);
```

## Troubleshooting

First run your agent with Azure.AI.AgentServer locally.

If it works on local by failed on cloud. Check your logs in the application insight connected to your Azure AI Foundry Project.


### Reporting issues

To report an issue with the client library, or request additional features, please open a GitHub issue [here](https://github.com/Azure/azure-sdk-for-net/issues). Mention the package name "Azure.AI.AgentServer" in the title or content.

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[RequestFailedException]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects/tests/Samples
[api_ref_docs]: https://learn.microsoft.com/dotnet/api/azure.ai.projects?view=azure-dotnet-preview
[nuget]: https://www.nuget.org/packages/Azure.AI.Projects
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects
[product_doc]: https://learn.microsoft.com/azure/ai-studio/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

