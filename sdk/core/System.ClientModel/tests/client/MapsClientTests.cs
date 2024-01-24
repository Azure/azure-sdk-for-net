// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Maps;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
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
        ApiKeyCredential credential = new ApiKeyCredential(key);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    #region Options Tests

    [Test]
    public void ChangeServiceVersion()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        // Service version is available on client subtype of ServiceClientOptions
        MapsClientOptions options = new MapsClientOptions(MapsClientOptions.ServiceVersion.V1);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void SetNetworkTimeout_ClientScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        options.NetworkTimeout = TimeSpan.FromSeconds(2);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void AddCustomPolicy_ClientScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        CustomPolicy customPolicy = new CustomPolicy();
        options.AddPolicy(customPolicy, PipelinePosition.PerCall);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            Assert.IsTrue(customPolicy.ProcessedMessage);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void OverrideTransport_ClientScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        options.Transport = new CustomTransport();

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            ClientResult<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

            PipelineResponse reponse = output.GetRawResponse();

            Assert.AreEqual("CustomTransportResponse", reponse.ReasonPhrase);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void PassCancellationToken_MethodScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            RequestOptions options = new RequestOptions();
            options.CancellationToken = new CancellationToken();

            // Call protocol method in order to pass RequestOptions
            ClientResult output = client.GetCountryCode(ipAddress.ToString(), options);

            // TODO: Add validation test
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void AddRequestHeader_MethodScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            RequestOptions options = new RequestOptions();
            options.AddHeader("CustomHeader", "CustomHeaderValue");

            // Call protocol method in order to pass RequestOptions
            ClientResult output = client.GetCountryCode(ipAddress.ToString(), options);

            // TODO: Add validation test
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void AddCustomPolicy_MethodScope()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            RequestOptions options = new RequestOptions();
            CustomPolicy customPolicy = new CustomPolicy();
            options.AddPolicy(customPolicy, PipelinePosition.PerCall);

            // Call protocol method in order to pass RequestOptions
            ClientResult output = client.GetCountryCode(ipAddress.ToString(), options);

            Assert.IsTrue(customPolicy.ProcessedMessage);
        }
        catch (ClientResultException e)
        {
            Assert.Fail($"Error: Response status code: '{e.Status}'");
        }
    }

    [Test]
    public void ChangeMethodBehaviorOnErrorResponse()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        ApiKeyCredential credential = new ApiKeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        try
        {
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");

            RequestOptions options = new RequestOptions();
            options.ErrorOptions = ClientErrorBehaviors.NoThrow;

            // Call protocol method in order to pass RequestOptions
            ClientResult output = client.GetCountryCode(ipAddress.ToString(), options);
        }
        catch (ClientResultException e)
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

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ProcessNext(message, pipeline, currentIndex);
            ProcessedMessage = true;
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
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
            private string _method;
            private Uri _uri;
            private PipelineRequestHeaders _headers;

            public CustomTransportRequest()
            {
                _headers = new CustomHeaders();
            }

            public override void Dispose() { }

            protected override string GetMethodCore()
                => _method!;

            protected override Uri GetUriCore()
                => _uri!;

            protected override PipelineRequestHeaders GetHeadersCore()
                => _headers;

            protected override BinaryContent GetContentCore()
            {
                throw new NotImplementedException();
            }

            protected override void SetMethodCore(string method)
                => _method = method;

            protected override void SetUriCore(Uri uri)
                => _uri = uri;

            protected override void SetContentCore(BinaryContent content)
            {
                throw new NotImplementedException();
            }
        }

        private class CustomTransportResponse : PipelineResponse
        {
            private Stream _stream;

            public CustomTransportResponse()
            {
                // Add fake response content
                _stream = BinaryData.FromString("{}").ToStream();
            }

            public override int Status => 200;

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

            protected override PipelineResponseHeaders GetHeadersCore()
            {
                throw new NotImplementedException();
            }
        }

        private class CustomHeaders : PipelineRequestHeaders
        {
            private readonly Dictionary<string, string> _headers;

            public CustomHeaders()
            {
                _headers = new Dictionary<string, string>();
            }

            public override void Add(string name, string value)
            {
                if (_headers.ContainsKey(name))
                {
                    _headers[name] = $"{_headers[name]};{value}";
                }
                else
                {
                    _headers.Add(name, value);
                }
            }

            public override bool Remove(string name)
            {
                throw new NotImplementedException();
            }

            public override void Set(string name, string value)
                => _headers[name] = value;

            public override bool TryGetValue(string name, out string value)
            {
                throw new NotImplementedException();
            }

            public override bool TryGetValues(string name, out IEnumerable<string> values)
            {
                throw new NotImplementedException();
            }

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
    #endregion
}
