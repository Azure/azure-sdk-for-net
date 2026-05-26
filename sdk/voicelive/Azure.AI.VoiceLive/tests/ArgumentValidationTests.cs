// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Comprehensive argument validation tests for <see cref="VoiceLiveSession"/> public surface area.
    /// These verify that null / empty parameters throw the expected <see cref="ArgumentNullException"/> or
    /// <see cref="ArgumentException"/> types without performing any live networking.
    /// </summary>
    [TestFixture]
    public class ArgumentValidationTests
    {
        [Test]
        public void StartAudioTurnAsync_InvalidTurnIds_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);

            // null -> ArgumentNullException
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.StartAudioTurnAsync(null));
            // empty -> ArgumentException
            Assert.ThrowsAsync<ArgumentException>(async () => await session.StartAudioTurnAsync(string.Empty));
        }

        [Test]
        public void AppendAudioToTurnAsync_InvalidParams_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);

            byte[] validAudio = new byte[] { 0x01 };

            // null turnId
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.AppendAudioToTurnAsync(null, validAudio));
            // empty turnId
            Assert.ThrowsAsync<ArgumentException>(async () => await session.AppendAudioToTurnAsync(string.Empty, validAudio));
#pragma warning disable CS8600
            // null audio
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.AppendAudioToTurnAsync("turn1", (byte[])null));
#pragma warning restore CS8600
        }

        [Test]
        public void EndAudioTurnAsync_InvalidTurnId_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.EndAudioTurnAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.EndAudioTurnAsync(string.Empty));
        }

        [Test]
        public void CancelAudioTurnAsync_InvalidTurnId_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.CancelAudioTurnAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.CancelAudioTurnAsync(string.Empty));
        }

        [Test]
        public void TruncateConversationAsync_InvalidItemId_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.TruncateConversationAsync(null, 0));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.TruncateConversationAsync(string.Empty, 0));
        }

        [Test]
        public void RequestItemRetrievalAsync_InvalidItemId_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.RequestItemRetrievalAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.RequestItemRetrievalAsync(string.Empty));
        }

        [Test]
        public void DeleteItemAsync_InvalidItemId_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.DeleteItemAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.DeleteItemAsync(string.Empty));
        }

        [Test]
        public void SendInputAudioAsync_NullByteArray_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
#pragma warning disable CS8600
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.SendInputAudioAsync((byte[])null));
#pragma warning restore CS8600
        }

        [Test]
        public void SendInputAudioAsync_NullBinaryData_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
#pragma warning disable CS8600
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.SendInputAudioAsync((BinaryData)null));
#pragma warning restore CS8600
        }

        [Test]
        public void StartResponseAsync_NullAdditionalInstructions_Throws()
        {
            var session = TestSessionFactory.CreateSession(out _);
#pragma warning disable CS8600
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.StartResponseAsync((string)null));
#pragma warning restore CS8600
        }
    }
}
