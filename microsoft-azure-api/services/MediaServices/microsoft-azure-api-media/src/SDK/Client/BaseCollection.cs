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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a base media collection.
    /// </summary>
    /// <typeparam name="T">The item type of the collection.</typeparam>
    public abstract class BaseCollection<T> : IQueryable<T>
	{
        /// <summary>
        /// Gets the <see cref="System.Linq.IQueryable"/> interface to evaluate queries against 
        /// the collection.
        /// </summary>
	    protected abstract IQueryable<T> Queryable { get; }

        public IEnumerator<T> GetEnumerator()
		{
            return Queryable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
            return ((IEnumerable)Queryable).GetEnumerator();
		}
		
        public Type ElementType
		{
			get
			{
                return Queryable.ElementType;
			}
		}
		
        public Expression Expression
		{
			get
			{
                return Queryable.Expression;
			}
		}
		
        public IQueryProvider Provider
		{
			get
			{
                return Queryable.Provider;
			}
		}
	}
}
