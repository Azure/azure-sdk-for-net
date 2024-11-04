// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.TypeSpec;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class TdkTests
{
    [Test]
    public void GenerateIAssistantService()
    {
        MemoryStream stream = new();
        TypeSpecWriter.WriteServer<IAssistantService>(stream);
        stream.Position = 0;

        BinaryData data = BinaryData.FromStream(stream);
        Assert.AreEqual(IAssistantServiceTsp, data.ToString());
    }

    private static string IAssistantServiceTsp =
    """
    import "@typespec/http";
    import "@typespec/rest";
    import "@azure-tools/typespec-client-generator-core";

    @service({
      title: "AssistantService",
    })

    namespace Azure.CloudMachine.Tests;

    using TypeSpec.Http;
    using TypeSpec.Rest;
    using Azure.ClientGenerator.Core;

    @client interface AssistantServiceClient {
      @put @route("upload") Upload(@header contentType: "application/octet-stream", @body document: bytes) : {
        @statusCode statusCode: 200;
        @body response : void;
      };
      @get @route("send") Send(@query message: string) : {
        @statusCode statusCode: 200;
        @body response : string;
      };
    }


    """;
}

internal interface IAssistantService
{
    [HttpPut]
    Task UploadAsync(HttpRequest document);
    Task<string> SendAsync([FromQuery] string message);
}
