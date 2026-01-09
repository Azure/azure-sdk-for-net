// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using System.Linq;
using Azure.AI.Language.QuestionAnswering.Authoring.Tests;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests.Samples
{
    public partial class QuestionAnsweringAuthoringClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void CreateAndDeploy()
        {
            QuestionAnsweringAuthoringClient client = Client;
            #region Snippet:QuestionAnsweringAuthoringClient_CreateProject_Authoring
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
            Pageable<QuestionAnsweringProject> projects = client.GetProjects();

            Console.WriteLine("Projects: ");
            foreach (QuestionAnsweringProject project in projects)
            {
                Console.WriteLine(project);
            }
            #endregion

            Assert.That(creationResponse.Status, Is.EqualTo(201));
            var x = projects.ToList();
            Assert.That(projects.Any(project => project.ProjectName.ToString().Contains(newProjectName)));

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSources_Authoring

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

            Operation updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);

            // Knowledge Sources can be retrieved as follows
            BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

            Console.WriteLine($"Sources: {sources}");
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(updateSourcesOperation.HasCompleted, Is.True);
                Assert.That(sources.ToString(), Does.Contain(sourceUri));
            });

            #region Snippet:QuestionAnsweringAuthoringClient_DeployProject_Authoring
            // Set deployment name and start operation
            string newDeploymentName = "{DeploymentName}";
#if !SNIPPET
            newDeploymentName = "production";
#endif

            Operation deploymentOperation = client.DeployProject(WaitUntil.Completed, newProjectName, newDeploymentName);

            // Deployments can be retrieved as follows
            Pageable<ProjectDeployment> deployments = client.GetDeployments(newProjectName);
            Console.WriteLine("Deployments: ");
            foreach (ProjectDeployment deployment in deployments)
            {
                Console.WriteLine(deployment);
            }

            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(deploymentOperation.HasCompleted, Is.True);
                Assert.That(deployments.Any(deployment => deployment.DeploymentName.ToString().Contains(newDeploymentName)));
            });
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task CreateAndDeployAsync()
        {
            QuestionAnsweringAuthoringClient client = Client;

#region Snippet:QuestionAnsweringAuthoringClient_CreateProjectAsync_Authoring
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
            AsyncPageable<QuestionAnsweringProject> projects = client.GetProjectsAsync();

            Console.WriteLine("Projects: ");
            await foreach (QuestionAnsweringProject project in projects)
            {
                Console.WriteLine(project);
            }

            Assert.Multiple(async () =>
            {
                #endregion

                Assert.That(creationResponse.Status, Is.EqualTo(201));
                Assert.That((await projects.ToEnumerableAsync()).Any(project => project.ProjectName.ToString().Contains(newProjectName)));
            });

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSourcesAsync_Authoring

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

            Operation updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);

            // Knowledge Sources can be retrieved as follows
            BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

            Console.WriteLine($"Sources: {sources}");
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(updateSourcesOperation.HasCompleted, Is.True);
                Assert.That(sources.ToString(), Does.Contain(sourceUri));
            });

            #region Snippet:QuestionAnsweringAuthoringClient_DeployProjectAsync_Authoring
            // Set deployment name and start operation
            string newDeploymentName = "{DeploymentName}";
#if !SNIPPET
            newDeploymentName = "production";
#endif

            Operation deploymentOperation = await client.DeployProjectAsync(WaitUntil.Completed, newProjectName, newDeploymentName);

            // Deployments can be retrieved as follows
            AsyncPageable<ProjectDeployment> deployments = client.GetDeploymentsAsync(newProjectName);
            Console.WriteLine("Deployments: ");
            await foreach (ProjectDeployment deployment in deployments)
            {
                Console.WriteLine(deployment);
            }

            Assert.Multiple(async () =>
            {
                #endregion

                Assert.That(deploymentOperation.HasCompleted, Is.True);
                Assert.That((await deployments.ToEnumerableAsync()).Any(deployment => deployment.DeploymentName.ToString().Contains(newDeploymentName)));
            });
        }
    }
}
