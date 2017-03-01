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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.Common.OData
{
    /// <summary>
    /// Expression visitor class that generates OData style $filter parameter.
    /// </summary>
    public class UrlExpressionVisitor : ExpressionVisitor
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        private StringBuilder _generatedUrl = new StringBuilder();
        private PropertyInfo _currentProperty;

        /// <summary>
        /// Visits binary expression like ==, &amp;&amp;, >, etc.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            this.Visit(node.Left);

            _generatedUrl.Append(" " + GetUrlName(node.NodeType) + " ");

            this.Visit(node.Right);

            _currentProperty = null;

            return node;
        }

        /// <summary>
        /// Visits binary expression !foo.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Not)
            {
                throw new NotSupportedException(
                    "Unary expressions are not supported. Please use binary expressions (e.g. Property == false) instead.");
            }
            else
            {
                return base.VisitUnary(node);
            }
        }

        /// <summary>
        /// Visits conditional expression foo == true ? bar : fee. Throws NotSupportedException.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Throws NotSupportedException.</returns>
        protected override Expression VisitConditional(ConditionalExpression node)
        {
            throw new NotSupportedException(
                    "Conditional sub-expressions are not supported.");
        }

        /// <summary>
        /// Visits new object expression like new DateTime().
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitNew(NewExpression node)
        {
            var newObject = node.Constructor.Invoke(node.Arguments.Select(a => ((ConstantExpression)a).Value).ToArray());
            PrintConstant(newObject);

            return node;
        }

        /// <summary>
        /// Visits constants like 'a' or 123.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            PrintConstant(node.Value);
            return node;
        }

        /// <summary>
        /// Visits object members like p.Foo or dateTime.Hour.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitMember(MemberExpression node)
        {
            // Assumes that left side expression parameters are properties like p.Foo
            if (node.Expression.NodeType == ExpressionType.Parameter)
            {
                var nodeMemberProperty = node.Member as PropertyInfo;
                if (nodeMemberProperty != null)
                {
                    _currentProperty = nodeMemberProperty;
                    _generatedUrl.Append(GetPropertyName(nodeMemberProperty));
                }
                else
                {
                    throw new NotSupportedException("Only properties are supported as parameters.");
                }
            }
            else
            {
                // This fork is executed when right side of the expression is not a constant

                object val = null;
                if (node.Member is PropertyInfo || node.Member is FieldInfo)
                {
                    val = Expression.Lambda(node).Compile().DynamicInvoke();
                }
                else
                {
                    throw new NotSupportedException("Not supported expression: " + node.Member.DeclaringType);
                }
                PrintConstant(val);
            }

            return node;
        }

        /// <summary>
        /// Visits method calls like Contains, StartsWith, etc. Methods that are not supported will throw an exception.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Contains" && 
                (node.Arguments.Count == 2 ||
                node.Arguments.Count == 1))
            {
                Expression leftSide = node.Object;
                Expression rightSide = node.Arguments[0];
                if (node.Arguments.Count == 2)
                {
                    leftSide = node.Arguments[0];
                    rightSide = node.Arguments[1];
                }
                Visit(leftSide);
                _generatedUrl.Append("/any(c: c eq ");
                Visit(rightSide);
                _generatedUrl.Append(")");
                return node;
            }
            else if (node.Method.Name == "StartsWith" &&
                (node.Arguments.Count == 2 ||
                node.Arguments.Count == 1))
            {
                Expression leftSide = node.Object;
                Expression rightSide = node.Arguments[0];
                if (node.Arguments.Count == 2)
                {
                    leftSide = node.Arguments[0];
                    rightSide = node.Arguments[1];
                }

                _generatedUrl.Append("startswith(");
                Visit(leftSide);
                _generatedUrl.Append(", ");
                Visit(rightSide);
                _generatedUrl.Append(") eq true");
                return node;
            }
            else if (node.Method.Name == "EndsWith" &&
            (node.Arguments.Count == 2 ||
            node.Arguments.Count == 1))
            {
                Expression leftSide = node.Object;
                Expression rightSide = node.Arguments[0];
                if (node.Arguments.Count == 2)
                {
                    leftSide = node.Arguments[0];
                    rightSide = node.Arguments[1];
                }

                _generatedUrl.Append("endswith(");
                Visit(leftSide);
                _generatedUrl.Append(", ");
                Visit(rightSide);
                _generatedUrl.Append(") eq true");
                return node;
            }
            else
            {
                throw new NotSupportedException("Method call " + node.Method.Name + " is not supported.");
            }
        }

        /// <summary>
        /// Appends 'eq true' to Boolean unary operators.
        /// </summary>
        private void closeUnaryBooleanOperator()
        {
            if (_currentProperty != null)
            {
                if (_currentProperty.PropertyType == typeof (bool))
                {
                    _generatedUrl.Append(" eq true");
                    _currentProperty = null;
                }
            }
        }

        /// <summary>
        /// Helper method to print constant.
        /// </summary>
        /// <param name="val">Object to print.</param>
        private void PrintConstant(object val)
        {
            if (val == null)
            {
                _generatedUrl.Append("null");
            }
            else
            {
                var format = GetPropertyFormat(_currentProperty);
                if (val is DateTime)
                {
                    if (string.IsNullOrEmpty(format))
                    {
                        format = DefaultDateTimeFormat;
                    }
                    val = ((DateTime) val).ToUniversalTime();
                }

                string formattedString;
                if (!string.IsNullOrEmpty(format))
                {
                    formattedString = string.Format("{0:" + format + "}", val);
                }
                else
                {
                    formattedString = string.Format("{0}", val);
                }

                if (val is int ||
                    val is bool ||
                    val is long ||
                    val is short)
                {
                    _generatedUrl.Append(formattedString.ToLowerInvariant());
                }
                else
                {
                    _generatedUrl.AppendFormat("'{0}'", formattedString);
                }
            }
        }

        /// <summary>
        /// Helper method to generate property name.
        /// </summary>
        /// <param name="property">Property to examine.</param>
        /// <returns>Property name or value specified in the FilterParameterAttribute.</returns>
        private string GetPropertyName(PropertyInfo property)
        {
            if (property == null)
            {
                return string.Empty;
            }
            foreach (var attribute in property.GetCustomAttributes(true))
            {
                var parameterAttribute = attribute as FilterParameterAttribute;
                if (parameterAttribute != null && !string.IsNullOrEmpty(parameterAttribute.Name))
                {
                    return parameterAttribute.Name;
                }
            }
            return property.Name;
        }

        /// <summary>
        /// Helper method to retrieve format from the FilterParameterAttribute.
        /// </summary>
        /// <param name="property">Property to examine.</param>
        /// <returns>Format from FilterParameterAttribute or null.</returns>
        private string GetPropertyFormat(PropertyInfo property)
        {
            if (property == null)
            {
                return string.Empty;
            }
            else
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    var parameterAttribute = attribute as FilterParameterAttribute;
                    if (parameterAttribute != null && !string.IsNullOrEmpty(parameterAttribute.Name))
                    {
                        return parameterAttribute.Format;
                    }
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            closeUnaryBooleanOperator();
            return _generatedUrl.ToString();
        }

        private string GetUrlName(ExpressionType exprType)
        {
            switch (exprType)
            {
                case ExpressionType.GreaterThan:
                    return "gt";
                case ExpressionType.GreaterThanOrEqual:
                    return "ge";
                case ExpressionType.LessThan:
                    return "lt";
                case ExpressionType.LessThanOrEqual:
                    return "le";
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    // Reset current property
                    closeUnaryBooleanOperator();
                    _currentProperty = null;
                    return "and";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    // Reset current property
                    closeUnaryBooleanOperator();
                    _currentProperty = null;
                    return "or";
                case ExpressionType.Equal:
                    return "eq";
                case ExpressionType.NotEqual:
                    return "ne";
                default:
                    throw new System.NotSupportedException("Cannot get name for: " + exprType.ToString());
            }
        }
    }
}
