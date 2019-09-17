// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
{
    class ClientSideBlobEncryptionPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// The {@link IKeyResolver} used to select the correct key for decrypting existing blobs.
        /// </summary>
        private IKeyResolver KeyResolver { get; }

        /// <summary>
        /// An object of type {@link IKey} that is used to wrap/unwrap the content key during encryption.
        /// </summary>
        private IKey KeyWrapper { get; }

        /// <summary>
        /// A value to indicate that the data read from the server should be encrypted.
        /// </summary>
        private bool RequireEncryption { get; }

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
        public ClientSideBlobEncryptionPolicy(IKey key = default, IKeyResolver keyResolver = default, bool requireEncryption = true)
        {
            this.KeyWrapper = key;
            this.KeyResolver = keyResolver;
            this.RequireEncryption = requireEncryption;
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            throw new NotImplementedException();
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
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

            EncryptionData encryptionData = getAndValidateEncryptionData(metadata);
            if (encryptionData == null)
            {
                if (this.RequireEncryption)
                {
                    throw new IllegalStateException("Require encryption is set to true but the blob is not encrypted.");
                }
                else
                {
                    return encryptedFlux;
                }
            }

            // The number of bytes we have put into the Cipher so far.
            AtomicLong totalInputBytes = new AtomicLong(0);
            // The number of bytes that have been sent to the downstream so far.
            AtomicLong totalOutputBytes = new AtomicLong(0);

            return getKeyEncryptionKey(encryptionData)
                .flatMapMany(contentEncryptionKey-> {

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
                byte[] IV = new byte[ENCRYPTION_BLOCK_SIZE];
                /*
                Adjusting the range by <= 16 means we only adjusted to align on an encryption block boundary
                (padding will add 1-16 bytes as it will prefer to pad 16 bytes instead of 0) and therefore the key
                is in the metadata.
                    */
                if (encryptedBlobRange.offsetAdjustment() <= ENCRYPTION_BLOCK_SIZE)
                {
                    IV = encryptionData.contentEncryptionIV();
                }

                Cipher cipher;
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
                });
            });
            }

        #endregion
    }
}
