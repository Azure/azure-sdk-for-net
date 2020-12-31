// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal class ShareFileWriteStream : StorageWriteStream
    {
        private readonly ShareFileClient _fileClient;
        private readonly ShareFileRequestConditions _conditions;
        private long _writeIndex;

        public ShareFileWriteStream(
            ShareFileClient fileClient,
            long bufferSize,
            long position,
            ShareFileRequestConditions conditions,
            IProgress<long> progressHandler) : base(
                position,
                bufferSize,
                progressHandler)
        {
            ValidateBufferSize(bufferSize);
            _fileClient = fileClient;
            _conditions = conditions;
            _writeIndex = position;
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                HttpRange httpRange = new HttpRange(_writeIndex, _buffer.Length);

                if (async)
                {
                    await _fileClient.UploadRangeAsync(
                        range: httpRange,
                        content: _buffer,
                        progressHandler: _progressHandler,
                        conditions: _conditions,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    _fileClient.UploadRange(
                        range: httpRange,
                        content: _buffer,
                        progressHandler: _progressHandler,
                        conditions: _conditions,
                        cancellationToken: cancellationToken);
                }

                _writeIndex += _buffer.Length;
                _buffer.Clear();
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
            => await AppendInternal(async, cancellationToken).ConfigureAwait(false);

        protected override void ValidateBufferSize(long bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > Constants.File.MaxFileUpdateRange)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must <= {Constants.File.MaxFileUpdateRange}");
            }
        }
    }
}
