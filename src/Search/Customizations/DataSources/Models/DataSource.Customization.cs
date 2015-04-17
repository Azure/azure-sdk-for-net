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

using System;

namespace Microsoft.Azure.Search.Models
{
    public partial class DataSource
    {
        /// <summary>
        /// Initializes a new instance of the DataSource class with required arguments.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="type">The data type of the datasource.</param>
        /// <param name="credentials">Credentials to connect to the datasource.</param>
        /// <param name="container">Information about the entity (such as Azure SQL table or
        /// DocumentDb collection) that will be indexed.</param>
        public DataSource(
            string name, 
            DataSourceType type, 
            DataSourceCredentials credentials,
            DataContainer container)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Name = name;
            Type = type;
            Credentials = credentials;
            Container = container;
        }
    }
}
