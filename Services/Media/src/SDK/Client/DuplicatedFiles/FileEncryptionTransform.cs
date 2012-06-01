// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Security.Cryptography;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public class FileEncryptionTransform : ICryptoTransform
    {
        const int aesBlockSize = 16;
        readonly ulong _initializationVector;
        ICryptoTransform _transform;

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

            _initializationVector = iv;
            _transform = transform;
            FileOffset = fileOffset;
        }

        public long FileOffset { get; set; }

        #region ICryptoTransformMembers

        public int InputBlockSize
        {
            get { return 1; }
        }

        public int OutputBlockSize
        {
            get { return 1; }
        }

        public bool CanTransformMultipleBlocks
        {
            get { return true; }
        }

        public bool CanReuseTransform
        {
            get { return false; }
        }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            Array.Copy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
            AesCtr(outputBuffer, outputOffset, inputCount, FileOffset);
            FileOffset += inputCount;

            return inputCount;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[] tempOutputBuffer = new byte[inputCount];

            if (inputCount != 0)
            {
                TransformBlock(inputBuffer, inputOffset, inputCount, tempOutputBuffer, 0);
            }

            return tempOutputBuffer;
        }

        #endregion

        #region IDisposeMembers

        public void Dispose()
        {
            Dispose(true);

            // Take this object off the finalization queue and prevent the finalization
            // code from running a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transform != null)
                {
                    _transform.Dispose();
                    _transform = null;
                }
            }
        }

        #endregion

        private delegate void AsyncAesDelegate(byte[] data, int offset, int length, long fileOffset);
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

            //
            //  The fileOffset represents the number of bytes from the start of the file that
            //  data[offset] was copied from.  We need to convert this byte offset into a block
            //  offset (number of 16 byte blocks from the front of the file) and the byte offset 
            //  within the block.
            //
            long offsetFromStartOfFileToFirstByteToProcess = fileOffset;
            UInt64 currentBlock = Convert.ToUInt64(offsetFromStartOfFileToFirstByteToProcess) / aesBlockSize;
            int startByteInFirstBlock = Convert.ToInt32(offsetFromStartOfFileToFirstByteToProcess % aesBlockSize);

            //
            //  Calculate the byte length of the cryptostream
            //
            int totalLength = startByteInFirstBlock + length;
            int totalBlockCount = ((totalLength) / aesBlockSize) + ((totalLength % aesBlockSize > 0) ? 1 : 0);
            int cryptoStreamLength = totalBlockCount * aesBlockSize;

            //
            //  Write the data to encrypt to the cryptostream
            //
            byte[] ivAsBigEndianBytes = new byte[8];
            byte[] cryptoStream = new byte[cryptoStreamLength];
            ConvertToBigEndianBytes(_initializationVector, ivAsBigEndianBytes, 0);

            for (int i = 0; i < totalBlockCount; i++)
            {
                Array.Copy(ivAsBigEndianBytes, 0, cryptoStream, i * 16, ivAsBigEndianBytes.Length);
                ConvertToBigEndianBytes(currentBlock, cryptoStream, i * 16 + 8);
                currentBlock++;
            }

            _transform.TransformBlock(cryptoStream, 0, cryptoStream.Length, cryptoStream, 0);

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

        private static void ConvertToBigEndianBytes(ulong original, byte[] outputBuffer, int indexToWriteTo)
        {
            byte[] originalAsBytes = BitConverter.GetBytes(original);

            int destIndex = indexToWriteTo;
            for (int sourceIndex = (originalAsBytes.Length - 1); sourceIndex >= 0; sourceIndex--)
            {
                outputBuffer[destIndex] = originalAsBytes[sourceIndex];
                destIndex++;
            }
        }
    }
}
