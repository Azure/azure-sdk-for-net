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

            // TODO: show that trying to write to this manifest fails.
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
