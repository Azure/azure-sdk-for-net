using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Specialized;
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

//ContainerRegistryClient client = new ContainerRegistryClient(endpoint, credential, options);

// Pull sample via protocol methods
var path = Path.Combine(Environment.CurrentDirectory, "Data", "pull-test");

ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, credential, "oci-artifact", options);

var manifestResult = await client.DownloadManifestAsync(new DownloadManifestOptions("v1"));

// Write manifest to file
Directory.CreateDirectory(path);
string manifestFile = Path.Combine(path, "manifest.json");
using (FileStream fs = File.Create(manifestFile))
{
    Stream stream = manifestResult.Value.ManifestStream;
    await stream.CopyToAsync(fs).ConfigureAwait(false);
}

OciManifest manifest = manifestResult.Value.Manifest;

// Write Config
string configFileName = Path.Combine(path, "config.json");
using (FileStream fs = File.Create(configFileName))
{
    var layerResult = await client.DownloadBlobAsync(manifest.Config.Digest);
    Stream stream = layerResult.Value.Content;
    await stream.CopyToAsync(fs).ConfigureAwait(false);
}

// Write Layers
foreach (var layerFile in manifest.Layers)
{
    string fileName = Path.Combine(path, Helpers.TrimSha(layerFile.Digest));

    using (FileStream fs = File.Create(fileName))
    {
        var layerResult = await client.DownloadBlobAsync(layerFile.Digest);
        Stream stream = layerResult.Value.Content;
        await stream.CopyToAsync(fs).ConfigureAwait(false);
    }
}

Console.WriteLine("Done.");
Console.ReadLine();



// ######## Start of Definitions ########

public class Helpers
{
    public static string TrimSha(string digest)
    {
        int index = digest.IndexOf(':');
        if (index > -1)
        {
            return digest.Substring(index + 1);
        }
        return digest;
    }
}
