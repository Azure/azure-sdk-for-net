// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ContentHasherTests
    {
        public enum DataType
        {
            Stream,
            BinaryData
        }

        public bool IsAsync { get; }

        public ContentHasherTests(bool async)
        {
            IsAsync = async;
        }

        public static IEnumerable<DataType> GetDataTypes()
            => new HashSet<DataType>(Enum.GetValues(typeof(DataType)).Cast<DataType>());

        public static IEnumerable<StorageChecksumAlgorithm> GetValidationAlgorithms()
        {
            var values = new HashSet<StorageChecksumAlgorithm>(Enum.GetValues(typeof(StorageChecksumAlgorithm))
                .Cast<StorageChecksumAlgorithm>());
            values.Remove(StorageChecksumAlgorithm.None);
            return values;
        }

        [Test]
        [Combinatorial]
        public async Task GetHashOrDefaultChecksOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
            [ValueSource(nameof(GetDataTypes))] DataType dataType)
        {
            // Given data and options with precalculated checksum
            var stream = new Mock<Stream>();
            var binaryData = new Mock<BinaryData>("hello world");

            var precalculatedChecksum = new byte[8];
            new Random().NextBytes(precalculatedChecksum);

            var options = new UploadTransferValidationOptions()
            {
                ChecksumAlgorithm = algorithm,
                PrecalculatedChecksum = precalculatedChecksum
            };

            // Get hash
            var result = dataType switch
            {
                DataType.Stream => await ContentHasher.GetHashOrDefaultInternal(stream.Object, options, IsAsync, default),
                DataType.BinaryData => ContentHasher.GetHashOrDefault(binaryData.Object, options),
                _ => throw new NotImplementedException(),
            };

            // Assert
            stream.VerifyNoOtherCalls();
            binaryData.VerifyNoOtherCalls();
            CollectionAssert.AreEqual(precalculatedChecksum, result.Checksum.ToArray());
        }

        [Test]
        [Combinatorial]
        public async Task GetHashOrDefaultCalculatesChecksum(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
            [ValueSource(nameof(GetDataTypes))] DataType dataType)
        {
            // Given data and an independently calculated checksum
            var data = new byte[1024];
            new Random().NextBytes(data);

            var dataChecksum = algorithm.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.MD5 => MD5.Create().ComputeHash(data),
                StorageChecksumAlgorithm.StorageCrc64 => CrcInline(data),
                _ => throw new NotImplementedException("Test not implemented for given algorithm."),
            };

            var options = new UploadTransferValidationOptions()
            {
                ChecksumAlgorithm = algorithm
            };

            // Get hash
            var result = dataType switch
            {
                DataType.Stream => await ContentHasher.GetHashOrDefaultInternal(new MemoryStream(data), options, IsAsync, default),
                DataType.BinaryData => ContentHasher.GetHashOrDefault(BinaryData.FromBytes(data), options),
                _ => throw new NotImplementedException(),
            };

            // Assert
            CollectionAssert.AreEqual(dataChecksum, result.Checksum.ToArray());
        }

        private static byte[] CrcInline(byte[] data)
        {
            var crc = StorageCrc64HashAlgorithm.Create();
            crc.Append(data);
            return crc.GetCurrentHash();
        }
    }
}
