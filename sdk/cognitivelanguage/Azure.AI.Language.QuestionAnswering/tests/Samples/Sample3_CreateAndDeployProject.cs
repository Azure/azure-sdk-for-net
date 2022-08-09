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

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringProjectsClientSamples : QuestionAnsweringProjectsLiveTestBase
    {
        [RecordedTest]
        [SyncOnly]
        // TODO: Make this test Sync once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
        public async Task CreateAndDeploy()
        {
            QuestionAnsweringProjectsClient client = Client;
            #region Snippet:QuestionAnsweringProjectsClient_CreateProject
            // Set project name and request content parameters
            string newProjectName = "{ProjectName}";
#if !SNIPPET
            newProjectName = CreateTestProjectName();
#endif
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

            Response creationResponse = client.CreateProject(newProjectName, creationRequestContent);
#if !SNIPPET
            EnqueueProjectDeletion(newProjectName);
#endif

            // Projects can be retrieved as follows
            Pageable<BinaryData> projects = client.GetProjects();

            Console.WriteLine("Projects: ");
            foreach (BinaryData project in projects)
            {
                Console.WriteLine(project);
            }
            #endregion

            Assert.AreEqual(201, creationResponse.Status);
            Assert.That(projects.Any(project => project.ToString().Contains(newProjectName)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSources

            // Set request content parameters for updating our new project's sources
            string sourceUri = "{KnowledgeSourceUri}";
#if !SNIPPET
            sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
#endif
            RequestContent updateSourcesRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                displayName = "MicrosoftFAQ",
                                source = sourceUri,
                                sourceUri = sourceUri,
                                sourceKind = "url",
                                contentStructureKind = "unstructured",
                                refresh = false
                            }
                        }
                });

#if SNIPPET
            Operation<BinaryData> updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);
#else
            // TODO: Remove this region once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
            Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Started, newProjectName, updateSourcesRequestContent);
            await updateSourcesOperation.WaitForCompletionAsync();
#endif

            // Knowledge Sources can be retrieved as follows
            Pageable<BinaryData> sources = client.GetSources(newProjectName);
            Console.WriteLine("Sources: ");
            foreach (BinaryData source in sources)
            {
                Console.WriteLine(source);
            }
            #endregion

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That(sources.Any(source => source.ToString().Contains(sourceUri)));

            #region Snippet:QuestionAnsweringProjectsClient_DeployProject
            // Set deployment name and start operation
            string newDeploymentName = "{DeploymentName}";
#if !SNIPPET
            newDeploymentName = "production";
#endif
#if SNIPPET
            Operation<BinaryData> deploymentOperation = client.DeployProject(WaitUntil.Completed, newProjectName, newDeploymentName);
#else
            // TODO: Remove this region once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
            Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(WaitUntil.Started, newProjectName, newDeploymentName);
            await deploymentOperation.WaitForCompletionAsync();
#endif

            // Deployments can be retrieved as follows
            Pageable<BinaryData> deployments = client.GetDeployments(newProjectName);
            Console.WriteLine("Deployments: ");
            foreach (BinaryData deployment in deployments)
            {
                Console.WriteLine(deployment);
            }
            #endregion

            Assert.True(deploymentOperation.HasCompleted);
            Assert.That(deployments.Any(deployment => deployment.ToString().Contains(newDeploymentName)));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task CreateAndDeployAsync()
        {
            QuestionAnsweringProjectsClient client = Client;

            #region Snippet:QuestionAnsweringProjectsClient_CreateProjectAsync
            // Set project name and request content parameters
            string newProjectName = "{ProjectName}";
#if !SNIPPET
            newProjectName = CreateTestProjectName();
#endif
            RequestContent creationRequestContent = RequestContent.Create(
                new
                {
                    description = "This is the description for a test project",
                    language = "en",
                    multilingualResource = false,
                    settings = new
                    {
                        defaultAnswer = "No answer found for your question."
                    }
                }
                );

            Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);
#if !SNIPPET
            EnqueueProjectDeletion(newProjectName);
#endif

            // Projects can be retrieved as follows
            AsyncPageable<BinaryData> projects = client.GetProjectsAsync();

            Console.WriteLine("Projects: ");
            await foreach (BinaryData project in projects)
            {
                Console.WriteLine(project);
            }
            #endregion

            Assert.AreEqual(201, creationResponse.Status);
            Assert.That((await projects.ToEnumerableAsync()).Any(project => project.ToString().Contains(newProjectName)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSourcesAsync

            // Set request content parameters for updating our new project's sources
            string sourceUri = "{KnowledgeSourceUri}";
#if !SNIPPET
            sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
#endif
            RequestContent updateSourcesRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                displayName = "MicrosoftFAQ",
                                source = sourceUri,
                                sourceUri = sourceUri,
                                sourceKind = "url",
                                contentStructureKind = "unstructured",
                                refresh = false
                            }
                        }
                });

#if SNIPPET
            Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);
#else
            // TODO: Remove this region once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
            Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Started, newProjectName, updateSourcesRequestContent);
            await updateSourcesOperation.WaitForCompletionAsync();
#endif

            Console.WriteLine($"Update Sources operation result: \n{updateSourcesOperation.Value}");

            // Knowledge Sources can be retrieved as follows
            AsyncPageable<BinaryData> sources = client.GetSourcesAsync(newProjectName);
            Console.WriteLine("Sources: ");
            await foreach (BinaryData source in sources)
            {
                Console.WriteLine(source);
            }
            #endregion

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(sourceUri)));

            #region Snippet:QuestionAnsweringProjectsClient_DeployProjectAsync
            // Set deployment name and start operation
            string newDeploymentName = "{DeploymentName}";
#if !SNIPPET
            newDeploymentName = "production";
#endif
#if SNIPPET
            Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(WaitUntil.Completed, newProjectName, newDeploymentName);
#else
            // TODO: Remove this region once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
            Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(WaitUntil.Started, newProjectName, newDeploymentName);
            await deploymentOperation.WaitForCompletionAsync();
#endif

            Console.WriteLine($"Update Sources operation result: \n{deploymentOperation.Value}");

            // Deployments can be retrieved as follows
            AsyncPageable<BinaryData> deployments = client.GetDeploymentsAsync(newProjectName);
            Console.WriteLine("Deployments: ");
            await foreach (BinaryData deployment in deployments)
            {
                Console.WriteLine(deployment);
            }
#endregion

            Assert.True(deploymentOperation.HasCompleted);
            Assert.That((await deployments.ToEnumerableAsync()).Any(deployment => deployment.ToString().Contains(newDeploymentName)));
        }
    }
}
