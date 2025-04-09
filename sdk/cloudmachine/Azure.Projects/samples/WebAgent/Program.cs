// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.AI;
using Azure.Projects;
using OpenAI.Chat;
using Azure.AI.OpenAI;
using Azure.Projects.Ofx;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OfxFeatures()); // add opinionated infrastructure
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
infrastructure.AddFeature(new AppServiceFeature());

// the app can be called with -bicep switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

// add opinionated framework client to the DI container
OfxClient client = builder.AddOfxClient();
EmbeddingsStore embeddings = EmbeddingsStore.Create(client.GetOpenAIEmbeddingClient());
client.Storage.WhenUploaded(embeddings.Add); // update vector db when a new file is uploaded
ChatThread conversationThread = new();

var app = builder.Build();
app.MapRazorPages();
app.UseStaticFiles();

app.MapPost("/upload", async (HttpRequest request, OfxClient client)
    => await client.Storage.UploadFormAsync(request));

app.MapPost("/chat", async (HttpRequest request) =>
{
    try {
        var message = await new StreamReader(request.Body).ReadToEndAsync();
        IEnumerable<VectorbaseEntry> related = embeddings.FindRelated(message);
        conversationThread.Add(related);
        conversationThread.Add(ChatMessage.CreateUserMessage(message));

        ChatClient chat = client.GetOpenAIChatClient();
        ChatCompletion completion = await chat.CompleteChatAsync(conversationThread);
        switch (completion.FinishReason)
        {
            case ChatFinishReason.Stop:
                conversationThread.Add(completion);
                return completion.AsText();
            #region NotImplemented
            //case ChatFinishReason.Length:
            //case ChatFinishReason.ToolCalls:
            //case ChatFinishReason.ContentFilter:
            //case ChatFinishReason.FunctionCall:
            default:
                return ($"FinishReason {completion.FinishReason} not implemented");
                #endregion
        }
    }
    catch (Exception e) {
        return e.Message;
    }
});

app.Run();
