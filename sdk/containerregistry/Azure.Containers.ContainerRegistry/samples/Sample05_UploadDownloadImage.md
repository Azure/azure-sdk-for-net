# Azure.Containers.ContainerRegistry Samples - Upload and Download Images

The following sample illustrates how to upload and download OCI and Docker Images to an Azure Container Registry instance.

## Overview

An image consists of a manifest file, config file, and one or more layer files.  The following samples illustrate how to upload and download these files to effectively "push" and "pull" the images. For more details regarding image formats, please see the [OCI Image Format](https://github.com/opencontainers/image-spec/blob/main/spec.md) and [Docker Registry API](https://docs.docker.com/registry/spec/api/#pulling-an-image) docs.

## Create Client

Create a `ContainerRegistryContentClient` for the registry, passing the repository, credentials, and client options.

```C# Snippet:ContainerRegistry_Samples_CreateContentClient
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
OciImageManifest manifest = new(schemaVersion: 2);

// Upload a config file
BinaryData config = BinaryData.FromString("Sample config");
UploadRegistryBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

// Update manifest with config info
manifest.Configuration = new OciDescriptor()
{
    Digest = uploadConfigResult.Digest,
    SizeInBytes = uploadConfigResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.config.v1+json"
};

// Upload a layer file
BinaryData layer = BinaryData.FromString("Sample layer");
UploadRegistryBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

// Update manifest with layer info
manifest.Layers.Add(new OciDescriptor()
{
    Digest = uploadLayerResult.Digest,
    SizeInBytes = uploadLayerResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.layer.v1.tar"
});

// Finally, upload the manifest file
await client.SetManifestAsync(manifest, tag);
```

## Download an OCI Image

To download an OCI image, first download its manifest.
The manifest describes the files that will need to be downloaded to pull the full image.

```C# Snippet:ContainerRegistry_Samples_DownloadOciImageAsync
// Download the manifest to obtain the list of files in the image
GetManifestResult result = await client.GetManifestAsync(tag);
OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

string manifestFile = Path.Combine(path, "manifest.json");
using (FileStream stream = File.Create(manifestFile))
{
    await result.Manifest.ToStream().CopyToAsync(stream);
}

// Download and write out the config
DownloadRegistryBlobResult configBlob = await client.DownloadBlobContentAsync(manifest.Configuration.Digest);

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

## Upload a Docker manifest list

To upload an image with a custom manifest type, pass the `ManifestMediaType` to the `UploadManifest` method.

```C# Snippet:ContainerRegistry_Samples_UploadCustomManifestAsync
// Create a manifest file in the Docker v2 Manifest List format
var manifestList = new
{
    schemaVersion = 2,
    mediaType = "application/vnd.docker.distribution.manifest.list.v2+json",
    manifests = new[]
    {
        new
        {
            digest = "sha256:721089ae5c4d90e58e3d7f7e6c652a351621fbf37c26eceae23622173ec5a44d",
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
await client.SetManifestAsync(content, tag: "sample", ManifestMediaType.DockerManifestList);
```

## Download a manifest of an unknown type

If you are downloading a manifest where the media type isn't known ahead of time, check the `MediaType` property returned on the `DownloadManifestResult` to determine the type.

```C# Snippet:ContainerRegistry_Samples_DownloadCustomManifestAsync
GetManifestResult result = await client.GetManifestAsync("sample");

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
GetManifestResult manifestResult = await client.GetManifestAsync(tag);
await client.DeleteManifestAsync(manifestResult.Digest);
```

## Delete a blob

A blob can be deleted as shown below.  It is also possible to delete a full image using the `ContainerRegistryClient` as shown in [Sample 2: Delete Image](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/samples/Sample02b_DeleteImagesAsync.md).

```C# Snippet:ContainerRegistry_Samples_DeleteBlob
GetManifestResult result = await client.GetManifestAsync(tag);
OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

foreach (OciDescriptor layerInfo in manifest.Layers)
{
    await client.DeleteBlobAsync(layerInfo.Digest);
}
```
