// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests.Services;

public class SdkValidatorTests
{
    [Test]
    public void ValidateAsync_WithNullPath_ThrowsArgumentException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => validator.ValidateAsync(null!));
    }

    [Test]
    public void ValidateAsync_WithEmptyPath_ThrowsArgumentException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => validator.ValidateAsync(string.Empty));
    }

    [Test]
    public void ValidateAsync_WithNonExistentPath_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);
        var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        // Act & Assert
        Assert.ThrowsAsync<DirectoryNotFoundException>(() => validator.ValidateAsync(nonExistentPath));
    }

    [Test]
    public void ValidateAsync_WithPathMissingSrcDirectory_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempPath);

        try
        {
            // Act & Assert
            Assert.ThrowsAsync<DirectoryNotFoundException>(() => validator.ValidateAsync(tempPath));
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }

    [Test]
    public void ValidateAsync_WithSrcButNoCsproj_ThrowsFileNotFoundException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var srcPath = Path.Combine(tempPath, "src");
        Directory.CreateDirectory(srcPath);

        try
        {
            // Act & Assert
            Assert.ThrowsAsync<FileNotFoundException>(() => validator.ValidateAsync(tempPath));
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }

    [Test]
    public async Task ValidateAsync_WithValidSdkStructure_ReturnsAbsolutePath()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<SdkValidator>>();
        var validator = new SdkValidator(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var srcPath = Path.Combine(tempPath, "src");
        Directory.CreateDirectory(srcPath);

        var csprojPath = Path.Combine(srcPath, "Test.csproj");
        File.WriteAllText(csprojPath, "<Project Sdk=\"Microsoft.NET.Sdk\"></Project>");

        try
        {
            // Act
            var result = await validator.ValidateAsync(tempPath);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(Path.IsPathFullyQualified(result), Is.True);
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }
}
