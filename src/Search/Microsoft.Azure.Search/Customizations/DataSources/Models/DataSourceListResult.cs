// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response from a List Datasources request. If successful, it includes
    /// the full definitions of all datasources.
    /// </summary>
    public class DataSourceListResult
    {
        /// <summary>
        /// Initializes a new instance of the DataSourceListResult class.
        /// </summary>
        public DataSourceListResult() { }

        /// <summary>
        /// Initializes a new instance of the DataSourceListResult class.
        /// </summary>
        public DataSourceListResult(IList<DataSource> dataSources = default(IList<DataSource>))
        {
            DataSources = dataSources;
        }

        /// <summary>
        /// Gets the datasources in the Search service.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<DataSource> DataSources { get; private set; }

    }
}
