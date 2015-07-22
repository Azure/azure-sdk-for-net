﻿// Copyright (c) Microsoft Corporation
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
    using System;

    /// <summary>
    ///     Class represents a string schema.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#schema_primitive">the specification</a>.
    /// </summary>
    public class StringSchema : PrimitiveTypeSchema
    {
        internal StringSchema()
            : this(typeof(string))
        {
        }

        internal StringSchema(Type type)
            : this(type, new Dictionary<string, string>())
        {
        }

        internal StringSchema(Type type, Dictionary<string, string> attributes)
            : base(type, attributes)
        {
        }

        internal override string Type
        {
            get { return Token.String; }
        }
    }
}
