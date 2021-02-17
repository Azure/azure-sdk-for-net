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
    public class Samples_ManageTags
    {
        public async Task ViewAllTagsForRepository()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            // TODO: what is the story around tag signing?

            AsyncPageable<TagAttributes> tags = repositoryClient.GetTagsAsync();
            await foreach (var tag in tags)
            {
                PrintTagAttributes(tag);
            }
        }

        private void PrintTagAttributes(TagAttributes tag)
        {
            // Print Tag
            Console.WriteLine($"Tag repository and digest are {tag.ImageName}:{tag.Digest}");
            Console.WriteLine($"Tag registry is {tag.Registry}");

            Console.WriteLine($"Tag {tag.ImageName}:{tag.Name} was created at {tag.CreatedTime}");
            Console.WriteLine($"Tag {tag.ImageName}:{tag.Name} was last updated at {tag.LastUpdateTime}");

            // TODO: What is the story here?
            Console.WriteLine($"Tag IsSigned is {tag.IsSigned}");

            Console.WriteLine($"Tag {tag.ImageName}:{tag.Name} permissions are:");
            Console.WriteLine($"    CanList: {tag.Permissions.CanList}");
            Console.WriteLine($"    CanRead: {tag.Permissions.CanRead}");
            Console.WriteLine($"    CanWrite: {tag.Permissions.CanWrite}");
            Console.WriteLine($"    CanDelete: {tag.Permissions.CanDelete}");
        }

        public async Task ViewAllTagsOrderedByLastUpdateTime()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            AsyncPageable<TagAttributes> tags = repositoryClient.GetTagsAsync(new GetTagOptions(
              
              // Set of orderby values can be found in the az acr client (see --orderby / Allowed values
              //PS C: \Users\annelo > az acr repository show - tags--help

              //Command
              //    az acr repository show - tags : Show tags for a repository in an Azure Container Registry.

              //  Arguments
              //      --name - n[Required] : The name of the container registry.You can configure the default

              //                                registry name using `az configure --defaults acr =< registry name >`.
              //    --repository[Required] : The name of the repository.

              //   --detail:
              //            Show detailed information.

              //--orderby:
              //            Order the items in the results. Default to alphabetical order of
              //                              names.Allowed values: time_asc, time_desc.

              //  --password - p           : The password used to log into a container registry.

              //   --suffix:
              //            The tenant suffix in registry login server.You may specify '--suffix
              //                              tenant' if your registry login server is in the format 'registry -
              //                              tenant.azurecr.io'. Applicable if you're accessing the registry from a
              //                              different subscription or you have permission to access images but not
              //                              the permission to manage the registry resource.
              //    --top                   : Limit the number of items in the results.
              //    --username - u           : The username used to log into a container registry.

              //Global Arguments
              //    --debug                 : Increase logging verbosity to show all debug logs.
              //    --help - h               : Show this help message and exit.
              //    --only - show - errors      : Only show errors, suppressing warnings.
              //    --output - o             : Output format.  Allowed values: json, jsonc, none, table, tsv, yaml,
              //                              yamlc.Default: json.

              //  --query:
              //            JMESPath query string.See http://jmespath.org/ for more information
              //            and examples.
              //    --subscription          : Name or ID of subscription.You can configure the default subscription
              //                              using `az account set - s NAME_OR_ID`.
              //    --verbose               : Increase logging verbosity.Use--debug for full debug logs.


              //Examples

              //  Show tags of a repository in an Azure Container Registry.

              //      az acr repository show - tags - n MyRegistry--repository MyRepository


              //  Show the detailed information of tags of a repository in an Azure Container Registry.

              //      az acr repository show - tags - n MyRegistry--repository MyRepository--detail


              //  Show the detailed information of the latest 10 tags ordered by timestamp of a repository in an

              //  Azure Container Registry.

              //      az acr repository show - tags - n MyRegistry--repository MyRepository--top 10--orderby

              //      time_desc--detail
              //
              // From Teja: you can only sort by last update time, not created time

              orderBy: TagOrderBy.LastUpdateTimeDescending
                ));

            await foreach (TagAttributes tag in tags)
            {
                Console.WriteLine($"Updated {tag.LastUpdateTime}: Tag: {tag.Name}");
            }
        }

        public async Task ViewAllTagsForGivenDigest()
        {
            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            AsyncPageable<TagAttributes> tags = repositoryClient.GetTagsAsync(new GetTagOptions(
                digest: "sha256:90659bf80b44ce6be8234e6ff90a1ac34acbeb826903b02cfa0da11c82cbc042"
                ));


            await foreach (TagAttributes tag in tags)
            {
                Console.WriteLine($"Updated {tag.LastUpdateTime}: Tag: {tag.Name}");
            }
        }

        public async Task GetTagMetadata()
        {
            // TODO: what is the story around why you would do this?


            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            TagAttributes tagAttributes = await repositoryClient.GetTagAttributesAsync("latest");

            PrintTagAttributes(tagAttributes);
        }

        public async Task UpdateTagPermissions()
        {
            // We can only update the permissions component of the tag metadata - everything else is read-only

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

            // TODO: show that trying to write to this tag fails.  Also, what is the bigger story here? 
        }

        public async Task DeleteTag()
        {
            // TODO: does this just delete the tag but not the manifest or anything else?
            // Or is there more to this story?

            var registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());
            var repositoryClient = registryClient.GetRepositoryClient("hello-world");

            await repositoryClient.DeleteTagAsync("latest");

            // TODO: Write a story where we verify that this is gone.
        }

    }
}
