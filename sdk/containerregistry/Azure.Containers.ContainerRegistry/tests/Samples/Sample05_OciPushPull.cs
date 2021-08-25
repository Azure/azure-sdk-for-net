// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class OciPushPullSample : ContainerRegistrySamplesBase
    {
        [Test]
        [AsyncOnly]
        public async Task PullOciArtifactAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_PullOciArtifactAsync

            // TODO: get these from configuration
            var repository = "hello-artifact";
            var digest = "sha256:02d0a223fe27cbce4487d352e2fb36528ea69eb7958987f1ed21d75502a1f86d";
            string path = @"C:\temp\acr\test-oci-pull";

            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));
            var downloadClient = new ContainerRegistryBlobClient(endpoint, new DefaultAzureCredential(), repository, new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            // Get Manifest
            var manifestResult = await downloadClient.DownloadManifestAsync(digest);

            // Write manifest to file
            Directory.CreateDirectory(path);
            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream fs = File.Create(manifestFile))
            {
                Stream stream = manifestResult.Value.Content;
                await stream.CopyToAsync(fs).ConfigureAwait(false);
            }

            // Write Config and Layers
            foreach (var artifactFile in manifestResult.Value.ArtifactFiles)
            {
                string fileName = Path.Combine(path, artifactFile.FileName ?? TrimSha(artifactFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    var layerResult = await downloadClient.DownloadBlobAsync(artifactFile.Digest);
                    await layerResult.Value.Content.CopyToAsync(fs).ConfigureAwait(false);
                }
            }

            #endregion
        }

        private static string TrimSha(string digest)
        {
            int index = digest.IndexOf(':');
            if (index > -1)
            {
                return digest.Substring(index + 1);
            }

            return digest;
        }

        [Test]
        [AsyncOnly]
        public async Task PushOciArtifactAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_PushOciArtifactAsync

            // TODO: get these from configuration
            var repository = "hello-artifact";
            string path = @"C:\temp\acr\test-oci-push";

            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));
            var uploadClient = new ContainerRegistryBlobClient(endpoint, new DefaultAzureCredential(), repository, new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            var manifestFilePath = Path.Combine(path, "manifest.json");
            foreach (var file in Directory.GetFiles(path))
            {
                using (var fs = File.OpenRead(file))
                {
                    if (file == manifestFilePath)
                    {
                        await uploadClient.UploadManifestAsync(fs,
                            new UploadManifestOptions(ManifestMediaType.OciManifestV1)
                        );
                    }
                    else
                    {
                        await uploadClient.UploadBlobAsync(fs);
                    }
                }
            }

            #endregion
        }
    }
}
