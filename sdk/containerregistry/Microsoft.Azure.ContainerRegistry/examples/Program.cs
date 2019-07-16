using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.Azure.ContainerRegistry;
using Microsoft.Rest.Serialization;
using Microsoft.Azure.ContainerRegistry.Models;
using System.Diagnostics;

class Program
{

    const int FETCH_COUNT_MANIFEST = 5;
    const int FETCH_COUNT_TAGS = 5;

    static void Main(string[] args)
    {
        int timeoutInMilliseconds = 1500000;
        CancellationToken ct = new CancellationTokenSource(timeoutInMilliseconds).Token;
        AzureContainerRegistryClient client = loginAad(ct);


        try
        {
            Console.WriteLine("# ACR V1 enpoint API #");
            testACRV1(client, ct);
            Console.WriteLine("# ACR V2 enpoint API #");
            testACR2(client, ct);

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught: " + e);
        }

    }

    /* Example Credentials provisioning: */
    private static AzureContainerRegistryClient loginBasic(CancellationToken ct)
    {
        Console.WriteLine("-- Basic Auth --");

        string username = "";
        string password = "";
        string loginUrl = "csharpsdktest.azurecr.io";


        AcrClientCredentials credentials = new AcrClientCredentials(AcrClientCredentials.LoginMode.Basic, loginUrl, username, password, ct);
        AzureContainerRegistryClient client = new AzureContainerRegistryClient(credentials);
        client.LoginUri = "https://csharpsdktest.azurecr.io";
        return client;
    }

    private static AzureContainerRegistryClient loginOauth2(CancellationToken ct)
    {
        Console.WriteLine("-- Login Oauth2 --");

        string username = "";
        string password = "";
        string loginUrl = "csharpsdktest.azurecr.io";

        AcrClientCredentials credentials = new AcrClientCredentials(AcrClientCredentials.LoginMode.TokenAuth, loginUrl, username, password, ct);
        AzureContainerRegistryClient client = new AzureContainerRegistryClient(credentials);
        client.LoginUri = "https://csharpsdktest.azurecr.io";
        return client;

    }

    private static AzureContainerRegistryClient loginAad(CancellationToken ct)
    {
        Console.WriteLine("-- Token Oauth2 --");

        string AAD_accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6InU0T2ZORlBId0VCb3NIanRyYXVPYlY4NExuWSIsImtpZCI6InU0T2ZORlBId0VCb3NIanRyYXVPYlY4NExuWSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTYyNzA3NTA0LCJuYmYiOjE1NjI3MDc1MDQsImV4cCI6MTU2MjcxMTQwNCwiX2NsYWltX25hbWVzIjp7Imdyb3VwcyI6InNyYzEifSwiX2NsYWltX3NvdXJjZXMiOnsic3JjMSI6eyJlbmRwb2ludCI6Imh0dHBzOi8vZ3JhcGgud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3VzZXJzLzU3ZmEyMGQwLWNhODItNGY4Ni05ZGE2LWQ3YjBkZWM4YmM4Ni9nZXRNZW1iZXJPYmplY3RzIn19LCJhY3IiOiIxIiwiYWlvIjoiQVVRQXUvOE1BQUFBOEZod1k1Ukg4dXpyWEdLUzBPQ21uRWpvSm9TbitpU2VpMUg1VHk5SmtoVFZTTXBFYlVVMWpra2dqSUJ6UDNFeHJHNmFnT2hITk14Y1p6M0tRTmhWMXc9PSIsImFtciI6WyJyc2EiLCJtZmEiXSwiYXBwaWQiOiIwNGIwNzc5NS04ZGRiLTQ2MWEtYmJlZS0wMmY5ZTFiZjdiNDYiLCJhcHBpZGFjciI6IjAiLCJkZXZpY2VpZCI6IjVmY2ZjZWRlLTI1NGYtNDQ4Yy05MWI2LWUyMjQ5MjZlNDNlYSIsImZhbWlseV9uYW1lIjoiUmV5IExvbmRvbm8iLCJnaXZlbl9uYW1lIjoiRXN0ZWJhbiIsImlwYWRkciI6IjEzMS4xMDcuMTU5LjIwMyIsIm5hbWUiOiJFc3RlYmFuIFJleSBMb25kb25vIiwib2lkIjoiNTdmYTIwZDAtY2E4Mi00Zjg2LTlkYTYtZDdiMGRlYzhiYzg2Iiwib25wcmVtX3NpZCI6IlMtMS01LTIxLTIxMjc1MjExODQtMTYwNDAxMjkyMC0xODg3OTI3NTI3LTM2MDA2NDYzIiwicHVpZCI6IjEwMDMyMDAwNDk3N0Q1NTQiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJPU0NZSl80WXhkNUx1bUlaUDhJc2Ridjl3cmhsVnV6Tk1qRkk5cWtMejlnIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJ0LWVzcmVAbWljcm9zb2Z0LmNvbSIsInVwbiI6InQtZXNyZUBtaWNyb3NvZnQuY29tIiwidXRpIjoieGZiYkJZQVRWa09aV1BoMnJ5OEZBQSIsInZlciI6IjEuMCJ9.TsxGne2kU9ncMHOv-MAzIj1YmVhWvQF2m6aUUheJfmWhoBJkqFK3FCRGZhJmVGE71dzdKeOC5l0t4WmyZAQZfBaPxqyvJ9exlYxZzpRs0pV8wzuEKVCFIiYSYViKgfnQQVT6LVtPNvcIkOqp3MQPj0Ln8woVbUNhYAvasuUYDAnysY3ov79WaMG9_IYFMkd9JIPdD_RIsazSGEYjvMD9mAkIRiTIlczIr3LTOAKHHHq2L4X9UkYSqFY3H9ymFqd0Y-tyxItmF_WKHLEwxrRy5KZuJYFuqYJBhJEQ4ySEdBvGiFsKiK9RcqXpBV9ZZ0Z0J-8FxT0iWl6HizBTyWGYaA";
        string tenant = null; // Tenant is optional
        string loginUrl = "csharpsdktest.azurecr.io";

        AcrClientCredentials credentials = new AcrClientCredentials(AAD_accessToken, loginUrl, tenant, null, ct,
        () =>
        {
            // Note: should be using real new access token
            return AcrClientCredentials.MakeToken(AAD_accessToken);
        });
        AzureContainerRegistryClient client = new AzureContainerRegistryClient(credentials);
        client.LoginUri = "https://csharpsdktest.azurecr.io";
        return client;

    }


    /**
     * Test the V1 api endpoints:
     * /acr/v1/_catalog
     *  - get               - Example Provided (1)
     *  
     * /acr/v1/{name}/_tag/ {reference}
     *  - get               - Example Provided (2)
     *  - patch             - Example Provided (3)
     *  - delete            - Example Provided (4)
     * 
     * /acr/v1/{name}/_tags
     *  - get               - Example Provided (5)
     *  
     * /acr/v1/{name}/_manifests
     *  - get               - Example Provided (6)
     *  
     * /acr/v1/{name}/_manifests/{reference}
     *  - get               - Example Provided (7)
     *  - patch             - Example Provided (8)
     * 
     */
    private static void testACRV1(AzureContainerRegistryClient client, CancellationToken ct)
    {
        // --> Acr V1 Get Repositories  (1)
        Repositories repositories = client.GetAcrRepositoriesAsync(null, 20, ct).GetAwaiter().GetResult();
        Console.WriteLine("GET /acr/v1/_catalog result");
        Console.WriteLine(SafeJsonConvert.SerializeObject(repositories, client.SerializationSettings));

        foreach (string repository in repositories.Names)
        {
            // --> Acr V1 Get Repository Attributes  (2)
            RepositoryAttributes repositoryAttributes;
            Console.WriteLine("GET /acr/v1/{0} result", repository);
            AcrRepositoryTags tags_in;

            try
            {
                repositoryAttributes = client.GetAcrRepositoryAttributesAsync(repository, ct).GetAwaiter().GetResult();
                Console.WriteLine(SafeJsonConvert.SerializeObject(repositoryAttributes, client.SerializationSettings));

                // --> Acr V1 Get Repository Tags  (5)
                Console.WriteLine("GET /acr/v1/{0}/_tags result", repository);
                tags_in = client.GetAcrTagsAsync(repository,
                    null,
                    FETCH_COUNT_TAGS,
                    null,
                    null,
                    ct).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }

            Console.WriteLine(SafeJsonConvert.SerializeObject(tags_in, client.SerializationSettings));
            foreach (AcrTagAttributesBase tag in tags_in.TagsAttributes)
            {
                // ------------------------ Acr V1 Get Tag Attributes ------------------------ ?
                Console.WriteLine("GET /acr/v1/{0}/_tags/{1} result", repository, tag.Name);
                AcrTagAttributes tagAttribute;
                try
                {
                    tagAttribute = client.GetAcrTagAttributesAsync(repository,
                    tag.Name, ct).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("{0} {1}", tag.Name, repository);
                    continue;
                }

                Console.WriteLine(SafeJsonConvert.SerializeObject(tagAttribute, client.SerializationSettings));
            }

            // --> Acr V1 Get Repository Manifests (6)
            AcrManifests manifests = client.GetAcrManifestsAsync(repository,
                null,
                FETCH_COUNT_MANIFEST,
                null,
                ct).GetAwaiter().GetResult();
            Console.WriteLine("GET /acr/v1/{0}/_manifests result", repository);

            Console.WriteLine(SafeJsonConvert.SerializeObject(manifests, client.SerializationSettings));
            foreach (AcrManifestAttributesBase manifest in manifests.ManifestsAttributes)
            {
                Console.WriteLine("GET /acr/v1/{0}/_manifests/{1} result", repository, manifest.Digest);
                AcrManifestAttributes manifestAttribute = null;
                // --> Acr V1 Get Manifest Attributes  (7)
                try
                {
                    manifestAttribute = client.GetAcrManifestAttributesAsync(repository,
                    manifest.Digest,
                    ct).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(SafeJsonConvert.SerializeObject(manifest, client.SerializationSettings));
                }
            }

            RepositoryAttributes attributes = client.GetAcrRepositoryAttributesAsync("hello-world").GetAwaiter().GetResult();
            client.UpdateAcrRepositoryAttributesAsync("hello-world", attributes.ChangeableAttributes).GetAwaiter().GetResult();
            //client.DeleteAcrRepositoryAsync("hello-world-2").GetAwaiter().GetResult();

        }
        // --> Acr V1 Patch Tag  (3)
        Console.WriteLine("PATCH /acr/v1/{name}/_tags/{reference}");
        AcrRepositoryTags tags = client.GetAcrTagsAsync(repositories.Names[0]).GetAwaiter().GetResult();

        // Need to enables delete in case it was disabled in preparation for delete
        ChangeableAttributes changed = new ChangeableAttributes(true, true, true, !tags.TagsAttributes[0].ChangeableAttributes.ReadEnabled);
        client.UpdateAcrTagAttributesAsync(tags.ImageName, tags.TagsAttributes[0].Name, changed, ct).GetAwaiter().GetResult();
        AcrRepositoryTags tagsPostPatch = client.GetAcrTagsAsync(repositories.Names[0], null, null, null, tags.TagsAttributes[0].Digest).GetAwaiter().GetResult();
        Console.WriteLine(SafeJsonConvert.SerializeObject(tagsPostPatch, client.SerializationSettings));
        Debug.Assert(tagsPostPatch.TagsAttributes[0].ChangeableAttributes.ReadEnabled == changed.ReadEnabled);


        // --> Acr V1 Delete Tag  (4)
        Console.WriteLine("DELETE /acr/v1/{name}/_tags/{reference}");
        Console.WriteLine(SafeJsonConvert.SerializeObject(tags, client.SerializationSettings));
        client.DeleteAcrTagAsync(tags.ImageName, tags.TagsAttributes[0].Name).GetAwaiter().GetResult();
        AcrRepositoryTags tagsPostDelete = client.GetAcrTagsAsync(repositories.Names[0]).GetAwaiter().GetResult();

        Console.WriteLine(SafeJsonConvert.SerializeObject(tagsPostDelete, client.SerializationSettings));
        Debug.Assert(!tagsPostDelete.TagsAttributes.Contains(tags.TagsAttributes[0]));
        Console.WriteLine("Succesfully deleted {0}/{1}", tags.ImageName, tags.TagsAttributes[0]);


        // --> Acr V1 Patch Manifest  (8)
        AcrManifests newManifests = client.GetAcrManifestsAsync(repositories.Names[0],
            null,
            null,
            null,
            ct).GetAwaiter().GetResult();

        Console.WriteLine("PATCH /acr/v1/{0}/_manifests/{1} result", repositories.Names[0], newManifests.ManifestsAttributes[0].Digest);
        ChangeableAttributes changed2 = new ChangeableAttributes(true, !newManifests.ManifestsAttributes[0].ChangeableAttributes.ListEnabled, true, !newManifests.ManifestsAttributes[0].ChangeableAttributes.ReadEnabled);
        client.UpdateAcrManifestAttributesAsync(newManifests.ImageName, newManifests.ManifestsAttributes[0].Digest, changed2).GetAwaiter().GetResult();
        AcrManifests manifestsPostPatch = client.GetAcrManifestsAsync(repositories.Names[0],
            null,
            null,
            null,
            ct).GetAwaiter().GetResult();
        Debug.Assert(manifestsPostPatch.ManifestsAttributes[0].ChangeableAttributes.ReadEnabled == changed2.ReadEnabled);


    }


    /**
    * Test the V2 api endpoints:
    * 
    * /v2/
    *  - get               - Test Provided (0)
    * /v2/_catalog
    *  - get               - Test Provided (1)
    * 
    * /v2/{name}/tags/list
    *  - get               - Test Provided (2)
    * 
    * /v2/{name}/manifests/{reference}
    *  - get               - Test Provided (3)
    *  - put               - Test Provided (4)
    *  - delete            - Test Provided (5)
    * 
    */
    private static void testACR2(AzureContainerRegistryClient client, CancellationToken ct)
    {

        // --> Docker V2 Enabled (No Crash indicates success)
        client.GetDockerRegistryV2SupportAsync().GetAwaiter().GetResult();

        // --> Docker V2 Get Repositories  (1)
        Repositories catalogResponse = client.GetRepositoriesAsync(null,
            null,
            ct).GetAwaiter().GetResult();
        Console.WriteLine("GET /v2/_catalog result");
        Console.WriteLine(SafeJsonConvert.SerializeObject(catalogResponse, client.SerializationSettings));

        foreach (string repository in catalogResponse.Names)
        {
            // -->  Docker V2 Get Tags  (2)
            RepositoryTags repositoryTagsPaginated = client.GetTagListAsync(repository,
                ct).GetAwaiter().GetResult();
            Console.WriteLine("GET /v2/{0}/tags/list result", repository);
            Console.WriteLine(SafeJsonConvert.SerializeObject(repositoryTagsPaginated, client.SerializationSettings));
            int max = 10;
            int count = 0;
            foreach (string tag in repositoryTagsPaginated.Tags)
            {
                if (count++ == 10) break;
                // -->  Docker V2 Get Manifest   (3)
                Manifest manifest = client.GetManifestAsync(repository,
                    tag,
                    "application/vnd.docker.distribution.manifest.v2+json", // most of docker images are v2 docker images now. The accept header should include "application/vnd.docker.distribution.manifest.v2+json"
                    ct).GetAwaiter().GetResult();
                Console.WriteLine("GET /v2/{0}/manifests/{1} result", repository, tag);
                Console.WriteLine(SafeJsonConvert.SerializeObject(manifest, client.SerializationSettings));

                // Use the same manifest to update the manifest
                // Keep in mind, you need to wait at least 5 seconds to let this change be committed in server.
                // Getting manifest again right after updating will actually getting old manifest.

                // --> Docker V2 Update Manifest   (4)
                client.CreateManifestAsync(repository,
                    tag, // Reference by tag
                    manifest,
                    ct).GetAwaiter().GetResult();
                Console.WriteLine("PUT /v2/{0}/manifests/{1} result. reference by tag", repository, tag);
                Console.WriteLine(SafeJsonConvert.SerializeObject(manifest, client.SerializationSettings));

                string manifestString = SafeJsonConvert.SerializeObject(manifest, client.SerializationSettings);
                string digest = computeDigest(manifestString);
                client.CreateManifestAsync(repository,
                    digest, // Reference by digest
                    manifest,
                    ct).GetAwaiter().GetResult();
                Console.WriteLine("PUT /v2/{0}/manifests/{1} result. reference by digest", repository, digest);
                Console.WriteLine(SafeJsonConvert.SerializeObject(manifest, client.SerializationSettings));
            }

        }

        string repo = catalogResponse.Names[0];
        RepositoryTags paginatedFirst = client.GetTagListAsync(repo, ct).GetAwaiter().GetResult();
        AcrTagAttributes foundTag = client.GetAcrTagAttributesAsync(repo, paginatedFirst.Tags[0]).GetAwaiter().GetResult();

        // --> Docker V2 Delete Manifest   (5)
        Console.WriteLine("Delete /v2/{0}/manifests/{1} result. Delete by Digest", repo, foundTag.TagAttributes.Digest);
        client.DeleteManifestAsync(repo, foundTag.TagAttributes.Digest, ct).GetAwaiter().GetResult();
        Console.WriteLine("Delete was succesful");

    }

    private static string computeDigest(string s)
    {
        StringBuilder sb = new StringBuilder();

        using (var hash = SHA256.Create())
        {
            Encoding enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(s));

            foreach (Byte b in result)
                sb.Append(b.ToString("x2"));
        }

        return "sha256:" + sb.ToString();
    }
}

