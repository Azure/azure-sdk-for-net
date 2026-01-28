// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.Identity;
using Npgsql;
using Microsoft.Azure.PostgreSQL.Auth;
using Microsoft.Extensions.Configuration;

namespace GettingStarted;

/// <summary>
/// This example enables Entra authentication before connecting to the database via NpgsqlConnection.
/// </summary>
public class CreateDbConnectionNpgsql
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("=== Getting Started with Azure Entra Authentication for PostgreSQL ===\n");

        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        // Read configuration values and build connection string once
        var server = configuration["Host"];
        var database = configuration["Database"] ?? "postgres";
        var port = configuration.GetValue<int>("Port", 5432);
        var connectionString = $"Host={server};Database={database};Port={port};SSL Mode=Require;";

        Console.WriteLine("--- Testing UseEntraAuthentication (sync) ---");
        await ExecuteQueriesWithEntraAuth(connectionString, useAsync: false);

        Console.WriteLine("\n--- Testing UseEntraAuthenticationAsync ---");
        await ExecuteQueriesWithEntraAuth(connectionString, useAsync: true);

        Console.WriteLine("\n=== Sample completed ===");
    }

    /// <summary>
    /// Show how to create a connection to the database with Entra authentication and execute some prompts.
    /// </summary>
    /// <param name="connectionString">The PostgreSQL connection string</param>
    /// <param name="useAsync">If true, uses UseEntraAuthenticationAsync; otherwise uses UseEntraAuthentication</param>
    private static async Task ExecuteQueriesWithEntraAuth(string connectionString, bool useAsync = false)
    {

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

        // Here, we use the appropriate extension method provided by NpgsqlDataSourceBuilderExtensions.cs
        // to enable Entra Authentication. This will handle username extraction and token refresh as needed.
        var credential = new DefaultAzureCredential();
        if (useAsync)
        {
            await dataSourceBuilder.UseEntraAuthenticationAsync(credential);
        }
        else
        {
            dataSourceBuilder.UseEntraAuthentication(credential);
        }

        using var dataSource = dataSourceBuilder.Build();
        await using var connection = await dataSource.OpenConnectionAsync();

        // Get PostgreSQL version
        using var cmd1 = new NpgsqlCommand("SELECT version()", connection);
        var version = await cmd1.ExecuteScalarAsync();
        Console.WriteLine($"PostgreSQL Version: {version}");
    }
}
