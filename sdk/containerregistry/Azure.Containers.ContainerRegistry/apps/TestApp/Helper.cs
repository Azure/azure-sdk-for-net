using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;

namespace TestApp
{
    public class Helper
    {
        public static async Task PullTestAsync(ContainerRegistryBlobClient client)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "pull-test");

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
                string fileName = Path.Combine(path, Helper.TrimSha(layerFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    var layerResult = await client.DownloadBlobAsync(layerFile.Digest);
                    Stream stream = layerResult.Value.Content;
                    await stream.CopyToAsync(fs).ConfigureAwait(false);
                }
            }
        }

        public static async Task PullInChunksTestAsync(ContainerRegistryBlobClient client)
        {
            var name = "oci-artifact";
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "pull-test-chunks");

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
                string fileName = Path.Combine(path, Helper.TrimSha(layerFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    var response = await client.GetChunkAsync(name, layerFile.Digest, "bytes=0-14");
                    await response.Content.ToStream().CopyToAsync(fs);
                    response = await client.GetChunkAsync(name, layerFile.Digest, "bytes=15-28");
                    await response.Content.ToStream().CopyToAsync(fs);
                }
            }
        }

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
}
