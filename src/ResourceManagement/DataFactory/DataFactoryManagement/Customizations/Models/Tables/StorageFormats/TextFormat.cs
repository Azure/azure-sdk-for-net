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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Text format.
    /// </summary>
    public class TextFormat : StorageFormat
    {
        /// <summary>
        /// The column delimiter.
        /// </summary>
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// The row delimeter.
        /// </summary>
        public string RowDelimiter { get; set; }

        /// <summary>
        /// The escape character.
        /// </summary>
        public string EscapeChar { get; set; }

        /// <summary>
        /// The quote character.
        /// </summary>
        public string QuoteChar { get; set; }

        /// <summary>
        /// The null value string.
        /// </summary>
        public string NullValue { get; set; }

        /// <summary>
        /// The code page name of the preferred encoding. If miss, the default value is “utf-8”, 
        /// unless BOM denotes another Unicode encoding. Refer to the “Name” column of the table in 
        /// the following link to set supported values: 
        /// https://msdn.microsoft.com/library/system.text.encoding.aspx. 
        /// </summary>
        public string EncodingName { get; set; }
    }
}
