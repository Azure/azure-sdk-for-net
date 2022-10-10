using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Identity;

var endpoint = new Uri("https://annelocontainerregistry.azurecr.io");
var credential = new ClientSecretCredential(
    Environment.GetEnvironmentVariable("CONTAINERREGISTRY_TENANT_ID"),
    Environment.GetEnvironmentVariable("CONTAINERREGISTRY_CLIENT_ID"),
    Environment.GetEnvironmentVariable("CONTAINERREGISTRY_CLIENT_SECRET"),
    new ClientSecretCredentialOptions()
    {
        AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
    }
);

var options = new ContainerRegistryClientOptions() { Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud };

ContainerRegistryClient client = new ContainerRegistryClient(endpoint, credential, options);
var names = client.GetRepositoryNamesAsync();

await foreach (string name in names)
{
    Console.WriteLine(name);
}

Console.WriteLine("Done.");
Console.ReadLine();
