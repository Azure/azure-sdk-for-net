# Azure.Containers.ContainerRegistry Samples - Upload and Download Images

The following sample illustrates how to upload and download OCI and Docker Images to an Azure Container Registry instance.

## Overview

An image consists of a manifest file, config file, and one or more layer files.  The following samples illustrate how to upload and download these files to effectively "push" and "pull" the images. For more details regarding image formats, please see the [OCI Image Format](https://github.com/opencontainers/image-spec/blob/main/spec.md) and [Docker Registry API](https://docs.docker.com/registry/spec/api/#pulling-an-image) docs.

## Create Client

Create a `ContainerRegistryBlobClient` for the registry, passing the repository, credentials, and client options.

```C# Snippet:ContainerRegistry_Samples_CreateBlobClient
// Get the service endpoint from the environment
Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repository = "sample-oci-image";
string tag = "demo";

// Create a new ContainerRegistryContentClient
ContainerRegistryContentClient client = new(endpoint, repository, new DefaultAzureCredential());
```

## Upload an OCI Image

To upload an OCI image, upload its config file, layers, and manifest.
In this sample, the manifest is updated with information about each file associated with the image, and then uploaded as a final step.

```C# Snippet:ContainerRegistry_Samples_UploadOciImageAsync
// Create a manifest to list files in this image
OciImageManifest manifest = new();

// Upload a config file
BinaryData config = BinaryData.FromString("Sample config");
UploadBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

// Update manifest with config info
manifest.Configuration = new OciDescriptor()
{
    Digest = uploadConfigResult.Digest,
    SizeInBytes = uploadConfigResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.config.v1+json"
};

// Upload a layer file
BinaryData layer = BinaryData.FromString("Sample layer");
UploadBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

// Update manifest with layer info
manifest.Layers.Add(new OciDescriptor()
{
    Digest = uploadLayerResult.Digest,
    SizeInBytes = uploadLayerResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.layer.v1.tar"
});

// Finally, upload the manifest file
await client.UploadManifestAsync(manifest, tag);
```

## Download an OCI Image

To download an OCI image, first download its manifest.
The manifest describes the files that will need to be downloaded to pull the full image.

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
DownloadBlobResult configBlob = await client.DownloadBlobAsync(manifest.Configuration.Digest);

string configFile = Path.Combine(path, "config.json");
using (FileStream stream = File.Create(configFile))
{
    await configBlob.Content.ToStream().CopyToAsync(stream);
}

// Download and write out the layers
foreach (OciDescriptor layerInfo in manifest.Layers)
{
    string layerFile = Path.Combine(path, TrimSha(layerInfo.Digest));
    using (FileStream stream = File.Create(layerFile))
    {
        await client.DownloadBlobToAsync(layerInfo.Digest, stream);
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

## Upload a custom manifest

To upload an image with a custom manifest type, pass the `ManifestMediaType` to the `UploadManifest` method.

```C# Snippet:ContainerRegistry_Samples_UploadCustomManifestAsync
// Create a manifest file in the Docker v2 Manifest List format
var manifestList = new
{
    schemaVersion = 2,
    mediaType = ManifestMediaType.DockerManifestList.ToString(),
    manifests = new[]
    {
        new
        {
            digest = "sha256:f54a58bc1aac5ea1a25d796ae155dc228b3f0e11d046ae276b39c4bf2f13d8c4",
            mediaType = ManifestMediaType.DockerManifest.ToString(),
            platform = new {
                architecture = ArtifactArchitecture.Amd64.ToString(),
                os = ArtifactOperatingSystem.Linux.ToString()
            }
        }
    }
};

// Finally, upload the manifest file
BinaryData content = BinaryData.FromObjectAsJson(manifestList);
await client.UploadManifestAsync(content, tag: "sample", ManifestMediaType.DockerManifestList);
```

## Download a custom manifest

To download a manifest of an unknown type, pass possible values to the list of acceptable media types.  The media type of the manifest is returned on the `DownloadManifestResult`.

```C# Snippet:ContainerRegistry_Samples_DownloadCustomManifestAsync
// Pass multiple media types if the media type of the manifest to download is unknown
List<ManifestMediaType> mediaTypes = new() {
    "application/vnd.docker.distribution.manifest.list.v2+json",
    "application/vnd.oci.image.index.v1+json" };

DownloadManifestResult result = await client.DownloadManifestAsync("sample", mediaTypes);

if (result.MediaType == "application/vnd.docker.distribution.manifest.list.v2+json")
{
    Console.WriteLine("Manifest is a Docker manifest list.");
}
else if (result.MediaType == "application/vnd.oci.image.index.v1+json")
{
    Console.WriteLine("Manifest is an OCI index.");
}
```

## Delete a manifest

A manifest can be deleted as shown below.  It is also possible to delete a full image using the `ContainerRegistryClient` as shown in [Sample 2: Delete Image](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/samples/Sample02b_DeleteImagesAsync.md).

```C# Snippet:ContainerRegistry_Samples_DeleteManifest
DownloadManifestResult downloadManifestResult = await client.DownloadManifestAsync(tag);
await client.DeleteManifestAsync(downloadManifestResult.Digest);
```

## Delete a blob

A blob can be deleted as shown below.  It is also possible to delete a full image using the `ContainerRegistryClient` as shown in [Sample 2: Delete Image](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/samples/Sample02b_DeleteImagesAsync.md).

```C# Snippet:ContainerRegistry_Samples_DeleteBlob
DownloadManifestResult result = await client.DownloadManifestAsync(tag);
OciImageManifest manifest = result.AsOciManifest();

foreach (OciDescriptor layerInfo in manifest.Layers)
{
    await client.DeleteBlobAsync(layerInfo.Digest);
}
```
