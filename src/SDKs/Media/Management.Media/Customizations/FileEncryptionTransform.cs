// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.Management.Media.StorageEncryption
{
    /// <summary>
    /// Provides a file encryption transformation.
    /// </summary>
    [Obsolete("The Azure Media Services StorageEncryption feature has been deprecated in favor of Azure Storage Server Side Encryption.  Existing Asset files with StorageEncryption applied can be decrypted but new Assets cannot use StorageEncryption.")]
    public class FileEncryptionTransform : ICryptoTransform
    {
        /// <summary>
        /// The AES block size.
        /// </summary>
        internal const int AesBlockSize = 16;

        private readonly ulong _initializationVector;

        private ICryptoTransform _transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEncryptionTransform"/> class.
        /// </summary>
        /// <param name="transform">The transform.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <param name="fileOffset">The file offset.</param>
        internal FileEncryptionTransform(ICryptoTransform transform, ulong iv, long fileOffset)
        {
            if (transform == null)
            {
                throw new ArgumentNullException("transform");
            }

            if (fileOffset < 0)
            {
                throw new ArgumentOutOfRangeException("fileOffset", "fileOffset cannot be less than zero");
            }

            this._initializationVector = iv;
            this._transform = transform;
            this.FileOffset = fileOffset;
        }

        private delegate void AsyncAesDelegate(byte[] data, int offset, int length, long fileOffset);

        /// <summary>
        /// Gets or sets the file offset.
        /// </summary>
        /// <value>
        /// The file offset.
        /// </value>
        public long FileOffset { get; set; }

        #region ICryptoTransformMembers

        /// <summary>
        /// Gets the input block size.
        /// </summary>
        /// <returns>The size of the input data blocks in bytes.</returns>
        public int InputBlockSize
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the output block size.
        /// </summary>
        /// <returns>The size of the output data blocks in bytes.</returns>
        public int OutputBlockSize
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a value indicating whether multiple blocks can be transformed.
        /// </summary>
        /// <returns>true if multiple blocks can be transformed; otherwise, false.</returns>
        public bool CanTransformMultipleBlocks
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current transform can be reused.
        /// </summary>
        /// <returns>true if the current transform can be reused; otherwise, false.</returns>
        public bool CanReuseTransform
        {
            get { return false; }
        }

        /// <summary>
        /// Transforms the specified region of the input byte array and copies the resulting transform to the specified region of the output byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the input byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the input byte array to use as data.</param>
        /// <param name="outputBuffer">The output to which to write the transform.</param>
        /// <param name="outputOffset">The offset into the output byte array from which to begin writing data.</param>
        /// <returns>
        /// The number of bytes written.
        /// </returns>
        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            Array.Copy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
            this.AesCtr(outputBuffer, outputOffset, inputCount, this.FileOffset);
            this.FileOffset += inputCount;

            return inputCount;
        }

        /// <summary>
        /// Transforms the specified region of the specified byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the byte array to use as data.</param>
        /// <returns>
        /// The computed transform.
        /// </returns>
        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[] tempOutputBuffer = new byte[inputCount];

            if (inputCount != 0)
            {
                this.TransformBlock(inputBuffer, inputOffset, inputCount, tempOutputBuffer, 0);
            }

            return tempOutputBuffer;
        }

        #endregion

        #region IDisposeMembers

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // Take this object off the finalization queue and prevent the finalization
            // code from running a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._transform != null)
                {
                    this._transform.Dispose();
                    this._transform = null;
                }
            }
        }

        #endregion

        private static void ConvertToBigEndianBytes(ulong original, byte[] outputBuffer, int indexToWriteTo)
        {
            byte[] originalAsBytes = BitConverter.GetBytes(original);

            int destIndex = indexToWriteTo;
            for (int sourceIndex = originalAsBytes.Length - 1; sourceIndex >= 0; sourceIndex--)
            {
                outputBuffer[destIndex] = originalAsBytes[sourceIndex];
                destIndex++;
            }
        }

        private void AesCtr(byte[] data, int offset, int length, long fileOffset)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", offset, "Negative values are not allowed for offset.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Negative values are not allowed for length.");
            }

            if (fileOffset < 0)
            {
                throw new ArgumentOutOfRangeException("fileOffset", fileOffset, "Negative values are not allowed for fileOffset.");
            }

            // The fileOffset represents the number of bytes from the start of the file that
            // data[offset] was copied from.  We need to convert this byte offset into a block
            // offset (number of 16 byte blocks from the front of the file) and the byte offset 
            // within the block.
            long offsetFromStartOfFileToFirstByteToProcess = fileOffset;
            ulong currentBlock = Convert.ToUInt64(offsetFromStartOfFileToFirstByteToProcess) / AesBlockSize;
            int startByteInFirstBlock = Convert.ToInt32(offsetFromStartOfFileToFirstByteToProcess % AesBlockSize);

            // Calculate the byte length of the cryptostream.
            int totalLength = startByteInFirstBlock + length;
            int totalBlockCount = (totalLength / AesBlockSize) + ((totalLength % AesBlockSize > 0) ? 1 : 0);
            int cryptoStreamLength = totalBlockCount * AesBlockSize;

            // Write the data to encrypt to the cryptostream.
            byte[] initializationVectorAsBigEndianBytes = new byte[8];
            byte[] cryptoStream = new byte[cryptoStreamLength];
            ConvertToBigEndianBytes(this._initializationVector, initializationVectorAsBigEndianBytes, 0);

            for (int i = 0; i < totalBlockCount; i++)
            {
                Array.Copy(initializationVectorAsBigEndianBytes, 0, cryptoStream, i * 16, initializationVectorAsBigEndianBytes.Length);
                ConvertToBigEndianBytes(currentBlock, cryptoStream, (i * 16) + 8);
                currentBlock++;
            }

            this._transform.TransformBlock(cryptoStream, 0, cryptoStream.Length, cryptoStream, 0);

            int cryptoStreamIndex = startByteInFirstBlock;
            int dataIndex = offset;
            while (dataIndex < (offset + length))
            {
                data[dataIndex] ^= cryptoStream[cryptoStreamIndex];

                // increment our indexes
                cryptoStreamIndex++;
                dataIndex++;
            }
        }
    }
}
