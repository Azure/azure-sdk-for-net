// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Map Legend operations using DataClient.
    /// Tests are mapped from Python tests in test_planetary_computer_07_map_legends.py.
    /// </summary>
    [Category("Tiler")]
    [Category("Legends")]
    [AsyncOnly]
    public class TestPlanetaryComputer07MapLegendsTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer07MapLegendsTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests getting a class map legend (categorical color map) for MTBS Severity.
        /// Maps to Python test: test_01_get_class_map_legend
        /// </summary>
        [Test]
        [Category("ClassMapLegend")]
        public async Task Test07_01_GetClassMapLegend()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string classmapName = "mtbs-severity"; // ColorMapNames.MTBS_SEVERITY from Python

            TestContext.WriteLine($"Input - classmap_name: {classmapName}");

            // Act
            Response response = await dataClient.GetClassMapLegendAsync(classmapName, null, null, null);

            // Assert
            ValidateResponse(response);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            TestContext.WriteLine($"Response type: {root.ValueKind}");

            // Verify response is an object (dictionary mapping class values to colors)
            Assert.That(root.ValueKind, Is.EqualTo(JsonValueKind.Object), "Response should be a JSON object");

            // Get all class values from the response
            var classValues = new List<string>();
            foreach (JsonProperty property in root.EnumerateObject())
            {
                classValues.Add(property.Name);
            }

            Assert.That(classValues.Count, Is.GreaterThan(0), "Response should not be empty");
            TestContext.WriteLine($"Number of classes: {classValues.Count}");

            // Assert MTBS Severity classes are present (0-6)
            string[] expectedClasses = { "0", "1", "2", "3", "4", "5", "6" };
            foreach (string expectedClass in expectedClasses)
            {
                Assert.That(root.TryGetProperty(expectedClass, out _), Is.True,
                    $"Class '{expectedClass}' should be in response");
            }

            // Validate color structure for each class
            foreach (JsonProperty property in root.EnumerateObject())
            {
                string classValue = property.Name;
                JsonElement colorElement = property.Value;

                // Each color should be an array of 4 RGBA values
                Assert.That(colorElement.ValueKind, Is.EqualTo(JsonValueKind.Array),
                    $"Color for class '{classValue}' should be an array");
                Assert.That(colorElement.GetArrayLength(), Is.EqualTo(4),
                    $"Color for class '{classValue}' should have 4 RGBA values");

                // Each RGBA component should be a number 0-255
                string[] componentNames = { "R", "G", "B", "A" };
                for (int i = 0; i < 4; i++)
                {
                    JsonElement component = colorElement[i];
                    Assert.That(component.ValueKind, Is.EqualTo(JsonValueKind.Number),
                        $"{componentNames[i]} for class '{classValue}' should be a number");

                    int value = component.GetInt32();
                    Assert.That(value, Is.InRange(0, 255),
                        $"{componentNames[i]} for class '{classValue}' should be 0-255");
                }

                if (classValue == "0" || classValue == "4")
                {
                    int[] rgba = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        rgba[i] = colorElement[i].GetInt32();
                    }
                    TestContext.WriteLine($"Class {classValue} color: RGBA({rgba[0]}, {rgba[1]}, {rgba[2]}, {rgba[3]})");
                }
            }

            // Validate specific colors for known MTBS severity classes
            if (Mode == RecordedTestMode.Live)
            {
                // Class 0: Transparent (no fire) - [0, 0, 0, 0]
                if (root.TryGetProperty("0", out JsonElement class0))
                {
                    Assert.That(class0[0].GetInt32(), Is.EqualTo(0), "Class 0 R should be 0");
                    Assert.That(class0[1].GetInt32(), Is.EqualTo(0), "Class 0 G should be 0");
                    Assert.That(class0[2].GetInt32(), Is.EqualTo(0), "Class 0 B should be 0");
                    Assert.That(class0[3].GetInt32(), Is.EqualTo(0), "Class 0 A should be 0 (transparent)");
                }

                // Class 4: Red (high severity) - should have high red component (255)
                if (root.TryGetProperty("4", out JsonElement class4))
                {
                    Assert.That(class4[0].GetInt32(), Is.EqualTo(255),
                        "Class 4 (high severity) should have high red component (255)");
                }
            }

            TestContext.WriteLine($"Classes found: {string.Join(", ", classValues)}");
        }

        /// <summary>
        /// Tests getting an interval legend (continuous color map).
        /// Maps to Python test: test_02_get_interval_legend
        /// </summary>
        [Test]
        [Category("IntervalLegend")]
        public async Task Test07_02_GetIntervalLegend()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string colormapName = "modis-64A1"; // ColorMapNames.MODIS64_A1 from Python (note: hyphen, and capital A)

            TestContext.WriteLine($"Input - colormap_name: {colormapName}");

            // Act
            // Note: Using protocol method because response contains raw numeric arrays, not BinaryData
            Response response = await dataClient.GetIntervalLegendAsync(colormapName, null, null, null);

            // Assert
            ValidateResponse(response);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            Assert.That(root.ValueKind, Is.EqualTo(JsonValueKind.Array), "Response should be an array");
            int intervalCount = root.GetArrayLength();
            Assert.That(intervalCount, Is.GreaterThan(0), "Should have at least one interval");

            TestContext.WriteLine($"Number of intervals: {intervalCount}");

            // Validate structure of each interval - each is [[min, max], [R, G, B, A]]
            int validatedCount = 0;
            for (int i = 0; i < intervalCount && validatedCount < 5; i++)
            {
                JsonElement interval = root[i];

                // Each interval should be an array with 2 elements: [range, color]
                Assert.That(interval.ValueKind, Is.EqualTo(JsonValueKind.Array),
                    $"Interval {i} should be an array");
                Assert.That(interval.GetArrayLength(), Is.EqualTo(2),
                    $"Interval {i} should have 2 elements [range, color]");

                TestContext.WriteLine($"Validated interval {i} structure");

                validatedCount++;
            }

            TestContext.WriteLine($"Successfully validated {validatedCount} intervals");
        }

        /// <summary>
        /// Tests getting a legend as a PNG image.
        /// Maps to Python test: test_03_get_legend_as_png
        /// </summary>
        [Test]
        [Category("Legend")]
        public async Task Test07_03_GetLegendAsPng()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string colorMapName = "rdylgn";

            TestContext.WriteLine($"Input - color_map_name: {colorMapName}");

            // Act
            Response<BinaryData> response = await dataClient.GetLegendAsync(colorMapName);

            // Assert
            ValidateResponse(response, "GetLegend");

            BinaryData legendData = response.Value;
            byte[] legendBytes = legendData.ToArray();

            TestContext.WriteLine($"Legend size: {legendBytes.Length} bytes");
            TestContext.WriteLine($"First 16 bytes (hex): {BitConverter.ToString(legendBytes.Take(16).ToArray())}");

            // Verify PNG magic bytes (89 50 4E 47 0D 0A 1A 0A)
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            Assert.That(legendBytes.Length, Is.GreaterThan(0), "Legend bytes should not be empty");
            Assert.That(legendBytes.Length, Is.GreaterThan(100), "Legend should be substantial image");

            bool hasPngMagic = true;
            for (int i = 0; i < 8; i++)
            {
                if (legendBytes[i] != pngMagic[i])
                {
                    hasPngMagic = false;
                    break;
                }
            }
            Assert.That(hasPngMagic, Is.True, "Response should be a valid PNG image (magic bytes mismatch)");

            TestContext.WriteLine("PNG magic bytes validated successfully");
            TestContext.WriteLine("Legend PNG retrieved successfully");
        }

        /// <summary>
        /// Tests getting a legend with a different color map (viridis).
        /// Maps to Python test: test_04_get_legend_with_different_colormap
        /// </summary>
        [Test]
        [Category("Legend")]
        public async Task Test07_04_GetLegendWithDifferentColormap()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string colorMapName = "viridis";

            TestContext.WriteLine($"Input - color_map_name: {colorMapName}");

            // Act
            Response<BinaryData> response = await dataClient.GetLegendAsync(colorMapName);

            // Assert
            ValidateResponse(response, "GetLegend");

            BinaryData legendData = response.Value;
            byte[] legendBytes = legendData.ToArray();

            TestContext.WriteLine($"Legend size: {legendBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            Assert.That(legendBytes.Length, Is.GreaterThan(0), "Legend bytes should not be empty");
            Assert.That(legendBytes.Length, Is.GreaterThan(100), "Legend should be substantial image");

            bool hasPngMagic = true;
            for (int i = 0; i < 8; i++)
            {
                if (legendBytes[i] != pngMagic[i])
                {
                    hasPngMagic = false;
                    break;
                }
            }
            Assert.That(hasPngMagic, Is.True, "Response should be a valid PNG image");

            TestContext.WriteLine("Legend PNG with viridis colormap retrieved successfully");
        }

        /// <summary>
        /// Tests class map legend structure and validates color consistency.
        /// Maps to Python test: test_05_class_map_legend_structure
        /// </summary>
        [Test]
        [Category("ClassMapLegend")]
        public async Task Test07_05_ClassMapLegendStructure()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string classmapName = "mtbs-severity";

            TestContext.WriteLine($"Input - classmap_name: {classmapName}");

            // Act
            Response response = await dataClient.GetClassMapLegendAsync(classmapName, null, null, null);

            // Assert
            ValidateResponse(response);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            // Assert response is a dictionary
            Assert.That(root.ValueKind, Is.EqualTo(JsonValueKind.Object), "Response should be a dict");

            // Validate all keys are string class values
            foreach (JsonProperty property in root.EnumerateObject())
            {
                Assert.That(property.Name, Is.TypeOf<string>(), $"Key '{property.Name}' should be a string");
            }

            // Validate color consistency - all colors should be [R, G, B, A] format
            var allColors = new List<int[]>();
            foreach (JsonProperty property in root.EnumerateObject())
            {
                JsonElement colorElement = property.Value;
                Assert.That(colorElement.GetArrayLength(), Is.EqualTo(4), "All colors should have RGBA format");

                int[] color = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    int component = colorElement[i].GetInt32();
                    Assert.That(component, Is.InRange(0, 255), "All color components should be integers 0-255");
                    color[i] = component;
                }
                allColors.Add(color);
            }

            // Validate that different classes have different colors (except transparent)
            var nonTransparentColors = new HashSet<(int, int, int, int)>(
                allColors
                    .Where(c => c[3] != 0) // Exclude transparent (alpha = 0)
                    .Select(c => (c[0], c[1], c[2], c[3]))
            );

            Assert.That(nonTransparentColors.Count, Is.GreaterThan(1),
                "Non-transparent classes should have different colors");

            TestContext.WriteLine($"Found {allColors.Count} classes with {nonTransparentColors.Count} unique non-transparent colors");
            TestContext.WriteLine("Color consistency validated successfully");
        }
    }
}
