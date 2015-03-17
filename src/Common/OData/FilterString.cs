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
using System.Linq.Expressions;

namespace Microsoft.Azure.Common.OData
{
    /// <summary>
    /// Handles OData filter generation.
    /// </summary>
    public class FilterString
    {
        /// <summary>
        /// Generates an OData filter from a specified Linq expression.
        /// </summary>
        /// <typeparam name="T">Filter type</typeparam>
        /// <param name="filter">Entity to use for filter generation</param>
        /// <returns></returns>
        public static string Generate<T>(Expression<Func<T, bool>> filter)
        {
            UrlExpressionVisitor visitor = new UrlExpressionVisitor();
            visitor.Visit(filter);
            return visitor.ToString();
        }
    }
}
