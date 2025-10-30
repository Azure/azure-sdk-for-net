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
    /// Tests for Map Legend operations using TilerClient.
    /// Tests are mapped from Python tests in test_planetary_computer_07_map_legends.py.
    /// </summary>
    [Category("Tiler")]
    [Category("Legends")]
    public class TestPlanetaryComputer07MapLegendsTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer07MapLegendsTests(bool isAsync) : base(isAsync)
        {
        }

        public TestPlanetaryComputer07MapLegendsTests() : base(true)
        {
        }

        /// <summary>
        /// Tests getting a class map legend (categorical color map) for MTBS Severity.
        /// Maps to Python test: test_01_get_class_map_legend
        /// </summary>
        [RecordedTest]
        [Category("ClassMapLegend")]
        public async Task Test07_01_GetClassMapLegend()
        {
            // Arrange
            var client = GetTestClient();
            var tilerClient = client.GetTilerClient();
            string classmapName = "mtbs-severity"; // ColorMapNames.MTBS_SEVERITY from Python

            TestContext.WriteLine($"Input - classmap_name: {classmapName}");

            // Act
            Response response = await tilerClient.GetClassMapLegendAsync(classmapName, null, null, null);

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
        [RecordedTest]
        [Category("IntervalLegend")]
        public async Task Test07_02_GetIntervalLegend()
        {
            // Arrange
            var client = GetTestClient();
            var tilerClient = client.GetTilerClient();
            string colormapName = "modis-64A1"; // ColorMapNames.MODIS64_A1 from Python (note: hyphen, and capital A)

            TestContext.WriteLine($"Input - colormap_name: {colormapName}");

            // Act
            // Note: Using protocol method because response contains raw numeric arrays, not BinaryData
            Response response = await tilerClient.GetIntervalLegendAsync(colormapName, null, null, null);

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
    }
}
