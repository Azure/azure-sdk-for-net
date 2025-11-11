// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

#pragma warning disable OPENAICUA001
public class Sample_ComputerUse : AgentsTestBase
{
    #region Snippet:Sample_ReadImageFile_ComputerUse
    private static BinaryData ReadImageFile(string name, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return new BinaryData(File.ReadAllBytes(Path.Combine(dirName, name)));
    }
    #endregion

    #region Snippet:Sample_ProcessComputerUseCall_ComputerUse
    private static string ProcessComputerUseCall(ComputerCallResponseItem item, string oldScreenshot)
    {
        string currentScreenshot = "browser_search";
        switch (item.Action.Kind)
        {
            case ComputerCallActionKind.Type:
                Console.WriteLine($"  Typing text \"{item.Action.TypeText}\" - Simulating keyboard input");
                currentScreenshot = "search_typed";
                break;
            case ComputerCallActionKind.KeyPress:
                HashSet<string> codes = [.. item.Action.KeyPressKeyCodes];
                if (codes.Contains("Return") || codes.Contains("ENTER"))
                {
                    // If we have typed the value to the search field, go to search results.
                    if (string.Equals(oldScreenshot, "search_typed"))
                    {
                        Console.WriteLine("  -> Detected ENTER key press, when search field was populated, displaying results.");
                        currentScreenshot = "search_results";
                    }
                    else
                    {
                        Console.WriteLine("  -> Detected ENTER key press, on results or unpopulated search, do nothing.");
                        currentScreenshot = oldScreenshot;
                    }
                }
                else
                {
                    Console.WriteLine($"  Key press: {item.Action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
                }
                break;
            case ComputerCallActionKind.Click:
                Console.WriteLine($"  Click at ({item.Action.ClickCoordinates.Value.X}, {item.Action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
                if (string.Equals(oldScreenshot, "search_typed"))
                {
                    Console.WriteLine("  -> Assuming click on Search button when search field was populated, displaying results.");
                    currentScreenshot = "search_results";
                }
                else
                {
                    Console.WriteLine("  -> Assuming click on Search on results or when search was not populated, do nothing.");
                    currentScreenshot = oldScreenshot;
                }
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

        return currentScreenshot;
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
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_ReadImageFilesToDictionaries_ComputerUse
        Dictionary<string, BinaryData> screenshots = new() {
            { "browser_search", ReadImageFile("Assets/cua_browser_search.png")},
            { "search_typed", ReadImageFile("Assets/cua_search_typed.png")},
            { "search_results", ReadImageFile("Assets/cua_search_results.png")},
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
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_ComputerUse_Async
        ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent(agentVersion.Name);
        ResponseCreationOptions responseOptions = new();
        responseOptions.TruncationMode = ResponseTruncationMode.Auto;
        ResponseItem request = ResponseItem.CreateUserMessageItem(
            [
                ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
                ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
            ]
        );
        List<ResponseItem> inputItems = [request];
        bool computerUseCalled = false;
        string currentScreenshot = "browser_search";
        int limitIteration = 10;
        OpenAIResponse response;
        do
        {
            response = await CreateAndWaitForResponseAsync(
                responseClient,
                inputItems,
                responseOptions
            );
            computerUseCalled = false;
            responseOptions.PreviousResponseId = response.Id;
            inputItems.Clear();
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
                    inputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
                    computerUseCalled = true;
                }
            }
            limitIteration--;
        } while (computerUseCalled && limitIteration > 0);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ComputerUse_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
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
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        Dictionary<string, BinaryData> screenshots = new() {
            {"browser_search", ReadImageFile("Assets/cua_browser_search.png")},
            {"search_typed", ReadImageFile("Assets/cua_search_typed.png")},
            {"search_results", ReadImageFile("Assets/cua_search_results.png")},
        };
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
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_ComputerUse_Sync
        ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent(agentVersion.Name);
        ResponseCreationOptions responseOptions = new();
        responseOptions.TruncationMode = ResponseTruncationMode.Auto;
        string currentScreenshot = "browser_search";
        ResponseItem request = ResponseItem.CreateUserMessageItem(
            [
                ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
                ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
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
            inputItems.Clear();
            responseOptions.PreviousResponseId = response.Id;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is ComputerCallResponseItem computerCall)
                {
                    currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
                    inputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
                    computerUseCalled = true;
                }
            }
            limitIteration--;
        } while (computerUseCalled && limitIteration > 0);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ComputerUse_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ComputerUse(bool isAsync) : base(isAsync)
    { }
}
