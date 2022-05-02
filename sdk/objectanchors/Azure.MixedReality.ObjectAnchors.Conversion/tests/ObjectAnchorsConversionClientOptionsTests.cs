// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    public class ObjectAnchorsConversionClientOptionsTests
    {
        public static IEnumerable<object[]> FileTypeTestCases =>
            new object[][]
            {
                new object[] { ".fbx", true },
                new object[] { ".FBX", true },
                new object[] { ".glb", true },
                new object[] { ".GLB", true },
                new object[] { ".obj", true },
                new object[] { ".OBJ", true },
                new object[] { ".ply", true },
                new object[] { ".PLY", true },
                new object[] { ".gltf", false },
                new object[] { ".GLTF", false },
                new object[] { ".exe", false },
                new object[] { ".EXE", false },
            };

        [Test]
        [TestCaseSource(nameof(FileTypeTestCases))]
        public void IsFileTypeSupported_V0_2_preview_0(string fileExtension, bool expectedIsSupported)
        {
            // Arrange
            AssetFileType assetFileType = new(fileExtension);
            ObjectAnchorsConversionClientOptions clientOptions = new(ObjectAnchorsConversionClientOptions.ServiceVersion.V0_2_preview_0);

            // Act
            bool actualIsSupported = clientOptions.IsFileTypeSupported(assetFileType);

            // Assert
            Assert.AreEqual(expectedIsSupported, actualIsSupported);
        }

        [Test]
        [TestCaseSource(nameof(FileTypeTestCases))]
        public void IsFileTypeSupported_V0_3_preview_0(string fileExtension, bool expectedIsSupported)
        {
            // Arrange
            AssetFileType assetFileType = new(fileExtension);
            ObjectAnchorsConversionClientOptions clientOptions = new(ObjectAnchorsConversionClientOptions.ServiceVersion.V0_3_preview_0);

            // Act
            bool actualIsSupported = clientOptions.IsFileTypeSupported(assetFileType);

            // Assert
            Assert.AreEqual(expectedIsSupported, actualIsSupported);
        }
    }
}
