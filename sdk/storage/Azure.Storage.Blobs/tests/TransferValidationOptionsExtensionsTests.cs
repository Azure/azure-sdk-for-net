// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture]
    public class TransferValidationOptionsExtensionsTests
    {
        [Test]
        public void ResolveAuto_WhenAuto_ReturnsStorageCrc64()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.Auto;

            StorageChecksumAlgorithm result = algorithm.ResolveAuto();

            Assert.AreEqual(StorageChecksumAlgorithm.StorageCrc64, result);
        }

        [Test]
        public void ResolveAuto_WhenMD5_ReturnsMD5()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.MD5;

            StorageChecksumAlgorithm result = algorithm.ResolveAuto();

            Assert.AreEqual(StorageChecksumAlgorithm.MD5, result);
        }

        [Test]
        public void ResolveAuto_WhenStorageCrc64_ReturnsStorageCrc64()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.StorageCrc64;

            StorageChecksumAlgorithm result = algorithm.ResolveAuto();

            Assert.AreEqual(StorageChecksumAlgorithm.StorageCrc64, result);
        }

        [Test]
        public void ToValidationOptions_ByteArray_WhenNull_ReturnsDefault()
        {
            byte[] md5 = null;

            UploadTransferValidationOptions result = md5.ToValidationOptions();

            Assert.IsNull(result);
        }

        [Test]
        public void ToValidationOptions_ByteArray_WhenProvided_ReturnsOptionsWithMD5()
        {
            byte[] md5 = new byte[] { 1, 2, 3, 4 };

            UploadTransferValidationOptions result = md5.ToValidationOptions();

            Assert.IsNotNull(result);
            Assert.AreEqual(StorageChecksumAlgorithm.MD5, result.ChecksumAlgorithm);
            Assert.AreEqual(md5, result.PrecalculatedChecksum.ToArray());
        }

        [Test]
        public void ToValidationOptions_Bool_WhenFalse_ReturnsDefault()
        {
            bool requestTransactionalMD5 = false;

            DownloadTransferValidationOptions result = requestTransactionalMD5.ToValidationOptions();

            Assert.IsNull(result);
        }

        [Test]
        public void ToValidationOptions_Bool_WhenTrue_ReturnsOptionsWithMD5AndNoAutoValidate()
        {
            bool requestTransactionalMD5 = true;

            DownloadTransferValidationOptions result = requestTransactionalMD5.ToValidationOptions();

            Assert.IsNotNull(result);
            Assert.AreEqual(StorageChecksumAlgorithm.MD5, result.ChecksumAlgorithm);
            Assert.IsFalse(result.AutoValidateChecksum);
        }

        [Test]
        public void CopyTo_UploadTransferValidationOptions_CopiesAllProperties()
        {
            byte[] checksum = new byte[] { 5, 6, 7, 8 };
            var source = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                PrecalculatedChecksum = checksum
            };
            var dest = new UploadTransferValidationOptions();

            source.CopyTo(dest);

            Assert.AreEqual(StorageChecksumAlgorithm.MD5, dest.ChecksumAlgorithm);
            Assert.AreEqual(checksum, dest.PrecalculatedChecksum.ToArray());
        }

        [Test]
        public void CopyTo_DownloadTransferValidationOptions_CopiesAllProperties()
        {
            var source = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                AutoValidateChecksum = false
            };
            var dest = new DownloadTransferValidationOptions();

            source.CopyTo(dest);

            Assert.AreEqual(StorageChecksumAlgorithm.StorageCrc64, dest.ChecksumAlgorithm);
            Assert.IsFalse(dest.AutoValidateChecksum);
        }
    }
}
