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
    public class Sample_ManageManifests
    {
        public async Task ViewListOfManifestsInRepositoryAndInfoAboutThem()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            Console.WriteLine($"Repository hello-world contains the following manifests:");

            AsyncPageable<ManifestAttributes> manifests = repositoryClient.GetManifestsAsync();
            await foreach (var manifestAttributes in manifests)
            {
                PrintManifestAttributes(manifestAttributes);
            }
        }

        public async Task ViewListOfManifestsOrderedByLastUpdateTime()
        {
            // TODO: Sample: List Manifests, orderby last update time
        }

        public async Task GetManifestMetadata()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");


            // By Tag
            ManifestAttributes manifestAttributes = await repositoryClient.GetManifestAttributesAsync("latest");

            // TODO: tagOrDigest - would it make sense to model this as Byte[] or other binary output of SHA256 class in .NET?
            // By Digest
            manifestAttributes = await repositoryClient.GetManifestAttributesAsync("<digest>");

            PrintManifestAttributes(manifestAttributes);
        }

        public async Task UpdateManifestPermissions()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            ContentPermissions permissions = new ContentPermissions()
            {
                CanList = true,
                CanRead = true,
                CanWrite = false,
                CanDelete = false
            };

            await repositoryClient.SetManifestPermissionsAsync("latest", permissions);

            // TODO: show that trying to write to this manifest fails.  Also, what is the bigger story here?  
            // It seems like it would be a DevOps story, since this is about being able to push to a registry.
        }

        public async Task GetDockerV2Schema2Manifest()
        {
            // ManifestMediaType.DockerManifestV2Schema2

            // TODO: how will the customer use this once retrieved?
            // I think the answer is, to pull down the entire image represented by the manifest. 
            // It'd be good for this sample to reflect that.

            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            // TODO: we can tidy up this having to create a list inline method = 
            CombinedManifest manifest = await repositoryClient.GetManifestAsync("latest", new List<ManifestMediaType>() { ManifestMediaType.DockerManifestV2Schema2 });

            // To use this, do we need to know what the discriminator type is?
            if (manifest.MediaType == ManifestMediaType.DockerManifestV2Schema2)
            {
                // let's use it to pull the image
                // TODO: need blobs client for this
                // TODO: Come back and do this after blobs client is available.
            }
        }

        public async Task GetOCIImageManifest()
        {
            // ManifestMediaType.OciManifest
            // TODO: how will the customer use this once retrieved?
            // TODO: how would the use of OCIManifest look different from the use of DockerManifestV2Schema2 schema?

            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            // TODO: we can tidy up this having to create a list inline method = 
            CombinedManifest manifest = await repositoryClient.GetManifestAsync("latest", new List<ManifestMediaType>() { ManifestMediaType.OciManifest });

            // To use this, do we need to know what the discriminator type is?
            if (manifest.MediaType == ManifestMediaType.OciManifest)
            {
                // let's use it to pull the image
                // TODO: need blobs client for this
                // TODO: Come back and do this after blobs client is available.

            }
        }

        public async Task CreateDockerV2Schema2Manifest()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            string configMediaType = "application/vnd.docker.container.image.v1+json";

            ContentDescriptor config = new ContentDescriptor(configMediaType);

            // TODO: do blob upload per: https://github.com/sajayantony/acr-cli/blob/main/Services/RegistryService.cs#L98
            // TODO: upload with blob client

            // TODO: investigate content descriptor polymorphism per https://github.com/Azure/azure-sdk-for-net/issues/18579

            //_logger.LogInformation($"Starting Upload {filename}");
            //var blobDescriptor = new FileInfo(filename).ToDescriptor();
            //using (var fs = File.OpenRead(filename))
            //{
            //    _logger.LogInformation($"Uploading {filename} with digest {blobDescriptor.Digest}");
            //    await _registry.UploadBlobAsync(reference, blobDescriptor.Digest, fs);
            //}

            V2Manifest manifest = new V2Manifest()
            {
                Config = config,
            };

            //manifest.Layers.Add(blobDescriptor);

            // YOU ARE HERE - address manifest polymorphism more closely -- will this require changes to the swagger?

            repositoryClient.CreateManifest("latest", manifest);
        }


        private void PrintManifestAttributes(ManifestAttributes manifestAttributes)
        {
            // Print Manifest
            Console.WriteLine($"Manifest repository and digest are {manifestAttributes.ImageName}:{manifestAttributes.Digest}");
            Console.WriteLine($"Manifest registry is {manifestAttributes.Registry}");

            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} was created at {manifestAttributes.CreatedTime}");
            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} was last updated at {manifestAttributes.LastUpdateTime}");

            // TODO: is this the right unit on size?
            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} is {manifestAttributes.ImageSize} bytes.");

            // TODO: better stated - image supports running on <architecture>?  What's the right verbiage here?
            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} CPU architecture is {manifestAttributes.CpuArchitecture}.");
            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} OS is {manifestAttributes.OperatingSystem}.");

            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} MediaType is {manifestAttributes.MediaType}.");
            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} ConfigMediaType is {manifestAttributes.ConfigMediaType}.");

            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} is tagged with the following tags:");
            foreach (string tag in manifestAttributes.Tags)
            {
                Console.WriteLine(tag);
            }

            Console.WriteLine($"Manifest {manifestAttributes.ImageName}:{manifestAttributes.Digest} permissions are:");
            Console.WriteLine($"    CanList: {manifestAttributes.Permissions.CanList}");
            Console.WriteLine($"    CanRead: {manifestAttributes.Permissions.CanRead}");
            Console.WriteLine($"    CanWrite: {manifestAttributes.Permissions.CanWrite}");
            Console.WriteLine($"    CanDelete: {manifestAttributes.Permissions.CanDelete}");
        }
    }
}
