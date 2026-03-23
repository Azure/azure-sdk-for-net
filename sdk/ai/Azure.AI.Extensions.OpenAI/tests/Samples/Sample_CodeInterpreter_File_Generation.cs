// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Containers;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_CodeInterpreter_File_Generation : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CodeInterpreter_File_Generation
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_CodeInterpreter_File_Generation_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a personal math tutor. When asked a math question, generate the appropriate PDF, save it and return its file ID.",
            Tools = {
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
                    )
                ),
            }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CodeInterpreter_File_Generation_Async
        AgentReference agentReference = new(name: agentVersion.Name, version: agentVersion.Version);
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
        ResponseResult response = await responseClient.CreateResponseAsync("Please create PDF file showing the rendering of Mandelbrot set");
        if (response.Status != ResponseStatus.Completed)
        {
            throw new InvalidOperationException($"The response status is not successful: {response.Status.Value}");
        }
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_GetCitation_CodeInterpreter_File_Generation
        ContainerFileCitationMessageAnnotation containerAnnotation = null;
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is MessageResponseItem messageItem)
            {
                foreach (ResponseContentPart content in messageItem.Content)
                {
                    foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                    {
                        if (annotation is ContainerFileCitationMessageAnnotation cntrAnnotation)
                        {
                            containerAnnotation = cntrAnnotation;
                        }
                    }
                }
            }
        }
        if (containerAnnotation is null)
        {
            throw new InvalidOperationException("The file was not generated.");
        }
        Console.WriteLine($"Container: {containerAnnotation.ContainerId}, fileID: {containerAnnotation.FileId}");
        #endregion
        #region Snippet:Sample_Download_CodeInterpreter_File_Generation_Async
        ContainerClient containerClient = projectClient.OpenAI.GetContainerClient();
        BinaryData fileData = await containerClient.DownloadContainerFileAsync(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
        File.WriteAllBytes(
            path: "./results.pdf",
            bytes: fileData.ToArray()
        );
        Console.WriteLine($"PDF downloaded and saved to: {Path.GetFullPath("results.pdf")}");
        #endregion
        #region Snippet:Sample_Cleanup_CodeInterpreter_File_Generation_Async
        await containerClient.DeleteContainerFileAsync(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreter()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_CodeInterpreter_File_Generation_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a personal math tutor. When asked a math question, generate the appropriate PDF, save it and return its file ID.",
            Tools = {
                ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
                    )
                ),
            }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CodeInterpreter_File_Generation_Sync
        AgentReference agentReference = new(name: agentVersion.Name, version: agentVersion.Version);
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
        ResponseResult response = responseClient.CreateResponse("Please create PDF file showing the rendering of Mandelbrot set");
        if (response.Status != ResponseStatus.Completed)
        {
            throw new InvalidOperationException($"The response status is not successful: {response.Status.Value}");
        }
        Console.WriteLine(response.GetOutputText());
        #endregion
        ContainerFileCitationMessageAnnotation containerAnnotation = null;
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is MessageResponseItem messageItem)
            {
                foreach (ResponseContentPart content in messageItem.Content)
                {
                    foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                    {
                        if (annotation is ContainerFileCitationMessageAnnotation cntrAnnotation)
                        {
                            containerAnnotation = cntrAnnotation;
                        }
                    }
                }
            }
        }
        if (containerAnnotation is null)
        {
            throw new InvalidOperationException("The file was not generated.");
        }
        Console.WriteLine($"Container: {containerAnnotation.ContainerId}, fileID: {containerAnnotation.FileId}");
        #region Snippet:Sample_Download_CodeInterpreter_File_Generation_Sync
        ContainerClient containerClient = projectClient.OpenAI.GetContainerClient();
        BinaryData fileData = containerClient.DownloadContainerFile(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
        File.WriteAllBytes(
            path: "./results.pdf",
            bytes: fileData.ToArray()
        );
        Console.WriteLine($"PDF downloaded and saved to: {Path.GetFullPath("results.pdf")}");
        #endregion
        #region Snippet:Sample_Cleanup_CodeInterpreter_File_Generation_Sync
        containerClient.DeleteContainerFile(containerId: containerAnnotation.ContainerId, fileId: containerAnnotation.FileId);
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CodeInterpreter_File_Generation(bool isAsync) : base(isAsync)
    { }
}
