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
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;
using FileSystemInfo = Azure.Storage.Files.DataLake.Models.FileSystemInfo;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeBlobAccessPointTests
    {
        private const string ConfigurationNameHeader = "x-ms-blob-access-point-configuration-name";
        private const string ConfigurationUniqueIdHeader = "x-ms-blob-access-point-configuration-unique-id";
        private const string IsBlobAccessPointContainerHeader = "x-ms-is-blob-access-point-container";
        private const string ConfigurationName = "bapconfiga";
        private const string ConfigurationUniqueId = "11111111-2222-3333-4444-555555555555";
        private const string OtherConfigurationUniqueId = "99999999-8888-7777-6666-555555555555";
        private const string ContainerETag = "\"0x8DCONTAINER\"";

        private static readonly Uri s_serviceUri = new Uri("https://account.dfs.core.windows.net/");
        private static readonly Uri s_fileSystemUri = new Uri("https://account.dfs.core.windows.net/filesystem");

        #region Create File System
        [Test]
        public async Task Create_WithConfiguration_SendsHeadersToBlobEndpoint([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<FileSystemInfo> response = async
                ? await fileSystem.CreateAsync(options)
                : fileSystem.Create(options);

            Assert.IsNotNull(response.Value);
            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual("account.blob.core.windows.net", request.Uri.Host);
            StringAssert.Contains("restype=container", request.Uri.ToString());
            AssertHeader(request, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public async Task Create_WithoutConfiguration_DoesNotSendHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));

            if (async)
            {
                await fileSystem.CreateAsync(new DataLakeFileSystemCreateOptions());
            }
            else
            {
                fileSystem.Create(new DataLakeFileSystemCreateOptions());
            }

            MockRequest request = transport.SingleRequest;
            Assert.IsFalse(request.Headers.Contains(ConfigurationNameHeader));
            Assert.IsFalse(request.Headers.Contains(ConfigurationUniqueIdHeader));
        }

        [Test]
        public async Task Create_NullOptions_DoesNotSendHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));

            if (async)
            {
                await fileSystem.CreateAsync();
            }
            else
            {
                fileSystem.Create();
            }

            MockRequest request = transport.SingleRequest;
            Assert.IsFalse(request.Headers.Contains(ConfigurationNameHeader));
            Assert.IsFalse(request.Headers.Contains(ConfigurationUniqueIdHeader));
        }

        [Test]
        public async Task Create_WithOptions_ForwardsAllOptions([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                PublicAccessType = PublicAccessType.Path,
                Metadata = new Dictionary<string, string> { { "foo", "bar" } },
                EncryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
                {
                    DefaultEncryptionScope = "scope",
                    PreventEncryptionScopeOverride = true,
                },
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            if (async)
            {
                await fileSystem.CreateAsync(options);
            }
            else
            {
                fileSystem.Create(options);
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
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<FileSystemInfo> response = async
                ? await fileSystem.CreateIfNotExistsAsync(options)
                : fileSystem.CreateIfNotExists(options);

            Assert.IsNotNull(response);
            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public async Task ServiceClient_CreateFileSystem_WithConfiguration_SendsHeaders([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateContainerCreatedResponse());
            DataLakeServiceClient service = new DataLakeServiceClient(s_serviceUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            Response<DataLakeFileSystemClient> response = async
                ? await service.CreateFileSystemAsync("filesystem", options)
                : service.CreateFileSystem("filesystem", options);

            Assert.AreEqual("filesystem", response.Value.Name);
            MockRequest request = transport.SingleRequest;
            StringAssert.Contains("/filesystem", request.Uri.ToString());
            AssertHeader(request, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(request, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public void Create_FictitiousConfigurationName_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(404, "BlobAccessPointConfigurationNameNotFound"));
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationName = "doesnotexist",
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await fileSystem.CreateAsync(options);
                }
                else
                {
                    fileSystem.Create(options);
                }
            });

            Assert.AreEqual("BlobAccessPointConfigurationNameNotFound", ex.ErrorCode);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, "doesnotexist");
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, ConfigurationUniqueId);
        }

        [Test]
        public void Create_MismatchedConfigurationUniqueId_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(400, "BlobAccessPointConfigurationUniqueIdMismatch"));
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationName = ConfigurationName,
                BlobAccessPointConfigurationUniqueId = OtherConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await fileSystem.CreateAsync(options);
                }
                else
                {
                    fileSystem.Create(options);
                }
            });

            Assert.AreEqual("BlobAccessPointConfigurationUniqueIdMismatch", ex.ErrorCode);
            AssertHeader(transport.SingleRequest, ConfigurationNameHeader, ConfigurationName);
            AssertHeader(transport.SingleRequest, ConfigurationUniqueIdHeader, OtherConfigurationUniqueId);
        }

        [Test]
        public void Create_UniqueIdOnly_Throws([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateErrorResponse(400, "MissingRequiredHeader"));
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                BlobAccessPointConfigurationUniqueId = ConfigurationUniqueId,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (async)
                {
                    await fileSystem.CreateAsync(options);
                }
                else
                {
                    fileSystem.Create(options);
                }
            });

            Assert.AreEqual("MissingRequiredHeader", ex.ErrorCode);
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
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));

            Response<FileSystemProperties> response = async
                ? await fileSystem.GetPropertiesAsync()
                : fileSystem.GetProperties();

            Assert.AreEqual("account.blob.core.windows.net", transport.SingleRequest.Uri.Host);
            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.AreEqual(true, response.Value.IsBlobAccessPointContainer);
            Assert.AreEqual(ConfigurationName, response.Value.BlobAccessPointConfigurationName);
            Assert.AreEqual(ConfigurationUniqueId, response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetProperties_RegularContainer([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateGetPropertiesResponse(isBlobAccessPointContainer: false));
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));

            Response<FileSystemProperties> response = async
                ? await fileSystem.GetPropertiesAsync()
                : fileSystem.GetProperties();

            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.AreEqual(false, response.Value.IsBlobAccessPointContainer);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationName);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetProperties_HeaderNotReturned_IsNull([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateGetPropertiesResponse(isBlobAccessPointContainer: null));
            DataLakeFileSystemClient fileSystem = new DataLakeFileSystemClient(s_fileSystemUri, GetOptions(transport));

            Response<FileSystemProperties> response = async
                ? await fileSystem.GetPropertiesAsync()
                : fileSystem.GetProperties();

            Assert.AreEqual(new ETag(ContainerETag), response.Value.ETag);
            Assert.IsNull(response.Value.IsBlobAccessPointContainer);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationName);
            Assert.IsNull(response.Value.BlobAccessPointConfigurationUniqueId);
        }

        [Test]
        public async Task GetFileSystems_MapsBlobAccessPointProperties([Values(true, false)] bool async)
        {
            MockTransport transport = new MockTransport(_ => CreateListContainersResponse());
            DataLakeServiceClient service = new DataLakeServiceClient(s_serviceUri, GetOptions(transport));

            IList<FileSystemItem> fileSystems = async
                ? await service.GetFileSystemsAsync().ToListAsync()
                : service.GetFileSystems().ToList();

            Assert.AreEqual("account.blob.core.windows.net", transport.SingleRequest.Uri.Host);
            Assert.AreEqual(3, fileSystems.Count);

            FileSystemItem bapFileSystem = fileSystems.Single(f => f.Name == "bapfilesystem");
            Assert.AreEqual(new ETag("\"0x8DBAP\""), bapFileSystem.Properties.ETag);
            Assert.AreEqual(true, bapFileSystem.Properties.IsBlobAccessPointContainer);
            Assert.AreEqual(ConfigurationName, bapFileSystem.Properties.BlobAccessPointConfigurationName);
            Assert.AreEqual(ConfigurationUniqueId, bapFileSystem.Properties.BlobAccessPointConfigurationUniqueId);

            FileSystemItem regularFileSystem = fileSystems.Single(f => f.Name == "regularfilesystem");
            Assert.AreEqual(new ETag("\"0x8DREG\""), regularFileSystem.Properties.ETag);
            Assert.AreEqual(false, regularFileSystem.Properties.IsBlobAccessPointContainer);
            Assert.IsNull(regularFileSystem.Properties.BlobAccessPointConfigurationName);
            Assert.IsNull(regularFileSystem.Properties.BlobAccessPointConfigurationUniqueId);

            FileSystemItem notReturnedFileSystem = fileSystems.Single(f => f.Name == "notreturnedfilesystem");
            Assert.AreEqual(new ETag("\"0x8DNONE\""), notReturnedFileSystem.Properties.ETag);
            Assert.IsNull(notReturnedFileSystem.Properties.IsBlobAccessPointContainer);
            Assert.IsNull(notReturnedFileSystem.Properties.BlobAccessPointConfigurationName);
            Assert.IsNull(notReturnedFileSystem.Properties.BlobAccessPointConfigurationUniqueId);
        }
        #endregion

        #region Helpers
        private static DataLakeClientOptions GetOptions(MockTransport transport)
        {
            DataLakeClientOptions options = new DataLakeClientOptions { Transport = transport };
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
                "<Container><Name>bapfilesystem</Name><Properties>" +
                "<Last-Modified>Wed, 18 Nov 2026 01:20:48 GMT</Last-Modified><Etag>\"0x8DBAP\"</Etag>" +
                "<IsBlobAccessPointContainer>true</IsBlobAccessPointContainer>" +
                $"<BlobAccessPointConfigurationName>{ConfigurationName}</BlobAccessPointConfigurationName>" +
                $"<BlobAccessPointConfigurationUniqueId>{ConfigurationUniqueId}</BlobAccessPointConfigurationUniqueId>" +
                "</Properties></Container>" +
                "<Container><Name>regularfilesystem</Name><Properties>" +
                "<Last-Modified>Wed, 18 Nov 2026 01:20:48 GMT</Last-Modified><Etag>\"0x8DREG\"</Etag>" +
                "<IsBlobAccessPointContainer>false</IsBlobAccessPointContainer>" +
                "</Properties></Container>" +
                "<Container><Name>notreturnedfilesystem</Name><Properties>" +
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
