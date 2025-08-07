// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Projects;

/// <summary>
/// ASp.NET Core extension methods for mapping a service implementation to a set of HTTP endpoints.
/// </summary>
public static class AzureProjectsExtensions
{
    /// <summary>
    /// Adds the project client to the DI container.
    /// </summary>
    /// <param name="builder"></param>
    public static ProjectClient AddProjectClient(this WebApplicationBuilder builder)
    {
        ProjectClient project = new ProjectClient();
        builder.Services.AddSingleton(project);
        return project;
    }

    /// <summary>
    /// Adds the project client to the DI container.
    /// </summary>
    /// <param name="builder"></param>
    public static OfxClient AddOfxClient(this WebApplicationBuilder builder)
    {
        OfxClient client = new();
        builder.Services.AddSingleton(client);
        return client;
    }

    /// <summary>
    /// Uploads a document to the storage service.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="multiPartFormData"></param>
    /// <returns></returns>
    public static async Task UploadFormAsync(this StorageServices storage, HttpRequest multiPartFormData)
    {
        IFormCollection form = await multiPartFormData.ReadFormAsync().ConfigureAwait(false);
        IFormFile? file = form.Files.GetFile("file");
        Stream? fileStram = file!.OpenReadStream();
        await storage.UploadAsync(fileStram, file.FileName, file.ContentType, overwrite: true).ConfigureAwait(false);
    }
}
