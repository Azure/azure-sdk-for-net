// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobAccessPointTests
    {
        private const string ConfigurationNameHeader = "x-ms-blob-access-point-configuration-name";
        private const string ConfigurationUniqueIdHeader = "x-ms-blob-access-point-configuration-unique-id";
        private const string IsBlobAccessPointContainerHeader = "x-ms-is-blob-access-point-container";
        private const string ConfigurationName = "bapconfiga";
        private const string ConfigurationUniqueId = "11111111-2222-3333-4444-555555555555";
        private const string OtherConfigurationUniqueId = "99999999-8888-7777-6666-555555555555";
        private const string ContainerETag = "\"0x8DCONTAINER\"";

        private static readonly Uri s_serviceUri = new Uri("https://account.blob.core.windows.net/");
        private static readonly Uri s_containerUri = new Uri("https://account.blob.core.windows.net/container");

        #region Create Container
        [Test]
        public async Task Create_WithConfiguration_SendsHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<BlobContainerInfo> response = async
                ? await container.CreateAsync(options)
                : container.Create(options);

            Assert.IsNotNull(response.Value);
            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(RequestMethod.Put, request.Method);
            StringAssert.Contains("restype=container", request.Uri.ToString());
            AssertHeader(request, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public async Task Create_WithoutConfiguration_DoesNotSendHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));

            if (async)
            {
                await container.CreateAsync(new BlobContainerCreateOptions());
            }
            else
            {
                container.Create(new BlobContainerCreateOptions());
            }

            MockRequest request = transport.SingleRequest;
            Assert.IsFalse(request.Headers.Contains(ConfigurationNameHeader));
            Assert.IsFalse(request.Headers.Contains(ConfigurationUniqueIdHeader));
        }

        [Test]
        public async Task Create_NullOptions_DoesNotSendHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));

            if (async)
            {
                await container.CreateAsync();
            }
            else
            {
                container.Create();
            }

            MockRequest request = transport.SingleRequest;
            Assert.IsFalse(request.Headers.Contains(ConfigurationNameHeader));
            Assert.IsFalse(request.Headers.Contains(ConfigurationUniqueIdHeader));
        }

        [Test]
        public async Task Create_WithOptions_ForwardsAllOptions([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                PublicAccessType = PublicAccessType.Blob,
                Metadata = new Dictionary<string, string> { { "foo", "bar" } },
                EncryptionScopeOptions = new BlobContainerEncryptionScopeOptions
                {
                    DefaultEncryptionScope = "scope",
                    PreventEncryptionScopeOverride = true,
                },
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            if (async)
            {
                await container.CreateAsync(options);
            }
            else
            {
                container.Create(options);
            }

            MockRequest request = transport.SingleRequest;
            AssertHeader(request, "x-ms-blob-public-access", "blob");
            AssertHeader(request, "x-ms-meta-foo", "bar");
            AssertHeader(request, "x-ms-default-encryption-scope", "scope");
            AssertHeader(request, "x-ms-deny-encryption-scope-override", "true");
            AssertHeader(request, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public async Task CreateIfNotExists_WithConfiguration_SendsHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<BlobContainerInfo> response = async
                ? await container.CreateIfNotExistsAsync(options)
                : container.CreateIfNotExists(options);

            Assert.IsNotNull(response);
            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public async Task ServiceClient_CreateBlobContainer_WithConfiguration_SendsHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            BlobServiceClient service = new BlobServiceClient(s_serviceUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<BlobContainerClient> response = async
                ? await service.CreateBlobContainerAsync("container", options)
                : service.CreateBlobContainer("container", options);

            Assert.AreEqual("container", response.Value.Name);
            MockRequest request = transport.SingleRequest;
            StringAssert.Contains("/container", request.Uri.ToString());
            AssertHeader(request, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public void Create_FictitiousConfigurationName_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(404, "BlobAccessPointConfigurationNameNotFound"));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationName = "doesnotexist",
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await container.CreateAsync(options);
                }
                else
                {
                    container.Create(options);
                }
            });

            Assert.AreEqual(BlobErrorCode.BlobAccessPointConfigurationNameNotFound.ToString(), ex.ErrorCode);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, "doesnotexist");
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public void Create_MismatchedConfigurationUniqueId_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(400, "BlobAccessPointConfigurationUniqueIdMismatch"));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = OtherConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await container.CreateAsync(options);
                }
                else
                {
                    container.Create(options);
                }
            });

            Assert.AreEqual(BlobErrorCode.BlobAccessPointConfigurationUniqueIdMismatch.ToString(), ex.ErrorCode);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, OtherConfigurationUniqueId);
        }

        [Test]
        public void Create_UniqueIdOnly_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(400, "MissingRequiredHeader"));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));
            BlobContainerCreateOptions options = new BlobContainerCreateOptions
            {
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await container.CreateAsync(options);
                }
                else
                {
                    container.Create(options);
                }
            });

            Assert.AreEqual(BlobErrorCode.MissingRequiredHeader.ToString(), ex.ErrorCode);
            MockRequest request = transport.SingleRequest;
            Assert.IsFalse(request.Headers.Contains(ConfigurationNameHeader));
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }
        #endregion

        #region Read Operations
        [Test]
        public async Task GetProperties_BlobAccessPointContainer([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateGetPropertiesResponse(isBlobAccessPointContainer: true));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));

            Response<BlobContainerProperties> response = async
                ? await container.GetPropertiesAsync()
                : container.GetProperties();

            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.AreEqual(true, response.Value.IsBlobAccessPointContainer);
            Assert.AreEqual(ConfigurationName, response.Value.BlobAccessPointConfigurationName);
            Assert.AreEqual(ConfigurationUniqueId, response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetProperties_RegularContainer([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateGetPropertiesResponse(isBlobAccessPointContainer: false));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));

            Response<BlobContainerProperties> response = async
                ? await container.GetPropertiesAsync()
                : container.GetProperties();

            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.AreEqual(false, response.Value.IsBlobAccessPointContainer);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationName);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetProperties_HeaderNotReturned_IsNull([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateGetPropertiesResponse(isBlobAccessPointContainer: null));
            BlobContainerClient container = new BlobContainerClient(s_containerUri, GetOptions(transport));

            Response<BlobContainerProperties> response = async
                ? await container.GetPropertiesAsync()
                : container.GetProperties();

            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.IsNull(response.Value.IsBlobAccessPointContainer);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationName);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetBlobContainers_MapsBlobAccessPointProperties([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateListContainersResponse());
            BlobServiceClient service = new BlobServiceClient(s_serviceUri, GetOptions(transport));

            IList<BlobContainerItem> containers = async
                ? await service.GetBlobContainersAsync().ToListAsync()
                : service.GetBlobContainers().ToList();

            Assert.AreEqual(3, containers.Count);

            BlobContainerItem bapContainer = containers.Single(c => c.Name == "bapcontainer");
            Assert.AreEqual(new ETag("\"0x8DBAP\""), bapContainer.Properties.ETag);
            Assert.AreEqual(true, bapContainer.Properties.IsBlobAccessPointContainer);
            Assert.AreEqual(ConfigurationName, bapContainer.Properties.BlobAccessPointConfigurationName);
            Assert.AreEqual(ConfigurationUniqueId, bapContainer.Properties.BlobAccessPointConfigurationUniqueId);

            BlobContainerItem regularContainer = containers.Single(c => c.Name == "regularcontainer");
            Assert.AreEqual(new ETag("\"0x8DREG\""), regularContainer.Properties.ETag);
            Assert.AreEqual(false, regularContainer.Properties.IsBlobAccessPointContainer);
            Assert.IsNull(regularContainer.Properties.BlobAccessPointConfigurationName);
            Assert.IsNull(regularContainer.Properties.BlobAccessPointConfigurationUniqueId);

            BlobContainerItem notReturnedContainer = containers.Single(c => c.Name == "notreturnedcontainer");
            Assert.AreEqual(new ETag("\"0x8DNONE\""), notReturnedContainer.Properties.ETag);
            Assert.IsNull(notReturnedContainer.Properties.IsBlobAccessPointContainer);
            Assert.IsNull(notReturnedContainer.Properties.BlobAccessPointConfigurationName);
            Assert.IsNull(notReturnedContainer.Properties.BlobAccessPointConfigurationUniqueId);
        }
        #endregion

        #region Helpers
        private static BlobClientOptions GetOptions(MockTransport transport)
        {
            BlobClientOptions options = new BlobClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            return options;
        }

        private static void AssertHeader(MockRequest request, string name, string expected)
        {
            Assert.IsTrue(request.Headers.TryGetValue(name, out string actual), $"Expected header '{name}' was not sent.");
            Assert.AreEqual(expected, actual);
        }

        private static MockResponse CreateContainerCreatedResponse()
        {
            MockResponse response = new MockResponse(201);
            response.AddHeader("ETag", ContainerETag);
            response.AddHeader("Last-Modified", "Wed, 18 Nov 2026 01:20:48 GMT");
            return response;
        }

        private static MockResponse CreateGetPropertiesResponse(bool? isBlobAccessPointContainer)
        {
            MockResponse response = new MockResponse(200);
            response.AddHeader("ETag", ContainerETag);
            response.AddHeader("Last-Modified", "Wed, 18 Nov 2026 01:20:48 GMT");
            if (isBlobAccessPointContainer.HasValue)
            {
                response.AddHeader(IsBlobAccessPointContainerHeader, isBlobAccessPointContainer.Value ? "true" : "false");
            }
            if (isBlobAccessPointContainer == true)
            {
                response.AddHeader(ConfigurationNameHeader, ConfigurationName);
                response.AddHeader(ConfigurationUniqueIdHeader, ConfigurationUniqueId);
            }
            return response;
        }

        private static MockResponse CreateListContainersResponse()
        {
            string body =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<EnumerationResults ServiceEndpoint=\"https://account.blob.core.windows.net/\">" +
                "<Containers>" +
                "<Container><Name>bapcontainer</Name><Properties>" +
                "<Last-Modified>Wed, 18 Nov 2026 01:20:48 GMT</Last-Modified><Etag>\"0x8DBAP\"</Etag>" +
                "<IsBlobAccessPointContainer>true</IsBlobAccessPointContainer>" +
                $"<BlobAccessPointConfigurationName>{ConfigurationName}</BlobAccessPointConfigurationName>" +
                $"<BlobAccessPointConfigurationUniqueId>{ConfigurationUniqueId}</BlobAccessPointConfigurationUniqueId>" +
                "</Properties></Container>" +
                "<Container><Name>regularcontainer</Name><Properties>" +
                "<Last-Modified>Wed, 18 Nov 2026 01:20:48 GMT</Last-Modified><Etag>\"0x8DREG\"</Etag>" +
                "<IsBlobAccessPointContainer>false</IsBlobAccessPointContainer>" +
                "</Properties></Container>" +
                "<Container><Name>notreturnedcontainer</Name><Properties>" +
                "<Last-Modified>Wed, 18 Nov 2026 01:20:48 GMT</Last-Modified><Etag>\"0x8DNONE\"</Etag>" +
                "</Properties></Container>" +
                "</Containers>" +
                "<NextMarker />" +
                "</EnumerationResults>";

            MockResponse response = new MockResponse(200);
            response.AddHeader("Content-Type", "application/xml");
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(body));
            return response;
        }

        private static MockResponse CreateErrorResponse(int status, string errorCode)
        {
            string body =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<Error><Code>{errorCode}</Code><Message>Mocked error.</Message></Error>";

            MockResponse response = new MockResponse(status);
            response.AddHeader("x-ms-error-code", errorCode);
            response.AddHeader("Content-Type", "application/xml");
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(body));
            return response;
        }
        #endregion
    }
}
