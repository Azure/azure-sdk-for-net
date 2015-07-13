﻿//
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
    /// A table defines the schema of the data as well as its storage.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Name of the table.
        /// </summary>
        [AdfRequired]
        public string Name { get; set; }

        /// <summary>
        /// Table properties.
        /// </summary>
        [AdfRequired]
        public TableProperties Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the Table class.
        /// </summary>
        public Table()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Table class with required
        /// arguments.
        /// </summary>
        public Table(string name, TableProperties properties)
            : this()
        {
            Ensure.IsNotNullOrEmpty(name, "name");
            Ensure.IsNotNull(properties, "properties");

            this.Name = name;
            this.Properties = properties;
        }
    }
}
