// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to work with Map Legends API for retrieving color maps
    /// and legends for data visualization.
    /// </summary>
    public partial class Sample07_MapLegends : PlanetaryComputerTestBase
    {
        public Sample07_MapLegends(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetClassMapLegend()
        {
            #region Snippet:Sample07_GetClassMapLegend
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Get a class map legend (categorical color map) for MTBS Severity
            string classmapName = "mtbs-severity";
            Response response = await dataClient.GetClassMapLegendAsync(classmapName, null, null, null);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            Console.WriteLine("MTBS Severity Classes:");
            foreach (JsonProperty property in root.EnumerateObject())
            {
                string classValue = property.Name;
                JsonElement colorElement = property.Value;

                // Each color is an array of 4 RGBA values
                int[] rgba = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    rgba[i] = colorElement[i].GetInt32();
                }

                Console.WriteLine($"Class {classValue}: RGBA({rgba[0]}, {rgba[1]}, {rgba[2]}, {rgba[3]})");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetIntervalLegend()
        {
            #region Snippet:Sample07_GetIntervalLegend
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Get an interval legend (continuous color map)
            string colormapName = "modis-64A1";
            Response response = await dataClient.GetIntervalLegendAsync(colormapName, null, null, null);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            Console.WriteLine($"Interval Legend: {root.GetArrayLength()} intervals");

            // Each interval is [[min, max], [R, G, B, A]]
            for (int i = 0; i < Math.Min(5, root.GetArrayLength()); i++)
            {
                JsonElement interval = root[i];
                JsonElement range = interval[0];
                JsonElement color = interval[1];

                Console.WriteLine($"Interval {i}: Range [{range[0].GetDouble()}, {range[1].GetDouble()}]");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetLegendAsPng()
        {
            #region Snippet:Sample07_GetLegendAsPng
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Get a legend as a PNG image
            string colorMapName = "rdylgn";
            Response<BinaryData> response = await dataClient.GetLegendAsync(colorMapName);

            BinaryData legendData = response.Value;
            byte[] legendBytes = legendData.ToArray();

            Console.WriteLine($"Legend PNG size: {legendBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            bool isPng = true;
            for (int i = 0; i < 8; i++)
            {
                if (legendBytes[i] != pngMagic[i])
                {
                    isPng = false;
                    break;
                }
            }

            if (isPng)
            {
                Console.WriteLine("Valid PNG legend retrieved");
                // Save to file
                System.IO.File.WriteAllBytes("legend.png", legendBytes);
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetLegendWithDifferentColormap()
        {
            #region Snippet:Sample07_GetLegendWithDifferentColormap
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Get a legend with the viridis color map
            string colorMapName = "viridis";
            Response<BinaryData> response = await dataClient.GetLegendAsync(colorMapName);

            BinaryData legendData = response.Value;
            byte[] legendBytes = legendData.ToArray();

            Console.WriteLine($"Viridis legend PNG size: {legendBytes.Length} bytes");
            System.IO.File.WriteAllBytes("viridis_legend.png", legendBytes);
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ValidateClassMapStructure()
        {
            #region Snippet:Sample07_ValidateClassMapStructure
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Get class map legend and validate structure
            string classmapName = "mtbs-severity";
            Response response = await dataClient.GetClassMapLegendAsync(classmapName, null, null, null);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            // Collect all colors
            var allColors = new List<int[]>();
            foreach (JsonProperty property in root.EnumerateObject())
            {
                JsonElement colorElement = property.Value;
                int[] color = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    color[i] = colorElement[i].GetInt32();
                }
                allColors.Add(color);
            }

            // Count unique non-transparent colors
            var nonTransparentColors = new HashSet<(int, int, int, int)>(
                allColors
                    .Where(c => c[3] != 0) // Exclude transparent (alpha = 0)
                    .Select(c => (c[0], c[1], c[2], c[3]))
            );

            Console.WriteLine($"Total classes: {allColors.Count}");
            Console.WriteLine($"Unique non-transparent colors: {nonTransparentColors.Count}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task WorkingWithMultipleColormaps()
        {
            #region Snippet:Sample07_WorkingWithMultipleColormaps
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            // Retrieve legends for multiple color maps
            string[] colorMaps = { "rdylgn", "viridis", "plasma", "magma" };

            foreach (string colorMap in colorMaps)
            {
                Response<BinaryData> response = await dataClient.GetLegendAsync(colorMap);
                byte[] legendBytes = response.Value.ToArray();

                Console.WriteLine($"{colorMap}: {legendBytes.Length} bytes");
                System.IO.File.WriteAllBytes($"{colorMap}_legend.png", legendBytes);
            }

            Console.WriteLine($"Retrieved {colorMaps.Length} color map legends");
            #endregion
        }
    }
}
