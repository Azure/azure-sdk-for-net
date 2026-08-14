// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class ValidateTspConfigToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"ValidateTspConfigTests_{Guid.NewGuid():N}");
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, true);
        }
    }

    [Test]
    public void ValidateInProcess_ValidConfig_ReturnsValid()
    {
        var configPath = Path.Combine(_tempDir, "tspconfig.yaml");
        File.WriteAllText(configPath, """
            options:
              "@azure-typespec/http-client-csharp":
                emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
                namespace: Azure.Test.Service
                model-namespace: false
            """);

        var result = ValidateTspConfigTool.ValidateInProcess(configPath, "Azure.Test.Service");

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void ValidateInProcess_MissingEmitter_ReturnsInvalid()
    {
        var configPath = Path.Combine(_tempDir, "tspconfig.yaml");
        File.WriteAllText(configPath, """
            options:
              "@azure-tools/typespec-autorest":
                output-file: openapi.json
            """);

        var result = ValidateTspConfigTool.ValidateInProcess(configPath, "Azure.Test.Service");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Reason, Does.Contain("@azure-typespec/http-client-csharp"));
        });
    }

    [Test]
    public void ValidateInProcess_DifferentNamespace_StillValid()
    {
        var configPath = Path.Combine(_tempDir, "tspconfig.yaml");
        File.WriteAllText(configPath, """
            options:
              "@azure-typespec/http-client-csharp":
                emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
                namespace: Azure.Wrong.Namespace
                model-namespace: false
            """);

        var result = ValidateTspConfigTool.ValidateInProcess(configPath, "Azure.Test.Service");

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void ValidateInProcess_FileNotFound_ReturnsInvalid()
    {
        var result = ValidateTspConfigTool.ValidateInProcess(
            Path.Combine(_tempDir, "nonexistent.yaml"), "Azure.Test.Service");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Reason, Does.Contain("not found"));
        });
    }

    [Test]
    public void FixTspConfig_CreatesCorrectConfig()
    {
        var configPath = Path.Combine(_tempDir, "tspconfig.yaml");
        File.WriteAllText(configPath, """
            options:
              "@azure-tools/typespec-autorest":
                output-file: openapi.json
            """);

        var (success, error) = ValidateTspConfigTool.FixTspConfig(configPath, "Azure.Test.Service");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(error, Is.Null);
        });

        var content = File.ReadAllText(configPath);
        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("@azure-typespec/http-client-csharp"));
            Assert.That(content, Does.Contain("Azure.Test.Service"));
        });
    }

    [Test]
    public void FixTspConfig_FileNotFound_ReturnsFalse()
    {
        var (success, error) = ValidateTspConfigTool.FixTspConfig(
            Path.Combine(_tempDir, "nonexistent.yaml"), "Azure.Test.Service");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Is.Not.Null);
        });
    }

    [Test]
    public void ValidateInProcess_MissingModelNamespace_ReturnsInvalid()
    {
        var configPath = Path.Combine(_tempDir, "tspconfig.yaml");
        File.WriteAllText(configPath, """
            options:
              "@azure-typespec/http-client-csharp":
                emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
                namespace: Azure.Test.Service
            """);

        var result = ValidateTspConfigTool.ValidateInProcess(configPath, "Azure.Test.Service");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Reason, Does.Contain("model-namespace"));
        });
    }
}
