# Azure.Containers.ContainerRegistry Samples - Upload an OCI Artifact

The following sample illustrates how to upload an OCI Artifact to an Azure Container Registry instance.

## Overview

An OCI artifact consists of a manifest file, config file, and one or more layer files.  The following samples illustrate how to upload and download these files to effectively "push" and "pull" the artifacts. For more details regarding the OCI artifact format, please see the [OCI Image Format Specification](https://github.com/opencontainers/image-spec/blob/main/spec.md).

## Create Client

Create a `ContainerRegistryBlobClient` for the registry, passing the repository, credentials, and client options.

```C# Snippet:ContainerRegistry_Samples_CreateBlobClient
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repository = "sample-artifact";
string tag = "demo";

// Create a new ContainerRegistryBlobClient
ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
{
    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
});
```

## Upload Artifact

To upload an artifact, upload its config file, layers, and manifest.  In this sample, the manifest is updated with information about each file associated with the artifact, and then uploaded as a final step.

```C# Snippet:ContainerRegistry_Samples_UploadArtifactAsync
// Create a manifest to list files in this artifact
OciManifest manifest = new()
{
    SchemaVersion = 2
};

// Upload a config file
using Stream config = BinaryData.FromString("Sample config").ToStream();
var uploadConfigResult = await client.UploadBlobAsync(config);

// Update manifest with config info
manifest.Config = new OciBlobDescriptor()
{
    Digest = uploadConfigResult.Value.Digest,
    Size = uploadConfigResult.Value.Size,
    MediaType = OciMediaType.ImageConfig.ToString()
};

// Upload a layer file
using Stream layer = BinaryData.FromString("Sample layer").ToStream();
var uploadLayerResult = await client.UploadBlobAsync(layer);

// Update manifest with layer info
manifest.Layers.Add(new OciBlobDescriptor()
{
    Digest = uploadLayerResult.Value.Digest,
    Size = uploadLayerResult.Value.Size,
    MediaType = OciMediaType.ImageLayer.ToString()
});

// Finally, upload the manifest file
await client.UploadManifestAsync(manifest, new UploadManifestOptions(tag));
```

## Download Artifact

To download an artifact, first download its manifest.  The manifest describes the files that need to be downloaded to pull the full artifact.

```C# Snippet:ContainerRegistry_Samples_DownloadArtifactAsync
// Download the manifest to obtain the list of files in the artifact
var manifestResult = await client.DownloadManifestAsync(new DownloadManifestOptions(tag));
OciManifest manifest = (OciManifest)manifestResult.Value.Manifest;

await WriteFile(Path.Combine(path, "manifest.json"), manifestResult.Value.ManifestStream);

// Download and write out the config
var configResult = await client.DownloadBlobAsync(manifest.Config.Digest);

await WriteFile(Path.Combine(path, "config.json"), configResult.Value.Content);

// Download and write out the layers
foreach (var layerFile in manifest.Layers)
{
    var layerResult = await client.DownloadBlobAsync(layerFile.Digest);
    Stream stream = layerResult.Value.Content;

    await WriteFile(Path.Combine(path, TrimSha(layerFile.Digest)), configResult.Value.Content);
}

// Helper methods
async Task WriteFile(string path, Stream content)
{
    using (FileStream fs = File.Create(path))
    {
        await content.CopyToAsync(fs);
    }
}

static string TrimSha(string digest)
{
    int index = digest.IndexOf(':');
    if (index > -1)
    {
        return digest.Substring(index + 1);
    }

    return digest;
}
```
