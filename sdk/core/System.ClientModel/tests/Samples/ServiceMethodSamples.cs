// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Maps;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class ServiceMethodSamples
{
    [Test]
    [Ignore("Used for README")]
    public async Task ClientResultTReadme()
    {
        // Create a client
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new(key!);

        #region Snippet:ReadmeClientResultT
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

        // Call a convenience method, which returns ClientResult<T>
        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);

        // Access the output model from the service response.
        IPAddressCountryPair value = result.Value;
        Console.WriteLine($"Country is {value.CountryRegion.IsoCode}.");
        #endregion

        #region Snippet:ReadmeGetRawResponse
        // Access the HTTP response details.
        PipelineResponse response = result.GetRawResponse();

        Console.WriteLine($"Response status code: '{response.Status}'.");
        Console.WriteLine("Response headers:");
        foreach (KeyValuePair<string, string> header in response.Headers)
        {
            Console.WriteLine($"Name: '{header.Key}', Value: '{header.Value}'.");
        }
        #endregion
    }

    [Test]
    [Ignore("Used for README")]
    public async Task ClientResultExceptionReadme()
    {
        // Create a client
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new(key!);
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

        #region Snippet:ClientResultExceptionReadme
        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);
        }
        // Handle exception with status code 404
        catch (ClientResultException e) when (e.Status == 404)
        {
            // Handle not found error
            Console.Error.WriteLine($"Error: Response failed with status code: '{e.Status}'");
        }
        #endregion
    }

    [Test]
    [Ignore("Used for README")]
    public async Task RequestOptionsReadme()
    {
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(key!);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        // CancellationToken used for snippet - doesn't need a real value.
        CancellationToken cancellationToken = CancellationToken.None;

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            #region Snippet:RequestOptionsReadme
            // Create RequestOptions instance.
            RequestOptions options = new();

            // Set the CancellationToken.
            options.CancellationToken = cancellationToken;

            // Add a header to the request.
            options.AddHeader("CustomHeader", "CustomHeaderValue");

            // Create an instance of a model that implements the IJsonModel<T> interface.
            CountryRegion region = new("US");

            // Create BinaryContent from the input model.
            BinaryContent content = BinaryContent.Create(region);

            // Call the protocol method, passing the content and options.
            ClientResult result = await client.AddCountryCodeAsync(content, options);
            #endregion
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    [Ignore("Used for README")]
    public async Task ServiceMethodsProtocolMethod()
    {
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(key!);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        // Dummy CancellationToken
        CancellationToken cancellationToken = CancellationToken.None;

        try
        {
#nullable disable
            #region Snippet:ServiceMethodsProtocolMethod
            // Create a BinaryData instance from a JSON string literal.
            BinaryData input = BinaryData.FromString("""
                {
                    "countryRegion": {
                        "isoCode": "US"
                    },
                }
                """);

            // Create a BinaryContent instance to set as the HTTP request content.
            BinaryContent requestContent = BinaryContent.Create(input);

            // Call the protocol method.
            ClientResult result = await client.AddCountryCodeAsync(requestContent);

            // Obtain the output response content from the returned ClientResult.
            BinaryData output = result.GetRawResponse().Content;

            using JsonDocument outputAsJson = JsonDocument.Parse(output.ToString());
            string isoCode = outputAsJson.RootElement
                .GetProperty("countryRegion")
                .GetProperty("isoCode")
                .GetString();

            Console.WriteLine($"Code for added country is '{isoCode}'.");
            #endregion
#nullable enable
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    [Ignore("Used for README")]
    public async Task ServiceMethodsBinaryContentAnonymous()
    {
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(key!);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        #region Snippet:ServiceMethodsBinaryContentAnonymous
        // Create a BinaryData instance from an anonymous object representing
        // the JSON the service expects for the service operation.
        BinaryData input = BinaryData.FromObjectAsJson(new
        {
            countryRegion = new
            {
                isoCode = "US"
            }
        });

        // Create the BinaryContent instance to pass to the protocol method.
        BinaryContent content = BinaryContent.Create(input);

        // Call the protocol method.
        ClientResult result = await client.AddCountryCodeAsync(content);
        #endregion
    }

    [Test]
    [Ignore("Used for README")]
    public async Task ServiceMethodsBinaryContentStream()
    {
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(key!);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        #region Snippet:ServiceMethodsBinaryContentStream
        // Create a BinaryData instance from a file stream
        FileStream stream = File.OpenRead(@"c:\path\to\file.txt");
        BinaryData input = BinaryData.FromStream(stream);

        // Create the BinaryContent instance to pass to the protocol method.
        BinaryContent content = BinaryContent.Create(input);

        // Call the protocol method.
        ClientResult result = await client.AddCountryCodeAsync(content);
        #endregion
    }

    [Test]
    [Ignore("Used for README")]
    public async Task ServiceMethodsBinaryContentModel()
    {
        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(key!);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        #region Snippet:ServiceMethodsBinaryContentModel
        // Create an instance of a model that implements the IJsonModel<T> interface.
        CountryRegion region = new("US");

        // Create BinaryContent from the input model.
        BinaryContent content = BinaryContent.Create(region);

        // Call the protocol method, passing the content and options.
        ClientResult result = await client.AddCountryCodeAsync(content);
        #endregion
    }
}
