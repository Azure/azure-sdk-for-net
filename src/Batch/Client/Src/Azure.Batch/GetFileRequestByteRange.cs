// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Batch
{
    using System;

    /// <summary>
    /// The byte range to retrieve in a file download operation.
    /// </summary>
    public class GetFileRequestByteRange
    {
        private const string OcpRangeFormat = "bytes={0}-{1}";

        /// <summary>
        /// Gets the start of the byte range to retrieve.
        /// </summary>
        public int StartRange { get; private set; }

        /// <summary>
        /// Gets the end of the byte range to retrieve.
        /// </summary>
        public int EndRange { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFileRequestByteRange"/> class.
        /// </summary>
        /// <param name="startRange">The start of the byte range to retrieve.</param>
        /// <param name="endRange">The end of the byte range to retrieve.</param>
        public GetFileRequestByteRange(int startRange, int endRange)
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        internal string GetOcpRangeHeader()
        {
            return string.Format(OcpRangeFormat, this.StartRange, this.EndRange);
        }
    }
}
