// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
#region Snippet:SaveToFile
using System.IO;
#endregion
#region Snippet:RenderImportNamespaces
using Azure.Maps.Rendering;
#endregion
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:RenderSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
#endregion

namespace Azure.Maps.Rendering.Tests
{
    public class RenderingClientSamples : SamplesBase<RenderingClientTestEnvironment>
    {
        public void RenderingClientViaAAD()
        {
            #region Snippet:InstantiateRenderClientViaAAD
            // Create a MapsRenderingClient that will authenticate through Active Directory
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);
            #endregion
        }

        public void RenderingClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRenderClientViaSubscriptionKey
            // Create a MapsRenderingClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRenderingClient client = new MapsRenderingClient(credential);
            #endregion
        }

        public void RenderingClientViaSas()
        {
            #region Snippet:InstantiateRenderingClientViaSas
            // Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // Authenticate your client
            ArmClient armClient = new ArmClient(cred);

            string subscriptionId = "MyMapsSubscriptionId";
            string resourceGroupName = "MyMapsResourceGroupName";
            string accountName = "MyMapsAccountName";

            // Get maps account resource
            ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

            // Assign SAS token information
            // Every time you want to SAS token, update the principal ID, max rate, start and expiry time
            string principalId = "MyManagedIdentityObjectId";
            int maxRatePerSecond = 500;

            // Set start and expiry time for the SAS token in round-trip date/time format
            DateTime now = DateTime.Now;
            string start = now.ToString("O");
            string expiry = now.AddDays(1).ToString("O");

            MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
            Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

            // Create a SearchClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsRenderingClient client = new MapsRenderingClient(sasCredential);
            #endregion
        }

        [Test]
        public void RenderingStaticImages()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);

            #region Snippet:RenderStaticImages
            // Prepare static image options
            GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
            {
                ZoomLevel = 10,
                Language = RenderingLanguage.EnglishUsa,
            };

            // Get static image
            Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinStaticImage.png"))
            {
                image.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingStaticImagesWithPinsAndPaths()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);
            Assert.IsNotNull(client);

            #region Snippet:RenderStaticImagesWithPinsAndPaths
            // Prepare pushpin styles
            ImagePushpinStyle pushpinSet1 = new ImagePushpinStyle(
                new List<PushpinPosition>()
                {
                    new PushpinPosition(13.35, 52.577, "Label start"),
                    new PushpinPosition(13.2988, 52.6, "Label end"),
                }
            )
            {
                PushpinScaleRatio = 0.9,
                PushpinColor = Color.Red,
                LabelColor = Color.Blue,
                LabelScaleRatio = 18
            };
            ImagePushpinStyle pushpinSet2 = new ImagePushpinStyle(
                new List<PushpinPosition>() {new PushpinPosition(13.495, 52.497, "Label 3")}
            )
            {
                PushpinScaleRatio = 1.2,
                PushpinColor = Color.Beige,
                LabelColor = Color.White,
                LabelScaleRatio = 18
            };

            // Prepare path styles
            ImagePathStyle path1 = new ImagePathStyle(
                new List<GeoPosition>() {
                    new GeoPosition(13.35, 52.577),
                    new GeoPosition(13.2988, 52.6)
                }
            )
            {
                LineColor = Color.Beige,
                LineWidthInPixels = 5
            };

            // Prepare static image options
            GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(
                new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629),
                new List<ImagePushpinStyle>() { pushpinSet1, pushpinSet2 },
                new List<ImagePathStyle>() { path1 }
            )
            {
                ZoomLevel = 10,
                Language = RenderingLanguage.EnglishUsa
            };

            // Get static image
            Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinStaticImageWithPinsAndPaths.png"))
            {
                image.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(staticImageOptions);
            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingMapTiles()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);

            #region Snippet:RenderMapTiles
            #region Snippet:GetTileXY
            int zoom = 10, tileSize = 256;

            // Get tile X, Y index by coordinate, zoom and tile size information
            MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
            #endregion

            // Fetch map tiles
            GetMapTileOptions GetMapTileOptions = new GetMapTileOptions(
                MapTileSetId.MicrosoftBaseRoad,
                new MapTileIndex(tileIndex.X, tileIndex.Y, zoom)
            );
            Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinMapTile.png"))
            {
                mapTile.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(mapTile);
        }

        [Test]
        public void GetImageryMapTiles()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);

            #region Snippet:GetImageryMapTiles
            int zoom = 10, tileSize = 256;

            // Get tile X, Y index by coordinate, zoom and tile size information
            MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

            // Fetch imagery map tiles
            GetMapTileOptions GetMapTileOptions = new GetMapTileOptions(
                MapTileSetId.MicrosoftImagery,
                new MapTileIndex(tileIndex.X, tileIndex.Y, zoom)
            );
            Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinImagery.png"))
            {
                mapTile.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(mapTile);
        }

        [Test]
        public void GetMapTileSet()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderingClient client = new MapsRenderingClient(credential, clientId);

            #region Snippet:GetMapTileSet
            Response<MapTileSet> tileSetMetadata = client.GetMapTileSet(MapTileSetId.MicrosoftBaseRoad);

            Console.WriteLine("TileSet ID: {0}", tileSetMetadata.Value.TileSetName);
            Console.WriteLine("Tile scheme: {0}", tileSetMetadata.Value.TileScheme);
            foreach (string endpoint in tileSetMetadata.Value.TileEndpoints)
            {
                Console.WriteLine("TileSet endpoint: {0}", endpoint);
            }
            #endregion

            Assert.IsNotNull(tileSetMetadata);
        }
    }
}
