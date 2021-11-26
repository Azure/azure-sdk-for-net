// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using System.Linq;
using System.Threading;
using System.Text.Json;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringProjectsClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void ExportAndImport()
        {
            #region Creating new project for testing purposes
            QuestionAnsweringProjectsClient client = Client;
            string exportedProjectName = "NewProjectForExport";
            RequestContent creationRequestContent = RequestContent.Create(
                new {
                    description = "This is the description for a test project",
                    language = "en",
                    multilingualResource = false,
                    settings = new {
                        defaultAnswer = "No answer found for your question."
                        }
                    }
                );
            Response creationResponse = client.CreateProject(exportedProjectName, creationRequestContent);
            #endregion

            #region Snippet:QuestionAnsweringProjectsClient_ExportProject
            string exportFormat = "json"; // can also be tsv or excel
            Operation<BinaryData> exportOperation = client.Export(exportedProjectName, exportFormat);

            // Wait for operation completion
            TimeSpan pollingInterval = new TimeSpan(1000);

            while (true)
            {
                exportOperation.UpdateStatus();
                if (exportOperation.HasCompleted)
                {
                    Console.WriteLine($"Export operation value: \n{exportOperation.Value}");
                    break;
                }

                Thread.Sleep(pollingInterval);
            }

            // retrieve export operation response, and extract url of exported file
            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
            #endregion

            // TODO: remove this when api-version parameter bug is resolved
            exportedFileUrl = exportedFileUrl + ""; //+ "?api-version=2021-10-01";
            Assert.True(exportOperation.HasCompleted);
            Assert.True(!String.IsNullOrEmpty(exportedFileUrl));

            #region Snippet:QuestionAnsweringProjectsClient_ImportProject
            // Set import project name and request content
            string importedProjectName = "importedProject";
            string importFormat = "json";
            RequestContent importRequestContent = RequestContent.Create(new
                {
                //Metadata = new {
                //       ProjectName= "NewProjectForExport",
                //       Description= "This is the description for a test project",
                //       Language= "en",
                //       DefaultAnswer= "No answer found for your question.",
                //       MultilingualResource= false,
                //       CreatedDateTime= "2021-11-25T09=35=33Z",
                //       LastModifiedDateTime= "2021-11-25T09=35=33Z",
                //       Settings= new {
                //                   DefaultAnswer= "No answer found for your question."
                //       }
                //           }
                //,
                //Assets= new {
                //            Synonyms= new[] { },
                //    Qnas= new[] {}
                //},
                fileUri = exportedFileUrl
            });

            Operation<BinaryData> importOperation = client.Import(importedProjectName, importRequestContent, importFormat);

            // Wait for completion with manual polling.
            while (true)
            {
                importOperation.UpdateStatus();
                if (importOperation.HasCompleted)
                {
                    Console.WriteLine($"Deployment operation value: \n{importOperation.Value}");
                    break;
                }

                Thread.Sleep(pollingInterval);
            }

            // Deployments can be retrieved as follows
            //Pageable<BinaryData> deployments = client.GetDeployments(newProjectName);
            //Console.WriteLine("Deployments: ");
            //foreach (BinaryData deployment in deployments)
            //{
            //    Console.WriteLine(deployment);
            //}
            #endregion

            //Assert.True(deploymentOperation.HasCompleted);
            //Assert.That(deployments.Any(deployment => deployment.ToString().Contains(newDeploymentName)));

            // TODO: This section is prone to change since the delete API will become an LRO

            Response deletionImResponse = client.DeleteProject(importedProjectName);

            Assert.AreEqual(202, deletionImResponse.Status);
        }

        //[RecordedTest]
        //[AsyncOnly]
        //public async Task ExportAndImportAsync()
        //{
        //    QuestionAnsweringProjectsClient client = Client;

        //    #region Snippet:QuestionAnsweringProjectsClient_CreateProjectAsync
        //    // Set project name and request content parameters
        //    string newProjectName = "NewFAQ";
        //    RequestContent creationRequestContent = RequestContent.Create(
        //        new
        //        {
        //            description = "This is the description for a test project",
        //            language = "en",
        //            multilingualResource = false,
        //            settings = new
        //            {
        //                defaultAnswer = "No answer found for your question."
        //            }
        //        }
        //        );

        //    Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);

        //    // Projects can be retrieved as follows
        //    AsyncPageable<BinaryData> projects = client.GetProjectsAsync();

        //    Console.WriteLine("Projects: ");
        //    await foreach (BinaryData project in projects)
        //    {
        //        Console.WriteLine(project);
        //    }
        //    #endregion

        //    Assert.AreEqual(201, creationResponse.Status);
        //    Assert.That((await projects.ToEnumerableAsync()).Any(project => project.ToString().Contains(newProjectName)));

        //    #region Snippet:QuestionAnsweringProjectsClient_UpdateSourcesAsync

        //    // Set request content parameters for updating our new project's sources
        //    string sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
        //    RequestContent updateSourcesRequestContent = RequestContent.Create(
        //        new[] {
        //            new {
        //                    op = "add",
        //                    value = new
        //                    {
        //                        displayName = "MicrosoftFAQ",
        //                        source = sourceUri,
        //                        sourceUri = sourceUri,
        //                        sourceKind = "url",
        //                        contentStructureKind = "unstructured",
        //                        refresh = false
        //                    }
        //                }
        //        });

        //    Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(newProjectName, updateSourcesRequestContent);

        //    // Wait for operation completion
        //    Response<BinaryData> updateSourcesOperationResult = await updateSourcesOperation.WaitForCompletionAsync();

        //    Console.WriteLine($"Update Sources operation result: \n{updateSourcesOperationResult}");

        //    // Deployments can be retrieved as follows
        //    AsyncPageable<BinaryData> sources = client.GetSourcesAsync(newProjectName);
        //    Console.WriteLine("Sources: ");
        //    await foreach (BinaryData source in sources)
        //    {
        //        Console.WriteLine(source);
        //    }
        //    #endregion

        //    Assert.True(updateSourcesOperation.HasCompleted);
        //    Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(sourceUri)));

        //    #region Snippet:QuestionAnsweringProjectsClient_DeployProjectAsync
        //    // Set deployment name and start operation
        //    string newDeploymentName = "production";
        //    Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(newProjectName, newDeploymentName);

        //    // Wait for operation completion
        //    Response<BinaryData> deploymentOperationResult = await deploymentOperation.WaitForCompletionAsync();

        //    Console.WriteLine($"Update Sources operation result: \n{deploymentOperationResult}");

        //    // Deployments can be retrieved as follows
        //    AsyncPageable<BinaryData> deployments = client.GetDeploymentsAsync(newProjectName);
        //    Console.WriteLine("Deployments: ");
        //    await foreach (BinaryData deployment in deployments)
        //    {
        //        Console.WriteLine(deployment);
        //    }
        //    #endregion

        //    Assert.True(deploymentOperation.HasCompleted);
        //    Assert.That((await deployments.ToEnumerableAsync()).Any(deployment => deployment.ToString().Contains(newDeploymentName)));

        //    // TODO: This section is prone to change since the delete API will become an LRO
        //    #region Snippet:QuestionAnsweringProjectsClient_DeleteProjectAsync
        //    Response deletionResponse = await client.DeleteProjectAsync(newProjectName);
        //    #endregion

        //    Assert.AreEqual(202, deletionResponse.Status);
        //}
    }
}
