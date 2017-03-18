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

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A file from an HTTP web server.
    /// </summary>
    [AdfTypeName("Http")]
    public class HttpDataset : DatasetTypeProperties
    {
        /// <summary>
        /// The relative URL based on the URL in the <see cref="HttpLinkedService" />, which refers to an HTTP file.
        /// </summary>
        public string RelativeUrl { get; set; }

        /// <summary>
        /// The HTTP method for the HTTP request.
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// The body of the HTTP request.
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// The headers of the HTTP Request. 
        /// For example: "header-name1: header-value1 CRLF header-name2: header-value2 CRLF ...".
        /// </summary>
        public string AdditionalHeaders { get; set; }

        /// <summary>
        /// The partitions to be used by the path.
        /// </summary>
        public IList<Partition> PartitionedBy { get; set; }

        /// <summary>
        /// The format of the file.
        /// </summary>
        public StorageFormat Format { get; set; }

        /// <summary>
        /// The data compression method used on files. 
        /// </summary>
        public Compression Compression { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpDataset" />
        /// class with required arguments.
        /// </summary>
        public HttpDataset()
        {
        }
    }
}
