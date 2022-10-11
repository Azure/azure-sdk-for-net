using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Identity;
using TestApp;

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

ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, credential, "oci-artifact", options);

//await Helper.PullTestAsync(client);
await PerFilePulllSamples.PullInChunksTestAsync(client);

Console.WriteLine("Done.");
Console.ReadLine();
