// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Azure.Data.Tables.Queryable
{
    internal class PathBox
    {
        private const char EntireEntityMarker = UriHelper.ASTERISK;

        private readonly List<StringBuilder> projectionPaths = new List<StringBuilder>();

        private readonly List<StringBuilder> expandPaths = new List<StringBuilder>();

        private readonly Stack<ParameterExpression> parameterExpressions = new Stack<ParameterExpression>();

        private readonly Dictionary<ParameterExpression, string> basePaths = new Dictionary<ParameterExpression, string>(ReferenceEqualityComparer<ParameterExpression>.Instance);

        internal PathBox()
        {
            projectionPaths.Add(new StringBuilder());
        }

        internal IEnumerable<string> ProjectionPaths
        {
            get
            {
                return projectionPaths.Where(s => s.Length > 0).Select(s => s.ToString()).Distinct();
            }
        }

        internal IEnumerable<string> ExpandPaths
        {
            get
            {
                return expandPaths.Where(s => s.Length > 0).Select(s => s.ToString()).Distinct();
            }
        }

        internal void PushParamExpression(ParameterExpression pe)
        {
            StringBuilder basePath = projectionPaths.Last();
            basePaths.Add(pe, basePath.ToString());
            projectionPaths.Remove(basePath);
            parameterExpressions.Push(pe);
        }

        internal void PopParamExpression()
        {
            parameterExpressions.Pop();
        }

        internal ParameterExpression ParamExpressionInScope
        {
            get
            {
                // Debug.Assert(parameterExpressions.Count > 0);
                return parameterExpressions.Peek();
            }
        }

        internal void StartNewPath()
        {
            Debug.Assert(ParamExpressionInScope != null, "this.ParamExpressionInScope != null -- should not be starting new path with no lambda parameter in scope.");

            StringBuilder sb = new StringBuilder(basePaths[ParamExpressionInScope]);
            RemoveEntireEntityMarkerIfPresent(sb);
            expandPaths.Add(new StringBuilder(sb.ToString()));
            AddEntireEntityMarker(sb);
            projectionPaths.Add(sb);
        }

        internal void AppendToPath(PropertyInfo pi)
        {
            Debug.Assert(pi != null, "pi != null");

            StringBuilder sb;
            Type t = TypeSystem.GetElementType(pi.PropertyType);

            if (CommonUtil.IsClientType(t))
            {
                sb = expandPaths.Last();

                // Debug.Assert(sb != null);
                if (sb.Length > 0)
                {
                    sb.Append(UriHelper.FORWARDSLASH);
                }

                sb.Append(pi.Name);
            }

            sb = projectionPaths.Last();
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
