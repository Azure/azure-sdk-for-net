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
    /// The data stored in JSON format.
    /// </summary>
    public class JsonFormat : StorageFormat
    {
        /// <summary>
        /// File pattern of JSON. To be more specific, the way of separating single JSON object. 
        /// Must be one of <see cref="JsonFormatFilePattern"/>.
        /// Default value is "setOfObjects".
        /// It is case-sensitive.
        /// </summary>
        public string FilePattern { get; set; }

        /// <summary>
        /// The character used to separate nesting levels. Default value is "." (dot). 
        /// </summary>
        public string NestingSeparator { get; set; }

        /// <summary>
        /// The code page name of the preferred encoding. If not provided, the default value is "utf-8", 
        /// unless the byte order mark (BOM) denotes another Unicode encoding. 
        /// The full list of supported values can be found in the "Name" column of the table of encodings in the following reference: 
        /// https://msdn.microsoft.com/library/system.text.encoding.aspx#Anchor_5.
        /// </summary>
        public string EncodingName { get; set; }

        /// <summary>
        /// Optional. The JSONPath of the JSON array node to be flattened. 
        /// Reference: http://goessner.net/articles/JsonPath/.
        /// </summary>
        public string JsonNodeReference { get; set; }

        /// <summary>
        /// Optional. The definition of the relative JSONPath in the original JSON objects for the targeted column in the converted row when converting JSON objects to rows. Example: { "Column1": "$.Column1Path"}. 
        /// The JSONPath of the root items must start with a "$" character. All the other items in the flattened array defined by JsonNodeReference must not.
        /// </summary>
        public Dictionary<string, string> JsonPathDefinition { get; set; }
    }
}
