// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Entry point for the AzureSql ASP.NET Core scenario project.
/// </summary>
public partial class Program
{
    /// <summary>
    /// Starts the AzureSql ASP.NET Core scenario project.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiVersioning(options =>
        {
            options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
            options.AssumeDefaultVersionWhenUnspecified = false;
            options.ReportApiVersions = true;
        })
        .AddMvc();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
