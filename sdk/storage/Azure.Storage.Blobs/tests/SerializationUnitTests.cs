// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class SerializationUnitTests
    {
        private static readonly ModelReaderWriterOptions XmlOptions = new ModelReaderWriterOptions("X");

        #region SkuName
        private static object[] SkuNameCases =
        {
            new object[] { SkuName.StandardLrs, "Standard_LRS" },
            new object[] { SkuName.StandardGrs, "Standard_GRS" },
            new object[] { SkuName.StandardRagrs, "Standard_RAGRS" },
            new object[] { SkuName.StandardZrs, "Standard_ZRS" },
            new object[] { SkuName.PremiumLrs, "Premium_LRS" },
            new object[] { SkuName.StandardGzrs, "Standard_GZRS" },
            new object[] { SkuName.PremiumZrs, "Premium_ZRS" },
            new object[] { SkuName.StandardRagzrs, "Standard_RAGZRS" },
        };

        [TestCaseSource(nameof(SkuNameCases))]
        public void SkuName_SerializesCorrectly(SkuName enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(SkuNameCases))]
        public void SkuName_DeserializesCorrectly(SkuName expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToSkuName());
        }

        [TestCaseSource(nameof(SkuNameCases))]
        public void SkuName_RoundTrips(SkuName enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToSkuName());
        }

        [Test]
        public void SkuName_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((SkuName)999).ToSerialString());
        }

        [Test]
        public void SkuName_ToSkuName_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Not_A_Sku".ToSkuName());
        }
        #endregion

        #region BlobType
        private static object[] BlobTypeCases =
        {
            new object[] { BlobType.Block, "BlockBlob" },
            new object[] { BlobType.Page, "PageBlob" },
            new object[] { BlobType.Append, "AppendBlob" },
        };

        [TestCaseSource(nameof(BlobTypeCases))]
        public void BlobType_SerializesCorrectly(BlobType enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(BlobTypeCases))]
        public void BlobType_DeserializesCorrectly(BlobType expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToBlobType());
        }

        [TestCaseSource(nameof(BlobTypeCases))]
        public void BlobType_RoundTrips(BlobType enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToBlobType());
        }

        [Test]
        public void BlobType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((BlobType)999).ToSerialString());
        }

        [Test]
        public void BlobType_ToBlobType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "UnknownBlob".ToBlobType());
        }
        #endregion

        #region PublicAccessType
        private static object[] PublicAccessTypeCases =
        {
            new object[] { PublicAccessType.Blob, "blob" },
            new object[] { PublicAccessType.BlobContainer, "container" },
        };

        [TestCaseSource(nameof(PublicAccessTypeCases))]
        public void PublicAccessType_SerializesCorrectly(PublicAccessType enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(PublicAccessTypeCases))]
        public void PublicAccessType_DeserializesCorrectly(PublicAccessType expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToPublicAccessType());
        }

        [TestCaseSource(nameof(PublicAccessTypeCases))]
        public void PublicAccessType_RoundTrips(PublicAccessType enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToPublicAccessType());
        }

        [Test]
        public void PublicAccessType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((PublicAccessType)999).ToSerialString());
        }

        [Test]
        public void PublicAccessType_ToPublicAccessType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToPublicAccessType());
        }
        #endregion

        #region BlockListType
        private static object[] BlockListTypeCases =
        {
            new object[] { BlockListType.Committed, "committed" },
            new object[] { BlockListType.Uncommitted, "uncommitted" },
            new object[] { BlockListType.All, "all" },
        };

        [TestCaseSource(nameof(BlockListTypeCases))]
        public void BlockListType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((BlockListType)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(BlockListTypeCases))]
        public void BlockListType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToBlockListType());
        }

        [TestCaseSource(nameof(BlockListTypeCases))]
        public void BlockListType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((BlockListType)enumValue).ToSerialString().ToBlockListType());
        }

        [Test]
        public void BlockListType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((BlockListType)999).ToSerialString());
        }

        [Test]
        public void BlockListType_ToBlockListType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToBlockListType());
        }
        #endregion

        #region EncryptionAlgorithmTypeInternal
        private static object[] EncryptionAlgorithmTypeInternalCases =
        {
            new object[] { EncryptionAlgorithmTypeInternal.None, "None" },
            new object[] { EncryptionAlgorithmTypeInternal.AES256, "AES256" },
        };

        [TestCaseSource(nameof(EncryptionAlgorithmTypeInternalCases))]
        public void EncryptionAlgorithmTypeInternal_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((EncryptionAlgorithmTypeInternal)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(EncryptionAlgorithmTypeInternalCases))]
        public void EncryptionAlgorithmTypeInternal_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToEncryptionAlgorithmTypeInternal());
        }

        [TestCaseSource(nameof(EncryptionAlgorithmTypeInternalCases))]
        public void EncryptionAlgorithmTypeInternal_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((EncryptionAlgorithmTypeInternal)enumValue).ToSerialString().ToEncryptionAlgorithmTypeInternal());
        }

        [Test]
        public void EncryptionAlgorithmTypeInternal_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((EncryptionAlgorithmTypeInternal)999).ToSerialString());
        }

        [Test]
        public void EncryptionAlgorithmTypeInternal_ToEncryptionAlgorithmTypeInternal_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "RSA".ToEncryptionAlgorithmTypeInternal());
        }
        #endregion

        #region CopyStatus
        private static object[] CopyStatusCases =
        {
            new object[] { CopyStatus.Pending, "pending" },
            new object[] { CopyStatus.Success, "success" },
            new object[] { CopyStatus.Failed, "failed" },
            new object[] { CopyStatus.Aborted, "aborted" },
        };

        [TestCaseSource(nameof(CopyStatusCases))]
        public void CopyStatus_SerializesCorrectly(CopyStatus enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(CopyStatusCases))]
        public void CopyStatus_DeserializesCorrectly(CopyStatus expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToCopyStatus());
        }

        [TestCaseSource(nameof(CopyStatusCases))]
        public void CopyStatus_RoundTrips(CopyStatus enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToCopyStatus());
        }

        [Test]
        public void CopyStatus_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((CopyStatus)999).ToSerialString());
        }

        [Test]
        public void CopyStatus_ToCopyStatus_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToCopyStatus());
        }
        #endregion

        #region LeaseState
        private static object[] LeaseStateCases =
        {
            new object[] { LeaseState.Available, "available" },
            new object[] { LeaseState.Leased, "leased" },
            new object[] { LeaseState.Expired, "expired" },
            new object[] { LeaseState.Breaking, "breaking" },
            new object[] { LeaseState.Broken, "broken" },
        };

        [TestCaseSource(nameof(LeaseStateCases))]
        public void LeaseState_SerializesCorrectly(LeaseState enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(LeaseStateCases))]
        public void LeaseState_DeserializesCorrectly(LeaseState expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToLeaseState());
        }

        [TestCaseSource(nameof(LeaseStateCases))]
        public void LeaseState_RoundTrips(LeaseState enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToLeaseState());
        }

        [Test]
        public void LeaseState_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((LeaseState)999).ToSerialString());
        }

        [Test]
        public void LeaseState_ToLeaseState_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToLeaseState());
        }
        #endregion

        #region LeaseStatus
        private static object[] LeaseStatusCases =
        {
            new object[] { LeaseStatus.Unlocked, "unlocked" },
            new object[] { LeaseStatus.Locked, "locked" },
        };

        [TestCaseSource(nameof(LeaseStatusCases))]
        public void LeaseStatus_SerializesCorrectly(LeaseStatus enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(LeaseStatusCases))]
        public void LeaseStatus_DeserializesCorrectly(LeaseStatus expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToLeaseStatus());
        }

        [TestCaseSource(nameof(LeaseStatusCases))]
        public void LeaseStatus_RoundTrips(LeaseStatus enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToLeaseStatus());
        }

        [Test]
        public void LeaseStatus_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((LeaseStatus)999).ToSerialString());
        }

        [Test]
        public void LeaseStatus_ToLeaseStatus_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToLeaseStatus());
        }
        #endregion

        #region LeaseDurationType
        private static object[] LeaseDurationTypeCases =
        {
            new object[] { LeaseDurationType.Infinite, "infinite" },
            new object[] { LeaseDurationType.Fixed, "fixed" },
        };

        [TestCaseSource(nameof(LeaseDurationTypeCases))]
        public void LeaseDurationType_SerializesCorrectly(LeaseDurationType enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(LeaseDurationTypeCases))]
        public void LeaseDurationType_DeserializesCorrectly(LeaseDurationType expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToLeaseDurationType());
        }

        [TestCaseSource(nameof(LeaseDurationTypeCases))]
        public void LeaseDurationType_RoundTrips(LeaseDurationType enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToLeaseDurationType());
        }

        [Test]
        public void LeaseDurationType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((LeaseDurationType)999).ToSerialString());
        }

        [Test]
        public void LeaseDurationType_ToLeaseDurationType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToLeaseDurationType());
        }
        #endregion

        #region DeleteSnapshotsOption
        private static object[] DeleteSnapshotsOptionCases =
        {
            new object[] { DeleteSnapshotsOption.OnlySnapshots, "only" },
            new object[] { DeleteSnapshotsOption.IncludeSnapshots, "include" },
        };

        [TestCaseSource(nameof(DeleteSnapshotsOptionCases))]
        public void DeleteSnapshotsOption_SerializesCorrectly(DeleteSnapshotsOption enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(DeleteSnapshotsOptionCases))]
        public void DeleteSnapshotsOption_DeserializesCorrectly(DeleteSnapshotsOption expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToDeleteSnapshotsOption());
        }

        [TestCaseSource(nameof(DeleteSnapshotsOptionCases))]
        public void DeleteSnapshotsOption_RoundTrips(DeleteSnapshotsOption enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToDeleteSnapshotsOption());
        }

        [Test]
        public void DeleteSnapshotsOption_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((DeleteSnapshotsOption)999).ToSerialString());
        }

        [Test]
        public void DeleteSnapshotsOption_ToDeleteSnapshotsOption_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToDeleteSnapshotsOption());
        }
        #endregion

        #region ArchiveStatus
        private static object[] ArchiveStatusCases =
        {
            new object[] { ArchiveStatus.RehydratePendingToHot, "rehydrate-pending-to-hot" },
            new object[] { ArchiveStatus.RehydratePendingToCool, "rehydrate-pending-to-cool" },
            new object[] { ArchiveStatus.RehydratePendingToCold, "rehydrate-pending-to-cold" },
            new object[] { ArchiveStatus.RehydratePendingToSmart, "rehydrate-pending-to-smart" },
        };

        [TestCaseSource(nameof(ArchiveStatusCases))]
        public void ArchiveStatus_SerializesCorrectly(ArchiveStatus enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(ArchiveStatusCases))]
        public void ArchiveStatus_DeserializesCorrectly(ArchiveStatus expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToArchiveStatus());
        }

        [TestCaseSource(nameof(ArchiveStatusCases))]
        public void ArchiveStatus_RoundTrips(ArchiveStatus enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToArchiveStatus());
        }

        [Test]
        public void ArchiveStatus_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ArchiveStatus)999).ToSerialString());
        }

        [Test]
        public void ArchiveStatus_ToArchiveStatus_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToArchiveStatus());
        }
        #endregion

        #region SequenceNumberAction
        private static object[] SequenceNumberActionCases =
        {
            new object[] { SequenceNumberAction.Increment, "increment" },
            new object[] { SequenceNumberAction.Max, "max" },
            new object[] { SequenceNumberAction.Update, "update" },
        };

        [TestCaseSource(nameof(SequenceNumberActionCases))]
        public void SequenceNumberAction_SerializesCorrectly(SequenceNumberAction enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(SequenceNumberActionCases))]
        public void SequenceNumberAction_DeserializesCorrectly(SequenceNumberAction expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToSequenceNumberAction());
        }

        [TestCaseSource(nameof(SequenceNumberActionCases))]
        public void SequenceNumberAction_RoundTrips(SequenceNumberAction enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToSequenceNumberAction());
        }

        [Test]
        public void SequenceNumberAction_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((SequenceNumberAction)999).ToSerialString());
        }

        [Test]
        public void SequenceNumberAction_ToSequenceNumberAction_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToSequenceNumberAction());
        }
        #endregion

        #region RehydratePriority
        private static object[] RehydratePriorityCases =
        {
            new object[] { RehydratePriority.High, "High" },
            new object[] { RehydratePriority.Standard, "Standard" },
        };

        [TestCaseSource(nameof(RehydratePriorityCases))]
        public void RehydratePriority_SerializesCorrectly(RehydratePriority enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(RehydratePriorityCases))]
        public void RehydratePriority_DeserializesCorrectly(RehydratePriority expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToRehydratePriority());
        }

        [TestCaseSource(nameof(RehydratePriorityCases))]
        public void RehydratePriority_RoundTrips(RehydratePriority enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToRehydratePriority());
        }

        [Test]
        public void RehydratePriority_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((RehydratePriority)999).ToSerialString());
        }

        [Test]
        public void RehydratePriority_ToRehydratePriority_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentException>(() => "unknown".ToRehydratePriority());
        }
        #endregion

        #region AccountKind
        private static object[] AccountKindCases =
        {
            new object[] { AccountKind.Storage, "Storage" },
            new object[] { AccountKind.BlobStorage, "BlobStorage" },
            new object[] { AccountKind.StorageV2, "StorageV2" },
            new object[] { AccountKind.FileStorage, "FileStorage" },
            new object[] { AccountKind.BlockBlobStorage, "BlockBlobStorage" },
        };

        [TestCaseSource(nameof(AccountKindCases))]
        public void AccountKind_SerializesCorrectly(AccountKind enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(AccountKindCases))]
        public void AccountKind_DeserializesCorrectly(AccountKind expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToAccountKind());
        }

        [TestCaseSource(nameof(AccountKindCases))]
        public void AccountKind_RoundTrips(AccountKind enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToAccountKind());
        }

        [Test]
        public void AccountKind_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((AccountKind)999).ToSerialString());
        }

        [Test]
        public void AccountKind_ToAccountKind_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "UnknownKind".ToAccountKind());
        }
        #endregion

        #region BlobDeleteType
        private static object[] BlobDeleteTypeCases =
        {
            new object[] { BlobDeleteType.None, "None" },
            new object[] { BlobDeleteType.Permanent, "Permanent" },
        };

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((BlobDeleteType)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToBlobDeleteType());
        }

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((BlobDeleteType)enumValue).ToSerialString().ToBlobDeleteType());
        }

        [Test]
        public void BlobDeleteType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((BlobDeleteType)999).ToSerialString());
        }

        [Test]
        public void BlobDeleteType_ToBlobDeleteType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Unknown".ToBlobDeleteType());
        }
        #endregion

        #region BlobImmutabilityPolicyMode
        private static object[] BlobImmutabilityPolicyModeCases =
        {
            new object[] { BlobImmutabilityPolicyMode.Mutable, "mutable" },
            new object[] { BlobImmutabilityPolicyMode.Locked, "locked" },
            new object[] { BlobImmutabilityPolicyMode.Unlocked, "unlocked" },
        };

        [TestCaseSource(nameof(BlobImmutabilityPolicyModeCases))]
        public void BlobImmutabilityPolicyMode_SerializesCorrectly(BlobImmutabilityPolicyMode enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(BlobImmutabilityPolicyModeCases))]
        public void BlobImmutabilityPolicyMode_DeserializesCorrectly(BlobImmutabilityPolicyMode expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToBlobImmutabilityPolicyMode());
        }

        [TestCaseSource(nameof(BlobImmutabilityPolicyModeCases))]
        public void BlobImmutabilityPolicyMode_RoundTrips(BlobImmutabilityPolicyMode enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToBlobImmutabilityPolicyMode());
        }

        [Test]
        public void BlobImmutabilityPolicyMode_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((BlobImmutabilityPolicyMode)999).ToSerialString());
        }

        [Test]
        public void BlobImmutabilityPolicyMode_ToBlobImmutabilityPolicyMode_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToBlobImmutabilityPolicyMode());
        }
        #endregion

        #region FilterBlobsIncludeItem
        private static object[] FilterBlobsIncludeItemCases =
        {
            new object[] { FilterBlobsIncludeItem.None, "none" },
            new object[] { FilterBlobsIncludeItem.Versions, "versions" },
        };

        [TestCaseSource(nameof(FilterBlobsIncludeItemCases))]
        public void FilterBlobsIncludeItem_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((FilterBlobsIncludeItem)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(FilterBlobsIncludeItemCases))]
        public void FilterBlobsIncludeItem_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToFilterBlobsIncludeItem());
        }

        [TestCaseSource(nameof(FilterBlobsIncludeItemCases))]
        public void FilterBlobsIncludeItem_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((FilterBlobsIncludeItem)enumValue).ToSerialString().ToFilterBlobsIncludeItem());
        }

        [Test]
        public void FilterBlobsIncludeItem_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((FilterBlobsIncludeItem)999).ToSerialString());
        }

        [Test]
        public void FilterBlobsIncludeItem_ToFilterBlobsIncludeItem_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToFilterBlobsIncludeItem());
        }
        #endregion

        #region QueryFormatType
        private static object[] QueryFormatTypeCases =
        {
            new object[] { QueryFormatType.Delimited, "delimited" },
            new object[] { QueryFormatType.Json, "json" },
            new object[] { QueryFormatType.Arrow, "arrow" },
            new object[] { QueryFormatType.Parquet, "parquet" },
        };

        [TestCaseSource(nameof(QueryFormatTypeCases))]
        public void QueryFormatType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((QueryFormatType)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(QueryFormatTypeCases))]
        public void QueryFormatType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToQueryFormatType());
        }

        [TestCaseSource(nameof(QueryFormatTypeCases))]
        public void QueryFormatType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((QueryFormatType)enumValue).ToSerialString().ToQueryFormatType());
        }

        [Test]
        public void QueryFormatType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((QueryFormatType)999).ToSerialString());
        }

        [Test]
        public void QueryFormatType_ToQueryFormatType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToQueryFormatType());
        }
        #endregion

        #region ListContainersIncludeType
        private static object[] ListContainersIncludeTypeCases =
        {
            new object[] { ListContainersIncludeType.Metadata, "metadata" },
            new object[] { ListContainersIncludeType.Deleted, "deleted" },
            new object[] { ListContainersIncludeType.System, "system" },
        };

        [TestCaseSource(nameof(ListContainersIncludeTypeCases))]
        public void ListContainersIncludeType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((ListContainersIncludeType)enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(ListContainersIncludeTypeCases))]
        public void ListContainersIncludeType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToListContainersIncludeType());
        }

        [TestCaseSource(nameof(ListContainersIncludeTypeCases))]
        public void ListContainersIncludeType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((ListContainersIncludeType)enumValue).ToSerialString().ToListContainersIncludeType());
        }

        [Test]
        public void ListContainersIncludeType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ListContainersIncludeType)999).ToSerialString());
        }

        [Test]
        public void ListContainersIncludeType_ToListContainersIncludeType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToListContainersIncludeType());
        }
        #endregion

        // =====================================================================
        // MODEL XML SERIALIZATION TESTS (IPersistableModel Write/Create round-trips)
        // =====================================================================

        #region Helper
        /// <summary>
        /// Round-trips a model through IPersistableModel Write → Create and returns the deserialized instance.
        /// </summary>
        private static T RoundTripXml<T>(T model) where T : IPersistableModel<T>
        {
            BinaryData data = model.Write(XmlOptions);
            return model.Create(data, XmlOptions);
        }
        #endregion

        #region BlobAccessPolicy
        [Test]
        public void BlobAccessPolicy_XmlRoundTrip()
        {
            var original = new BlobAccessPolicy
            {
                PolicyStartsOn = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                PolicyExpiresOn = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero),
                Permissions = "rwd"
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.PolicyStartsOn, result.PolicyStartsOn);
            Assert.AreEqual(original.PolicyExpiresOn, result.PolicyExpiresOn);
            Assert.AreEqual(original.Permissions, result.Permissions);
        }

        [Test]
        public void BlobAccessPolicy_XmlRoundTrip_Empty()
        {
            var original = new BlobAccessPolicy();
            var result = RoundTripXml(original);

            Assert.IsNull(result.PolicyStartsOn);
            Assert.IsNull(result.PolicyExpiresOn);
            Assert.IsNull(result.Permissions);
        }

        [Test]
        public void BlobAccessPolicy_UnsupportedFormat_Throws()
        {
            var model = new BlobAccessPolicy();
            var jsonOptions = new ModelReaderWriterOptions("J");
            Assert.Throws<FormatException>(() => ((IPersistableModel<BlobAccessPolicy>)model).Write(jsonOptions));
        }
        #endregion

        #region BlobRetentionPolicy
        [Test]
        public void BlobRetentionPolicy_XmlRoundTrip()
        {
            var original = new BlobRetentionPolicy { Enabled = true, Days = 7 };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Enabled, result.Enabled);
            Assert.AreEqual(original.Days, result.Days);
        }

        [Test]
        public void BlobRetentionPolicy_XmlRoundTrip_Disabled()
        {
            var original = new BlobRetentionPolicy { Enabled = false };

            var result = RoundTripXml(original);

            Assert.AreEqual(false, result.Enabled);
            Assert.IsNull(result.Days);
        }
        #endregion

        #region BlobAnalyticsLogging
        [Test]
        public void BlobAnalyticsLogging_XmlRoundTrip()
        {
            var original = new BlobAnalyticsLogging
            {
                Version = "1.0",
                Delete = true,
                Read = false,
                Write = true,
                RetentionPolicy = new BlobRetentionPolicy { Enabled = true, Days = 5 }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Version, result.Version);
            Assert.AreEqual(original.Delete, result.Delete);
            Assert.AreEqual(original.Read, result.Read);
            Assert.AreEqual(original.Write, result.Write);
            Assert.IsNotNull(result.RetentionPolicy);
            Assert.AreEqual(original.RetentionPolicy.Enabled, result.RetentionPolicy.Enabled);
            Assert.AreEqual(original.RetentionPolicy.Days, result.RetentionPolicy.Days);
        }
        #endregion

        #region BlobCorsRule
        [Test]
        public void BlobCorsRule_XmlRoundTrip()
        {
            var original = new BlobCorsRule
            {
                AllowedOrigins = "https://example.com",
                AllowedMethods = "GET,PUT",
                AllowedHeaders = "x-ms-*",
                ExposedHeaders = "x-ms-request-id",
                MaxAgeInSeconds = 3600
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.AllowedOrigins, result.AllowedOrigins);
            Assert.AreEqual(original.AllowedMethods, result.AllowedMethods);
            Assert.AreEqual(original.AllowedHeaders, result.AllowedHeaders);
            Assert.AreEqual(original.ExposedHeaders, result.ExposedHeaders);
            Assert.AreEqual(original.MaxAgeInSeconds, result.MaxAgeInSeconds);
        }
        #endregion

        #region BlobBlock
        [Test]
        public void BlobBlock_XmlRoundTrip()
        {
            var xml = "<Block><Name>YmxvY2sx</Name><Size>1024</Size></Block>";
            var element = XElement.Parse(xml);
            var block = BlobBlock.DeserializeBlobBlock(element, XmlOptions);

            Assert.AreEqual("YmxvY2sx", block.Name);
            Assert.AreEqual(1024, block.SizeLong);

            // Write round-trip
            var data = ((IPersistableModel<BlobBlock>)block).Write(XmlOptions);
            var result = ((IPersistableModel<BlobBlock>)block).Create(data, XmlOptions);

            Assert.AreEqual(block.Name, result.Name);
            Assert.AreEqual(block.SizeLong, result.SizeLong);
        }
        #endregion

        #region BlobSignedIdentifier
        [Test]
        public void BlobSignedIdentifier_XmlRoundTrip()
        {
            var original = new BlobSignedIdentifier
            {
                Id = "test-id",
                AccessPolicy = new BlobAccessPolicy
                {
                    Permissions = "r",
                    PolicyStartsOn = new DateTimeOffset(2024, 6, 1, 0, 0, 0, TimeSpan.Zero),
                    PolicyExpiresOn = new DateTimeOffset(2025, 6, 1, 0, 0, 0, TimeSpan.Zero)
                }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Id, result.Id);
            Assert.IsNotNull(result.AccessPolicy);
            Assert.AreEqual(original.AccessPolicy.Permissions, result.AccessPolicy.Permissions);
            Assert.AreEqual(original.AccessPolicy.PolicyStartsOn, result.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(original.AccessPolicy.PolicyExpiresOn, result.AccessPolicy.PolicyExpiresOn);
        }
        #endregion

        #region BlobStaticWebsite
        [Test]
        public void BlobStaticWebsite_XmlRoundTrip()
        {
            var original = new BlobStaticWebsite
            {
                Enabled = true,
                IndexDocument = "index.html",
                ErrorDocument404Path = "error/404.html",
                DefaultIndexDocumentPath = "default.html"
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Enabled, result.Enabled);
            Assert.AreEqual(original.IndexDocument, result.IndexDocument);
            Assert.AreEqual(original.ErrorDocument404Path, result.ErrorDocument404Path);
            Assert.AreEqual(original.DefaultIndexDocumentPath, result.DefaultIndexDocumentPath);
        }
        #endregion

        #region BlobMetrics
        [Test]
        public void BlobMetrics_XmlRoundTrip()
        {
            var original = new BlobMetrics
            {
                Version = "1.0",
                Enabled = true,
                IncludeApis = true,
                RetentionPolicy = new BlobRetentionPolicy { Enabled = true, Days = 7 }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Version, result.Version);
            Assert.AreEqual(original.Enabled, result.Enabled);
            Assert.AreEqual(original.IncludeApis, result.IncludeApis);
            Assert.IsNotNull(result.RetentionPolicy);
            Assert.AreEqual(original.RetentionPolicy.Enabled, result.RetentionPolicy.Enabled);
            Assert.AreEqual(original.RetentionPolicy.Days, result.RetentionPolicy.Days);
        }
        #endregion

        #region BlobServiceProperties
        [Test]
        public void BlobServiceProperties_XmlRoundTrip()
        {
            var original = new BlobServiceProperties
            {
                Logging = new BlobAnalyticsLogging
                {
                    Version = "1.0",
                    Delete = true,
                    Read = true,
                    Write = true,
                    RetentionPolicy = new BlobRetentionPolicy { Enabled = false }
                },
                HourMetrics = new BlobMetrics
                {
                    Version = "1.0",
                    Enabled = false,
                    RetentionPolicy = new BlobRetentionPolicy { Enabled = false }
                },
                MinuteMetrics = new BlobMetrics
                {
                    Version = "1.0",
                    Enabled = false,
                    RetentionPolicy = new BlobRetentionPolicy { Enabled = false }
                },
                DefaultServiceVersion = "2021-08-06",
                DeleteRetentionPolicy = new BlobRetentionPolicy { Enabled = true, Days = 7 },
                StaticWebsite = new BlobStaticWebsite { Enabled = false },
                Cors = new List<BlobCorsRule>
                {
                    new BlobCorsRule
                    {
                        AllowedOrigins = "*",
                        AllowedMethods = "GET",
                        AllowedHeaders = "*",
                        ExposedHeaders = "",
                        MaxAgeInSeconds = 600
                    }
                }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.DefaultServiceVersion, result.DefaultServiceVersion);
            Assert.IsNotNull(result.Logging);
            Assert.AreEqual(original.Logging.Version, result.Logging.Version);
            Assert.IsNotNull(result.DeleteRetentionPolicy);
            Assert.AreEqual(original.DeleteRetentionPolicy.Enabled, result.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(original.DeleteRetentionPolicy.Days, result.DeleteRetentionPolicy.Days);
            Assert.IsNotNull(result.Cors);
            Assert.AreEqual(1, result.Cors.Count);
            Assert.AreEqual(original.Cors[0].AllowedOrigins, result.Cors[0].AllowedOrigins);
        }
        #endregion

        #region BlobTag
        [Test]
        public void BlobTag_XmlRoundTrip()
        {
            var original = new BlobTag("env", "production");

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Key, result.Key);
            Assert.AreEqual(original.Value, result.Value);
        }
        #endregion

        #region BlobTags
        [Test]
        public void BlobTags_XmlRoundTrip()
        {
            var original = new BlobTags(new List<BlobTag>
            {
                new BlobTag("key1", "value1"),
                new BlobTag("key2", "value2")
            });

            var result = RoundTripXml(original);

            Assert.AreEqual(2, result.BlobTagSet.Count);
            Assert.AreEqual("key1", result.BlobTagSet[0].Key);
            Assert.AreEqual("value1", result.BlobTagSet[0].Value);
            Assert.AreEqual("key2", result.BlobTagSet[1].Key);
            Assert.AreEqual("value2", result.BlobTagSet[1].Value);
        }
        #endregion

        #region ArrowFieldInternal
        [Test]
        public void ArrowFieldInternal_XmlRoundTrip()
        {
            var original = new ArrowFieldInternal("int64")
            {
                Name = "testField",
                Precision = 10,
                Scale = 2
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Type, result.Type);
            Assert.AreEqual(original.Name, result.Name);
            Assert.AreEqual(original.Precision, result.Precision);
            Assert.AreEqual(original.Scale, result.Scale);
        }
        #endregion

        #region ArrowTextConfigurationInternal
        [Test]
        public void ArrowTextConfigurationInternal_XmlRoundTrip()
        {
            var original = new ArrowTextConfigurationInternal(
                new List<ArrowFieldInternal>
                {
                    new ArrowFieldInternal("int64") { Name = "col1" },
                    new ArrowFieldInternal("string") { Name = "col2" }
                });

            var result = RoundTripXml(original);

            Assert.AreEqual(2, result.Schema.Count);
            Assert.AreEqual("int64", result.Schema[0].Type);
            Assert.AreEqual("col1", result.Schema[0].Name);
            Assert.AreEqual("string", result.Schema[1].Type);
        }
        #endregion

        #region DelimitedTextConfigurationInternal
        [Test]
        public void DelimitedTextConfigurationInternal_XmlRoundTrip()
        {
            var original = new DelimitedTextConfigurationInternal
            {
                ColumnSeparator = ",",
                FieldQuote = "\"",
                RecordSeparator = "\n",
                EscapeChar = "\\",
                HeadersPresent = true
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.ColumnSeparator, result.ColumnSeparator);
            Assert.AreEqual(original.FieldQuote, result.FieldQuote);
            Assert.AreEqual(original.RecordSeparator, result.RecordSeparator);
            Assert.AreEqual(original.EscapeChar, result.EscapeChar);
            Assert.AreEqual(original.HeadersPresent, result.HeadersPresent);
        }
        #endregion

        #region JsonTextConfigurationInternal
        [Test]
        public void JsonTextConfigurationInternal_XmlRoundTrip()
        {
            var original = new JsonTextConfigurationInternal
            {
                RecordSeparator = "\n"
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(original.RecordSeparator, result.RecordSeparator);
        }
        #endregion

        #region ParquetConfiguration
        [Test]
        public void ParquetConfiguration_XmlRoundTrip()
        {
            var original = new ParquetConfiguration();

            var result = RoundTripXml(original);

            Assert.IsNotNull(result);
        }
        #endregion

        #region QueryFormat
        [Test]
        public void QueryFormat_XmlRoundTrip_Delimited()
        {
            var original = new QueryFormat(QueryFormatType.Delimited)
            {
                DelimitedTextConfiguration = new DelimitedTextConfigurationInternal
                {
                    ColumnSeparator = ",",
                    HeadersPresent = true
                }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(QueryFormatType.Delimited, result.Type);
            Assert.IsNotNull(result.DelimitedTextConfiguration);
            Assert.AreEqual(",", result.DelimitedTextConfiguration.ColumnSeparator);
        }

        [Test]
        public void QueryFormat_XmlRoundTrip_Json()
        {
            var original = new QueryFormat(QueryFormatType.Json)
            {
                JsonTextConfiguration = new JsonTextConfigurationInternal { RecordSeparator = "\n" }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(QueryFormatType.Json, result.Type);
            Assert.IsNotNull(result.JsonTextConfiguration);
        }
        #endregion

        #region QuerySerialization
        [Test]
        public void QuerySerialization_XmlRoundTrip()
        {
            var original = new QuerySerialization(
                new QueryFormat(QueryFormatType.Delimited)
                {
                    DelimitedTextConfiguration = new DelimitedTextConfigurationInternal
                    {
                        ColumnSeparator = ","
                    }
                });

            var result = RoundTripXml(original);

            Assert.IsNotNull(result.Format);
            Assert.AreEqual(QueryFormatType.Delimited, result.Format.Type);
        }
        #endregion

        #region QueryRequest
        [Test]
        public void QueryRequest_XmlRoundTrip()
        {
            var original = new QueryRequest("SQL", "SELECT * FROM BlobStorage")
            {
                InputSerialization = new QuerySerialization(
                    new QueryFormat(QueryFormatType.Delimited)
                    {
                        DelimitedTextConfiguration = new DelimitedTextConfigurationInternal
                        {
                            ColumnSeparator = ","
                        }
                    }),
                OutputSerialization = new QuerySerialization(
                    new QueryFormat(QueryFormatType.Json)
                    {
                        JsonTextConfiguration = new JsonTextConfigurationInternal
                        {
                            RecordSeparator = "\n"
                        }
                    })
            };

            var result = RoundTripXml(original);

            Assert.AreEqual("SQL", result.QueryType);
            Assert.AreEqual("SELECT * FROM BlobStorage", result.Expression);
            Assert.IsNotNull(result.InputSerialization);
            Assert.IsNotNull(result.OutputSerialization);
        }
        #endregion

        #region KeyInfo
        [Test]
        public void KeyInfo_XmlRoundTrip()
        {
            var original = new KeyInfo(
                "2024-01-01T00:00:00Z",
                "2025-01-01T00:00:00Z");

            var result = RoundTripXml(original);

            Assert.AreEqual(original.Start, result.Start);
            Assert.AreEqual(original.Expiry, result.Expiry);
        }
        #endregion

        #region UserDelegationKey
        [Test]
        public void UserDelegationKey_XmlRoundTrip()
        {
            // UserDelegationKey is read-only (deserialized from service response).
            // Test deserialization from XML directly.
            string xml = @"<UserDelegationKey>
                <SignedOid>00000000-0000-0000-0000-000000000001</SignedOid>
                <SignedTid>00000000-0000-0000-0000-000000000002</SignedTid>
                <SignedStart>2024-01-01T00:00:00Z</SignedStart>
                <SignedExpiry>2025-01-01T00:00:00Z</SignedExpiry>
                <SignedService>b</SignedService>
                <SignedVersion>2021-08-06</SignedVersion>
                <Value>dGVzdGtleQ==</Value>
            </UserDelegationKey>";

            var element = XElement.Parse(xml);
            var key = UserDelegationKey.DeserializeUserDelegationKey(element, XmlOptions);

            Assert.AreEqual("00000000-0000-0000-0000-000000000001", key.SignedObjectId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000002", key.SignedTenantId);
            Assert.AreEqual("b", key.SignedService);
            Assert.AreEqual("2021-08-06", key.SignedVersion);
            Assert.AreEqual("dGVzdGtleQ==", key.Value);
        }
        #endregion

        #region BlobGeoReplication
        [Test]
        public void BlobGeoReplication_XmlRoundTrip()
        {
            string xml = @"<GeoReplication>
                <Status>live</Status>
                <LastSyncTime>Wed, 01 Jan 2025 00:00:00 GMT</LastSyncTime>
            </GeoReplication>";

            var element = XElement.Parse(xml);
            var geo = BlobGeoReplication.DeserializeBlobGeoReplication(element, XmlOptions);

            Assert.AreEqual(BlobGeoReplicationStatus.Live, geo.Status);
            Assert.IsNotNull(geo.LastSyncedOn);
        }
        #endregion

        #region BlobName
        [Test]
        public void BlobName_XmlDeserialize()
        {
            string xml = @"<Name Encoded=""true"">dGVzdC1ibG9i</Name>";
            var element = XElement.Parse(xml);
            var name = BlobName.DeserializeBlobName(element, XmlOptions);

            Assert.AreEqual(true, name.Encoded);
            Assert.AreEqual("dGVzdC1ibG9i", name.Content);
        }

        [Test]
        public void BlobName_XmlDeserialize_NotEncoded()
        {
            string xml = @"<Name>my-blob</Name>";
            var element = XElement.Parse(xml);
            var name = BlobName.DeserializeBlobName(element, XmlOptions);

            Assert.IsNull(name.Encoded);
            Assert.AreEqual("my-blob", name.Content);
        }
        #endregion

        #region BlockLookupList
        [Test]
        public void BlockLookupList_XmlRoundTrip()
        {
            var original = new BlockLookupList
            {
                Committed = { "block1", "block2" },
                Uncommitted = { "block3" },
                Latest = { "block4" }
            };

            var result = RoundTripXml(original);

            Assert.AreEqual(2, result.Committed.Count);
            Assert.AreEqual("block1", result.Committed[0]);
            Assert.AreEqual("block2", result.Committed[1]);
            Assert.AreEqual(1, result.Uncommitted.Count);
            Assert.AreEqual("block3", result.Uncommitted[0]);
            Assert.AreEqual(1, result.Latest.Count);
            Assert.AreEqual("block4", result.Latest[0]);
        }
        #endregion

        #region ClearRange
        [Test]
        public void ClearRange_XmlDeserialize()
        {
            string xml = @"<ClearRange><Start>0</Start><End>511</End></ClearRange>";
            var element = XElement.Parse(xml);
            var range = ClearRange.DeserializeClearRange(element, XmlOptions);

            Assert.AreEqual(0, range.Start);
            Assert.AreEqual(511, range.End);
        }
        #endregion

        #region PageRange
        [Test]
        public void PageRange_XmlDeserialize()
        {
            string xml = @"<PageRange><Start>0</Start><End>511</End></PageRange>";
            var element = XElement.Parse(xml);
            var range = PageRange.DeserializePageRange(element, XmlOptions);

            Assert.AreEqual(0, range.Start);
            Assert.AreEqual(511, range.End);
        }
        #endregion

        #region PageList
        [Test]
        public void PageList_XmlDeserialize()
        {
            string xml = @"<PageList>
                <PageRange><Start>0</Start><End>511</End></PageRange>
                <ClearRange><Start>512</Start><End>1023</End></ClearRange>
            </PageList>";

            var element = XElement.Parse(xml);
            var pageList = PageList.DeserializePageList(element, XmlOptions);

            Assert.AreEqual(1, pageList.PageRange.Count);
            Assert.AreEqual(0, pageList.PageRange[0].Start);
            Assert.AreEqual(1, pageList.ClearRange.Count);
            Assert.AreEqual(512, pageList.ClearRange[0].Start);
        }
        #endregion

        #region FilterBlobItem
        [Test]
        public void FilterBlobItem_XmlDeserialize()
        {
            string xml = @"<Blob>
                <Name>myblob</Name>
                <ContainerName>mycontainer</ContainerName>
            </Blob>";

            var element = XElement.Parse(xml);
            var item = FilterBlobItem.DeserializeFilterBlobItem(element, XmlOptions);

            Assert.AreEqual("myblob", item.Name);
            Assert.AreEqual("mycontainer", item.ContainerName);
        }
        #endregion

        #region FilterBlobSegment
        [Test]
        public void FilterBlobSegment_XmlDeserialize()
        {
            string xml = @"<EnumerationResults>
                <Where>tag1='value1'</Where>
                <Blobs>
                    <Blob>
                        <Name>blob1</Name>
                        <ContainerName>container1</ContainerName>
                    </Blob>
                </Blobs>
            </EnumerationResults>";

            var element = XElement.Parse(xml);
            var segment = FilterBlobSegment.DeserializeFilterBlobSegment(element, XmlOptions);

            Assert.AreEqual("tag1='value1'", segment.Where);
            Assert.AreEqual(1, segment.BlobItems.Count);
            Assert.AreEqual("blob1", segment.BlobItems[0].Name);
        }
        #endregion
    }
}
