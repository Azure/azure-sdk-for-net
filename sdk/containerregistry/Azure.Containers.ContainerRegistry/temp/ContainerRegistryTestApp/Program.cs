using System;

namespace ContainerRegistryTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

            // Perform an operation
            Pageable<string> repositories = client.GetRepositories();
            foreach (string repository in repositories)
            {
                Console.WriteLine(repository);
            }
        }
    }
}
