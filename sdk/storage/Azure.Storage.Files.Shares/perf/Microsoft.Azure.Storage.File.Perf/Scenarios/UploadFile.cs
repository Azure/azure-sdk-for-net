//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.File.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on uploading files to the Microsoft Azure File Shares storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadFile : PerfTest<SizeOptions>
    {
        /// <summary>
        /// Reference to the Share used by the test in the Microsoft Azure File service.
        /// </summary>
        private CloudFileShare _cloudFileShare;

        /// <summary>
        /// Reference to the file used by the test in the Microsoft Azure File service.
        /// </summary>
        private CloudFile _cloudFile;

        /// <summary>
        /// Local stream uploaded to Microsoft Azure File service.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(SizeOptions options) : base(options)
        {
            _stream = RandomStream.Create(options.Size);
        }

        public override void Dispose(bool disposing)
        {
            _stream.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Creates a cloud file share to be used by the test.
        /// Also, creates a file reference in the cloud file share.
        /// </summary>
        /// <returns></returns>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            PerfTestEnvironment testEnvironment = PerfTestEnvironment.Instance;
            _cloudFileShare = new CloudFileShare(new Uri($"{testEnvironment.FileShareAddressString}/{Guid.NewGuid()}"), testEnvironment.StorageCredentials);

            await _cloudFileShare.CreateAsync();

            _cloudFile = _cloudFileShare.GetRootDirectoryReference().GetFileReference(Path.GetRandomFileName());
            await _cloudFile.CreateAsync(Options.Size);
        }

        /// <summary>
        /// Deletes the cloud file share created by the test.
        /// </summary>
        public override async Task CleanupAsync()
        {
            await _cloudFileShare.DeleteAsync();
            await base.CleanupAsync();
        }

        /// <summary>
        /// Downloads a file from the Microsoft Azure File service by calling <see cref="CloudFile.UploadFromStream(Stream, AccessCondition, FileRequestOptions, OperationContext)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            _cloudFile.UploadFromStream(_stream);
        }

        /// <summary>
        /// Downloads a file from the Microsoft Azure File service by calling <see cref="CloudFile.UploadFromStreamAsync(Stream, AccessCondition, FileRequestOptions, OperationContext, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            await _cloudFile.UploadFromStreamAsync(_stream, cancellationToken);
        }
    }
}
