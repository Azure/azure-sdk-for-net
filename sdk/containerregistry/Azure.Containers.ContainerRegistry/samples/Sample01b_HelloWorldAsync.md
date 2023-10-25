# Azure.Search.Documents Samples - Hello World (async)

The following sample illustrates how to list repositories in a registry, and handle errors that might arise.

## Import the namespaces

```C# Snippet:ContainerRegistry_Tests_Samples_Namespaces
using Azure.Containers.ContainerRegistry;
```

## Create a client

Create a `ContainerRegistryClient` and send a request.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClientAsync
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
```

## Handle Errors

All Container Registry operations will throw a RequestFailedException on failure.

```C# Snippet:ContainerRegistry_Tests_Samples_HandleErrorsAsync
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
```
