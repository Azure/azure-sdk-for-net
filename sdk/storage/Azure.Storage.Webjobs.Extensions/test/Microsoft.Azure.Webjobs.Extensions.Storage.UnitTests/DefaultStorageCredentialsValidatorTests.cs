// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.Storage;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Executors
{
    public class DefaultStorageCredentialsValidatorTests
    {
        [Fact]
        public void UseReflectionToAccessIsDevStoreAccountFromCloudStorageAccount()
        {
            var isDevStoreAccountProperty = typeof(CloudStorageAccount).GetProperty("IsDevStoreAccount", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(isDevStoreAccountProperty);
        }

        [Theory(Skip = "Missing StorageCredentialsValidator")]
        [InlineData("UseDevelopmentStorage=true")]
        [InlineData("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://myProxyUri")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void StorageAccount_IsDevStoreAccount_StorageEmulatorRunning(string connectionString)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            //var validator = new DefaultStorageCredentialsValidator();

            //var storageMock = new Mock<IStorageAccount>(MockBehavior.Strict);
            //var blobClientMock = new Mock<IStorageBlobClient>();
            //var queueClientMock = new Mock<IStorageQueueClient>();
            //var queueMock = new Mock<IStorageQueue>();

            //storageMock.Setup(s => s.Credentials)
            //    .Returns(new StorageCredentials("name", string.Empty));

            //storageMock.Setup(s => s.CreateBlobClient(null))
            //    .Returns(blobClientMock.Object)
            //    .Verifiable();

            //storageMock.Setup(s => s.SdkObject)
            //    .Returns(() => CloudStorageAccount.Parse(connectionString));

            //blobClientMock.Setup(b => b.GetServicePropertiesAsync(It.IsAny<CancellationToken>()))
            //    .Throws(new StorageException(""));

            //var exception = Assert.Throws<InvalidOperationException>(() => validator.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()).GetAwaiter().GetResult());
            //Assert.Equal(Constants.CheckAzureStorageEmulatorMessage, exception.Message);
            //storageMock.Verify();
        }

        [Fact(Skip = "Missing StorageCredentialsValidator")]
        public void StorageAccount_GetPropertiesThrows_InvalidCredentials()
        {
            //var validator = new DefaultStorageCredentialsValidator();

            //var storageMock = new Mock<IStorageAccount>(MockBehavior.Strict);
            //var blobClientMock = new Mock<IStorageBlobClient>();
            //var queueClientMock = new Mock<IStorageQueueClient>();
            //var queueMock = new Mock<IStorageQueue>();

            //storageMock.Setup(s => s.Credentials)
            //    .Returns(new StorageCredentials("name", string.Empty));

            //storageMock.Setup(s => s.CreateBlobClient(null))
            //    .Returns(blobClientMock.Object)
            //    .Verifiable();

            //storageMock.Setup(s => s.SdkObject)
            //    .Returns(new CloudStorageAccount(new StorageCredentials("name", string.Empty), false));

            //blobClientMock.Setup(b => b.GetServicePropertiesAsync(It.IsAny<CancellationToken>()))
            //    .Throws(new StorageException(""));

            //var exception = Assert.Throws<InvalidOperationException>(() => validator.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()).GetAwaiter().GetResult());
            //Assert.Equal("Invalid storage account 'name'. Please make sure your credentials are correct.", exception.Message);
            //storageMock.Verify();
        }

        [Fact(Skip = "Missing StorageCredentialsValidator")]
        public void StorageAccount_QueueCheckThrows_BlobOnly_WhenCatchingNameResolutionFailure()
        {
            //var validator = new DefaultStorageCredentialsValidator();

            //var storageMock = new Mock<IStorageAccount>(MockBehavior.Strict);
            //var blobClientMock = new Mock<IStorageBlobClient>();
            //var queueClientMock = new Mock<IStorageQueueClient>();
            //var queueMock = new Mock<IStorageQueue>();

            //storageMock.Setup(s => s.Credentials)
            //    .Returns(new StorageCredentials());

            //storageMock.Setup(s => s.CreateBlobClient(null))
            //    .Returns(blobClientMock.Object)
            //    .Verifiable();

            //blobClientMock.Setup(b => b.GetServicePropertiesAsync(It.IsAny<CancellationToken>()))
            //    .ReturnsAsync((ServiceProperties)null);

            //storageMock.Setup(s => s.CreateQueueClient(null))
            //    .Returns(queueClientMock.Object)
            //    .Verifiable();

            //queueClientMock.Setup(q => q.GetQueueReference(It.IsAny<string>()))
            //    .Returns(queueMock.Object);

            //queueMock.Setup(q => q.ExistsAsync(It.IsAny<CancellationToken>()))
            //    .Throws(new StorageException("", new WebException("Remote name could not be resolved", WebExceptionStatus.NameResolutionFailure)));

            //storageMock.SetupSet(s => s.Type = StorageAccountType.BlobOnly);

            //validator.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()).GetAwaiter().GetResult();

            //storageMock.Verify();
        }

        [Fact(Skip = "Missing StorageCredentialsValidator")]
        public void StorageAccount_QueueCheckThrows_BlobOnly_WhenCatchingWinHttpNameNotResolved()
        {
            //var validator = new DefaultStorageCredentialsValidator();

            //var storageMock = new Mock<IStorageAccount>(MockBehavior.Strict);
            //var blobClientMock = new Mock<IStorageBlobClient>();
            //var queueClientMock = new Mock<IStorageQueueClient>();
            //var queueMock = new Mock<IStorageQueue>();

            //storageMock.Setup(s => s.Credentials)
            //    .Returns(new StorageCredentials());

            //storageMock.Setup(s => s.CreateBlobClient(null))
            //    .Returns(blobClientMock.Object)
            //    .Verifiable();

            //blobClientMock.Setup(b => b.GetServicePropertiesAsync(It.IsAny<CancellationToken>()))
            //    .ReturnsAsync((ServiceProperties)null);

            //storageMock.Setup(s => s.CreateQueueClient(null))
            //    .Returns(queueClientMock.Object)
            //    .Verifiable();

            //queueClientMock.Setup(q => q.GetQueueReference(It.IsAny<string>()))
            //    .Returns(queueMock.Object);

            //queueMock.Setup(q => q.ExistsAsync(It.IsAny<CancellationToken>()))
            //    .Throws(new StorageException("", new MockHttpRequestException(0x2ee7)));

            //storageMock.SetupSet(s => s.Type = StorageAccountType.BlobOnly);

            //validator.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()).GetAwaiter().GetResult();

            //storageMock.Verify();
        }

        [Fact(Skip = "Missing StorageCredentialsValidator")]
        public void StorageAccount_QueueCheckThrowsUnexpectedStorage()
        {
            //var validator = new DefaultStorageCredentialsValidator();

            //var storageMock = new Mock<IStorageAccount>(MockBehavior.Strict);
            //var blobClientMock = new Mock<IStorageBlobClient>();
            //var queueClientMock = new Mock<IStorageQueueClient>();
            //var queueMock = new Mock<IStorageQueue>();

            //storageMock.Setup(s => s.Credentials)
            //    .Returns(new StorageCredentials());

            //storageMock.Setup(s => s.CreateBlobClient(null))
            //    .Returns(blobClientMock.Object)
            //    .Verifiable();

            //blobClientMock.Setup(b => b.GetServicePropertiesAsync(It.IsAny<CancellationToken>()))
            //    .ReturnsAsync((ServiceProperties)null);

            //storageMock.Setup(s => s.CreateQueueClient(null))
            //    .Returns(queueClientMock.Object)
            //    .Verifiable();

            //queueClientMock.Setup(q => q.GetQueueReference(It.IsAny<string>()))
            //    .Returns(queueMock.Object);

            //queueMock.Setup(q => q.ExistsAsync(It.IsAny<CancellationToken>()))
            //    .Throws(new StorageException("some other storage exception", null));

            //var storageException = Assert.Throws<StorageException>(() => validator.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()).GetAwaiter().GetResult());
            //Assert.Equal("some other storage exception", storageException.Message);
            //storageMock.Verify();
        }

        internal class MockHttpRequestException : HttpRequestException
        {
            public MockHttpRequestException(int hresult)
            {
                HResult = hresult;
            }
        }
    }
}
