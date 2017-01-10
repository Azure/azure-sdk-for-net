// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    internal static class StringExtensions
    {

        /// <summary>
        /// Finds the index in the given buffer of a newline character, either the first or the last (based on the parameters).
        /// If a combined newline (\r\n), the index returned is that of the last character in the sequence.
        /// </summary>
        /// <param name="buffer">The buffer to search in.</param>
        /// <param name="startOffset">The index of the first byte to start searching at.</param>
        /// <param name="length">The number of bytes to search, starting from the given startOffset.</param>
        /// <param name="reverse">If true, searches from the startOffset down to the beginning of the buffer. If false, searches upwards.</param>
        /// <returns>The index of the closest newline character in the sequence (based on direction) that was found. Returns -1 if not found. </returns>
        public static int FindNewline(byte[] buffer, int startOffset, int length, bool reverse, System.Text.Encoding encoding, string delimiter = null)
        {
            if (buffer.Length == 0 || length == 0)
            {
                return -1;
            }

            // define the bytes per character to use
            int bytesPerChar;
            switch (encoding.CodePage)
            {
                // Big Endian Unicode (UTF-16)
                case 1201:
                // Unicode (UTF-16)
                case 1200:
                    bytesPerChar = 2;
                    break;
                // UTF-32
                case 12000:
                    bytesPerChar = 4;
                    break;
                // ASCII
                case 20127:
                // UTF-8
                case 65001:
                // UTF-7
                case 65000:
                // Default to UTF-8
                default:
                    bytesPerChar = 1;
                    break;
            }

            if(!string.IsNullOrEmpty(delimiter) && delimiter.Length > 1)
            {
                throw new ArgumentException("delimiter", "The delimiter must only be a single character or unspecified to represent the CRLF delimiter");
            }

            if (!string.IsNullOrEmpty(delimiter))
            {
                // convert the byte array back to a string
                var startOfSegment = reverse ? startOffset - length + 1 : startOffset;
                var bytesToString = encoding.GetString(buffer, startOfSegment, length);
                if(!bytesToString.Contains(delimiter))
                {
                    // didn't find the delimiter.
                    return -1;
                }

                // the index is returned, which is 0 based, so our loop must include the zero case.
                var numCharsToDelim = reverse ? bytesToString.LastIndexOf(delimiter) : bytesToString.IndexOf(delimiter);
                var toReturn = 0;
                for (int i = 0; i <= numCharsToDelim; i++)
                {
                    toReturn += encoding.GetByteCount(bytesToString[startOfSegment + i].ToString());
                }

                // we get the total number of bytes, but we want to return the index (which starts at 0)
                // so we subtract 1 from the total number of bytes to get the final byte index.
                return toReturn - 1;
            }

            //endOffset is a 'sentinel' value; we use that to figure out when to stop searching 
            int endOffset = reverse ? startOffset - length : startOffset + length;

            // if we are starting at the end, we need to move toward the front enough to grab the right number of bytes
            startOffset = reverse ? startOffset - (bytesPerChar - 1) : startOffset;

            if (startOffset < 0 || startOffset >= buffer.Length)
            {
                throw new ArgumentOutOfRangeException("startOffset", "Given start offset is outside the bounds of the given buffer. In reverse cases, the start offset is modified to ensure we check the full size of the last character");
            }

            // make sure that the length we are traversing is at least as long as a single character
            if ( length < bytesPerChar)
            {
                throw new ArgumentOutOfRangeException("length", "Length must be at least as long as the length, in bytes, of a single character");
            }

            if (endOffset < -1 || endOffset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException("length", "Given combination of startOffset and length would execute the search outside the bounds of the given buffer.");
            }

            int bufferEndOffset = reverse ? startOffset : startOffset + length;
            int result = -1;
            for (int charPos = startOffset; reverse ? charPos != endOffset : charPos + bytesPerChar - 1 < endOffset; charPos = reverse ? charPos - 1 : charPos + 1)
            {
                char c = bytesPerChar == 1 ? (char)buffer[charPos] : encoding.GetString(buffer, charPos, bytesPerChar).ToCharArray()[0];
                if (IsNewline(c, delimiter))
                {
                    result = charPos + bytesPerChar -1;
                    break;
                }
            }

            if (string.IsNullOrEmpty(delimiter) && !reverse && result < bufferEndOffset - bytesPerChar && IsNewline(bytesPerChar == 1 ? (char)buffer[result + bytesPerChar] : encoding.GetString(buffer, result + 1, bytesPerChar).ToCharArray()[0]))
            {
                //we originally landed on a \r character; if we have a \r\n character, advance one position to include that
                result+= bytesPerChar;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified character is newline.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns></returns>
        private static bool IsNewline(char c, string delimiter = null)
        {
            if (string.IsNullOrEmpty(delimiter))
            {
                return c == '\r' || c == '\n';
            }

            return c == delimiter[0];
        }
    }
}
