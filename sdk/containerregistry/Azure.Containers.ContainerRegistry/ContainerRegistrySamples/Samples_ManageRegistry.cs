using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Identity;

namespace ContainerRegistrySamples
{
    public class Sample_ManageRegistry
    {
        public async Task ViewRepositories()
        {
            var client = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
            await foreach (var repository in repositories)
            {
                Console.WriteLine($"Repository name is {repository}");
            }

            // TODO: Come up with a nice hero scenario to illustrate in samples
        }

        public async Task ViewManifestsInRepository()
        {
            var client = new ContainerRepositoryClient(new Uri("myacr.azurecr.io"), "hello-world", new DefaultAzureCredential());

            //// TODO: I don't think we need name here, because we specified the image name as the repository in the constructor.  Is this correct?
            //// TODO: This should be pageable
            //// TODO: Pageable of what?  It's meta-data about the manifest, so let's call it ManifestInfo for now...
            //AsyncPageable<ManifestAttributes> manifests = client.GetManifestsAsync();
            //await foreach (var manifest in manifests)
            //{
            //    Console.WriteLine($"Manifest for {manifest.ArtifactName} is {manifest.ArtifactSize} bytes.");
            //}
        }

        public async Task ViewTagsInRepository()
        {
            //var client = new ContainerRegistryRepositoryClient(new Uri("myacr.azurecr.io"), "hello-world", new DefaultAzureCredential());

            //// TODO: I don't think we need name here, because we specified the image name as the repository in the constructor.  Is this correct?
            //// TODO: This should be pageable
            //// TODO: Pageable of what?  It's meta-data about the manifest, so let's call it ManifestInfo for now...
            //AsyncPageable<TagAttributes> tags = client.GetTagsAsync();
            //await foreach (var tag in tags)
            //{
            //    Console.WriteLine($"Tag {tag.Name} was last updated on {tag.LastUpdateTime} bytes.");
            //}

            //// TODO: Order by last update time
            //// TODO: Get tags for digest
            //// Note: these should use GetTagsOptions()
        }
    }
}
