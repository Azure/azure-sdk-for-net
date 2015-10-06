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
namespace ProcDetailsTestApplication
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Represents a set of sections containing entries.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Not applicable in this case. [TGS]")]
    [Serializable]
    public class Sections : Dictionary<string, Entries>
    {
        /// <summary>
        /// Initializes a new instance of the Sections class.
        /// </summary>
        public Sections()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sections class.
        /// Used for serialization construction.
        /// </summary>
        /// <param name="info">
        /// The serialization info object.
        /// </param>
        /// <param name="context">
        /// The serialization context object.
        /// </param>
        protected Sections(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sections class.
        /// Used to copy from an existing dictionary of sections.
        /// </summary>
        /// <param name="content">
        /// The content to be copied.
        /// </param>
        public Sections(IDictionary<string, Entries> content) : base(content)
        {
        }
    }
}
