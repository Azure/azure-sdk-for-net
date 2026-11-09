// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class QuotaTransferModelTests
    {
        [TestCase(null)]
        [TestCase("W/\"version\"")]
        public void TransferResourcesPreserveETags(string eTag)
        {
            BinaryData json = BinaryData.FromString("{\"etag\":" + JsonSerializer.Serialize(eTag) + "}");
            var transfer = ModelReaderWriter.Read<QuotaTransferData>(json);
            var incomingTransfer = ModelReaderWriter.Read<IncomingQuotaTransferData>(json);
            ETag? expected = eTag is null ? null : new ETag(eTag);

            Assert.AreEqual(expected, transfer.ETag);
            Assert.AreEqual(expected, incomingTransfer.ETag);
            using JsonDocument transferJson = JsonDocument.Parse(ModelReaderWriter.Write(transfer).ToString());
            using JsonDocument incomingJson = JsonDocument.Parse(ModelReaderWriter.Write(incomingTransfer).ToString());
            if (eTag is not null)
            {
                Assert.AreEqual(eTag, transferJson.RootElement.GetProperty("etag").GetString());
                Assert.AreEqual(eTag, incomingJson.RootElement.GetProperty("etag").GetString());
            }
            else
            {
                Assert.IsFalse(transferJson.RootElement.TryGetProperty("etag", out _));
                Assert.IsFalse(incomingJson.RootElement.TryGetProperty("etag", out _));
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AutoApprovalPreservesWireName(bool enabled)
        {
            var properties = new QuotaTransferProperties("transfer", "subscription", "standardDv5Family", 1)
            {
                IsAutoApproveEnabled = enabled
            };

            BinaryData json = ModelReaderWriter.Write(properties);
            using JsonDocument document = JsonDocument.Parse(json.ToString());
            Assert.AreEqual(enabled, document.RootElement.GetProperty("autoApprove").GetBoolean());
            Assert.IsFalse(document.RootElement.TryGetProperty("isAutoApproveEnabled", out _));
            Assert.AreEqual(enabled, ModelReaderWriter.Read<QuotaTransferProperties>(json).IsAutoApproveEnabled);
        }

        [Test]
        public void TransferRecordsPreserveWireProperties()
        {
            BinaryData json = BinaryData.FromString(
                "{\"comment\":\"approved\",\"reason\":\"requested\",\"actor\":\"principal\",\"occurredAt\":\"2026-11-09T00:00:00Z\"}");
            var approval = ModelReaderWriter.Read<QuotaTransferApprovalRecord>(json);
            var cancellation = ModelReaderWriter.Read<QuotaTransferCancellationRecord>(json);
            var rejection = ModelReaderWriter.Read<QuotaTransferRejectionRecord>(json);
            var occurredOn = new DateTimeOffset(2026, 11, 9, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("approved", approval.Comment);
            Assert.AreEqual("requested", cancellation.Reason);
            Assert.AreEqual("requested", rejection.Reason);
            Assert.AreEqual("principal", approval.Actor);
            Assert.AreEqual("principal", cancellation.Actor);
            Assert.AreEqual("principal", rejection.Actor);
            Assert.AreEqual(occurredOn, approval.OccurredOn);
            Assert.AreEqual(occurredOn, cancellation.OccurredOn);
            Assert.AreEqual(occurredOn, rejection.OccurredOn);
        }
    }
}
