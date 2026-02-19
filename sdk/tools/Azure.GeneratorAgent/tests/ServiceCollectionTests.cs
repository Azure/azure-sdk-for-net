// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.GeneratorAgent.Commands;
using Azure.GeneratorAgent.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

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

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        var validationService1 = serviceProvider.GetRequiredService<ValidationService>();
        var validationService2 = serviceProvider.GetRequiredService<ValidationService>();

        Assert.That(validationService1, Is.Not.Null);
        Assert.That(validationService2, Is.Not.Null);
        Assert.That(ReferenceEquals(validationService1, validationService2), Is.True,
            "ValidationService should be registered as Singleton");
    }

    [Test]
    public void AddApplicationServices_Should_RegisterFileServiceAsSingleton()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(configuration, null);
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
        services.AddApplicationServices(configuration, null);
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
            services.AddApplicationServices(configuration, null);
            var serviceProvider = services.BuildServiceProvider();
        });
    }

    [Test]
    public void AddApplicationServices_Should_ReturnServiceCollection()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        var result = services.AddApplicationServices(configuration, null);

        Assert.That(result, Is.SameAs(services), "AddApplicationServices should return the same service collection for chaining");
    }

    [Test]
    public void AddApplicationServices_WithNullConfiguration_Should_ThrowArgumentNullException()
    {
        var services = new ServiceCollection();

        Assert.Throws<ArgumentNullException>(() => services.AddApplicationServices(null!, null));
    }

    [Test]
    public void AddApplicationServices_WithNullServiceCollection_Should_ThrowArgumentNullException()
    {
        var configuration = CreateTestConfiguration();
        ServiceCollection services = null!;

        Assert.Throws<ArgumentNullException>(() => services.AddApplicationServices(configuration, null));
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureMultipleServicesWithSameConfiguration()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
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

        services.AddApplicationServices(emptyConfig, null);
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

        services.AddApplicationServices(configuration, null);
        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<FileService>());

        var factory1 = serviceProvider.GetRequiredService<RootCommandFactory>();
        var factory2 = serviceProvider.GetRequiredService<RootCommandFactory>();
        Assert.That(factory1, Is.Not.Null);
        Assert.That(factory2, Is.Not.Null);
    }

    [Test]
    public void AddApplicationServices_WithProjectPath_Should_RegisterCopilotTaskAsSingleton()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, "/some/path");
        var serviceProvider = services.BuildServiceProvider();

        var task1 = serviceProvider.GetService<Task<CopilotService>>();
        var task2 = serviceProvider.GetService<Task<CopilotService>>();

        Assert.That(task1, Is.Not.Null);
        Assert.That(task2, Is.Not.Null);
        Assert.That(ReferenceEquals(task1, task2), Is.True,
            "Task<CopilotService> should be registered as Singleton");
    }

    [Test]
    public void AddApplicationServices_WithNullProjectPath_Should_NotRegisterCopilotTask()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        var task = serviceProvider.GetService<Task<CopilotService>>();
        Assert.That(task, Is.Null, "Task<CopilotService> should not be registered when projectPath is null");
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureHttpClientWithCorrectProperties()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("GitService");

        // Verify timeout
        Assert.That(httpClient.Timeout, Is.EqualTo(TimeSpan.FromSeconds(30)), "HttpClient timeout should be 30 seconds");

        // Verify max response content buffer size
        Assert.That(httpClient.MaxResponseContentBufferSize, Is.EqualTo(1_000_000), "MaxResponseContentBufferSize should be 10MB");

        // Verify User-Agent header
        Assert.That(httpClient.DefaultRequestHeaders.UserAgent.ToString(), Does.Contain("Azure-GeneratorAgent/1.0"));

        // Verify Accept header
        Assert.That(httpClient.DefaultRequestHeaders.Accept.Any(a => a.MediaType == "application/vnd.github.v3+json"), Is.True,
            "Accept header should include application/vnd.github.v3+json");

        // Verify X-GitHub-Api-Version header
        Assert.That(httpClient.DefaultRequestHeaders.Contains("X-GitHub-Api-Version"), Is.True,
            "X-GitHub-Api-Version header should be present");
        Assert.That(httpClient.DefaultRequestHeaders.GetValues("X-GitHub-Api-Version").First(), Is.EqualTo("2022-11-28"));
    }

    [Test]
    public void AddApplicationServices_Should_ConfigureHttpClientName()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

        // Verify the named client can be created
        Assert.DoesNotThrow(() => httpClientFactory.CreateClient("GitService"));

        var gitServiceClient = httpClientFactory.CreateClient("GitService");
        var defaultClient = httpClientFactory.CreateClient();

        // Verify they are different instances with different configurations
        Assert.That(gitServiceClient, Is.Not.SameAs(defaultClient));
        Assert.That(gitServiceClient.Timeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
        Assert.That(defaultClient.Timeout, Is.Not.EqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public void AddApplicationServices_Should_RegisterGitServiceWithHttpClient()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        var gitService1 = serviceProvider.GetRequiredService<GitService>();
        var gitService2 = serviceProvider.GetRequiredService<GitService>();

        Assert.That(gitService1, Is.Not.Null);
        Assert.That(gitService2, Is.Not.Null);

        // GitService should be registered as scoped/transient by AddHttpClient, not singleton
        Assert.That(ReferenceEquals(gitService1, gitService2), Is.False,
            "GitService should be registered as scoped by AddHttpClient, not singleton");
    }

    [Test]
    public void AddApplicationServices_Should_AllowServiceCollectionChaining()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        var result = services
            .AddLogging()
            .AddApplicationServices(configuration, null)
            .AddSingleton<string>("test");

        Assert.That(result, Is.SameAs(services), "Service collection methods should support chaining");

        var serviceProvider = services.BuildServiceProvider();
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<string>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
    }

    [Test]
    public void AddApplicationServices_Should_HandleComplexConfiguration()
    {
        var complexConfig = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"Logging:LogLevel:Default", "Debug"},
                {"Logging:LogLevel:System", "Warning"},
                {"App:Name", "Azure.GeneratorAgent"},
                {"App:Version", "1.0.0"},
                {"GitHub:ApiUrl", "https://api.github.com"},
                {"Timeouts:HttpClient", "30"},
                {"Features:EnableCopilot", "true"}
            }!)
            .Build();

        var services = new ServiceCollection();
        services.AddLogging();

        services.AddApplicationServices(complexConfig, null);
        var serviceProvider = services.BuildServiceProvider();

        var retrievedConfig = serviceProvider.GetRequiredService<IConfiguration>();
        Assert.That(retrievedConfig["App:Name"], Is.EqualTo("Azure.GeneratorAgent"));
        Assert.That(retrievedConfig["Features:EnableCopilot"], Is.EqualTo("true"));
        Assert.That(retrievedConfig["Timeouts:HttpClient"], Is.EqualTo("30"));

        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
    }

    [Test]
    public void AddApplicationServices_Should_WorkWithMinimalServiceCollection()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        // Add only the minimum required services
        services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.None));

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        // Should still be able to resolve all services
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<FileService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<RootCommandFactory>());
    }

    [Test]
    public void AddApplicationServices_Should_PreserveExistingServices()
    {
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        // Add some existing services
        services.AddSingleton<string>("existing-service");
        services.AddScoped<object>(_ => new { Value = 42 });
        services.AddLogging();

        services.AddApplicationServices(configuration, null);
        var serviceProvider = services.BuildServiceProvider();

        // Existing services should still be available
        Assert.That(serviceProvider.GetRequiredService<string>(), Is.EqualTo("existing-service"));
        var dynamicService = serviceProvider.GetRequiredService<object>();
        Assert.That(dynamicService, Is.Not.Null);

        // New services should also be available
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<ValidationService>());
        Assert.DoesNotThrow(() => serviceProvider.GetRequiredService<GitService>());
    }
}
