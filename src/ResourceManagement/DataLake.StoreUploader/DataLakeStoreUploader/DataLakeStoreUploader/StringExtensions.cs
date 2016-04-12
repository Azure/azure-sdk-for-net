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
        public static int FindNewline(byte[] buffer, int startOffset, int length, bool reverse)
        {
            if (buffer.Length == 0)
            {
                return -1;
            }

            if (startOffset < 0 || startOffset >= buffer.Length)
            {
                throw new ArgumentOutOfRangeException("startOffset", "Given start offset is outside the bounds of the given buffer.");
            }

            //endOffset is a 'sentinel' value; we use that to figure out when to stop searching 
            int endOffset = reverse ? startOffset - length : startOffset + length;
            if (endOffset < -1 || endOffset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException("length", "Given combination of startOffset and length would execute the search outside the bounds of the given buffer.");
            }

            int bufferEndOffset = reverse ? startOffset : startOffset + length;
            int result = -1;
            for (int charPos = startOffset; charPos != endOffset; charPos = reverse ? charPos - 1 : charPos + 1)
            {
                char c = (char)buffer[charPos];
                if (IsNewline(c))
                {
                    result = charPos;
                    break;
                }
            }

            if (!reverse && result < bufferEndOffset - 1 && IsNewline((char)buffer[result + 1]))
            {
                //we originally landed on a \r character; if we have a \r\n character, advance one position to include that
                result++;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified character is newline.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns></returns>
        private static bool IsNewline(char c)
        {
            return c == '\r' || c == '\n';
        }
    }
}
