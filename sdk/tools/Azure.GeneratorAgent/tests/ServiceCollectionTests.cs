// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public void ServiceCollection_Should_RegisterLoggingServices()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddLogging();

        // Act
        var serviceProvider = services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

        // Assert
        Assert.That(loggerFactory, Is.Not.Null);
    }

    [Test]
    public void ServiceProvider_Should_CreateLoggerInstances()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddLogging();

        // Act
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILogger<ServiceCollectionTests>>();

        // Assert
        Assert.That(logger, Is.Not.Null);
    }

    [Test]
    public void AddApplicationServices_Should_RegisterConfiguration()
    {
        // Arrange
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();

        // Act
        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();
        var config = serviceProvider.GetRequiredService<IConfiguration>();

        // Assert
        Assert.That(config, Is.Not.Null);
        Assert.That(config["Workflow:MaxRetries"], Is.EqualTo("5"));
    }

    [Test]
    public void AddApplicationServices_Should_RegisterRootCommandFactory()
    {
        // Arrange
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        // Act
        services.AddApplicationServices(configuration);
        var serviceProvider = services.BuildServiceProvider();
        var commandFactory = serviceProvider.GetService<RootCommandFactory>();

        // Assert
        Assert.That(commandFactory, Is.Not.Null);
    }

    [Test]
    public void AddApplicationServices_Should_BeCallableWithoutErrors()
    {
        // Arrange
        var configuration = CreateTestConfiguration();
        var services = new ServiceCollection();
        services.AddLogging();

        // Act & Assert
        Assert.DoesNotThrow(() =>
        {
            services.AddApplicationServices(configuration);
            var serviceProvider = services.BuildServiceProvider();
        });
    }
}
