// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Microsoft.Rest.Azure.OData
{
    /// <summary>
    /// Expression visitor class that generates OData style $filter parameter.
    /// </summary>
    public class UrlExpressionVisitor : ExpressionVisitor
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        private const string PropertiesNode = "properties";
        private readonly Stack<StringBuilder> _fullExpressionStack = new Stack<StringBuilder>();
        private StringBuilder _currentExpressionString = new StringBuilder();
        private bool _currentExpressionContainsNull;
        private PropertyInfo _currentProperty;
        private readonly Expression _baseExpression;
        private readonly bool _skipNullFilterParameters;

        /// <summary>
        /// Initializes a new instance of UrlExpressionVisitor. Skips null parameters.
        /// </summary>
        /// <param name="baseExpression">Base expression.</param>
        public UrlExpressionVisitor(Expression baseExpression) : this(baseExpression, true)
        { }

        /// <summary>
        /// Initializes a new instance of UrlExpressionVisitor.
        /// </summary>
        /// <param name="baseExpression">Base expression.</param>
        /// <param name="skipNullFilterParameters">Value indicating whether null values should be skipped.</param>
        public UrlExpressionVisitor(Expression baseExpression, bool skipNullFilterParameters)
        {
            _baseExpression = baseExpression;
            _skipNullFilterParameters = skipNullFilterParameters;
            
            // For binary expression add current string to a stack
            // so that if the expression contains null it can be cleared
            _fullExpressionStack.Push(_currentExpressionString);
            _currentExpressionString = new StringBuilder();
            _currentExpressionContainsNull = false;
        }

        /// <summary>
        /// Visits binary expression (e.g. ==, &amp;&amp;, >, etc).
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            // For binary expression add current string to a stack
            // so that if the expression contains null it can be cleared
            _fullExpressionStack.Push(_currentExpressionString);
            _currentExpressionString = new StringBuilder();
            _currentExpressionContainsNull = false;

            this.Visit(node.Left);
            CloseUnaryBooleanOperator(node.NodeType);
            var leftExpressionString = _currentExpressionString;
            _currentExpressionString = new StringBuilder();

            this.Visit(node.Right);
            CloseUnaryBooleanOperator(node.NodeType);
            var rightExpressionString = _currentExpressionString;
            _currentExpressionString = new StringBuilder();

            if (leftExpressionString.Length > 0)
            {
                _currentExpressionString.Append(leftExpressionString);
            }
            if (leftExpressionString.Length > 0 && rightExpressionString.Length > 0)
            {
                _currentExpressionString.Append(" " + GetODataOperatorName(node.NodeType) + " ");
            }
            if (rightExpressionString.Length > 0)
            {
                _currentExpressionString.Append(rightExpressionString);
            }

            // Merge expression back into the top expression from the stack
            MergeExpressionsWithStack();
            _currentExpressionContainsNull = false;
            _currentProperty = null;

            return node;
        }

        private void MergeExpressionsWithStack()
        {
            if (_fullExpressionStack.Count != 0)
            {
                var lastExpression = _fullExpressionStack.Pop();
                if (!_currentExpressionContainsNull || !_skipNullFilterParameters)
                {
                    lastExpression.Append(_currentExpressionString);
                }
                _currentExpressionString = lastExpression;
            }
        }

        /// <summary>
        /// Visits unary expression (e.g. !foo).
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
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
        /// Visits conditional expression (e.g. foo == true ? bar : fee). Throws NotSupportedException.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Throws NotSupportedException.</returns>
        protected override Expression VisitConditional(ConditionalExpression node)
        {
            throw new NotSupportedException(
                    "Conditional sub-expressions are not supported.");
        }

        /// <summary>
        /// Visits new object expression (e.g. new DateTime()).
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitNew(NewExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var newObject = node.Constructor.Invoke(node.Arguments.Select(a => ((ConstantExpression)a).Value).ToArray());
            PrintConstant(newObject);

            return node;
        }

        /// <summary>
        /// Visits constants (e.g. 'a' or 123).
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            PrintConstant(node.Value);
            return node;
        }

        /// <summary>
        /// Visits object members (e.g. p.Foo or dateTime.Hour).
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            // Assumes that left side expression parameters are properties like p.Foo
            if (ShouldBuildExpression(node))
            {
                if (node.Expression.NodeType == ExpressionType.Parameter)
                {
                    var nodeMemberProperty = node.Member as PropertyInfo;
                    PrintProperty(nodeMemberProperty);
                }
                else
                {
                    this.Visit(node.Expression);
                    _currentExpressionString.Append("/");

                    var nodeMemberProperty = node.Member as PropertyInfo;
                    PrintProperty(nodeMemberProperty);
                }
            }
            else
            {
                // This fork is executed when right side of the expression is not a constant

                if (!(node.Member is PropertyInfo) && !(node.Member is FieldInfo))
                {
                    throw new NotSupportedException("Not supported expression: " + node.Member.DeclaringType);
                }
                PrintConstant(Expression.Lambda(node).Compile().DynamicInvoke());
            }

            return node;
        }

        /// <summary>
        /// Visits object property.
        /// </summary>
        /// <param name="property">Property to print.</param>
        private void PrintProperty(PropertyInfo property)
        {
            if (property != null)
            {
                _currentProperty = property;
                _currentExpressionString.Append(GetPropertyName(property));
            }
            else
            {
                throw new NotSupportedException("Only properties are supported as parameters.");
            }
        }

        /// <summary>
        /// Visits method calls including Contains, StartsWith, and EndWith. 
        /// Methods that are not supported will throw an exception.
        /// </summary>
        /// <param name="node">Node to visit.</param>
        /// <returns>Original node.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
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
                _currentExpressionString.Append("/any(c: c eq ");
                Visit(rightSide);
                _currentExpressionString.Append(")");
                return node;
            }

            if (node.Method.Name == "StartsWith" &&
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

                _currentExpressionString.Append("startswith(");
                Visit(leftSide);
                _currentExpressionString.Append(",");
                Visit(rightSide);
                _currentExpressionString.Append(")");
                return node;
            }

            if (node.Method.Name == "EndsWith" &&
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

                _currentExpressionString.Append("endswith(");
                Visit(leftSide);
                _currentExpressionString.Append(", ");
                Visit(rightSide);
                _currentExpressionString.Append(")");
                return node;
            }

            var methodName = node.Method.Name;
            if (node.Method.GetCustomAttributes<ODataMethodAttribute>().Any())
            {
                methodName = node.Method.GetCustomAttribute<ODataMethodAttribute>().MethodName;
            }
            _currentExpressionString.Append(methodName + "(");
            for (var i = 0; i < node.Arguments.Count; i++)
            {
                var argument = node.Arguments[i];
                Visit(argument);
                if (i != node.Arguments.Count - 1)
                {
                    _currentExpressionString.Append(", ");
                }
            }
            _currentExpressionString.Append(")");
            return node;
        }

        /// <summary>
        /// Appends 'eq true' to Boolean unary operators.
        /// </summary>
        private void CloseUnaryBooleanOperator(ExpressionType expressionType)
        {
            if (_currentProperty != null)
            {
                // Reset unary operator if and/or node type
                if (expressionType == ExpressionType.And || expressionType == ExpressionType.AndAlso ||
                    expressionType == ExpressionType.Or || expressionType == ExpressionType.OrElse)
                {
                    if (_currentProperty.PropertyType == typeof (bool))
                    {
                        _currentExpressionString.Append(" eq true");
                    }
                    _currentProperty = null;
                }
            }
        }

        /// <summary>
        /// Helper method to print constant.
        /// </summary>
        /// <param name="val">Object to print.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        private void PrintConstant(object val)
        {
            if (val == null)
            {
                _currentExpressionString.Append("null");
                _currentExpressionContainsNull = true;
            }
            else
            {
                string formattedString;
                if (val is DateTime)
                {
                    val = ((DateTime)val).ToUniversalTime();
                    formattedString = string.Format(CultureInfo.InvariantCulture, 
                        "{0:" + DefaultDateTimeFormat + "}", val);
                }
                else if (val is TimeSpan)
                {
                    formattedString = string.Format(CultureInfo.InvariantCulture, 
                        "duration'{0}'", XmlConvert.ToString((TimeSpan)val));
                }
                else
                {
                    formattedString = string.Format(CultureInfo.InvariantCulture, 
                        "{0}", val);
                }

                if (val is int ||
                    val is bool ||
                    val is long ||
                    val is short)
                {
                    _currentExpressionString.Append(formattedString.ToLowerInvariant());
                }
                else if (val is TimeSpan)
                {
                    _currentExpressionString.Append(formattedString);
                }
                else
                {
                    _currentExpressionString.AppendFormat(CultureInfo.InvariantCulture, "'{0}'", Uri.EscapeDataString(formattedString));
                }
            }
        }

        /// <summary>
        /// Helper method to generate property name.
        /// </summary>
        /// <param name="propertyInfo">Property to examine.</param>
        /// <returns>Property name or value specified in the FilterParameterAttribute.</returns>
        private static string GetPropertyName(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                return string.Empty;
            }
            string propertyName = propertyInfo.Name;
            if (propertyInfo.GetCustomAttributes<JsonPropertyAttribute>().Any())
            {
                propertyName = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
            }
            if (typeof(IResource).GetTypeInfo().IsAssignableFrom(propertyInfo.DeclaringType.GetTypeInfo()))
            {
                propertyName = propertyName.Replace(PropertiesNode + ".", PropertiesNode + "/");
            }
            return propertyName;
        }

        /// <summary>
        /// Returns string representation of the current expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            CloseUnaryBooleanOperator(ExpressionType.And);
            MergeExpressionsWithStack();
            return _currentExpressionString.ToString();
        }

        /// <summary>
        /// Returns OData representation of the the ExpressionType. 
        /// </summary>
        /// <param name="exprType">Expression type.</param>
        /// <returns>OData representation of the the ExpressionType.</returns>
        private static string GetODataOperatorName(ExpressionType exprType)
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
                    return "and";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "or";
                case ExpressionType.Equal:
                    return "eq";
                case ExpressionType.NotEqual:
                    return "ne";
                default:
                    throw new NotSupportedException("Cannot get name for: " + exprType);
            }
        }

        /// <summary>
        /// Returns true if base expression matches _baseExpression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private bool ShouldBuildExpression(MemberExpression expression)
        {
            var parentExpression = expression.Expression as MemberExpression;
            if (parentExpression != null)
            {
                return ShouldBuildExpression(parentExpression);
            }
            if (expression.Expression == _baseExpression)
            {
                return true;
            }
            return false;
        }
    }
}
