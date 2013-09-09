// -----------------------------------------------------------------------------------------
// <copyright file="PathBox.cs" company="Microsoft">
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
    #region Namespaces.

    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    
    #endregion Namespaces.

    internal class PathBox
    {
        #region Private fields.

        private const char EntireEntityMarker = UriHelper.ASTERISK;

        private readonly List<StringBuilder> projectionPaths = new List<StringBuilder>();

        private readonly List<StringBuilder> expandPaths = new List<StringBuilder>();

        private readonly Stack<ParameterExpression> parameterExpressions = new Stack<ParameterExpression>();

        private readonly Dictionary<ParameterExpression, string> basePaths = new Dictionary<ParameterExpression, string>(ReferenceEqualityComparer<ParameterExpression>.Instance);

        #endregion Private fields.

        internal PathBox()
        {
            this.projectionPaths.Add(new StringBuilder());
        }

        internal IEnumerable<string> ProjectionPaths
        {
            get
            {
                return this.projectionPaths.Where(s => s.Length > 0).Select(s => s.ToString()).Distinct();
            }
        }

        internal IEnumerable<string> ExpandPaths
        {
            get
            {
                return this.expandPaths.Where(s => s.Length > 0).Select(s => s.ToString()).Distinct();
            }
        }

        internal void PushParamExpression(ParameterExpression pe)
        {
            StringBuilder basePath = this.projectionPaths.Last();
            this.basePaths.Add(pe, basePath.ToString());
            this.projectionPaths.Remove(basePath);
            this.parameterExpressions.Push(pe);
        }

        internal void PopParamExpression()
        {
            this.parameterExpressions.Pop();
        }

        internal ParameterExpression ParamExpressionInScope
        {
            get
            {
                // Debug.Assert(parameterExpressions.Count > 0);
                return this.parameterExpressions.Peek();
            }
        }

        internal void StartNewPath()
        {
            Debug.Assert(this.ParamExpressionInScope != null, "this.ParamExpressionInScope != null -- should not be starting new path with no lambda parameter in scope.");

            StringBuilder sb = new StringBuilder(this.basePaths[this.ParamExpressionInScope]);
            RemoveEntireEntityMarkerIfPresent(sb);
            this.expandPaths.Add(new StringBuilder(sb.ToString()));
            AddEntireEntityMarker(sb);
            this.projectionPaths.Add(sb);
        }

        internal void AppendToPath(PropertyInfo pi)
        {
            Debug.Assert(pi != null, "pi != null");

            StringBuilder sb;
            Type t = TypeSystem.GetElementType(pi.PropertyType);

            if (CommonUtil.IsClientType(t))
            {
                sb = this.expandPaths.Last();

                // Debug.Assert(sb != null);
                if (sb.Length > 0)
                {
                    sb.Append(UriHelper.FORWARDSLASH);
                }

                sb.Append(pi.Name);
            }

            sb = this.projectionPaths.Last();
            Debug.Assert(sb != null, "sb != null -- we are always building paths in the context of a parameter");

            RemoveEntireEntityMarkerIfPresent(sb);

            if (sb.Length > 0)
            {
                sb.Append(UriHelper.FORWARDSLASH);
            }

            sb.Append(pi.Name);

            if (CommonUtil.IsClientType(t))
            {
                AddEntireEntityMarker(sb);
            }
        }

        private static void RemoveEntireEntityMarkerIfPresent(StringBuilder sb)
        {
            if (sb.Length > 0 && sb[sb.Length - 1] == EntireEntityMarker)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            if (sb.Length > 0 && sb[sb.Length - 1] == UriHelper.FORWARDSLASH)
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        private static void AddEntireEntityMarker(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(UriHelper.FORWARDSLASH);
            }

            sb.Append(EntireEntityMarker);
        }
    }
}