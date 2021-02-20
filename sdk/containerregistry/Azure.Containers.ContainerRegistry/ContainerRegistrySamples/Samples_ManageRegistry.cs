using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Identity;
using System.Linq;

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
        }

        public async Task DeleteStaleImages()
        {
            // I would like to create a script that scans all my repositories on ACR, and delete all the old docker images, 
            // while only keep the latest three images

            // - list repositories
            // - list manifests by last update time
            // - delete manifest
            // - delete layer (TODO: ?)

            ContainerRegistryClient registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            
            AsyncPageable<string> repositoryNames = registryClient.GetRepositoryNamesAsync();
            await foreach (var repositoryName in repositoryNames)
            {
                Console.WriteLine($"Repository name: {repositoryName}");

                ContainerRepositoryClient repositoryClient = registryClient.GetRepositoryClient(repositoryName);
                AsyncPageable<ManifestAttributes> manifests = repositoryClient.GetManifestsAsync(
                    new GetManifestOptions(orderBy: ManifestOrderBy.LastUpdateTimeDescending)
                );

                int manifestCount = 0;
                int manifestsToKeep = 3;
                await foreach (ManifestAttributes manifest in manifests)
                {
                    if (manifestCount >= manifestsToKeep)
                    { 
                        Console.WriteLine($"Deleting manifest with digest {manifest.Digest}.");
                        Console.WriteLine($"   This corresponds to the following tagged images: ");
                        foreach (var tagName in manifest.Tags)
                        {
                            Console.WriteLine($"        {manifest.ImageName}:{tagName}");
                        }
                        await repositoryClient.DeleteImageAsync(repositoryName, manifest.Digest);
                    }

                    manifestCount++;

                    // TODO: the service does its own garbage collection, I think, so I don't think you need to delete the blob, but confirm this
                }
            }
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
