// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Queues.Specialized.Models;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;
using static Moq.It;
using static Azure.Storage.Constants.ClientSideEncryption;
using static Azure.Storage.Test.Shared.ClientSideEncryptionTestExtensions;

namespace Azure.Storage.Queues.Test
{
    public class ClientSideEncryptionTests : QueueTestBase
    {
        private const string s_algorithmName = "some algorithm name";
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;

        private readonly string SampleUTF8String = Encoding.UTF8.GetString(
            new byte[] { 0xe1, 0x9a, 0xa0, 0xe1, 0x9b, 0x87, 0xe1, 0x9a, 0xbb, 0x0a }); // valid UTF-8 bytes

        public ClientSideEncryptionTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // TODO: enable after new KeyValue is released (after Dec 2023)
            TestDiagnostics = false;
        }

        private static IEnumerable<ClientSideEncryptionVersion> GetEncryptionVersions()
            => Enum.GetValues(typeof(ClientSideEncryptionVersion)).Cast<ClientSideEncryptionVersion>();

        /// <summary>
        /// Provides encryption functionality clone of client logic, letting us validate the client got it right end-to-end.
        /// </summary>
        private string EncryptDataV2_0(string message, byte[] key)
        {
            var data = new BinaryData(message).ToArray();
            int encryptedDataLength = data.Length + V2.NonceSize + V2.TagSize;
            var result = new Span<byte>(new byte[encryptedDataLength]);

#if NET8_0_OR_GREATER
            using var gcm = new AesGcm(key, V2.TagSize);
#elif NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
            using var gcm = new AesGcm(key);
#else
            using var gcm = new Azure.Storage.Shared.AesGcm.AesGcmWindows(key);
#endif

            // generate nonce
            var nonce = result.Slice(0, V2.NonceSize);
            const int bytesInLong = 8;
            int remainingNonceBytes = V2.NonceSize - bytesInLong;
            Enumerable.Repeat((byte)0, remainingNonceBytes).ToArray().CopyTo(nonce.Slice(0, remainingNonceBytes));
            BitConverter.GetBytes(1L).CopyTo(nonce.Slice(remainingNonceBytes, bytesInLong));

            gcm.Encrypt(
                nonce,
                data,
                result.Slice(V2.NonceSize, data.Length),
                result.Slice(V2.NonceSize + data.Length, V2.TagSize));

            return Convert.ToBase64String(result.ToArray());
        }

        private string EncryptDataV1_0(string message, byte[] key, byte[] iv)
        {
            using var aesProvider = Aes.Create();
            aesProvider.Key = key;
            aesProvider.IV = iv;
            using var encryptor = aesProvider.CreateEncryptor();
            using var memStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(memStream.ToArray());
        }

        private async Task<IKeyEncryptionKey> GetKeyvaultIKeyEncryptionKey()
        {
            var keyClient = GetKeyClient_TargetKeyClient();
            Security.KeyVault.Keys.KeyVaultKey key = await keyClient.CreateRsaKeyAsync(
                new Security.KeyVault.Keys.CreateRsaKeyOptions($"CloudRsaKey-{Guid.NewGuid()}", false));
            return new CryptographyClient(key.Id, GetTokenCredential_TargetKeyClient());
        }

        /// <summary>
        /// Creates an encrypted queue client from a normal queue client. Note that this method does not copy over any
        /// client options from the container client. You must pass in your own options. These options will be mutated.
        /// </summary>
        public async Task<DisposingQueue> GetTestEncryptedQueueAsync(
            ClientSideEncryptionOptions encryptionOptions,
            string queueName = default,
            IDictionary<string, string> metadata = default)
        {
            // normally set through property on subclass; this is easier to hook up in current test infra with internals access
            var options = GetOptions();
            options._clientSideEncryptionOptions = encryptionOptions;

            var service = GetServiceClient_SharedKey(options);

            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            QueueClient queue = InstrumentClient(service.GetQueueClient(GetNewQueueName()));
            return await DisposingQueue.CreateAsync(queue, metadata);
        }

        /// <summary>
        /// Generates a random string of the given size.
        /// For implementation simplicity, this generates an ASCII string.
        /// </summary>
        /// <param name="size">Size of the string IN BYTES, not chars.</param>
        /// <returns></returns>
        public string GetRandomMessage(int size)
        {
            var buf = new byte[size];
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                buf[i] = (byte)random.Next(32, 127); // printable ASCII has values [32, 127)
            }

            return Encoding.ASCII.GetString(buf);
        }

        [Test]
        [LiveOnly]
        public void CanSwapKey(
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            int options1EventCalled = 0;
            int options2EventCalled = 0;
            void Options1_DecryptionFailed(object sender, ClientSideDecryptionFailureEventArgs e)
            {
                options1EventCalled++;
            }
            void Options2_DecryptionFailed(object sender, ClientSideDecryptionFailureEventArgs e)
            {
                options2EventCalled++;
            }
            var options1 = new QueueClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "foo"
            };
            options1.DecryptionFailed += Options1_DecryptionFailed;
            var options2 = new QueueClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };
            options2.DecryptionFailed += Options2_DecryptionFailed;

            var client = new QueueClient(new Uri("http://someuri.com"), new SpecializedQueueClientOptions()
            {
                ClientSideEncryption = options1
            });

            Assert.AreEqual(options1.KeyEncryptionKey, client.ClientConfiguration.ClientSideEncryption.KeyEncryptionKey);
            Assert.AreEqual(options1.KeyResolver, client.ClientConfiguration.ClientSideEncryption.KeyResolver);
            Assert.AreEqual(options1.KeyWrapAlgorithm, client.ClientConfiguration.ClientSideEncryption.KeyWrapAlgorithm);

            Assert.AreEqual(0, options1EventCalled);
            Assert.AreEqual(0, options2EventCalled);
            client.ClientConfiguration.ClientSideEncryption.OnDecryptionFailed(default, default);
            Assert.AreEqual(1, options1EventCalled);
            Assert.AreEqual(0, options2EventCalled);

            client = client.WithClientSideEncryptionOptions(options2);

            Assert.AreEqual(options2.KeyEncryptionKey, client.ClientConfiguration.ClientSideEncryption.KeyEncryptionKey);
            Assert.AreEqual(options2.KeyResolver, client.ClientConfiguration.ClientSideEncryption.KeyResolver);
            Assert.AreEqual(options2.KeyWrapAlgorithm, client.ClientConfiguration.ClientSideEncryption.KeyWrapAlgorithm);

            Assert.AreEqual(1, options1EventCalled);
            Assert.AreEqual(0, options2EventCalled);
            client.ClientConfiguration.ClientSideEncryption.OnDecryptionFailed(default, default);
            Assert.AreEqual(1, options1EventCalled);
            Assert.AreEqual(1, options2EventCalled);
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, false)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, 14, false)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB, false)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB - 4, false)] // multiple unalligned blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, 0, true)] // utf8 support testing
        [TestCase(ClientSideEncryptionVersion.V2_0, Constants.KB, false)] // block is larger than max message size, just use 1KB
        [TestCase(ClientSideEncryptionVersion.V2_0, 0, true)] // utf8 support testing
        [LiveOnly] // cannot seed content encryption key
#pragma warning disable CS0618 // obsolete
        public async Task UploadAsync(ClientSideEncryptionVersion version, int messageSize, bool usePrebuiltMessage)
        {
            var message = usePrebuiltMessage
                ? SampleUTF8String
                : GetRandomMessage(messageSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var queue = disposable.Queue;

                // upload with encryption
                await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken);

                // download without decrypting
                var receivedMessages = (await InstrumentClient(new QueueClient(queue.Uri, GetNewSharedKeyCredentials())).ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value;
                Assert.AreEqual(1, receivedMessages.Length);
                var encryptedMessage = receivedMessages[0].Body; // json of message and metadata
                var parsedEncryptedMessage = EncryptedMessageSerializer.Deserialize(encryptedMessage);

                // encrypt original data manually for comparison
                EncryptionData encryptionMetadata = parsedEncryptedMessage.EncryptionData;
                Assert.NotNull(encryptionMetadata, "Never encrypted data.");

                var explicitlyUnwrappedContent = IsAsync
                    ? await mockKey.UnwrapKeyAsync(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken).ConfigureAwait(false)
                    : mockKey.UnwrapKey(s_algorithmName, encryptionMetadata.WrappedContentKey.EncryptedKey, s_cancellationToken);
                byte[] explicitlyUnwrappedKey;
                switch (encryptionMetadata.EncryptionAgent.EncryptionVersion)
                {
#pragma warning disable CS0618 // obsolete
                    case ClientSideEncryptionVersionInternal.V1_0:
                        explicitlyUnwrappedKey = explicitlyUnwrappedContent;
                        break;
#pragma warning restore CS0618 // obsolete
                    case ClientSideEncryptionVersionInternal.V2_0:
                        explicitlyUnwrappedKey = new Span<byte>(explicitlyUnwrappedContent).Slice(8).ToArray();
                        break;
                    default:
                        throw new Exception();
                }

                string expectedEncryptedMessage;
                ClientSideEncryptionVersionInternal versionInternal = ClientSideEncryptionVersionInternal.V2_0;
                switch (version)
                {
#pragma warning disable CS0618 // obsolete
                    case ClientSideEncryptionVersion.V1_0:
                        expectedEncryptedMessage = EncryptDataV1_0(
                            message,
                            explicitlyUnwrappedKey,
                            encryptionMetadata.ContentEncryptionIV);
                        versionInternal = ClientSideEncryptionVersionInternal.V1_0;
                        break;
#pragma warning restore CS0618 // obsolete
                    case ClientSideEncryptionVersion.V2_0:
                        expectedEncryptedMessage = EncryptDataV2_0(
                            message,
                            explicitlyUnwrappedKey);
                        versionInternal = ClientSideEncryptionVersionInternal.V2_0;
                        break;
                    default: throw new ArgumentException("Test does not support clientside encryption version");
                }

                // compare data
                Assert.AreEqual(versionInternal, parsedEncryptedMessage.EncryptionData.EncryptionAgent.EncryptionVersion);
                Assert.AreEqual(expectedEncryptedMessage, parsedEncryptedMessage.EncryptedMessageText);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0, 16, false)] // a single cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, 14, false)] // a single unalligned cipher block
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB, false)] // multiple blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, Constants.KB - 4, false)] // multiple unalligned blocks
        [TestCase(ClientSideEncryptionVersion.V1_0, 0, true)] // utf8 support testing
        [TestCase(ClientSideEncryptionVersion.V2_0, Constants.KB, false)] // block is larger than max message size, just use 1KB
        [TestCase(ClientSideEncryptionVersion.V2_0, 0, true)] // utf8 support testing
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task RoundtripAsync(ClientSideEncryptionVersion version, int messageSize, bool usePrebuiltMessage)
        {
            var message = usePrebuiltMessage
                ? SampleUTF8String
                : GetRandomMessage(messageSize);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey,
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var queue = disposable.Queue;

                // upload with encryption
                await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken);

                // download with decryption
                var receivedMessages = (await queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value;
                Assert.AreEqual(1, receivedMessages.Length);
                var downloadedMessage = receivedMessages[0].MessageText;

                // compare data
                Assert.AreEqual(message, downloadedMessage);
            }
        }

        [TestCase(Constants.KB, false)] // multiple blocks
        [TestCase(Constants.KB - 4, false)] // multiple unalligned blocks
        [TestCase(0, true)] // utf8 support testing
        [LiveOnly] // cannot seed content encryption key
        public async Task Track2DownloadTrack1Blob(int messageSize, bool usePrebuiltMessage)
        {
            var message = usePrebuiltMessage
                ? SampleUTF8String
                : GetRandomMessage(messageSize);

            const int keySizeBits = 256;
            var keyEncryptionKeyBytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
            RandomNumberGenerator.Create().GetBytes(keyEncryptionKeyBytes);
#else
            new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
#endif
            var keyId = Guid.NewGuid().ToString();

            var mockKey = this.GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object).Object;
#pragma warning disable CS0618 // obsolete
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
#pragma warning restore CS0618 // obsolete
            {
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var track2Queue = disposable.Queue;

                // upload with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Queue = new Microsoft.Azure.Storage.Queue.CloudQueue(
                    track2Queue.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                var track1RequestOptions = new Microsoft.Azure.Storage.Queue.QueueRequestOptions()
                {
                    EncryptionPolicy = new Microsoft.Azure.Storage.Queue.QueueEncryptionPolicy(mockKey, default)
                };
                if (IsAsync)
                {
                    await track1Queue.AddMessageAsync(new Microsoft.Azure.Storage.Queue.CloudQueueMessage(message), null, null, track1RequestOptions, null, s_cancellationToken);
                }
                else
                {
                    track1Queue.AddMessage(new Microsoft.Azure.Storage.Queue.CloudQueueMessage(message), null, null, track1RequestOptions, null);
                }

                // download with track 2
                var receivedMessages = (await track2Queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value;
                Assert.AreEqual(1, receivedMessages.Length);
                var downloadedMessage = receivedMessages[0].MessageText;

                // compare original data to downloaded data
                Assert.AreEqual(message, downloadedMessage);
            }
        }

        [TestCase(Constants.KB, false)] // multiple blocks
        [TestCase(Constants.KB - 4, false)] // multiple unalligned blocks
        [TestCase(0, true)] // utf8 support testing
        [LiveOnly] // cannot seed content encryption key
        public async Task Track1DownloadTrack2Blob(int messageSize, bool usePrebuiltMessage)
        {
            var message = usePrebuiltMessage
                ? SampleUTF8String
                : GetRandomMessage(messageSize);

            const int keySizeBits = 256;
            var keyEncryptionKeyBytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
            RandomNumberGenerator.Create().GetBytes(keyEncryptionKeyBytes);
#else
            new RNGCryptoServiceProvider().GetBytes(keyEncryptionKeyBytes);
#endif
            var keyId = Guid.NewGuid().ToString();

            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken, keyEncryptionKeyBytes, keyId).Object;
            var mockKeyResolver = this.GetTrackOneIKeyResolver(this.GetTrackOneIKey(keyEncryptionKeyBytes, keyId).Object).Object;
#pragma warning disable CS0618 // obsolete
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
#pragma warning restore CS0618 // obsolete
            {
                KeyEncryptionKey = mockKey,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var track2Queue = disposable.Queue;

                // upload with track 2
                await track2Queue.SendMessageAsync(message, cancellationToken: s_cancellationToken);

                // download with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Queue = new Microsoft.Azure.Storage.Queue.CloudQueue(
                    track2Queue.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                var response = await track1Queue.GetMessageAsync(
                    null,
                    new Microsoft.Azure.Storage.Queue.QueueRequestOptions()
                    {
                        EncryptionPolicy = new Microsoft.Azure.Storage.Queue.QueueEncryptionPolicy(default, mockKeyResolver)
                    },
                    null);

                // compare original data to downloaded data
                Assert.AreEqual(message, response.AsString);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task RoundtripWithKeyvaultProvider(ClientSideEncryptionVersion version)
        {
            var message = GetRandomMessage(Constants.KB);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = key,
                KeyWrapAlgorithm = "RSA-OAEP-256"
            }))
            {
                var queue = disposable.Queue;

                await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken);

                var receivedMessages = (await queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value;
                Assert.AreEqual(1, receivedMessages.Length);
                var downloadedMessage = receivedMessages[0].MessageText;

                Assert.AreEqual(message, downloadedMessage);
            }
        }

        [TestCase("any old message")]
        [TestCase("\"aa\"")] // real world example
        [TestCase("{\"key1\":\"value1\",\"key2\":\"value2\"}")] // more typical json object, but not the actual schema we're looking for
        [TestCase("{\"EncryptedMessageContents\":\"value1\",\"key2\":\"value2\"}")] // one required piece but not the other
        [TestCase("{\"EncryptionData\":{},\"key2\":\"value2\"}")] // one required piece but not the other
        [LiveOnly] // cannot seed content encryption key
        public async Task ReadPlaintextMessage(string message)
        {
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
            {
                KeyEncryptionKey = mockKey,
                KeyResolver = mockKeyResolver,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var encryptedQueueClient = disposable.Queue;
                var plainQueueClient = new QueueClient(encryptedQueueClient.Uri, GetNewSharedKeyCredentials());

                // upload with encryption
                await plainQueueClient.SendMessageAsync(message, cancellationToken: s_cancellationToken);

                // download with decryption
                var receivedMessages = (await encryptedQueueClient.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value;
                Assert.AreEqual(1, receivedMessages.Length);
                var downloadedMessage = receivedMessages[0].MessageText;

                // compare data
                Assert.AreEqual(message, downloadedMessage);
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task OnlyOneKeyWrapCall(ClientSideEncryptionVersion version)
        {
            var message = "any old message";
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object);
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey.Object,
                KeyResolver = mockKeyResolver.Object,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var queue = disposable.Queue;

                await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken).ConfigureAwait(false);

                var wrapSyncMethod = typeof(IKeyEncryptionKey).GetMethod("WrapKey");
                var wrapAsyncMethod = typeof(IKeyEncryptionKey).GetMethod("WrapKeyAsync");

                Assert.AreEqual(1, IsAsync
                    ? mockKey.Invocations.Count(invocation => invocation.Method == wrapAsyncMethod)
                    : mockKey.Invocations.Count(invocation => invocation.Method == wrapSyncMethod));
                Assert.AreEqual(0, IsAsync
                    ? mockKey.Invocations.Count(invocation => invocation.Method == wrapSyncMethod)
                    : mockKey.Invocations.Count(invocation => invocation.Method == wrapAsyncMethod));
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly]
#pragma warning restore CS0618 // obsolete
        public async Task UpdateEncryptedMessage(ClientSideEncryptionVersion version)
        {
            var message1 = GetRandomMessage(Constants.KB);
            var message2 = GetRandomMessage(Constants.KB);
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey.Object,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var queue = disposable.Queue;

                // upload with encryption
                await queue.SendMessageAsync(message1, cancellationToken: s_cancellationToken); // invokes key wrap first time

                // download and update message
                var messageToUpdate = (await queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value[0];
                await queue.UpdateMessageAsync(messageToUpdate.MessageId, messageToUpdate.PopReceipt, message2, cancellationToken: s_cancellationToken); // invokes key unwrap first time and key wrap second time

                // download with decryption
                var receivedMessages = (await queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken)).Value; // invokes key unwrap second time
                Assert.AreEqual(1, receivedMessages.Length);
                var downloadedMessage = receivedMessages[0].MessageText;

                // compare data
                Assert.AreEqual(message2, downloadedMessage);

                // assert key wrap and unwrap were each invoked twice
                MethodInfo keyWrap;
                MethodInfo keyUnwrap;
                if (IsAsync)
                {
                    keyWrap = typeof(IKeyEncryptionKey).GetMethod("WrapKeyAsync");
                    keyUnwrap = typeof(IKeyEncryptionKey).GetMethod("UnwrapKeyAsync");
                }
                else
                {
                    keyWrap = typeof(IKeyEncryptionKey).GetMethod("WrapKey");
                    keyUnwrap = typeof(IKeyEncryptionKey).GetMethod("UnwrapKey");
                }
                Assert.AreEqual(2, mockKey.Invocations.Count(invocation => invocation.Method == keyWrap));
                Assert.AreEqual(2, mockKey.Invocations.Count(invocation => invocation.Method == keyUnwrap));
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
        [LiveOnly] // cannot seed content encryption key
#pragma warning restore CS0618 // obsolete
        public async Task OnlyOneKeyResolveAndUnwrapCall(ClientSideEncryptionVersion version)
        {
            var message = "any old message";
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken);
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey.Object);
            await using (var disposable = await GetTestEncryptedQueueAsync(new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = mockKey.Object,
                KeyResolver = mockKeyResolver.Object,
                KeyWrapAlgorithm = s_algorithmName
            }))
            {
                var queue = disposable.Queue;
                await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken).ConfigureAwait(false);

                // replace with client that has only key resolver
                var options = GetOptions();
                options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = default, // we want the key resolver to trigger; no cached key
                    KeyResolver = mockKeyResolver.Object
                };
                queue = InstrumentClient(new QueueClient(
                    queue.Uri,
                    GetNewSharedKeyCredentials(),
                    options));

                await queue.ReceiveMessagesAsync(cancellationToken: s_cancellationToken);

                System.Reflection.MethodInfo resolveSyncMethod = typeof(IKeyEncryptionKeyResolver).GetMethod("Resolve");
                System.Reflection.MethodInfo resolveAsyncMethod = typeof(IKeyEncryptionKeyResolver).GetMethod("ResolveAsync");
                System.Reflection.MethodInfo unwrapSyncMethod = typeof(IKeyEncryptionKey).GetMethod("UnwrapKey");
                System.Reflection.MethodInfo unwrapAsyncMethod = typeof(IKeyEncryptionKey).GetMethod("UnwrapKeyAsync");

                Assert.AreEqual(1, IsAsync
                    ? mockKeyResolver.Invocations.Count(invocation => invocation.Method == resolveAsyncMethod)
                    : mockKeyResolver.Invocations.Count(invocation => invocation.Method == resolveSyncMethod));
                Assert.AreEqual(0, IsAsync
                    ? mockKeyResolver.Invocations.Count(invocation => invocation.Method == resolveSyncMethod)
                    : mockKeyResolver.Invocations.Count(invocation => invocation.Method == resolveAsyncMethod));

                Assert.AreEqual(1, IsAsync
                    ? mockKey.Invocations.Count(invocation => invocation.Method == unwrapAsyncMethod)
                    : mockKey.Invocations.Count(invocation => invocation.Method == unwrapSyncMethod));
                Assert.AreEqual(0, IsAsync
                    ? mockKey.Invocations.Count(invocation => invocation.Method == unwrapSyncMethod)
                    : mockKey.Invocations.Count(invocation => invocation.Method == unwrapAsyncMethod));
            }
        }

        [Test]
        [Combinatorial]
        [LiveOnly]
        public async Task CannotFindKeyAsync(
            [Values(true, false)] bool useListener,
            [Values(true, false)] bool resolverThrows,
            [Values(true, false)] bool peek,
            [ValueSource("GetEncryptionVersions")] ClientSideEncryptionVersion version)
        {
            const int numMessages = 5;
            var message = "any old message";
            var mockKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object;
            var mockKeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, mockKey).Object;
            await using (var disposable = await GetTestEncryptedQueueAsync(
                new ClientSideEncryptionOptions(version)
                {
                    KeyEncryptionKey = mockKey,
                    KeyResolver = mockKeyResolver,
                    KeyWrapAlgorithm = s_algorithmName
                }))
            {
                var queue = disposable.Queue;
                foreach (var _ in Enumerable.Range(0, numMessages))
                {
                    await queue.SendMessageAsync(message, cancellationToken: s_cancellationToken).ConfigureAwait(false);
                }

                bool threw = false;
                var resolver = this.GetAlwaysFailsKeyResolver(s_cancellationToken, resolverThrows);
                int returnedMessages = int.MinValue; // obviously wrong value, but need to initialize to something before try block
                int failureEventCalled = 0;
                try
                {
                    // download but can't find key
                    var encryptionOptions = new QueueClientSideEncryptionOptions(version)
                    {
                        // note decryption will throw whether the resolver throws or just returns null
                        KeyResolver = resolver.Object,
                        KeyWrapAlgorithm = "test"
                    };
                    if (useListener)
                    {
                        encryptionOptions.DecryptionFailed += (source, args) => failureEventCalled++;
                    }
                    var options = GetOptions();
                    options._clientSideEncryptionOptions = encryptionOptions;
                    var badQueueClient = InstrumentClient(new QueueClient(queue.Uri, GetNewSharedKeyCredentials(), options));
                    returnedMessages = peek
                        ? (await badQueueClient.PeekMessagesAsync(numMessages, cancellationToken: s_cancellationToken)).Value.Length
                        : (await badQueueClient.ReceiveMessagesAsync(numMessages, cancellationToken: s_cancellationToken)).Value.Length;
                }
                catch (MockException e)
                {
                    Assert.Fail(e.Message);
                }
                catch (Exception)
                {
                    threw = true;
                }
                finally
                {
                    Assert.AreNotEqual(useListener, threw);

                    if (useListener)
                    {
                        // we already asserted the correct method was called in `catch (MockException e)`
                        Assert.AreEqual(numMessages, resolver.Invocations.Count);

                        // assert event was called for each message
                        Assert.AreEqual(numMessages, failureEventCalled);

                        // assert all messages were filtered out of formal response
                        Assert.AreEqual(0, returnedMessages);
                    }
                }
            }
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
#pragma warning restore CS0618 // obsolete
        public void CanGenerateSas_WithClientSideEncryptionOptions_True(ClientSideEncryptionVersion version)
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            var options = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };

            // Create blob
            QueueClient queue = new QueueClient(
                connectionString,
                GetNewQueueName());
            Assert.IsTrue(queue.CanGenerateSasUri);

            // Act
            QueueClient queueEncrypted = queue.WithClientSideEncryptionOptions(options);

            // Assert
            Assert.IsTrue(queueEncrypted.CanGenerateSasUri);
        }

#pragma warning disable CS0618 // obsolete
        [TestCase(ClientSideEncryptionVersion.V1_0)]
        [TestCase(ClientSideEncryptionVersion.V2_0)]
#pragma warning restore CS0618 // obsolete
        public void CanGenerateSas_WithClientSideEncryptionOptions_False(ClientSideEncryptionVersion version)
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            var options = new ClientSideEncryptionOptions(version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(s_cancellationToken).Object,
                KeyResolver = this.GetIKeyEncryptionKeyResolver(s_cancellationToken, default).Object,
                KeyWrapAlgorithm = "bar"
            };

            // Create blob
            QueueClient queue = InstrumentClient(new QueueClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(queue.CanGenerateSasUri);

            // Act
            QueueClient queueEncrypted = queue.WithClientSideEncryptionOptions(options);

            // Assert
            Assert.IsFalse(queueEncrypted.CanGenerateSasUri);
        }
    }
}
