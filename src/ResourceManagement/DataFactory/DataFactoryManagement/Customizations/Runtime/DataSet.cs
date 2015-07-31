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

using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    /// <summary>
    /// Represents a set of resolved <see cref="Microsoft.Azure.Management.DataFactories.Models.Table"/> and 
    /// <see cref="Microsoft.Azure.Management.DataFactories.Models.LinkedService"/> values.
    /// </summary>
    [JsonConverter(typeof(DataSetConverter))]
    internal class DataSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Microsoft.Azure.Management.DataFactories.Runtime.DataSet"/> class.
        /// </summary>
        public DataSet()
        {
        }

        /// <summary>
        /// The <see cref="Microsoft.Azure.Management.DataFactories.Models.Table"/> value.
        /// </summary>
        public Table Table { get; internal set; }

        /// <summary>
        /// The <see cref="Microsoft.Azure.Management.DataFactories.Models.LinkedService"/> value.
        /// </summary>
        public LinkedService LinkedService { get; internal set; }
    }
}
