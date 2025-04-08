// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using Azure.AI.OpenAI;
using Azure.Projects;
using Azure.Projects.AI;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new("cm3a7f6af8de8d492");
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-3-large", "1", AIModelKind.Embedding));
infrastructure.AddFeature(new BlobContainerFeature("guidelines", isObservable: false));

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;
ProjectClient project = new("cm3a7f6af8de8d492", null);

var namespaceReviewer = new Agent()
{
    Focus = "namespace naming and design",
    Guidelines = ["general_naming.txt", "namespaces.txt", "azure_namespaces.txt"],
    Project = project,
};

string dll = "Azure.Projects.AI.dll";
if (args.Length > 0) dll = args[0];

string analysis = await namespaceReviewer.AnalyzeAsync(dll);
Console.WriteLine($"Analysis:\n{analysis}\n");

class Agent
{
    public async Task<string> AnalyzeAsync(string dllFilePath)
    {
        ChatRunner runner = new(
            Project.GetOpenAIChatClient(),
            Project.GetOpenAIEmbeddingClient()
        );
        string instructions = $"""
            Review the following API for {Focus} issues.
            if there are no issues with the design, just say "no {Focus} issues".
            Be extremely brief!
        """;

        ChatMessage apis = ComposeApi(dllFilePath);
        ChatThread thread = CreateThread(apis);

        ChatCompletion completion = await runner.TakeTurnAsync(thread, instructions).ConfigureAwait(false);
        return completion.AsText();
    }
    public ChatThread CreateThread(ChatMessage apis)
    {
        ChatMessage guidelines = ComposeGuidelines(Guidelines);
        ChatThread conversation =
        [
            ChatMessage.CreateSystemMessage("You are Krzysztof Cwalina. You will be reviewing .NET APIs."),
            ChatMessage.CreateSystemMessage("The following are the design guidelines to consider:"),
            guidelines,
            ChatMessage.CreateSystemMessage("The following is the .NET API listing you will be reviewing:"),
            apis,
        ];
        return conversation;
    }

    public required string[] Guidelines { get; init; }
    public required string Focus { get; init; }
    public required ProjectClient Project { get; init; }

    static ChatMessage ComposeGuidelines(params string[] filenames)
    {
        StringBuilder sb = new();
        foreach (string filename in filenames)
        {
            string filePath = Path.Combine("guidelines", filename);
            sb.AppendLine(File.ReadAllText(filePath));
        }
        ChatMessage message = ChatMessage.CreateSystemMessage(sb.ToString());
        return message;
    }
    static ChatMessage ComposeApi(string dllFilePath)
    {
        using var fileStream = new FileStream(dllFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var peReader = new PEReader(fileStream);
        MetadataReader mr = peReader.GetMetadataReader();
        string[] nspaces = CSharpApiReader.ReadNamespaces(mr);
        string toAnalyze = String.Join("\n", nspaces);
        Console.WriteLine($"namespaces:\n{toAnalyze}\n");
        ChatMessage message = ChatMessage.CreateSystemMessage(toAnalyze);
        return message;
    }
}
