using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;
using NSubstitute;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    public class OutputFileReferenceUnitTests
    {
        [Fact]
        public void FilePathReflectsStoragePath_JobStorage()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();
            fakeBlob.Uri.Returns(new Uri("https://x.blob.core.windows.net/job-someid/$JobOutput/movie.mp4"));

            var reference = new OutputFileReference(fakeBlob);

            Assert.Equal("movie.mp4", reference.FilePath);
        }

        [Fact]
        public void FilePathReflectsStoragePath_TaskStorage()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();
            fakeBlob.Uri.Returns(new Uri("https://x.blob.core.windows.net/job-someid/sometaskid/$TaskLog/stdout.txt"));

            var reference = new OutputFileReference(fakeBlob);

            Assert.Equal("stdout.txt", reference.FilePath);
        }

        [Fact]
        public void FilePathReflectsStoragePath_Multilevel()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();
            fakeBlob.Uri.Returns(new Uri("https://x.blob.core.windows.net/job-someid/$JobOutput/how/deep/does/this/go.txt"));

            var reference = new OutputFileReference(fakeBlob);

            Assert.Equal("how/deep/does/this/go.txt", reference.FilePath);
        }

        [Fact]
        public void UriReflectsBlobUri()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();
            fakeBlob.Uri.Returns(new Uri("https://x.blob.core.windows.net/job-someid/$JobOutput/movie.mp4"));

            var reference = new OutputFileReference(fakeBlob);

            Assert.Equal(fakeBlob.Uri, reference.Uri);
        }

        [Fact]
        public void UnderlyingBlobReflectsConstructorParameter()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            Assert.Equal(fakeBlob, reference.CloudBlob);
        }

        [Fact]
        public async Task Delete_Abstraction_ForwardsToUnderlyingBlob()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            await reference.DeleteAsync();

            await fakeBlob.Received().DeleteAsync(CancellationToken.None);
        }

        [Fact]
        public async Task DownloadToByteArray_Abstraction_ForwardsToUnderlyingBlob()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            byte[] target = new byte[0];
            await reference.DownloadToByteArrayAsync(target, 0);

            await fakeBlob.Received().DownloadToByteArrayAsync(target, 0, CancellationToken.None);
        }

        [Fact]
        public async Task DownloadToFile_Abstraction_ForwardsToUnderlyingBlob()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            await reference.DownloadToFileAsync("file", FileMode.Create);

            await fakeBlob.Received().DownloadToFileAsync("file", FileMode.Create, CancellationToken.None);
        }

        [Fact]
        public async Task DownloadToStream_Abstraction_ForwardsToUnderlyingBlob()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            using (var stream = new MemoryStream())
            {
                await reference.DownloadToStreamAsync(stream);

                await fakeBlob.Received().DownloadToStreamAsync(stream, CancellationToken.None);
            }
        }

        [Fact]
        public async Task OpenRead_Abstraction_ForwardsToUnderlyingBlob()
        {
            var fakeBlob = Substitute.For<ICloudBlob>();

            var reference = new OutputFileReference(fakeBlob);

            await reference.OpenReadAsync();

            await fakeBlob.Received().OpenReadAsync(CancellationToken.None);
        }
    }
}
