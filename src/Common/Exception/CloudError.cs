//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Representation of the error object from the server.
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// Parsed error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Parsed error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Original error body
        /// </summary>
        public string OriginalMessage { get; set; }
    }
}
