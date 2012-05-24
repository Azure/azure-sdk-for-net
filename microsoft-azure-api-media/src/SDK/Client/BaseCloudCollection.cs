// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Data.Services.Client;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a Base Collection that has a <see cref="DataServiceContext"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the collections entity type.</typeparam>
    public abstract class BaseCloudCollection<T> : BaseCollection<T>
    {
        private readonly DataServiceContext _dataServiceContext;
        private readonly IQueryable<T> _queryable;

        protected BaseCloudCollection(DataServiceContext dataServiceContext, IQueryable<T> queryable)
        {
            _dataServiceContext = dataServiceContext;
            _queryable = queryable;
        }

        protected DataServiceContext DataContext
        {
            get { return _dataServiceContext; }
        }

        protected override IQueryable<T> Queryable
        {
            get { return _queryable; }
        }
    }
}
