// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace System.ClientModel.Tests.Options;

public class ConfigurePipelineTests
{
    [Test]
    public void CanSetClientEndpointFromConfigurationSettings()
    {
    }

    [Test]
    public void CanSetClientCredentialFromConfigurationSettings()
    {
    }

    [Test]
    public void CanRollCredentialFromConfigurationSettings()
    {
    }

    [Test]
    public void CanInjectCustomPolicyUsingDependencyInjectionExtensions()
    {
    }

    [Test]
    public void CanManuallySpecifyConfigurationPathViaExtensions()
    {
    }

    [Test]
    public void CanRegisterAndUseDerivedLoggingPolicyType()
    {
    }

    [Test]
    public void CanInjectCustomHttpClient()
    {
    }

    [Test]
    public void CanRegisterClientsAsKeyedServices()
    {
    }
}
