// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    internal class ClientSideBlobEncryptionPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// The {@link IKeyResolver} used to select the correct key for decrypting existing blobs.
        /// </summary>
        private IKeyEncryptionKeyResolver KeyResolver { get; }

        /// <summary>
        /// An object of type {@link IKey} that is used to wrap/unwrap the content key during encryption.
        /// </summary>
        private IKeyEncryptionKey KeyWrapper { get; }

        /// <summary>
        /// Initializes a new instance of the {@link BlobEncryptionPolicy} class with the specified key and resolver.
        /// <para />
        /// If the generated policy is intended to be used for encryption, users are expected to provide a key at the
        /// minimum.The absence of key will cause an exception to be thrown during encryption. If the generated policy is
        /// intended to be used for decryption, users can provide a keyResolver.The client library will - 1. Invoke the key
        /// resolver if specified to get the key. 2. If resolver is not specified but a key is specified, match the key id on
        /// the key and use it.
        /// </summary>
        /// <param name="key">An object of type {@link IKey} that is used to wrap/unwrap the content encryption key.</param>
        /// <param name="keyResolver">The key resolver used to select the correct key for decrypting existing blobs.</param>
        /// <param name="requireEncryption">If set to true, decryptBlob() will throw an IllegalArgumentException if blob is not encrypted.</param>
        public ClientSideBlobEncryptionPolicy(
            IKeyEncryptionKey key = default,
            IKeyEncryptionKeyResolver keyResolver = default)
        {
            this.KeyWrapper = key;
            this.KeyResolver = keyResolver;
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            throw new NotImplementedException();
        }

        public override ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            throw new NotImplementedException();
        }

        #region Encryption

        #endregion

        #region Decryption

        private async Task<Stream> DecryptBlobAsync(Stream ciphertext, Metadata metadata,
            EncryptedBlobRange encryptedBlobRange, bool padding)
        {
            if (this.KeyWrapper == default && this.KeyResolver == default)
            {
                throw new InvalidOperationException("Key and KeyResolver cannot both be null");
            }

            var encryptionData = getAndValidateEncryptionData(metadata);

            // The number of bytes we have put into the Cipher so far.
            InterlockedLong totalInputBytes = new InterlockedLong(0);
            // The number of bytes that have been sent to the downstream so far.
            InterlockedLong totalOutputBytes = new InterlockedLong(0);

            var contentEncryptionKey = await GetKeyEncryptionKey(encryptionData).ConfigureAwait(false);

            /*
            Calculate the IV.

            If we are starting at the beginning, we can grab the IV from the encryptionData. Otherwise,
            Rx makes it difficult to grab the first 16 bytes of data to pass as an IV to the cipher.
            As a work around, we initialize the cipher with a garbage IV (empty byte array) and attempt to
            decrypt the first 16 bytes (the actual IV for the relevant data). We throw away this "decrypted"
            data. Now, though, because each block of 16 is used as the IV for the next, the original 16 bytes
            of downloaded data are in position to be used as the IV for the data actually requested and we are
            in the desired state.
            */
            var IV = new byte[EncryptionConstants.ENCRYPTION_BLOCK_SIZE];
            /*
            Adjusting the range by <= 16 means we only adjusted to align on an encryption block boundary
            (padding will add 1-16 bytes as it will prefer to pad 16 bytes instead of 0) and therefore the key
            is in the metadata.
                */
            if (encryptedBlobRange.OriginalRange.Offset - encryptedBlobRange.AdjustedRange.Offset <= EncryptionConstants.ENCRYPTION_BLOCK_SIZE)
            {
                IV = encryptionData.ContentEncryptionIV;
            }

            RijndaelManaged rmCrypto = new RijndaelManaged();
            CryptoStream cryptStream = new CryptoStream(
                ciphertext,
                rmCrypto.CreateDecryptor(contentEncryptionKey.ToArray(), IV),
                CryptoStreamMode.Read);

            try
            {
                cipher = getCipher(contentEncryptionKey, encryptionData, IV, padding);
            }
            catch (InvalidKeyException e)
            {
                throw logger.logExceptionAsError(Exceptions.propagate(e));
            }

            return encryptedFlux.map(encryptedByteBuffer-> {
                ByteBuffer plaintextByteBuffer;
                /*
                If we could potentially decrypt more bytes than encryptedByteBuffer can hold, allocate more
                room. Note that, because getOutputSize returns the size needed to store
                max(updateOutputSize, finalizeOutputSize), this is likely to produce a ByteBuffer slightly
                larger than what the real outputSize is. This is accounted for below.
                    */
                int outputSize = cipher.getOutputSize(encryptedByteBuffer.remaining());
                if (outputSize > encryptedByteBuffer.remaining())
                {
                    plaintextByteBuffer = ByteBuffer.allocate(outputSize);
                }
                else
                {
                    /*
                    This is an ok optimization on download as the underlying buffer is not the customer's but
                    the protocol layer's, which does not expect to be able to reuse it.
                        */
                    plaintextByteBuffer = encryptedByteBuffer.duplicate();
                }

                // First, determine if we should update or finalize and fill the output buffer.

                // We will have reached the end of the downloaded range. Finalize.
                int decryptedBytes;
                int bytesToInput = encryptedByteBuffer.remaining();
                if (totalInputBytes.longValue() + bytesToInput >= encryptedBlobRange.adjustedDownloadCount())
                {
                    try
                    {
                        decryptedBytes = cipher.doFinal(encryptedByteBuffer, plaintextByteBuffer);
                    }
                    catch (GeneralSecurityException e)
                    {
                        throw logger.logExceptionAsError(Exceptions.propagate(e));
                    }
                }
                // We will not have reached the end of the downloaded range. Update.
                else
                {
                    try
                    {
                        decryptedBytes = cipher.update(encryptedByteBuffer, plaintextByteBuffer);
                    }
                    catch (ShortBufferException e)
                    {
                        throw logger.logExceptionAsError(Exceptions.propagate(e));
                    }
                }
                totalInputBytes.addAndGet(bytesToInput);
                plaintextByteBuffer.position(0); // Reset the position after writing.

                // Next, determine and set the position of the output buffer.

                /*
                The amount of data sent so far has not yet reached customer-requested data. i.e. it starts
                somewhere in either the IV or the range adjustment to align on a block boundary. We should
                advance the position so the customer does not read this data.
                    */
                if (totalOutputBytes.longValue() <= encryptedBlobRange.offsetAdjustment())
                {
                    /*
                    Note that the cast is safe because of the bounds on offsetAdjustment (see encryptedBlobRange
                    for details), which here upper bounds totalInputBytes.
                    Note that we do not simply set the position to be offsetAdjustment because of the (unlikely)
                    case that some ByteBuffers were small enough to be entirely contained within the
                    offsetAdjustment, so when we do reach customer-requested data, advancing the position by
                    the whole offsetAdjustment would be too much.
                        */
                    int remainingAdjustment = encryptedBlobRange.offsetAdjustment() -
                        (int)totalOutputBytes.longValue();

                    /*
                    Setting the position past the limit will throw. This is in the case of very small
                    ByteBuffers that are entirely contained within the offsetAdjustment.
                        */
                    int newPosition = remainingAdjustment <= plaintextByteBuffer.limit() ?
                        remainingAdjustment : plaintextByteBuffer.limit();

                    plaintextByteBuffer.position(newPosition);

                }
                /*
                Else: The beginning of this ByteBuffer is somewhere after the offset adjustment. If it is in the
                middle of customer requested data, let it be. If it starts in the end adjustment, this will
                be trimmed effectively by setting the limit below.
                    */

                // Finally, determine and set the limit of the output buffer.

                long beginningOfEndAdjustment; // read: beginning of end-adjustment.
                                                /*
                                                The user intended to download the whole blob, so the only extra we downloaded was padding, which
                                                is trimmed by the cipher automatically; there is effectively no beginning to the end-adjustment.
                                                */
                if (encryptedBlobRange.originalRange().count() == null)
                {
                    beginningOfEndAdjustment = Long.MAX_VALUE;
                }
                // Calculate the end of the user-requested data so we can trim anything after.
                else
                {
                    beginningOfEndAdjustment = encryptedBlobRange.offsetAdjustment() +
                        encryptedBlobRange.originalRange().count();
                }

                /*
                The end of the Cipher output lies after customer requested data (in the end adjustment) and
                should be trimmed.
                    */
                if (decryptedBytes + totalOutputBytes.longValue() > beginningOfEndAdjustment)
                {
                    long amountPastEnd // past the end of user-requested data.
                        = decryptedBytes + totalOutputBytes.longValue() - beginningOfEndAdjustment;
                    /*
                    Note that amountPastEnd can only be up to 16, so the cast is safe. We do not need to worry
                    about limit() throwing because we allocated at least enough space for decryptedBytes and
                    the newLimit will be less than that. In the case where this Cipher output starts after the
                    beginning of the endAdjustment, we don't want to send anything back, so we set limit to be
                    the same as position.
                        */
                    int newLimit = totalOutputBytes.longValue() <= beginningOfEndAdjustment ?
                        decryptedBytes - (int)amountPastEnd : plaintextByteBuffer.position();
                    plaintextByteBuffer.limit(newLimit);
                }
                /*
                The end of this Cipher output is before the end adjustment and after the offset adjustment, so
                it will lie somewhere in customer requested data. It is possible we allocated a ByteBuffer that
                is slightly too large, so we set the limit equal to exactly the amount we decrypted to be safe.
                    */
                else if (decryptedBytes + totalOutputBytes.longValue() >
                    encryptedBlobRange.offsetAdjustment())
                {
                    plaintextByteBuffer.limit(decryptedBytes);
                }
                /*
                Else: The end of this ByteBuffer will not reach the beginning of customer-requested data. Make
                it effectively empty.
                    */
                else
                {
                    plaintextByteBuffer.limit(plaintextByteBuffer.position());
                }

                totalOutputBytes.addAndGet(decryptedBytes);
                return plaintextByteBuffer;
            }

        #endregion

        /// <summary>
        /// Gets and validates a blob's encryption-related metadata
        /// </summary>
        /// <param name="metadata">The blob's metadata</param>
        /// <returns>The relevant metadata.</returns>
        private EncryptionData getAndValidateEncryptionData(Metadata metadata)
        {
            _ = metadata ?? throw new InvalidOperationException();

            EncryptionData encryptionData;
            if (metadata.TryGetValue(EncryptionConstants.ENCRYPTION_DATA_KEY, out string encryptedDataString))
            {
                using (var reader = new StringReader(encryptedDataString))
                {
                    var serializer = new XmlSerializer(typeof(EncryptionData));
                    encryptionData = (EncryptionData)serializer.Deserialize(reader);
                }
            }
            else
            {
                throw new InvalidOperationException("Encryption data does not exist.");
            }

            _ = encryptionData.ContentEncryptionIV ?? throw new NullReferenceException();
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw new NullReferenceException();

            // Throw if the encryption protocol on the message doesn't match the version that this client library
            // understands
            // and is able to decrypt.
            if (EncryptionConstants.ENCRYPTION_PROTOCOL_V1 != encryptionData.EncryptionAgent.Protocol) {
                throw new ArgumentException(
                    "Invalid Encryption Agent. This version of the client library does not understand the " +
                        $"Encryption Agent set on the queue message: {encryptionData.EncryptionAgent}");
            }

            return encryptionData;
        }

        /// <summary>
        /// Returns the key encryption key for blob. First tries to get key encryption key from KeyResolver, then
        /// falls back to IKey stored on this EncryptionPolicy.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <returns>Encryption key as a byte array.</returns>
        private async Task<Memory<byte>> GetKeyEncryptionKey(EncryptionData encryptionData)
        {
            /*
             * 1. Invoke the key resolver if specified to get the key. If the resolver is specified but does not have a
             * mapping for the key id, an error should be thrown. This is important for key rotation scenario.
             * 2. If resolver is not specified but a key is specified, match the key id on the key and and use it.
             */

            IKeyEncryptionKey key;

            if (this.KeyResolver != null)
            {
                key = await this.KeyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId).ConfigureAwait(false);
            }
            else
            {
                if (encryptionData.WrappedContentKey.KeyId == this.KeyWrapper.KeyId)
                {
                    key = this.KeyWrapper;
                }
                else
                {
                    throw new ArgumentException("Key mismatch. The key id stored on " +
                        "the service does not match the specified key.");
                }
            }

            return await key.UnwrapKeyAsync(
                encryptionData.WrappedContentKey.Algorithm,
                encryptionData.WrappedContentKey.EncryptedKey).ConfigureAwait(false);
        }
    }

    internal struct InterlockedLong
    {
        private long _value;

        public InterlockedLong(long l)
        {
            _value = l;
        }

        public long Increment()
        {
            return Interlocked.Increment(ref _value);
        }

        public long Decrement()
        {
            return Interlocked.Decrement(ref _value);
        }

        public long Add(long l)
        {
            return Interlocked.Add(ref _value, l);
        }
    }
}
