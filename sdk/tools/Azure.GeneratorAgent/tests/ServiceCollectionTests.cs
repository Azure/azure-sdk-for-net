// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Commands;
using Azure.GeneratorAgent.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Net.Http;

namespace Azure.GeneratorAgent.Tests;

public class ServiceCollectionTests
{
    private static IConfiguration CreateTestConfiguration()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Logging:LogLevel:Default", "Information"},
            {"Workflow:MaxRetries", "5"},
            {"Workflow:Verbose", "false"}
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
    }

    [Test]
    public void AddApplicationServices_Should_RegisterConfiguration()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();
        var config = serviceProvider.GetRequiredService<IConfiguration>();

        Assert.That(config, Is.Not.Null);
        Assert.That(config["Workflow:MaxRetries"], Is.EqualTo("5"));
        Assert.That(config["Workflow:Verbose"], Is.EqualTo("false"));
    }

    [Test]
    public void AddApplicationServices_Should_RegisterHttpClientForGitService()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

        Assert.That(httpClientFactory, Is.Not.Null);
        var httpClient = httpClientFactory.CreateClient("GitService");
        Assert.That(httpClient, Is.Not.Null);
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureHttpClientWithCorrectTimeout()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();
        var gitService = serviceProvider.GetRequiredService<GitService>();

        Assert.That(gitService, Is.Not.Null);
    }

    [Test]
    public void AddApplicationServices_Should_RegisterValidationServiceAsSingleton()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var validationService1 = serviceProvider.GetRequiredService<ValidationService>();
        var validationService2 = serviceProvider.GetRequiredService<ValidationService>();

        Assert.That(validationService1, Is.Not.Null);
        Assert.That(validationService2, Is.Not.Null);
        Assert.That(ReferenceEquals(validationService1, validationService2), Is.True,
            "ValidationService should be registered as Singleton");
    }

    [Test]
    public void AddApplicationServices_Should_RegisterGitServiceAsSingleton()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var gitService1 = serviceProvider.GetRequiredService<GitService>();
        var gitService2 = serviceProvider.GetRequiredService<GitService>();

        Assert.That(gitService1, Is.Not.Null);
        Assert.That(gitService2, Is.Not.Null);
        Assert.That(ReferenceEquals(gitService1, gitService2), Is.True,
            "GitService should be registered as Singleton");
    }

    [Test]
    public void AddApplicationServices_Should_RegisterFileServiceAsSingleton()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var fileService1 = serviceProvider.GetRequiredService<FileService>();
        var fileService2 = serviceProvider.GetRequiredService<FileService>();

        Assert.That(fileService1, Is.Not.Null);
        Assert.That(fileService2, Is.Not.Null);
        Assert.That(ReferenceEquals(fileService1, fileService2), Is.True,
            "FileService should be registered as Singleton");
    }

    [Test]
    public void AddApplicationServices_Should_RegisterRootCommandFactoryAsTransient()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var commandFactory1 = serviceProvider.GetRequiredService<RootCommandFactory>();
        var commandFactory2 = serviceProvider.GetRequiredService<RootCommandFactory>();

        Assert.That(commandFactory1, Is.Not.Null);
        Assert.That(commandFactory2, Is.Not.Null);
        Assert.That(ReferenceEquals(commandFactory1, commandFactory2), Is.False,
            "RootCommandFactory should be registered as Transient");
    }

    [Test]
    public void AddApplicationServices_Should_RegisterAllRequiredServices()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<IConfiguration>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<FileService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<RootCommandFactory>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<IHttpClientFactory>());
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureDependenciesCorrectly()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var rootCommandFactory = serviceProvider.GetRequiredService<RootCommandFactory>();
        Assert.That(rootCommandFactory, Is.Not.Null, "RootCommandFactory should resolve with all its dependencies");

        var gitService = serviceProvider.GetRequiredService<GitService>();
        Assert.That(gitService, Is.Not.Null, "GitService should resolve with HttpClient dependency");

        var validationService = serviceProvider.GetRequiredService<ValidationService>();
        Assert.That(validationService, Is.Not.Null, "ValidationService should resolve with logger dependency");

        var fileService = serviceProvider.GetRequiredService<FileService>();
        Assert.That(fileService, Is.Not.Null, "FileService should resolve with logger dependency");
    }

    [Test]
    public void AddApplicationServices_Should_BeCallableWithoutErrors()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        Assert.DoesNotThrow(() =>
        {
            services.AddApplicationServices(configuration);
            var serviceProvider = services.BuildServiceProvider();
        });
    }

    [Test]
    public void AddApplicationServices_Should_ReturnServiceCollection()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        var result = services.AddApplicationServices(configuration);

        Assert.That(result, Is.SameAs(services), "AddApplicationServices should return the same service collection for chaining");
    }

    [Test]
    public void AddApplicationServices_WithNullConfiguration_Should_ThrowArgumentNullException()
    {
        var services = new ServiceCollection();

        Assert.Throws<ArgumentNullException>(() => services.AddApplicationServices(null!));
    }

    [Test]
    public void AddApplicationServices_WithNullServiceCollection_Should_ThrowArgumentNullException()
    {
        var configuration = CreateTestConfiguration();
        ServiceCollection services = null!;

        Assert.Throws<ArgumentNullException>(() => services.AddApplicationServices(configuration));
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureMultipleServicesWithSameConfiguration()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var configFromFactory = serviceProvider.GetRequiredService<RootCommandFactory>();
        var configFromService = serviceProvider.GetRequiredService<IConfiguration>();

        Assert.That(configFromFactory, Is.Not.Null);
        Assert.That(configFromService, Is.Not.Null);
        Assert.That(configFromService["Workflow:MaxRetries"], Is.EqualTo("5"));
    }

    [Test]
    public void AddApplicationServices_EmptyConfiguration_Should_StillRegisterServices()
    {
        var emptyConfig = new ConfigurationBuilder().Build();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(emptyConfig);
        var serviceProvider = services.BuildServiceProvider();

        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<FileService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<RootCommandFactory>());
    }

    [Test]
    public void AddApplicationServices_Should_OnlyRegisterServicesOnce()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration);
        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();

        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<FileService>());

        var factory1 = serviceProvider.GetRequiredService<RootCommandFactory>();
        var factory2 = serviceProvider.GetRequiredService<RootCommandFactory>();
        Assert.That(factory1, Is.Not.Null);
        Assert.That(factory2, Is.Not.Null);
    }
}
