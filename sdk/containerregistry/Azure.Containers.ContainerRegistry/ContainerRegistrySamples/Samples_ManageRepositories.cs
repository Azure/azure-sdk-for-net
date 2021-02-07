using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Identity;

namespace ContainerRegistrySamples
{
    public class Sample_ManageRepositories
    {
        public async Task ViewRepositories()
        {
            var client = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
            await foreach (var repository in repositories)
            {
                Console.WriteLine($"Repository name is {repository}");
            }

            // TODO: Come up with a nice hero scenario to illustrate in samples
        }

        public async Task GetRepositoryMetadata()
        {
            var client = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            RepositoryAttributes attributes = await client.GetRepositoryAttributesAsync("hello-world");

            Console.WriteLine($"Repository name is {attributes.Name}");
            Console.WriteLine($"Repository registry is {attributes.Registry}");

            Console.WriteLine($"Repository {attributes.Name} was created at {attributes.CreatedTime}");
            Console.WriteLine($"Repository {attributes.Name} was last updated at {attributes.LastUpdateTime}");

            Console.WriteLine($"Repository {attributes.Name} has {attributes.ManifestCount} manifests");
            Console.WriteLine($"Repository {attributes.Name} has {attributes.TagCount} tags");

            Console.WriteLine($"Repository {attributes.Name} permissions are:");
            Console.WriteLine($"    CanList: {attributes.Permissions.CanList}");
            Console.WriteLine($"    CanRead: {attributes.Permissions.CanRead}");
            Console.WriteLine($"    CanWrite: {attributes.Permissions.CanWrite}");
            Console.WriteLine($"    CanDelete: {attributes.Permissions.CanDelete}");
        }

        public async Task SetRepositoryPermissions()
        {
            var client = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            ContentPermissions permissions = new ContentPermissions()
            {
                CanList = true,
                CanRead = true,
                CanWrite = false,
                CanDelete = false
            };

            await client.SetRepositoryPermissionsAsync("hello-world", permissions);
        }

        public async Task DeleteRepository()
        {
            var client = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            // TODO: add error handling
            DeleteRepositoryResult result = await client.DeleteRepositoryAsync("hello-world");

            Console.WriteLine("Deleted repository.");
            Console.WriteLine($"Deleted {result.ManifestsDeleted} manifests.");
            Console.WriteLine($"Deleted {result.TagsDeleted} tags.");
        }
    }
}
