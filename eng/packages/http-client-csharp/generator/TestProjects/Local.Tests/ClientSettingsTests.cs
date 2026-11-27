// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BasicTypeSpec;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

#pragma warning disable SCME0002

namespace TestProjects.Local.Tests
{
    public class ClientSettingsTests
    {
        private static readonly Uri Endpoint = new("https://example.test");

        [Test]
        public async Task DualAuthUsesConfiguredCredential(
            [Values("settings", "direct", "host", "keyedHost")] string construction,
            [Values(false, true)] bool apiKey,
            [Values(false, true)] bool isAsync)
        {
            var credential = new RecordingCredential();
            using var handler = new RecordingHandler();
            using var httpClient = new HttpClient(handler);
            var options = new BasicTypeSpecClientOptions
            {
                Transport = new HttpClientTransport(httpClient)
            };
            var settings = CreateSettings(apiKey, credential, options);
            BasicTypeSpecClient client;
            using var services = CreateServices(construction, apiKey, credential, options);
            switch (construction)
            {
                case "direct":
                    client = apiKey
                        ? new BasicTypeSpecClient(Endpoint, new AzureKeyCredential("test-key"), options)
                        : new BasicTypeSpecClient(Endpoint, credential, options);
                    break;
                case "host":
                    client = services.GetRequiredService<BasicTypeSpecClient>();
                    Assert.AreSame(client, services.GetRequiredService<BasicTypeSpecClient>());
                    break;
                case "keyedHost":
                    client = services.GetRequiredKeyedService<BasicTypeSpecClient>("client");
                    Assert.AreSame(client, services.GetRequiredKeyedService<BasicTypeSpecClient>("client"));
                    Assert.IsNull(services.GetService<BasicTypeSpecClient>());
                    break;
                default:
                    client = new BasicTypeSpecClient(settings);
                    break;
            }

            using Response response = isAsync
                ? await client.SayHiAsync("header", "query", null, new RequestContext())
                : client.SayHi("header", "query", null, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(Endpoint.Host, handler.RequestUri!.Host);
            Assert.AreEqual(apiKey ? "test-key" : null, handler.ApiKey);
            Assert.AreEqual(apiKey ? null : "Bearer test-token", handler.Authorization);
            CollectionAssert.AreEqual(
                apiKey ? Array.Empty<string>() : new[] { "https://theservice.azure.com/.default" },
                credential.Scopes);
            Assert.AreEqual(apiKey ? 0 : 1, credential.Calls);
            Assert.AreEqual(1, handler.Calls, "The supplied options transport must be used.");
        }

        [TestCase("ApiKeyCredential")]
        [TestCase("apikeycredential")]
        [TestCase("APIKEYCREDENTIAL")]
        public async Task ApiKeySourceTakesPrecedenceOverTokenProvider(string source)
        {
            var credential = new RecordingCredential();
            using var handler = new RecordingHandler();
            using var httpClient = new HttpClient(handler);
            var settings = CreateSettings(true, credential,
                new BasicTypeSpecClientOptions { Transport = new HttpClientTransport(httpClient) });
            settings.Credential!.CredentialSource = source;
            settings.Credential.TokenProvider = credential;

            using Response response = await new BasicTypeSpecClient(settings).SayHiAsync("header", "query", null, new RequestContext());

            Assert.AreEqual("test-key", handler.ApiKey);
            Assert.IsNull(handler.Authorization);
            Assert.AreEqual(0, credential.Calls);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ApiKeySettingsRejectInvalidKey(string? key)
        {
            var settings = CreateSettings(true);
            settings.Credential!.Key = key;
            var exception = Assert.Catch<ArgumentException>(() => new BasicTypeSpecClient(settings));
            Assert.AreEqual("key", exception!.ParamName);
            Assert.AreEqual(key == null ? typeof(ArgumentNullException) : typeof(ArgumentException), exception.GetType());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("unknown")]
        [TestCase("TokenCredential")]
        public void SettingsWithoutTokenProviderRejectCredential(string? source)
        {
            var settings = CreateSettings(false);
            settings.Credential!.CredentialSource = source;
            settings.Credential.Key = "not-an-api-key-without-the-source";
            var exception = Assert.Throws<ArgumentNullException>(() => new BasicTypeSpecClient(settings));
            Assert.AreEqual("credential", exception!.ParamName);
        }

        [Test]
        public void NullSettingsRejectCredential()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BasicTypeSpecClient((BasicTypeSpecClientSettings)null!));
            Assert.AreEqual("credential", exception!.ParamName);
        }

        [Test]
        public void MissingCredentialSettingsRejectCredential()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new BasicTypeSpecClient(new BasicTypeSpecClientSettings { BasicTypeSpecUrl = Endpoint }));
            Assert.AreEqual("credential", exception!.ParamName);
        }

        [Test]
        public void NonAzureTokenProviderRejectsCredential()
        {
            var settings = CreateSettings(false);
            settings.Credential!.TokenProvider = new NonAzureTokenProvider();
            var exception = Assert.Throws<ArgumentNullException>(() => new BasicTypeSpecClient(settings));
            Assert.AreEqual("credential", exception!.ParamName);
        }

        [Test]
        public void HostRegistrationRejectsInvalidCredentials(
            [Values("host", "keyedHost")] string construction,
            [Values("missing", "unknown", "nullKey", "emptyKey")] string invalidCredential)
        {
            using var services = CreateServices(
                construction, true, new RecordingCredential(), new BasicTypeSpecClientOptions(),
                settings =>
                {
                    switch (invalidCredential)
                    {
                        case "missing":
                            settings.Credential = null;
                            break;
                        case "unknown":
                            settings.Credential!.CredentialSource = "unknown";
                            break;
                        case "nullKey":
                            settings.Credential!.Key = null;
                            break;
                        case "emptyKey":
                            settings.Credential!.Key = "";
                            break;
                    }
                });
            var exception = Assert.Catch<ArgumentException>(() =>
            {
                if (construction == "host")
                {
                    services.GetRequiredService<BasicTypeSpecClient>();
                }
                else
                {
                    services.GetRequiredKeyedService<BasicTypeSpecClient>("client");
                }
            });
            Assert.AreEqual(invalidCredential is "nullKey" or "emptyKey" ? "key" : "credential", exception!.ParamName);
        }

        [Test]
        public void SettingsPreserveEndpointValidation([Values(false, true)] bool apiKey)
        {
            var settings = CreateSettings(apiKey, new RecordingCredential());
            settings.BasicTypeSpecUrl = null!;
            var exception = Assert.Throws<ArgumentNullException>(() => new BasicTypeSpecClient(settings));
            Assert.AreEqual("endpoint", exception!.ParamName);
        }

        [Test]
        public void SettingsAllowDefaultOptions([Values(false, true)] bool apiKey)
        {
            var client = new BasicTypeSpecClient(CreateSettings(apiKey, new RecordingCredential()));
            Assert.IsNotNull(client.Pipeline);
        }

        private static BasicTypeSpecClientSettings CreateSettings(
            bool apiKey, TokenCredential? token = null, BasicTypeSpecClientOptions? options = null)
            => new()
            {
                BasicTypeSpecUrl = Endpoint,
                Credential = new CredentialSettings(null!)
                {
                    CredentialSource = apiKey ? "ApiKeyCredential" : null,
                    Key = apiKey ? "test-key" : null,
                    TokenProvider = apiKey ? null : token
                },
                Options = options
            };

        private static ServiceProvider CreateServices(
            string construction, bool apiKey, TokenCredential token, BasicTypeSpecClientOptions options,
            Action<BasicTypeSpecClientSettings>? configure = null)
        {
            var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { DisableDefaults = true });
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Client:BasicTypeSpecUrl"] = Endpoint.AbsoluteUri,
                ["Client:Credential:CredentialSource"] = apiKey ? "ApiKeyCredential" : null,
                ["Client:Credential:Key"] = apiKey ? "test-key" : null
            });
            void Configure(BasicTypeSpecClientSettings settings)
            {
                settings.Options = options;
                if (!apiKey)
                {
                    settings.Credential!.TokenProvider = token;
                }
                configure?.Invoke(settings);
            }

            if (construction == "keyedHost")
            {
                builder.AddKeyedBasicTypeSpecClient("client", "Client", Configure);
            }
            else if (construction == "host")
            {
                builder.AddBasicTypeSpecClient("Client", Configure);
            }
            return builder.Services.BuildServiceProvider();
        }

        private sealed class RecordingCredential : TokenCredential
        {
            public string[] Scopes { get; private set; } = [];
            public int Calls { get; private set; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                Calls++;
                Scopes = requestContext.Scopes;
                return new AccessToken("test-token", DateTimeOffset.UtcNow.AddHours(1));
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }

        private sealed class NonAzureTokenProvider : AuthenticationTokenProvider
        {
            public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
                => throw new NotSupportedException();

            public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
                => throw new NotSupportedException();

            public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
                => throw new NotSupportedException();
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            public Uri? RequestUri { get; private set; }
            public string? ApiKey { get; private set; }
            public string? Authorization { get; private set; }
            public int Calls { get; private set; }

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Calls++;
                RequestUri = request.RequestUri;
                ApiKey = request.Headers.TryGetValues("my-api-key", out var values) ? values.Single() : null;
                Authorization = request.Headers.Authorization?.ToString();
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("\"hello\"") };
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(Send(request, cancellationToken));
        }
    }
}
