// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro
{
    using System;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Class representing a single generated serializer.
    /// </summary>
    internal sealed class GeneratedSerializer
    {
        /// <summary>
        /// Gets or sets the reader schema.
        /// </summary>
        public TypeSchema ReaderSchema { get; set; }

        /// <summary>
        /// Gets or sets the writer schema.
        /// </summary>
        public TypeSchema WriterSchema { get; set; }

        /// <summary>
        /// Gets or sets the serialize function.
        /// </summary>
        //public Action<IEncoder, object> Serialize { get; set; }
        public Delegate Serialize { get; set; }

        /// <summary>
        /// Gets or sets the deserialize function.
        /// </summary>
        //public Func<IDecoder, object> Deserialize { get; set; }
        public Delegate Deserialize { get; set; }
    }
}
