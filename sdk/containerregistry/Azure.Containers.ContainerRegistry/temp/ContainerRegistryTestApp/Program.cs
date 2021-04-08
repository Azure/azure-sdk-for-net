using System;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Core;
using Azure.Identity;

namespace ContainerRegistryTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Get the service endpoint from the environment
            //Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));
            string endpoint = "https://localtestacr01.azurecr.io/";

            // Create a new ContainerRegistryClient
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

            // protected Request CreateGetRepositoriesRequest(string last = null, int? n = null)
            //Request req = client.CreateGetRepositoriesRequest();

            Response response = await client.GetRepositoriesAsync();

            //// Perform an operation
            //Pageable<string> repositories = client.GetRepositories();
            //foreach (string repository in repositories)
            //{
            //    Console.WriteLine(repository);
            //}
        }
    }
}
