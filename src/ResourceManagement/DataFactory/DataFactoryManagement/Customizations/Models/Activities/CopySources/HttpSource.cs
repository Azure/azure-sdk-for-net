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

using System;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity source for an HTTP file.
    /// </summary>
    public class HttpSource : CopySource
    {
        /// <summary>
        /// Optional. Specifies the timeout for an HTTP client to get a response. 
        /// </summary>
        public TimeSpan RequestTimeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSource" />
        /// class with required arguments.
        /// </summary>
        public HttpSource()
        {
        }
    }
}
