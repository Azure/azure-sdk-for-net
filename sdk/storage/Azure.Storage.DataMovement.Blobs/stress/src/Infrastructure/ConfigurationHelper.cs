// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    internal static class ConfigurationHelper
    {
        public static string Randomize(string prefix = "sample") =>
            $"{prefix}-{Guid.NewGuid()}";

        public static async Task<Stream> CreateLimitedMemoryStream(
            long size,
            long maxMemory = DataMovementBlobStressConstants.MB * 100,
            CancellationToken cancellationToken = default)
        {
            Stream stream =default;
            if (size < maxMemory)
            {
                var data = TestHelper.GetRandomBuffer(size);
                stream = new MemoryStream(data);
            }
            else
            {
                var path = Path.GetTempFileName();
                stream = new TemporaryFileStream(path, FileMode.Create);
                var bufferSize = 4 * DataMovementBlobStressConstants.KB;

                while (stream.Position + bufferSize < size)
                {
                    await stream.WriteAsync(
                        TestHelper.GetRandomBuffer(bufferSize),
                        0,
                        bufferSize,
                        cancellationToken);
                }
                if (stream.Position < size)
                {
                    await stream.WriteAsync(
                        TestHelper.GetRandomBuffer(size - stream.Position),
                        0,
                        (int)(size - stream.Position),
                        cancellationToken);
                }
                // reset the stream
                stream.Seek(0, SeekOrigin.Begin);
            }
            return stream;
        }

        public static async Task<StorageResource> GetTemporaryFileStorageResourceAsync(
            string prefixPath,
            string fileName = default,
            int bufferSize = DataMovementBlobStressConstants.MB,
            int fileSize = 4 * DataMovementBlobStressConstants.MB,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(prefixPath))
            {
                throw new ArgumentException("prefixPath cannot be null or empty", nameof(prefixPath));
            }
            fileName ??= Randomize("file-");

            // Create new source file
            Console.Out.WriteLine($"Creating Stream..");
            using Stream originalStream = await CreateLimitedMemoryStream(fileSize, cancellationToken: cancellationToken);
            Console.Out.WriteLine($"Stream Created..");
            Console.Out.WriteLine($"Creating Local File.. {prefixPath} + {fileName}");
            string localSourceFile = Path.Combine(prefixPath, fileName);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            Console.Out.Write($"Creating File: {localSourceFile}..");
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                Console.Out.WriteLine("Copying Stream to File..");
                await originalStream.CopyToAsync(
                    fileStream,
                    bufferSize,
                    cancellationToken: cancellationToken);
            }
            LocalFilesStorageResourceProvider files = new();
            return files.FromFile(localSourceFile);
        }
    }
}
