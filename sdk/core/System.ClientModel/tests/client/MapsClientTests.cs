// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Maps;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace System.ClientModel.Tests;

public class MapsClientTests
{
    // This is a "TestSupportProject", so these tests will never be run as part of CIs.
    // It's here now for quick manual validation of client functionality, but we can revisit
    // this story going forward.
    [Test]
    public void TestClientSync()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        KeyCredential credential = new KeyCredential(key);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            OutputMessage<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientRequestException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    #region Options Tests

    [Test]
    public void ChangeServiceVersion()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        KeyCredential credential = new KeyCredential(key);

        // Service version is available on client subtype of ServiceClientOptions
        MapsClientOptions options = new MapsClientOptions(MapsClientOptions.ServiceVersion.V1);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            OutputMessage<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientRequestException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void SetNetworkTimeout()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        KeyCredential credential = new KeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        options.NetworkTimeout = TimeSpan.FromSeconds(2);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            OutputMessage<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientRequestException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void AddCustomPolicy_ClientScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        KeyCredential credential = new KeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        CustomPolicy customPolicy = new CustomPolicy();
        options.AddPolicy(customPolicy, PipelinePosition.PerCall);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            OutputMessage<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.IsTrue(customPolicy.ProcessedMessage);
        }
        catch (ClientRequestException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void OverrideTransport_ClientScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        KeyCredential credential = new KeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        options.Transport = new CustomTransport();

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            OutputMessage<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            PipelineResponse reponse = output.GetRawResponse();

            Assert.AreEqual("CustomTransportResponse", reponse.ReasonPhrase);
        }
        catch (ClientRequestException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    #endregion

    #region Helpers
    public class CustomPolicy : PipelinePolicy
    {
        public bool ProcessedMessage { get; private set; }

        public CustomPolicy() { }

        public override void Process(PipelineMessage message, PipelineProcessor pipeline)
        {
            pipeline.ProcessNext();
            ProcessedMessage = true;
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        {
            await pipeline.ProcessNextAsync().ConfigureAwait(false);
            ProcessedMessage = true;
        }
    }

    public class CustomTransport : PipelineTransport
    {
        protected override PipelineMessage CreateMessageCore()
        {
            CustomTransportRequest request = new CustomTransportRequest();
            CustomTransportMessage message = new CustomTransportMessage(request);
            return message;
        }

        protected override void ProcessCore(PipelineMessage message)
        {
            if (message is CustomTransportMessage customMessage)
            {
                CustomTransportResponse reponse = new CustomTransportResponse();
                customMessage.SetResponse(reponse);
            }
        }

        protected override ValueTask ProcessCoreAsync(PipelineMessage message)
        {
            if (message is CustomTransportMessage customMessage)
            {
                CustomTransportResponse reponse = new CustomTransportResponse();
                customMessage.SetResponse(reponse);
            }

            return default;
        }

        private class CustomTransportMessage : PipelineMessage
        {
            protected internal CustomTransportMessage(PipelineRequest request) : base(request)
            {
            }

            public void SetResponse(CustomTransportResponse response)
            {
                Response = response;
            }
        }

        private class CustomTransportRequest : PipelineRequest
        {
        }

        private class CustomTransportResponse : PipelineResponse
        {
            private Stream _stream;

            public CustomTransportResponse()
            {
                // Add fake response content
                _stream = BinaryData.FromString("{}").ToStream();
            }

            public override int Status => 0;

            public override string ReasonPhrase => "CustomTransportResponse";

            public override Stream ContentStream
            {
                get => _stream;
                set => _stream = value;
            }

            public override void Dispose()
            {
                _stream?.Dispose();
            }
        }
    }
    #endregion
}
