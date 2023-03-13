﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class UploadDownloadImageSample : ContainerRegistrySamplesBase
    {
        public async Task UploadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Samples_CreateBlobClient

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #endregion

            #region Snippet:ContainerRegistry_Samples_UploadOciImageAsync

            // Create a manifest to list files in this image
            OciImageManifest manifest = new();

            // Upload a config file
            BinaryData config = BinaryData.FromString("Sample config");
            UploadBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

            // Update manifest with config info
            manifest.Config = new OciDescriptor()
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

            #endregion
        }

        public async Task DownloadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);

            #region Snippet:ContainerRegistry_Samples_DownloadOciImageAsync

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
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task UploadDownloadOciImageAsync()
        {
            await UploadOciImageAsync();
            await DownloadOciImageAsync();

            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #region Snippet:ContainerRegistry_Samples_DeleteBlob
            DownloadManifestResult result = await client.DownloadManifestAsync(tag);
            OciImageManifest manifest = result.AsOciManifest();

            foreach (OciDescriptor layerInfo in manifest.Layers)
            {
                await client.DeleteBlobAsync(layerInfo.Digest);
            }
            #endregion

            #region Snippet:ContainerRegistry_Samples_DeleteManifest
            DownloadManifestResult downloadManifestResult = await client.DownloadManifestAsync(tag);
            await client.DeleteManifestAsync(downloadManifestResult.Digest);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task UploadDockerManifestAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "library/hello-world";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

#region Snippet:ContainerRegistry_Samples_UploadCustomManifestAsync

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

#endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DownloadCustomManifestAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "library/hello-world";
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "custom-manifest");
            Directory.CreateDirectory(path);

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

#region Snippet:ContainerRegistry_Samples_DownloadCustomManifestAsync

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

#endregion
        }
    }
}
