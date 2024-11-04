// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Threading.Tasks;
using Azure.Provisioning.CloudMachine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class TdkTests
{
    [Theory]
    [TestCase([new string[] { "-tsp" }])]
    public void BasicTsp(string[] args)
    {
        CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddEndpoints<IAssistantService>();
        });
    }
}

internal interface IAssistantService
{
    [HttpPut]
    Task UploadAsync(HttpRequest document);
    Task<string> SendAsync([FromQuery] string message);
}
