// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class ValidationServiceTests
{
    [Test]
    public void ValidateAsync_WithNullPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);

        Assert.ThrowsAsync<ArgumentException>(() => validator.ValidateAsync(null!));
    }

    [Test]
    public void ValidateAsync_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);

        Assert.ThrowsAsync<ArgumentException>(() => validator.ValidateAsync(string.Empty));
    }

    [Test]
    public void ValidateAsync_WithNonExistentPath_ThrowsDirectoryNotFoundException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        Assert.ThrowsAsync<DirectoryNotFoundException>(() => validator.ValidateAsync(nonExistentPath));
    }

    [Test]
    public void ValidateAsync_WithPathMissingSrcDirectory_ThrowsDirectoryNotFoundException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempPath);

        try
        {
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
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var srcPath = Path.Combine(tempPath, "src");
        Directory.CreateDirectory(srcPath);

        try
        {
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
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var srcPath = Path.Combine(tempPath, "src");
        Directory.CreateDirectory(srcPath);

        var csprojPath = Path.Combine(srcPath, "Test.csproj");
        File.WriteAllText(csprojPath, "<Project Sdk=\"Microsoft.NET.Sdk\"></Project>");

        try
        {
            var result = await validator.ValidateAsync(tempPath);

            Assert.That(result, Is.Not.Null);
            Assert.That(Path.IsPathFullyQualified(result), Is.True);
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }

    [Test]
    public void ValidateLocalSpecsPath_WithNullPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);

        Assert.Throws<ArgumentException>(() => validator.ValidateLocalSpecsPath(null!));
    }

    [Test]
    public void ValidateLocalSpecsPath_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);

        Assert.Throws<ArgumentException>(() => validator.ValidateLocalSpecsPath(string.Empty));
    }

    [Test]
    public void ValidateLocalSpecsPath_WithNonExistentDirectory_ThrowsDirectoryNotFoundException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        Assert.Throws<DirectoryNotFoundException>(() => validator.ValidateLocalSpecsPath(nonExistentPath));
    }

    [Test]
    public void ValidateLocalSpecsPath_WithDirectoryMissingTspConfig_ThrowsFileNotFoundException()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempPath);

        try
        {
            Assert.Throws<FileNotFoundException>(() => validator.ValidateLocalSpecsPath(tempPath));
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }

    [Test]
    public void ValidateLocalSpecsPath_WithValidDirectory_ReturnsAbsolutePath()
    {
        var loggerMock = new Mock<ILogger<ValidationService>>();
        var validator = new ValidationService(loggerMock.Object);
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempPath);
        File.WriteAllText(Path.Combine(tempPath, "tspconfig.yaml"), "emitter: test");

        try
        {
            var result = validator.ValidateLocalSpecsPath(tempPath);

            Assert.That(result, Is.Not.Null);
            Assert.That(Path.IsPathFullyQualified(result), Is.True);
        }
        finally
        {
            Directory.Delete(tempPath, true);
        }
    }
}
