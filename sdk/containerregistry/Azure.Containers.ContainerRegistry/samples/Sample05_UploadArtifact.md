# Azure.Containers.ContainerRegistry Samples - Upload an OCI Artifact

The following sample illustrates how to upload an OCI Artifact to an Azure Container Registry instance.

## Overview

An OCI artifact consists of a manifest file, config file, and one or more layer files.  To upload an image, you will upload each of these files, ending with the manifest file.  For more details regarding the OCI artifact format, please see the [OCI Image Format Specification](https://github.com/opencontainers/image-spec/blob/main/spec.md).

## Upload Image

Create a `ContainerRegistryBlobClient`.

```C# Snippet:ContainerRegistry_Tests_Samples_UploadArtifactAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repository = "sample-artifact";
string tag = "demo";

// Create a new ContainerRegistryBlobClient
ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
{
    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
});

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
