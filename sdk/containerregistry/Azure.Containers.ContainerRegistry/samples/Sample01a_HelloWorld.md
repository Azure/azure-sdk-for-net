# Azure.Containers.ContainerRegistry Samples - Hello World (sync)

## Import the namespaces

```C# Snippet:ContainerRegistry_Tests_Samples_Namespaces
using Azure.Containers.ContainerRegistry;
```

## Create a client

Create a `ContainerRegistryClient` and send a request.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClient
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
```

## Handle Errors

All Container Registry operations will throw a RequestFailedException on failure.

```C# Snippet:ContainerRegistry_Tests_Samples_HandleErrors
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create an invalid ContainerRepositoryClient
string fakeRepositoryName = "doesnotexist";
ContainerRepositoryClient client = new ContainerRepositoryClient(endpoint, fakeRepositoryName, new DefaultAzureCredential());

try
{
    client.GetProperties();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Repository wasn't found.");
}
```
