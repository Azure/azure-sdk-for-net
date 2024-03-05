// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
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
        #region Snippet:ClientResultTReadme
        // Create a client
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new(key);
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

        // Call a service method, which returns ClientResult<T>
        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);

        // ClientResult<T> has two members:
        //
        // (1) A Value property to access the strongly-typed output
        IPAddressCountryPair value = result.Value;
        Console.WriteLine($"Country is {value.CountryRegion.IsoCode}.");

        // (2) A GetRawResponse method for accessing the details of the HTTP response
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
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new(key);
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
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        // CancellationToken used for snippet - doesn't need a real value.
        CancellationToken cancellationToken = CancellationToken.None;

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            #region Snippet:RequestOptionsReadme
            // Create RequestOptions instance
            RequestOptions options = new();

            // Set CancellationToken
            options.CancellationToken = cancellationToken;

            // Add a header to the request
            options.AddHeader("CustomHeader", "CustomHeaderValue");

            // Call protocol method to pass RequestOptions
            ClientResult output = await client.GetCountryCodeAsync(ipAddress.ToString(), options);
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
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        // Dummy CancellationToken
        CancellationToken cancellationToken = CancellationToken.None;

        try
        {
#nullable disable
            #region Snippet:ServiceMethodsProtocolMethod

            // Create a BinaryData instance from a JSON string literal
            BinaryData input = BinaryData.FromString("""   
                {
                    "countryRegion": {
                        "isoCode": "US"
                    },
                }
                """);

            // Call the protocol method
            ClientResult result = await client.AddCountryCodeAsync(BinaryContent.Create(input));

            // Obtain the output response content from the returned ClientResult
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
}
