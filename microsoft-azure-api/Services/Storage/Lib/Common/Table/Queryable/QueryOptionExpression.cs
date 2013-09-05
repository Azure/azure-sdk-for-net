// -----------------------------------------------------------------------------------------
// <copyright file="QueryOptionExpression.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;

    internal abstract class QueryOptionExpression : Expression
    {
#pragma warning disable 618
        internal QueryOptionExpression(ExpressionType nodeType, Type type) : base(nodeType, type)
        {
        }
#pragma warning restore 618

        internal virtual QueryOptionExpression ComposeMultipleSpecification(QueryOptionExpression previous)
        {
            Debug.Assert(previous != null, "other != null");
            Debug.Assert(previous.GetType() == this.GetType(), "other.GetType == this.GetType() -- otherwise it's not the same specification");
            return this;
        }
    }
}
