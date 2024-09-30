// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using ClientModel.ReferenceClients;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace System.ClientModel.Tests.Options;

public class LoggingOptionsTests
{
    [Test]
    public void CanUseHttpClientLoggingInsteadOfScmLogging()
    {
        ServiceCollection services = new();

        // see https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory
        services.AddHttpClient();

        HttpClient httpClient = new HttpClient();

        RequestResponseClient client = new();
    }
}
