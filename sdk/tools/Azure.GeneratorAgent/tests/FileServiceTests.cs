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
    public void ReadFieldAsync_DirectoryField_WithNullPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.ReadFieldAsync(null!, "directory"));
        Assert.That(ex!.ParamName, Is.EqualTo("yamlFilePath"));
    }

    [Test]
    public void ReadFieldAsync_DirectoryField_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.ReadFieldAsync(string.Empty, "directory"));
        Assert.That(ex!.ParamName, Is.EqualTo("yamlFilePath"));
    }

    [Test]
    public void ReadFieldAsync_DirectoryField_WithNonExistentFile_ThrowsInvalidOperationException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var nonExistentFile = Path.Combine(testDirectory, "nonexistent.yaml");

        try
        {
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
                fileService.ReadFieldAsync(nonExistentFile, "directory"));
            Assert.That(ex!.Message, Does.Contain($"Failed to read YAML file at {nonExistentFile}"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithValidYamlContainingDirectoryField_ReturnsDirectoryValue()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithValidYamlMissingDirectoryField_ReturnsNull()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.Null);
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithQuotedDirectoryValue_RemovesQuotes()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithSingleQuotedDirectoryValue_RemovesQuotes()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithEmptyQuotes_ReturnsEmptyString()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo(string.Empty));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithIndentedDirectoryField_ReturnsValue()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithMultipleLines_ReturnsFirstMatch()
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

            var result = await fileService.ReadFieldAsync(yamlFile, "directory");

            Assert.That(result, Is.EqualTo("./src/service"));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_DirectoryField_WithCancellationToken_CanBeCancelled()
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

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                fileService.ReadFieldAsync(yamlFile, "directory", cts.Token));
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
        Assert.That(ex!.ParamName, Is.EqualTo("yamlFilePath"));
        Assert.That(ex.Message, Does.Contain("YAML file path is required but was not provided"));
    }

    [Test]
    public void WriteFieldAsync_WithEmptyPath_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.WriteFieldAsync(string.Empty, "field", "value"));
        Assert.That(ex!.ParamName, Is.EqualTo("yamlFilePath"));
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
        Assert.That(ex!.Message, Does.Contain($"Failed to write YAML file at {nonExistentFile}"));
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

            Assert.ThrowsAsync<TaskCanceledException>(() =>
                fileService.WriteFieldAsync(yamlFile, "field", "value", cts.Token));
        }
        finally
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_WithCommitField_ReturnsCommitValue()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: ./src/service
                commit: abc123def456
                emitterPackageJsonPath: eng/emitter.json
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadFieldAsync(yamlFile, "commit");

            Assert.That(result, Is.EqualTo("abc123def456"));
        }
        finally
        {
            Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public async Task ReadFieldAsync_WithMissingField_ReturnsNull()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                directory: ./src/service
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadFieldAsync(yamlFile, "commit");

            Assert.That(result, Is.Null);
        }
        finally
        {
            Directory.Delete(testDirectory, true);
        }
    }

    [Test]
    public void ReadFieldAsync_WithNullFieldName_ThrowsArgumentException()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);

        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            fileService.ReadFieldAsync("somefile.yaml", null!));
        Assert.That(ex!.ParamName, Is.EqualTo("fieldName"));
    }

    [Test]
    public async Task ReadFieldAsync_WithQuotedValue_RemovesQuotes()
    {
        var loggerMock = new Mock<ILogger<FileService>>();
        var fileService = new FileService(loggerMock.Object);
        var testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDirectory);

        try
        {
            var yamlContent = """
                commit: "abc123def456"
                """;
            var yamlFile = Path.Combine(testDirectory, "tsp-location.yaml");
            await File.WriteAllTextAsync(yamlFile, yamlContent);

            var result = await fileService.ReadFieldAsync(yamlFile, "commit");

            Assert.That(result, Is.EqualTo("abc123def456"));
        }
        finally
        {
            Directory.Delete(testDirectory, true);
        }
    }
}
