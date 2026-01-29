// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to work with Shared Access Signatures for secure storage access.
    /// </summary>
    public partial class Sample03_SharedAccessSignatures : PlanetaryComputerTestBase
    {
        public Sample03_SharedAccessSignatures(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTokenWithDefaultDuration()
        {
            #region Snippet:Sample03_GetTokenDefaultDuration
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();

            // Get a SAS token with default duration (24 hours)
            string collectionId = "naip";
            Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(collectionId);
            SharedAccessSignatureToken token = response.Value;

            Console.WriteLine($"SAS Token: {token.Token.Substring(0, 50)}...");
            Console.WriteLine($"Expires On: {token.ExpiresOn:yyyy-MM-dd HH:mm:ss} UTC");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTokenWithCustomDuration()
        {
            #region Snippet:Sample03_GetTokenCustomDuration
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();

            // Get a SAS token with custom duration (60 minutes)
            string collectionId = "naip";
            int durationMinutes = 60;
            Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(
                collectionId,
                durationInMinutes: durationMinutes);

            SharedAccessSignatureToken token = response.Value;
            Console.WriteLine($"SAS Token (valid for {durationMinutes} minutes): {token.Token.Substring(0, 50)}...");
            Console.WriteLine($"Expires On: {token.ExpiresOn:yyyy-MM-dd HH:mm:ss} UTC");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SignAssetHref()
        {
            #region Snippet:Sample03_SignAssetHref
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();

            // Get a collection and its thumbnail asset
            string collectionId = "naip";
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;

            // Get the thumbnail asset HREF
            StacAsset thumbnailAsset = collection.Assets["thumbnail"];
            Uri originalHref = new Uri(thumbnailAsset.Href);
            Console.WriteLine($"Original HREF: {originalHref}");

            // Sign the HREF with SAS token
            Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(originalHref);
            SharedAccessSignatureSignedLink signedLink = signResponse.Value;

            Console.WriteLine($"Signed HREF: {signedLink.Href}");
            if (signedLink.ExpiresOn.HasValue)
            {
                Console.WriteLine($"Expires On: {signedLink.ExpiresOn.Value:yyyy-MM-dd HH:mm:ss} UTC");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task DownloadAssetWithSignedHref()
        {
            #region Snippet:Sample03_DownloadWithSignedHref
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();

            // Get a collection thumbnail
            string collectionId = "naip";
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;
            Uri thumbnailHref = new Uri(collection.Assets["thumbnail"].Href);

            // Get signed HREF
            Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(thumbnailHref);
            Uri signedHref = signResponse.Value.Href;

            // Download the asset using the signed HREF
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage downloadResponse = await httpClient.GetAsync(signedHref);
                byte[] content = await downloadResponse.Content.ReadAsByteArrayAsync();

                Console.WriteLine($"Downloaded {content.Length} bytes");
                Console.WriteLine($"Content-Type: {downloadResponse.Content.Headers.ContentType}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task RevokeToken()
        {
            #region Snippet:Sample03_RevokeToken
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();

            // Generate a SAS token
            string collectionId = "naip";
            Response<SharedAccessSignatureToken> tokenResponse = await sasClient.GetTokenAsync(
                collectionId,
                durationInMinutes: 60);
            Console.WriteLine("Token generated");

            // Revoke the token
            Response revokeResponse = await sasClient.RevokeTokenAsync();
            Console.WriteLine("Token revoked successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SecureAssetAccessWorkflow()
        {
            #region Snippet:Sample03_SecureAccessWorkflow
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";

            // Step 1: Get a collection
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;
            Console.WriteLine($"Retrieved collection: {collection.Id}");

            // Step 2: Extract asset HREFs that need signing
            foreach (var assetEntry in collection.Assets)
            {
                string assetName = assetEntry.Key;
                StacAsset asset = assetEntry.Value;
                Uri assetHref = new Uri(asset.Href);

                Console.WriteLine($"\nAsset: {assetName}");
                Console.WriteLine($"Original HREF: {assetHref}");

                // Step 3: Sign the HREF
                Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(assetHref);
                Uri signedHref = signResponse.Value.Href;
                Console.WriteLine($"Signed HREF: {signedHref}");

                // Step 4: Use signed HREF to access the asset
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(signedHref);
                    if (response.IsSuccessStatusCode)
                    {
                        long contentLength = response.Content.Headers.ContentLength ?? 0;
                        Console.WriteLine($"Successfully accessed asset ({contentLength} bytes)");
                    }
                }
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task WorkingWithMultipleCollections()
        {
            #region Snippet:Sample03_MultipleCollections
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();

            // Get SAS tokens for multiple collections
            string[] collectionIds = { "naip", "landsat-c2-l2", "sentinel-2-l2a" };

            foreach (string collectionId in collectionIds)
            {
                // Get a short-lived token (30 minutes) for each collection
                Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(
                    collectionId,
                    durationInMinutes: 30);

                SharedAccessSignatureToken token = response.Value;
                Console.WriteLine($"Collection: {collectionId}");
                Console.WriteLine($"  Token: {token.Token.Substring(0, 40)}...");
                Console.WriteLine($"  Expires: {token.ExpiresOn:yyyy-MM-dd HH:mm:ss} UTC");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SignItemAsset()
        {
            #region Snippet:Sample03_SignItemAsset
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();

            // Search for items
            string collectionId = "naip";
            var searchRequest = new
            {
                collections = new[] { collectionId },
                limit = 1
            };

            Response searchResponse = await stacClient.SearchAsync(RequestContent.Create(searchRequest));

            // Note: This is a simplified example. In real usage, you would parse the search response
            // to extract item assets and their HREFs, then sign them as needed.

            // Example HREF from an item asset
            Uri itemAssetHref = new Uri("https://naipblobs.blob.core.windows.net/naip/v002/example.tif");

            // Sign the item asset HREF
            Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(itemAssetHref);
            Uri signedHref = signResponse.Value.Href;

            Console.WriteLine($"Original asset HREF: {itemAssetHref}");
            Console.WriteLine($"Signed asset HREF: {signedHref}");
            #endregion
        }
    }
}
