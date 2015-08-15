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
namespace Microsoft.Hadoop.Avro.Schema
{
    using System.Collections.Generic;

    /// <summary>
    ///     Class containing standard properties for different avro types.
    /// </summary>
    internal static class StandardProperties
    {
        public static readonly HashSet<string> Primitive = new HashSet<string> { Token.Type };

        public static readonly HashSet<string> Record = new HashSet<string>
        {
            Token.Type,
            Token.Name,
            Token.Namespace,
            Token.Doc,
            Token.Aliases,
            Token.Fields
        };

        public static readonly HashSet<string> Enumeration = new HashSet<string>
        {
            Token.Type,
            Token.Name,
            Token.Namespace,
            Token.Doc,
            Token.Aliases,
            Token.Symbols
        };
    }
}
