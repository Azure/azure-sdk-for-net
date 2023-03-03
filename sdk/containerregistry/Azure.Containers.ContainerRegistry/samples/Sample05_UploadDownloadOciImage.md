# Azure.Containers.ContainerRegistry Samples - Upload an OCI Image

The following sample illustrates how to upload an OCI Image to an Azure Container Registry instance.

## Overview

An OCI image consists of a manifest file, config file, and one or more layer files.  The following samples illustrate how to upload and download these files to effectively "push" and "pull" the images. For more details regarding the OCI image format, please see the [OCI Image Format Specification](https://github.com/opencontainers/image-spec/blob/main/spec.md).

## Create Client

Create a `ContainerRegistryBlobClient` for the registry, passing the repository, credentials, and client options.

```C# Snippet:ContainerRegistry_Samples_CreateBlobClient
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repository = "sample-oci-image";
string tag = "demo";

// Create a new ContainerRegistryBlobClient
ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
{
    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
});
```

## Upload Image

To upload an image, upload its config file, layers, and manifest.  In this sample, the manifest is updated with information about each file associated with the image, and then uploaded as a final step.

```C# Snippet:ContainerRegistry_Samples_UploadOciImageAsync
// Create a manifest to list files in this image
OciImageManifest manifest = new();

// Upload a config file
BinaryData config = BinaryData.FromString("Sample config");
UploadBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

// Update manifest with config info
manifest.Config = new OciBlobDescriptor()
{
    Digest = uploadConfigResult.Digest,
    SizeInBytes = config.ToMemory().Length,
    MediaType = "application/vnd.oci.image.config.v1+json"
};

// Upload a layer file
BinaryData layer = BinaryData.FromString("Sample layer");
UploadBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

// Update manifest with layer info
manifest.Layers.Add(new OciBlobDescriptor()
{
    Digest = uploadLayerResult.Digest,
    SizeInBytes = layer.ToMemory().Length,
    MediaType = "application/vnd.oci.image.layer.v1.tar"
});

// Finally, upload the manifest file
await client.UploadManifestAsync(manifest, tag);
```

## Download Image

To download an image, first download its manifest.  The manifest describes the files that need to be downloaded to pull the full image.

```C# Snippet:ContainerRegistry_Samples_DownloadOciImageAsync
// Download the manifest to obtain the list of files in the image
DownloadManifestResult result = await client.DownloadManifestAsync(tag);
OciImageManifest manifest = result.AsOciManifest();

string manifestFile = Path.Combine(path, "manifest.json");
using (FileStream stream = File.Create(manifestFile))
{
    await result.Content.ToStream().CopyToAsync(stream);
}

// Download and write out the config
DownloadBlobResult configBlob = await client.DownloadBlobAsync(manifest.Config.Digest);

string configFile = Path.Combine(path, "config.json");
using (FileStream stream = File.Create(configFile))
{
    await configBlob.Content.ToStream().CopyToAsync(stream);
}

// Download and write out the layers
foreach (OciBlobDescriptor layer in manifest.Layers)
{
    string layerFile = Path.Combine(path, TrimSha(layer.Digest));
    using (FileStream stream = File.Create(layerFile))
    {
        await client.DownloadBlobToAsync(layer.Digest, stream);
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
