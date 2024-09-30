// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Net.Http;
using ClientModel.ReferenceClients;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class LoggingOptionsTests
{
    [Test]
    public void CanUseHttpClientLoggingInsteadOfScmLogging()
    {
        ServiceCollection services = new();

        // see https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory
        services.AddHttpClient();

        // see https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.httpclientloggingservicecollectionextensions.addextendedhttpclientlogging?view=net-8.0
        //services.AddExtendedHttpClientLogging();

        services.AddOptions<RequestResponseClientOptions>();

        services.AddSingleton<RequestResponseClient>(serviceProvider =>
        {
            HttpClient httpClient = serviceProvider.GetRequiredService<HttpClient>();
            RequestResponseClientOptions options = serviceProvider.GetRequiredService<RequestResponseClientOptions>();
            options.Diagnostics.EnableHttpLogging = false;
            options.Transport = new HttpClientPipelineTransport(httpClient);
            return new RequestResponseClient(options);
        });
    }
}
