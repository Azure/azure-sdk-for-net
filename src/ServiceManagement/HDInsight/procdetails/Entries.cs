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
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Represents a group of entries in the serialized data.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Not applicable in this case")]
    [Serializable]
    public class Entries : Dictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the Entries class.
        /// </summary>
        public Entries()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Entries class.
        /// Used for serialization construction.
        /// </summary>
        /// <param name="info">
        /// The serialization info object.
        /// </param>
        /// <param name="context">
        /// The serialization context object.
        /// </param>
        protected Entries(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Entries class.
        /// Used when to copy an existing dictionary of entries.
        /// </summary>
        /// <param name="content">
        /// A dictionary containing the entries to copy.
        /// </param>
        public Entries(IDictionary<string, string> content)
            : base(content)
        {
        }

        /// <summary>
        /// Constructs an entries object from a supplied list of strings.
        /// </summary>
        /// <param name="values">
        /// A list of strings representing the values of the entries object.
        /// </param>
        /// <returns>
        /// A new entries object with the supplied values.
        /// </returns>
        public static Entries MakeEntries(IEnumerable<string> values)
        {
            int index = 0;
            var dictionary = new Dictionary<string, string>();
            var asPairs = values.Select(v => new KeyValuePair<string, string>((index++).ToString(CultureInfo.InvariantCulture), v));
            foreach (var pair in asPairs)
            {
                dictionary.Add(pair.Key, pair.Value);
            }
            return new Entries(dictionary);
        }
    }
}
