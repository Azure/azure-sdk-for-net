// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

#pragma warning disable OPENAICUA001
public class Sample_ComputerUse : AgentsTestBase
{
    #region Snippet:Sample_GetFile_ComputerUse
    private static string GetFile(string name, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, name);
    }
    #endregion

    #region Snippet:Sample_ProcessComputerUseCall_ComputerUse
    private static ComputerCallOutputResponseItem ProcessComputerUseCall(ComputerCallResponseItem item, IReadOnlyDictionary<string, string> screenshots)
    {
        string currentScreenshot = screenshots["browser_search"];
        switch (item.Action.Kind)
        {
            case ComputerCallActionKind.Type:
                Console.WriteLine($"  Typing text\"{item.Action.TypeText}\" - Simulating keyboard input");
                currentScreenshot = screenshots["search_typed"];
                break;
            case ComputerCallActionKind.KeyPress:
                HashSet<string> codes = [.. item.Action.KeyPressKeyCodes];
                if (codes.Contains("Return") || codes.Contains("ENTER"))
                {
                    Console.WriteLine("  -> Detected ENTER key press");
                    currentScreenshot = screenshots["search_results"];
                }
                else
                {
                    Console.WriteLine($"  Key press: {item.Action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
                }
                break;
            case ComputerCallActionKind.Click:
                Console.WriteLine($"  Click at ({item.Action.ClickCoordinates.Value.X}, {item.Action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
                currentScreenshot = screenshots["search_results"];
                break;
            case ComputerCallActionKind.Drag:
                string pathStr = item.Action.DragPath.ToArray().Select(p => $"{p.X}, {p.Y}").Aggregate("", (agg, next) => $"{agg} -> {next}");
                Console.WriteLine($"  Drag path: {pathStr} - Simulating drag operation");
                break;
            case ComputerCallActionKind.Scroll:
                Console.WriteLine($"  Scroll at ({item.Action.ScrollCoordinates.Value.X}, {item.Action.ScrollCoordinates.Value.Y}) - Simulating scroll action");
                break;
            case ComputerCallActionKind.Screenshot:
                Console.WriteLine("  Taking screenshot - Capturing current screen state");
                break;
            default:
                break;
        }
        Console.WriteLine($"  -> Action processed: {item.Action.Kind}");

        return ResponseItem.CreateComputerCallOutputItem(callId: item.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageFileId: screenshots["browser_search"]));
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task ComputerUseAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ComputerUse
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("COMPUTER_USE_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.COMPUTER_USE_DEPLOYMENT_NAME;
#endif
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #endregion
        #region Snippet:Sample_UploadFiles_ComputerUse_Async
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        Dictionary<string, string> screenshots = new() {
            { "browser_search", (await fileClient.UploadFileAsync(GetFile("Assets/cua_browser_search.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_typed", (await fileClient.UploadFileAsync(GetFile("Assets/cua_search_typed.png"), FileUploadPurpose.Assistants)).Value.Id },
            { "search_results", (await fileClient.UploadFileAsync(GetFile("Assets/cua_search_results.png"), FileUploadPurpose.Assistants)).Value.Id },
        };
        #endregion
        #region Snippet:Sample_CreateAgent_ComputerUse_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a computer automation assistant.\n\n" +
                           "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
            Tools = {
                ResponseTool.CreateComputerTool(
                    environment: new ComputerToolEnvironment("windows"),
                    displayWidth: 1026,
                    displayHeight: 769
                ),
            }
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            definition: agentDefinition,
            options: null);
        #endregion
        #region Snippet:Sample_CreateResponse_ComputerUse_Async
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));
        responseOptions.TruncationMode = ResponseTruncationMode.Auto;
        ResponseItem request = ResponseItem.CreateUserMessageItem(
            [
                ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
                ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
            ]
        );
        List<ResponseItem> inputItems = [request];
        bool computerUseCalled = false;
        int limitIteration = 10;
        OpenAIResponse response;
        do
        {
            response = await CreateAndWaitForResponseAsync(
                responseClient,
                inputItems,
                responseOptions);
            computerUseCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    inputItems.Add(ProcessComputerUseCall(computerCall, screenshots));
                    computerUseCalled = true;
                }
            }
            limitIteration--;
        } while (computerUseCalled && limitIteration > 0);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ComputerUse_Async
        screenshots.Values.Select(async id => await fileClient.DeleteFileAsync(id));
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_WaitForResponse_ComputerUse_Async
    public static async Task<OpenAIResponse> CreateAndWaitForResponseAsync(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
    {
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            inputItems: items,
            options: options);
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    #region Snippet:Sample_WaitForResponse_ComputerUse_Sync
    public static OpenAIResponse CreateAndWaitForResponse(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
    {
        OpenAIResponse response = responseClient.CreateResponse(
            inputItems: items,
            options: options);
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    [Test]
    [SyncOnly]
    public void ComputerUseSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("COMPUTER_USE_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.COMPUTER_USE_DEPLOYMENT_NAME;
#endif
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #region Snippet:Sample_UploadFiles_ComputerUse_Sync
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        Dictionary<string, string> screenshots = new() {
            { "browser_search", fileClient.UploadFile(GetFile("Assets/cua_browser_search.png"), FileUploadPurpose.Assistants).Value.Id },
            { "search_typed", fileClient.UploadFile(GetFile("Assets/cua_search_typed.png"), FileUploadPurpose.Assistants).Value.Id },
            { "search_results", fileClient.UploadFile(GetFile("Assets/cua_search_results.png"), FileUploadPurpose.Assistants).Value.Id },
        };
        #endregion
        #region Snippet:Sample_CreateAgent_ComputerUse_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a computer automation assistant.\n\n" +
                           "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
            Tools = {
                ResponseTool.CreateComputerTool(
                    environment: new ComputerToolEnvironment("windows"),
                    displayWidth: 1026,
                    displayHeight: 769
                ),
            }
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            definition: agentDefinition,
            options: null);
        #endregion
        #region Snippet:Sample_CreateResponse_ComputerUse_Sync
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));
        responseOptions.TruncationMode = ResponseTruncationMode.Auto;
        ResponseItem request = ResponseItem.CreateUserMessageItem(
            [
                ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
                ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
            ]
        );
        List<ResponseItem> inputItems = [request];
        bool computerUseCalled = false;
        int limitIteration = 10;
        OpenAIResponse response;
        do
        {
            response = CreateAndWaitForResponse(
                responseClient,
                inputItems,
                responseOptions);
            computerUseCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    inputItems.Add(ProcessComputerUseCall(computerCall, screenshots));
                    computerUseCalled = true;
                }
            }
            limitIteration--;
        } while (computerUseCalled && limitIteration > 0);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ComputerUse_Sync
        screenshots.Values.Select(id => fileClient.DeleteFile(id));
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ComputerUse(bool isAsync) : base(isAsync)
    { }
}
