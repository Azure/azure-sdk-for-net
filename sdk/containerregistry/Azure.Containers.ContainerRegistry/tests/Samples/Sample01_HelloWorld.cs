// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:ContainerRegistry_Tests_Samples_Namespaces
using Azure.Containers.ContainerRegistry;
#endregion Snippet:ContainerRegistry_Tests_Samples_Namespaces
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class HelloWorld : ContainerRegistrySamplesBase
    {
        [Test]
        [SyncOnly]
        public void CreateClient()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_CreateClient
            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

            // Get the collection of repository names from the registry
            Pageable<string> repositories = client.GetRepositoryNames();
            foreach (string repository in repositories)
            {
                Console.WriteLine(repository);
            }
            #endregion Snippet:ContainerRegistry_Tests_Samples_CreateClient
        }

        [Test]
        [AsyncOnly]
        public async Task CreateClientAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_CreateClientAsync
            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

            // Get the collection of repository names from the registry
            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
            await foreach (string repository in repositories)
            {
                Console.WriteLine(repository);
            }
            #endregion Snippet:ContainerRegistry_Tests_Samples_CreateClientAsync
        }

        [Test]
        [SyncOnly]
        public void HandleErrors()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_HandleErrors
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a ContainerRepository class for an invalid repository
            string fakeRepositoryName = "doesnotexist";
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
            ContainerRepository repository = client.GetRepository(fakeRepositoryName);

            try
            {
                repository.GetProperties();
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Repository wasn't found.");
                Console.WriteLine($"Service error: {ex.Message}.");
            }
            #endregion Snippet:ContainerRegistry_Tests_Samples_HandleErrors
        }

        [Test]
        [AsyncOnly]
        public async Task HandleErrorsAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_HandleErrorsAsync
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a ContainerRepository class for an invalid repository
            string fakeRepositoryName = "doesnotexist";
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
            ContainerRepository repository = client.GetRepository(fakeRepositoryName);

            try
            {
                await repository.GetPropertiesAsync();
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Repository wasn't found.");
                Console.WriteLine($"Service error: {ex.Message}.");
            }
            #endregion Snippet:ContainerRegistry_Tests_Samples_HandleErrorsAsync
        }
    }
}
