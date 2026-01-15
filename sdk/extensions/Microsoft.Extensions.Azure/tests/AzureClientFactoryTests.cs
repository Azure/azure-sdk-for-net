// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    public class AzureClientFactoryTests
    {
        [Test]
        public void AllowsResolvingFactoryAndCreatingClientInstance()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.NotNull(client);
            Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
        }

        [Test]
        public void ReturnsSameInstanceWhenResolvedMultipleTimes()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");
            TestClient anotherClient = factory.CreateClient("Default");

            Assert.That(anotherClient, Is.SameAs(client));
        }

        [Test]
        public void ExecutesConfigurationDelegateOnOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder =>
                builder.AddTestClient(new Uri("http://localhost/")).ConfigureOptions(options => options.Property = "Value"));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.That(client, Is.SameAs(client));
            Assert.That(client.Options.Property, Is.EqualTo("Value"));
        }

        [Test]
        public void ExecutesConfigureDelegateOnOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));
            serviceCollection.Configure<TestClientOptions>("Default", options => options.Property = "Value");

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.That(client, Is.SameAs(client));
            Assert.That(client.Options.Property, Is.EqualTo("Value"));
        }

        [Test]
        public void SubsequentRegistrationOverrides()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://otherhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.That(client.Uri.ToString(), Is.EqualTo("http://otherhost/"));
        }

        [Test]
        public void CanRegisterMultipleClients()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient(new Uri("http://localhost/")).ConfigureOptions(options => options.Property = "Value1");
                builder.AddTestClient(new Uri("http://otherhost/")).WithName("OtherClient").ConfigureOptions(options => options.Property = "Value2");
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");
            TestClient otherClient = factory.CreateClient("OtherClient");

            Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
            Assert.That(otherClient.Uri.ToString(), Is.EqualTo("http://otherhost/"));

            Assert.That(client.Options.Property, Is.EqualTo("Value1"));
            Assert.That(otherClient.Options.Property, Is.EqualTo("Value2"));

            Assert.AreNotSame(client, otherClient);
        }

        [Test]
        public void CanCreateClientFromConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "http://localhost/"));
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.NotNull(client);
            Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
        }

        [Test]
        public void SetsOptionsPropertiesFromConfiguration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("connectionstring", "http://localhost/"),
                new KeyValuePair<string, string>("property", "value"),
                new KeyValuePair<string, string>("nested:property", "nested-value"),
                new KeyValuePair<string, string>("intproperty", "15")
                );

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            TestClient client = factory.CreateClient("Default");

            Assert.That(client.Options.Property, Is.EqualTo("value"));
            Assert.That(client.Options.Nested.Property, Is.EqualTo("nested-value"));
            Assert.That(client.Options.IntProperty, Is.EqualTo(15));
            Assert.That(client.ConnectionString, Is.EqualTo("http://localhost/"));
        }

        [Test]
        public void CreateClientThrowsWhenClientIsNotRegistered()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();
            var exception = Assert.Throws<InvalidOperationException>(() => factory.CreateClient("Other"));

            Assert.That(exception.Message, Is.EqualTo("Unable to find client registration with type 'TestClient' and name 'Other'."));
        }

        [Test]
        public void RethrowsExceptionFromClientCreation()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("throw"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IAzureClientFactory<TestClient> factory = provider.GetService<IAzureClientFactory<TestClient>>();

            var exception = Assert.Throws<ArgumentException>(() => factory.CreateClient("Default"));
            var otherException = Assert.Throws<ArgumentException>(() => factory.CreateClient("Default"));

            Assert.That(exception, Is.SameAs(otherException));
            Assert.That(exception.Message, Is.EqualTo("Throwing"));
        }

        [Test]
        public void CanSetGlobalOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient("TestClient1");
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(options => options.Diagnostics.ApplicationId = "GlobalAppId");
            });
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            TestClient testClient = provider.GetService<IAzureClientFactory<TestClient>>().CreateClient("Default");
            TestClientWithCredentials testClientWithCredentials = provider.GetService<IAzureClientFactory<TestClientWithCredentials>>().CreateClient("Default");

            Assert.That(testClient.Options.Diagnostics.ApplicationId, Is.EqualTo("GlobalAppId"));
            Assert.That(testClientWithCredentials.Options.Diagnostics.ApplicationId, Is.EqualTo("GlobalAppId"));
        }

        [Test]
        public void CanSetGlobalOptionsUsingConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("Diagnostics:ApplicationId", "GlobalAppId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClient("TestClient1");
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(configuration);
            });
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            TestClient testClient = provider.GetService<IAzureClientFactory<TestClient>>().CreateClient("Default");
            TestClientWithCredentials testClientWithCredentials = provider.GetService<IAzureClientFactory<TestClientWithCredentials>>().CreateClient("Default");

            Assert.That(testClient.Options.Diagnostics.ApplicationId, Is.EqualTo("GlobalAppId"));
            Assert.That(testClientWithCredentials.Options.Diagnostics.ApplicationId, Is.EqualTo("GlobalAppId"));
        }

        [Test]
        public void ResolvesDefaultClientByDefault()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient("Connection string"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            var client = provider.GetService<TestClient>();

            Assert.That(client.ConnectionString, Is.EqualTo("Connection string"));
        }

        [Test]
        public void UsesProvidedCredentialIfOverGlobal()
        {
            var serviceCollection = new ServiceCollection();
            var defaultAzureCredential = new ManagedIdentityCredential(ManagedIdentityId.SystemAssigned);
            serviceCollection.AddAzureClients(builder => builder.AddTestClientWithCredentials(new Uri("http://localhost")).WithCredential(defaultAzureCredential));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.That(client.Credential, Is.SameAs(defaultAzureCredential));
        }

        [Test]
        public void UsesGlobalCredential()
        {
            var serviceCollection = new ServiceCollection();
            var defaultAzureCredential = new ManagedIdentityCredential(ManagedIdentityId.SystemAssigned);
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.UseCredential(defaultAzureCredential);
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.That(client.Credential, Is.SameAs(defaultAzureCredential));
        }

        [Test]
        public void UsesCredentialFromGlobalConfiguration()
        {
            var configuration = GetConfiguration(new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => {
                builder.AddTestClientWithCredentials(new Uri("http://localhost"));
                builder.ConfigureDefaults(configuration);
            });

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.IsInstanceOf<ClientSecretCredential>(client.Credential);
            var clientSecretCredential = (ClientSecretCredential)client.Credential;

            Assert.That(clientSecretCredential.ClientId, Is.EqualTo("ConfigurationClientId"));
            Assert.That(clientSecretCredential.ClientSecret, Is.EqualTo("ConfigurationClientSecret"));
            Assert.That(clientSecretCredential.TenantId, Is.EqualTo("ConfigurationTenantId"));
        }

        [Test]
        public void UsesCredentialFromConfiguration()
        {
            var configuration = GetConfiguration(
                new KeyValuePair<string, string>("uri", "http://localhost/"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder
                .AddTestClientWithCredentials(configuration));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.IsInstanceOf<ClientSecretCredential>(client.Credential);
            var clientSecretCredential = (ClientSecretCredential)client.Credential;

            Assert.That(client.Uri.ToString(), Is.EqualTo("http://localhost/"));
            Assert.That(clientSecretCredential.ClientId, Is.EqualTo("ConfigurationClientId"));
            Assert.That(clientSecretCredential.ClientSecret, Is.EqualTo("ConfigurationClientSecret"));
            Assert.That(clientSecretCredential.TenantId, Is.EqualTo("ConfigurationTenantId"));
        }

        [Test]
        public void SupportsSettingVersion()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")).WithVersion(TestClientOptions.ServiceVersion.B));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClient client = provider.GetService<TestClient>();
            Assert.That(client.Options.Version, Is.EqualTo(TestClientOptions.ServiceVersion.B));
        }

        [Test]
        public void ThrowsIfCredentialIsNullButIsRequired()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClient(new Uri("http://localhost/")).WithCredential((TokenCredential)null));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => provider.GetService<TestClient>());
            Assert.That(exception.Message, Is.EqualTo("Client registration requires a TokenCredential. Configure it using UseCredential method."));
        }

        [Test]
        public void CanCreateClientOptionsWithMultipleParameters()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClientOptionsMultipleParameters("http://localhost/"));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientMultipleOptionsParameters client = provider.GetService<TestClientMultipleOptionsParameters>();

            Assert.NotNull(client.Options);
            Assert.That(client.Options.Version, Is.EqualTo(TestClientOptionsMultipleParameters.ServiceVersion.D));
            Assert.That(client.Options.OtherParameter, Is.EqualTo("some default value"));
        }

        [Test]
        public void CanCreateClientOptionsWithMultipleParametersAndSetVersion()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder => builder.AddTestClientOptionsMultipleParameters("http://localhost/").WithVersion(TestClientOptionsMultipleParameters.ServiceVersion.B));
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientMultipleOptionsParameters client = provider.GetService<TestClientMultipleOptionsParameters>();

            Assert.NotNull(client.Options);
            Assert.That(client.Options.Version, Is.EqualTo(TestClientOptionsMultipleParameters.ServiceVersion.B));
            Assert.That(client.Options.OtherParameter, Is.EqualTo("some default value"));
        }

        [Test]
        public void CanRegisterCustomClient()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<TestClient, TestClientOptions>(options => new TestClient("conn str", options))
            );
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClient client = provider.GetService<TestClient>();

            Assert.That(client.ConnectionString, Is.EqualTo("conn str"));
            Assert.NotNull(client.Options);
        }

        [Test]
        public void CanRegisterStructClient()
        {
            var name = "Test";
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<ValueClient, object>(options => new ValueClient(name)));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            ValueClient client = provider.GetService<ValueClient>();

            Assert.That(client.Name, Is.EqualTo(name));
        }

        [Test]
        public void CanRegisterPrimitive()
        {
            var value = 55;
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<int, object>(options => value));

            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            int clientValue = provider.GetService<int>();

            Assert.That(clientValue, Is.EqualTo(value));
        }

        [Test]
        public void CanRegisterCustomClientWithOptionsAndCredential()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<TestClientWithCredentials, TestClientOptions>((options, credential) => new TestClientWithCredentials(new Uri("http://localhost/"), credential, options))
            );
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.That(client.Uri.AbsoluteUri, Is.EqualTo("http://localhost/"));
            Assert.NotNull(client.Options);
            Assert.NotNull(client.Credential);
        }

        [Test]
        public void CanRegisterCustomClientProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton("conn str");
            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<TestClient, TestClientOptions>((options, p) => new TestClient(p.GetService<string>(),  options))
            );
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClient client = provider.GetService<TestClient>();

            Assert.That(client.ConnectionString, Is.EqualTo("conn str"));
            Assert.NotNull(client.Options);
        }

        [Test]
        public void CanRegisterCustomClientWithOptionsAndCredentialProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(new Uri("http://localhost/"));
            serviceCollection.AddAzureClients(builder =>
                builder.AddClient<TestClientWithCredentials, TestClientOptions>((options, credential, p) => new TestClientWithCredentials(p.GetService<Uri>(), credential, options))
            );
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            TestClientWithCredentials client = provider.GetService<TestClientWithCredentials>();

            Assert.That(client.Uri.AbsoluteUri, Is.EqualTo("http://localhost/"));
            Assert.NotNull(client.Options);
            Assert.NotNull(client.Credential);
        }

        [Test]
        public void DisposeHandlesDisposableClient()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposed = false;

            Action disposeCallback = () =>
            {
                disposed = true;
                tcs.TrySetResult(true);
            };

            services.AddAzureClients(builder =>
                builder.AddClient<DisposableClient, object>(_ => new DisposableClient(disposeCallback)).WithName(nameof(DisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<DisposableClient>>();
            var client = factory.CreateClient(nameof(DisposableClient));

            provider.Dispose();

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposed, Is.True);
        }

        [Test]
        public void DisposeHandlesAsyncDisposableClient()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposed = false;

            Action disposeCallback= () =>
            {
                disposed = true;
                tcs.TrySetResult(true);
            };

            services.AddAzureClients(builder =>
                builder.AddClient<AsyncDisposableClient, object>(_ => new AsyncDisposableClient(disposeCallback)).WithName(nameof(AsyncDisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<AsyncDisposableClient>>();
            var client = factory.CreateClient(nameof(AsyncDisposableClient));

            provider.Dispose();

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposed, Is.True);
        }

        [Test]
        public void DisposeHandlesNonDisposableClients()
        {
            var services = new ServiceCollection();

            services.AddAzureClients(builder =>
                builder.AddClient<NonDisposableClient, object>(_ => new NonDisposableClient()).WithName(nameof(NonDisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<NonDisposableClient>>();
            var client = factory.CreateClient(nameof(NonDisposableClient));

            Assert.DoesNotThrow(provider.Dispose);
        }

        [Test]
        public void DisposableHandlesMixedClients()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposeCount = 0;

            Action disposeCallback= () =>
            {
                if (++disposeCount >= 3)
                {
                    tcs.TrySetResult(true);
                }
            };

            services.AddAzureClients(builder =>
                builder.AddClient<NonDisposableClient, object>(_ => new NonDisposableClient()).WithName(nameof(NonDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<BothDisposableClient, object>(_ => new BothDisposableClient(disposeCallback)).WithName(nameof(BothDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<AsyncDisposableClient, object>(_ => new AsyncDisposableClient(disposeCallback)).WithName(nameof(AsyncDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<DisposableClient, object>(_ => new DisposableClient(disposeCallback)).WithName(nameof(DisposableClient)));

            var provider = services.BuildServiceProvider();

            var factory = provider.GetRequiredService<IAzureClientFactory<NonDisposableClient>>();
            var client = factory.CreateClient(nameof(NonDisposableClient));

            var disposableFactory = provider.GetRequiredService<IAzureClientFactory<DisposableClient>>();
            var disposableClient = disposableFactory.CreateClient(nameof(DisposableClient));

            var asyncDisposableFactory = provider.GetRequiredService<IAzureClientFactory<AsyncDisposableClient>>();
            var asyncDisposableClient = asyncDisposableFactory.CreateClient(nameof(AsyncDisposableClient));

            var bothDisposableFactory = provider.GetRequiredService<IAzureClientFactory<BothDisposableClient>>();
            var bothDisposableClient = bothDisposableFactory.CreateClient(nameof(BothDisposableClient));

            Assert.DoesNotThrow(provider.Dispose);

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposeCount, Is.EqualTo(3));
        }

        [Test]
        public async Task DisposeAsyncHandlesDisposableClient()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposed = false;

            Action disposeCallback= () =>
            {
                disposed = true;
                tcs.TrySetResult(true);
            };

            services.AddAzureClients(builder =>
                builder.AddClient<DisposableClient, object>(_ => new DisposableClient(disposeCallback)).WithName(nameof(DisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<DisposableClient>>();
            var client = factory.CreateClient(nameof(DisposableClient));

            await provider.DisposeAsync();

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposed, Is.True);
        }

        [Test]
        public async Task DisposeAsyncHandlesAsyncDisposableClient()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposed = false;

            Action disposeCallback= () =>
            {
                disposed = true;
                tcs.TrySetResult(true);
            };

            services.AddAzureClients(builder =>
                builder.AddClient<AsyncDisposableClient, object>(_ => new AsyncDisposableClient(disposeCallback)).WithName(nameof(AsyncDisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<AsyncDisposableClient>>();
            var client = factory.CreateClient(nameof(AsyncDisposableClient));

            await provider.DisposeAsync();

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposed, Is.True);
        }

        [Test]
        public void DisposeAsyncisposeHandlesNonDisposableClients()
        {
            var services = new ServiceCollection();

            services.AddAzureClients(builder =>
                builder.AddClient<NonDisposableClient, object>(_ => new NonDisposableClient()).WithName(nameof(NonDisposableClient)));

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IAzureClientFactory<NonDisposableClient>>();
            var client = factory.CreateClient(nameof(NonDisposableClient));

            Assert.DoesNotThrowAsync(async () => await provider.DisposeAsync());
        }

        [Test]
        public async Task DisposeAsyncHandlesMixedClients()
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var services = new ServiceCollection();
            var disposeCount = 0;

            Action disposeCallback= () =>
            {
                if (++disposeCount >= 3)
                {
                    tcs.TrySetResult(true);
                }
            };

            services.AddAzureClients(builder =>
                builder.AddClient<NonDisposableClient, object>(_ => new NonDisposableClient()).WithName(nameof(NonDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<BothDisposableClient, object>(_ => new BothDisposableClient(disposeCallback)).WithName(nameof(BothDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<AsyncDisposableClient, object>(_ => new AsyncDisposableClient(disposeCallback)).WithName(nameof(AsyncDisposableClient)));

            services.AddAzureClients(builder =>
                builder.AddClient<DisposableClient, object>(_ => new DisposableClient(disposeCallback)).WithName(nameof(DisposableClient)));

            var provider = services.BuildServiceProvider();

            var factory = provider.GetRequiredService<IAzureClientFactory<NonDisposableClient>>();
            var client = factory.CreateClient(nameof(NonDisposableClient));

            var disposableFactory = provider.GetRequiredService<IAzureClientFactory<DisposableClient>>();
            var disposableClient = disposableFactory.CreateClient(nameof(DisposableClient));

            var asyncDisposableFactory = provider.GetRequiredService<IAzureClientFactory<AsyncDisposableClient>>();
            var asyncDisposableClient = asyncDisposableFactory.CreateClient(nameof(AsyncDisposableClient));

            var bothDisposableFactory = provider.GetRequiredService<IAzureClientFactory<BothDisposableClient>>();
            var bothDisposableClient = bothDisposableFactory.CreateClient(nameof(BothDisposableClient));

            await provider.DisposeAsync();

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            Assert.DoesNotThrowAsync(async () => await tcs.Task.AwaitWithCancellation(cancellationSource.Token));
            Assert.That(disposeCount, Is.EqualTo(3));
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }

        private class DisposableClient : IDisposable
        {
            private Action _disposeCallback;

            public DisposableClient(Action disposeCallback) => _disposeCallback = disposeCallback;

            public void Dispose()
            {
                _disposeCallback();
            }
        }

        private class AsyncDisposableClient : IAsyncDisposable
        {
            private Action _disposeCallback;

            public AsyncDisposableClient(Action disposeCallback) => _disposeCallback = disposeCallback;

            public ValueTask DisposeAsync()
            {
                _disposeCallback();
                return new ValueTask();
            }
        }

        private class BothDisposableClient : IDisposable, IAsyncDisposable
        {
            private Action _disposeCallback;

            public BothDisposableClient(Action disposeCallback) => _disposeCallback = disposeCallback;

            public void Dispose()
            {
                _disposeCallback();
            }

            public ValueTask DisposeAsync()
            {
                _disposeCallback();
                return new ValueTask();
            }
        }

        private class NonDisposableClient
        {
        }

        private struct ValueClient
        {
            public string Name { get; }
            public ValueClient(string name) => Name = name;
        }
    }
}
