// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClientModel.ReferenceClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace System.ClientModel.Tests.Options;

public class LoggingOptionsTests
{
    [Test]
    public void CanDisableLoggingFromConfigurationSettings()
    {
    }

    [Test]
    public void CanAddAllowedHeadersFromConfigurationSettings()
    {
    }

    [Test]
    public void CanAddToClientAuthorAllowedHeadersListFromConfigurationSettings()
    {
    }

    [Test]
    public void CanConfigureCustomLoggingPolicyFromConfigurationSettings()
    {
    }
}
