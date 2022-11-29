# Azure.Containers.ContainerRegistry Samples - Upload an OCI Artifact

The following sample illustrates how to upload an OCI Artifact to an Azure Container Registry instance.

## Overview

An OCI artifact consists of a manifest file, config file, and one or more layer files.  To upload an image, you will upload each of these files, ending with the manifest file.  For more details regarding the OCI artifact format, please see the [OCI Image Format Specification](https://github.com/opencontainers/image-spec/blob/main/spec.md).

## Upload Image

Create a `ContainerRegistryBlobClient`.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClient

```
