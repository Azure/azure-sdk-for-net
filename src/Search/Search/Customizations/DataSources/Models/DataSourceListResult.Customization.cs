// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class DataSourceListResult
    {
        /// <summary>
        /// Gets the datasources in the Search service.
        /// </summary>
        [JsonIgnore]
        public IList<DataSource> DataSources 
        {
            get { return this.Value; }
        }
    }
}
