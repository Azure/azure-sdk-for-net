// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

public class FileServiceTests
{
    [Test]
    public void ReadDirectoryFieldAsync_WithNullPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.ReadDirectoryFieldAsync(null!));
        Assert.That(ex!.ParamName, Is.EqualTo("tspLocationPath"));
        Assert.That(ex.Message, Does.Contain("tsp-location.yaml path is required but was not provided"));
    }

    [Test]
    public void ReadDirectoryFieldAsync_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.ReadDirectoryFieldAsync(string.Empty));
        Assert.That(ex!.ParamName, Is.EqualTo("tspLocationPath"));
        Assert.That(ex.Message, Does.Contain("tsp-location.yaml path is required but was not provided"));
    }

    [Test]
    public void ReadDirectoryFieldAsync_WithNonExistentFile_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var nonExistentFile = Path.Combine(testDirectory, "nonexistent.yaml");

        try
        {
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
                fileService.ReadDirectoryFieldAsync(nonExistentFile));
            Assert.That(ex!.Message, Does.Contain($"Failed to read tsp-location.yaml at {nonExistentFile}"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithValidYamlContainingDirectoryField_ReturnsDirectoryValue()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                # TypeSpec Configuration File
                directory: ./src/service
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithValidYamlMissingDirectoryField_ReturnsNull()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                # TypeSpec Configuration File
                commit: abcd1234
                otherField: someValue
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.Null);
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithQuotedDirectoryValue_RemovesQuotes()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: "./src/service"
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithSingleQuotedDirectoryValue_RemovesQuotes()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: './src/service'
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithEmptyQuotes_ReturnsEmptyString()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: ""
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo(string.Empty));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithIndentedDirectoryField_ReturnsValue()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                # TypeSpec Configuration File
                  directory: ./src/service
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithMultipleLines_ReturnsFirstMatch()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                # This should not match: directory: wrong
                directory: ./src/service
                # directory: ./another/path (comment)
                otherField: value
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadDirectoryFieldAsync(yamlFile);

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadDirectoryFieldAsync_WithCancellationToken_CanBeCancelled()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = "directory: ./src/service";
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            using var cts = new CancellationTokenSource();
            cts.Cancel();

            var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
                fileService.ReadDirectoryFieldAsync(yamlFile, cts.Token));

            Assert.That(ex!.Message, Does.Contain("A task was canceled"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public void WriteFieldAsync_WithNullPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(null!, "field", "value"));
        Assert.That(ex!.ParamName, Is.EqualTo("tspLocationPath"));
        Assert.That(ex.Message, Does.Contain("tsp-location.yaml path is required but was not provided"));
    }

    [Test]
    public void WriteFieldAsync_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(string.Empty, "field", "value"));
        Assert.That(ex!.ParamName, Is.EqualTo("tspLocationPath"));
    }

    [Test]
    public void WriteFieldAsync_WithNullField_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var yamlFile = Path.Combine(testDirectory, "test.yaml");

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(yamlFile, null!, "value"));
        Assert.That(ex!.ParamName, Is.EqualTo("field"));
        Assert.That(ex.Message, Does.Contain("Field name is required but was not provided"));
    }

    [Test]
    public void WriteFieldAsync_WithEmptyField_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var yamlFile = Path.Combine(testDirectory, "test.yaml");

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(yamlFile, string.Empty, "value"));
        Assert.That(ex!.ParamName, Is.EqualTo("field"));
    }

    [Test]
    public void WriteFieldAsync_WithNullValue_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var yamlFile = Path.Combine(testDirectory, "test.yaml");

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(yamlFile, "field", null!));
        Assert.That(ex!.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("Field value is required but was not provided"));
    }

    [Test]
    public void WriteFieldAsync_WithEmptyValue_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var yamlFile = Path.Combine(testDirectory, "test.yaml");

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(yamlFile, "field", string.Empty));
        Assert.That(ex!.ParamName, Is.EqualTo("value"));
    }

    [Test]
    public async Task WriteFieldAsync_WithExistingFieldInFile_UpdatesField()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: ./old/path
                commit: abcd1234
                otherField: value
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            await fileService.WriteFieldAsync(yamlFile, "directory", "./new/path");

            var updatedContent = await File.ReadAllTextAsync(yamlFile);
            Assert.That(updatedContent, Does.Contain("directory: ./new/path"));
            Assert.That(updatedContent, Does.Contain("commit: abcd1234"));
            Assert.That(updatedContent, Does.Contain("otherField: value"));
            Assert.That(updatedContent, Does.Not.Contain("./old/path"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task WriteFieldAsync_WithNewFieldInExistingFile_AddsField()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: ./src/service
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            await fileService.WriteFieldAsync(yamlFile, "newField", "newValue");

            var updatedContent = await File.ReadAllTextAsync(yamlFile);
            Assert.That(updatedContent, Does.Contain("directory: ./src/service"));
            Assert.That(updatedContent, Does.Contain("commit: abcd1234"));
            Assert.That(updatedContent, Does.Contain("newField: newValue"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task WriteFieldAsync_WithIndentedExistingField_UpdatesField()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                # Configuration
                  directory: ./old/path
                commit: abcd1234
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            await fileService.WriteFieldAsync(yamlFile, "directory", "./new/path");

            var updatedContent = await File.ReadAllTextAsync(yamlFile);
            Assert.That(updatedContent, Does.Contain("directory: ./new/path"));
            Assert.That(updatedContent, Does.Not.Contain("./old/path"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public void WriteFieldAsync_WithNonExistentFile_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var nonExistentFile = Path.Combine(testDirectory, "nonexistent.yaml");

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            fileService.WriteFieldAsync(nonExistentFile, "field", "value"));
        Assert.That(ex!.Message, Does.Contain($"Failed to write tsp-location.yaml at {nonExistentFile}"));
    }

    [Test]
    public async Task WriteFieldAsync_WithCancellationToken_CanBeCancelled()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = "directory: ./src/service";
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            using var cts = new CancellationTokenSource();
            cts.Cancel();

            var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
                fileService.WriteFieldAsync(yamlFile, "field", "value", cts.Token));

            Assert.That(ex!.Message, Does.Contain("A task was canceled"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }
}
