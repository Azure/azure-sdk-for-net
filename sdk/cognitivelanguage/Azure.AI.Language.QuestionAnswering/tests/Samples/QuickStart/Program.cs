/*
* ==========================================
  Install Azure.AI.Language.QuestionAnswering package with command
* ==========================================
*
* dotnet add package Azure.AI.Language.QuestionAnswering
*
* ==========================================
  Tasks Included
* ==========================================
* Create a project
* Update a project
* Deploy a project
* Getting Project data (Sources, QA pairs and synonyms)
* Get Answer
* Delete Project
* ==========================================
  Further reading
* General documentation: https://learn.microsoft.com/en-us/azure/cognitive-services/language-service/question-answering/overview
* Reference documentation: https://learn.microsoft.com/en-us/dotnet/api/Azure.AI.Language.QuestionAnswering?view=azure-dotnet
* ==========================================
*/

namespace Knowledgebase_Quickstart
{
    // Dependencies
    using Azure;
    using Azure.Core;
    using Azure.AI.Language.QuestionAnswering;
    using Azure.AI.Language.QuestionAnswering.Authoring;
    using System;
    using System.Threading.Tasks;

    class Program
    {

        /// <summary>
        /// Main function
        /// </summary>
        static async Task Main(string[] args)
        {
            // Defining Resource Variables
            var languageEndpoint = "<ENTER_LANGUAGE_ENDPOINT_HERE>";
            var apiKey = "<ENTER_LANGUAGE_KEY_HERE>";

            var projectName = "<ENTER_PROJECT_NAME_HERE>";


            // Setting Credentials and URL
            Uri endpoint = new Uri(languageEndpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);

            // Create Clients
            QuestionAnsweringAuthoringClient authoringClient = new QuestionAnsweringAuthoringClient(endpoint, credential);
            QuestionAnsweringClient inferenceClient = new QuestionAnsweringClient(endpoint, credential);

            // Operations
            await CreateProject(authoringClient, projectName);
            await UpdateProject(authoringClient, projectName);
            await DeployProject(authoringClient, projectName);
            await GetProjectData(authoringClient, projectName);
            await GetAnswer(inferenceClient, projectName);
            await DeleteProject(authoringClient, projectName);
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="client">Question Answering Authoring Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task UpdateProject(QuestionAnsweringAuthoringClient client, string projectName)
        {
            // Adding Knowledgebase Source
            var sourceUri = "https://learn.microsoft.com/en-us/azure/cognitive-services/language-service/question-answering/how-to/troubleshooting";
            RequestContent updateSourcesRequestContent = RequestContent.Create(new[]
            {
                new
                {
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

            Operation<AsyncPageable<BinaryData>> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, projectName, updateSourcesRequestContent);

            // Adding a qna pair
            string question = "hello";
            string answer = "Hello, please select from the list of questions or enter a new question to continue.";
            RequestContent updateQnasRequestContent = RequestContent.Create(new[]
            {
                new
                {
                    op = "add",
                    value = new
                    {
                        questions = new[]
                        {
                            question
                        },
                        answer = answer,
                        metadata = new
                        {
                            Category = "Chitchat",
                            Chitchat = "begin"
                        },
                        dialog = new
                        {
                            isContextOnly = false,
                            prompts = new[]
                            {
                                new
                                {
                                    displayOrder = 1,
                                    displayText = "Prompt 1",
                                    qnaId = 1
                                },
                            }
                        }
                    },
                }
            });

            Operation<AsyncPageable<BinaryData>> updateQnasOperation = await client.UpdateQnasAsync(WaitUntil.Completed, projectName, updateQnasRequestContent);


            // Updating synonyms
            RequestContent updateSynonymsRequestContent = RequestContent.Create(new
            {
                value = new[]
                {
                    new  {
                            alterations = new[]
                            {
                                "cqa",
                                "custom question answering",
                            }
                         },
                    new  {
                            alterations = new[]
                            {
                                "qa",
                                "question answer",
                            }
                         }
                }
            });

            Response updateSynonymsResponse = await client.UpdateSynonymsAsync(projectName, updateSynonymsRequestContent);

            // Add active learning feedback
            RequestContent addFeedbackRequestContent = RequestContent.Create(new
            {
                records = new[]
                {
                    new
                    {
                        userId = "userX",
                        userQuestion = "{Follow-up question}",
                        qnaId = 1
                    }
                }
            });

            Response addFeedbackResponse = await client.AddFeedbackAsync(projectName, addFeedbackRequestContent);
        }

        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="client">Question Answering Authoring Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task CreateProject(QuestionAnsweringAuthoringClient client, string projectName)
        {
            string newProjectName = projectName;
            RequestContent creationRequestContent = RequestContent.Create(new
            {
                description = "This is the description for a test project",
                language = "en",
                multilingualResource = false,
                settings = new
                {
                    defaultAnswer = "No answer found for your question."
                }
            });

            Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);

            if (creationResponse.IsError)
            {
                throw new Exception(creationResponse.ReasonPhrase);
            }
        }

        /// <summary>
        /// Deploy Project.
        /// </summary>
        /// <param name="client">Question Answering Authoring Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task DeployProject(QuestionAnsweringAuthoringClient client, string projectName)
        {
            // Set deployment name and start operation
            string newDeploymentName = "production";

            Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(WaitUntil.Completed, projectName, newDeploymentName);

            // Deployments can be retrieved as follows
            AsyncPageable<BinaryData> deployments = client.GetDeploymentsAsync(projectName);
            Console.WriteLine("Deployments: ");
            await foreach (BinaryData deployment in deployments)
            {
                Console.WriteLine(deployment);
            }
        }

        /// <summary>
        /// Get Project Data.
        /// </summary>
        /// <param name="client">Question Answering Authoring Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task GetProjectData(QuestionAnsweringAuthoringClient client, string projectName)
        {
            // Get QnAs
            AsyncPageable<BinaryData> qnas = client.GetQnasAsync(projectName);

            Console.WriteLine("Qnas: ");
            await foreach (var qna in qnas)
            {
                Console.WriteLine(qna);
            }

            // Get Synonyms
            AsyncPageable<BinaryData> synonyms = client.GetSynonymsAsync(projectName);

            Console.WriteLine("Synonyms: ");
            await foreach (BinaryData synonym in synonyms)
            {
                Console.WriteLine(synonym);
            }

            // Get Sources
            AsyncPageable<BinaryData> sources = client.GetSourcesAsync(projectName);

            Console.WriteLine("Sources: ");
            await foreach (var source in sources)
            {
                Console.WriteLine(source);
            }
        }

        /// <summary>
        /// Get Answer.
        /// </summary>
        /// <param name="client">Question Answering Inference Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task GetAnswer(QuestionAnsweringClient client, string projectName)
        {
            string deploymentName = "production";
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            Response<AnswersResult> response = await client.GetAnswersAsync("How do I manage my knowledgebase?", project);

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"({answer.Confidence:P2}) {answer.Answer}");
                Console.WriteLine($"Source: {answer.Source}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="client">Question Answering Authoring Client.</param>
        /// <param name="projectName">Project name.</param>
        /// <returns>Task that completes on completion of operation</returns>
        private static async Task DeleteProject(QuestionAnsweringAuthoringClient client, string projectName)
        {
            Operation<BinaryData> response = await client.DeleteProjectAsync(WaitUntil.Completed, projectName);
        }
    }
}
