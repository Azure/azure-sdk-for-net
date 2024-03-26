// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Models;

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents a <see cref="Resource"/> with a strongly typed properties object.
    /// </summary>
    /// <typeparam name="T">The type from Azure ResourceManager Sdk that represents the properties for the resource.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Resource<T> : Resource
#pragma warning restore AZC0012 // Avoid single word type names
#pragma warning restore SA1649 // File name should match first type name
        where T : notnull
    {
        /// <summary>
        /// Gets the properties of the resource.
        /// </summary>
        public T Properties
        {
            get
            {
                if (IsExisting)
                {
                    throw new InvalidOperationException("Properties are not available for existing resources");
                }

                return _properties;
            }
        }

        private readonly T _properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource{T}"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="resourceType">The resourceType.</param>
        /// <param name="version">The version.</param>
        /// <param name="createProperties">Lambda to create the ARM properties.</param>
        protected Resource(
            IConstruct scope,
            Resource? parent,
            string resourceName,
            ResourceType resourceType,
            string version,
            Func<string, T> createProperties)
            : this(scope, parent, resourceName, resourceType, version, name => createProperties(name), false)
        {
        }

        internal Resource(
            IConstruct scope,
            Resource? parent,
            string resourceName,
            ResourceType resourceType,
            string version,
            Func<string, T> createProperties,
            bool isExisting)
            : base(scope, parent, resourceName, resourceType, version, name => createProperties(name), isExisting)
        {
            _properties = (T)ResourceData;

            if (scope.Configuration?.UseInteractiveMode == true)
            {
                // We can't use the lambda overload because not all of the T's will inherit from TrackedResourceData
                // TODO we may need to add a protected LocationSelector property in the future if there are exceptions to the rule
                AssignProperty(_properties, "Location", new Parameter("location", null, defaultValue: $"{ResourceGroup.ResourceGroupFunction}.location", isExpression: true));
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertySelector"></param>
        /// <param name="parameter"></param>
        /// <exception cref="NotSupportedException"></exception>
        public void AssignProperty(Expression<Func<T, object?>> propertySelector, Parameter parameter)
        {
            (object instance, string name, string expression) = EvaluateLambda(propertySelector);
            AssignProperty(instance, name, parameter);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertySelector"></param>
        /// <param name="propertyValue"></param>
        /// <exception cref="NotSupportedException"></exception>
        public void AssignProperty(Expression<Func<T, object?>> propertySelector, string propertyValue)
        {
            (object instance, string name, _) = EvaluateLambda(propertySelector);
            AssignProperty(instance, name, propertyValue);
        }

        /// <summary>
        /// Adds an output to the resource.
        /// </summary>
        /// <param name="outputName">The name of the output.</param>
        /// <param name="propertySelector">A lambda expression to select the property to use as the source of the output.</param>
        /// <param name="isLiteral">Is the output literal.</param>
        /// <param name="isSecure">Is the output secure.</param>
        /// <returns>The <see cref="Output"/>.</returns>
        public Output AddOutput(string outputName, Expression<Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false)
        {
            (_, _, string expression) = EvaluateLambda(propertySelector, true);

            return AddOutput(outputName, expression, isLiteral, isSecure);
        }

        /// <summary>
        /// Adds an output to the resource.
        /// </summary>
        /// <param name="outputName">The name of the output.</param>
        /// <param name="propertySelector">A lambda expression to select the property to use as the source of the output.</param>
        /// <param name="formattedString">A tokenized string containing the output.</param>
        /// <param name="isLiteral">Is the output literal.</param>
        /// <param name="isSecure">Is the output secure.</param>
        /// <returns>The <see cref="Output"/>.</returns>
        public Output AddOutput(string outputName, string formattedString, Expression<Func<T, object?>> propertySelector, bool isLiteral = false, bool isSecure = false)
        {
            (_, _, string expression) = EvaluateLambda(propertySelector, true);

            return AddOutput(outputName, expression, isLiteral, isSecure, formattedString);
        }

        private (object Instance, string PropertyName, string Expression) EvaluateLambda(Expression<Func<T, object?>> propertySelector, bool isOutput = false)
        {
            ParameterExpression? root = null;
            Expression? body = null;
            string? name = null;
            string expression = string.Empty;
            if (propertySelector is LambdaExpression lambda)
            {
                root = lambda.Parameters[0];
                switch (lambda.Body)
                {
                    case MemberExpression memberExpression:
                        GetBicepExpression(memberExpression, ref expression);
                        body = memberExpression.Expression;
                        name = memberExpression.Member.Name;
                        break;
                    case UnaryExpression { NodeType: ExpressionType.Convert, Operand: MemberExpression memberExpression }:
                        GetBicepExpression(memberExpression, ref expression);
                        body = memberExpression.Expression;
                        name = memberExpression.Member.Name;
                        break;
                    default:
                        throw new InvalidOperationException($"Unsupported expression type {lambda.Body.GetType().Name}");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unsupported expression type {propertySelector.GetType().Name}");
            }

            object instance = Expression.Lambda(body!, root).Compile().DynamicInvoke(isOutput ? _properties : Properties)!;
            return (instance, name, expression);
        }

        private void GetBicepExpression(Expression expression, ref string result)
        {
            switch (expression)
            {
                case MemberExpression memberExpression:
                    var attrib = memberExpression.Member.GetCustomAttributes(false).FirstOrDefault(a => a.GetType().Name == "WirePathAttribute");
                    string nodeString = attrib?.ToString() ?? memberExpression.Member.Name.ToCamelCase();
                    result = result == string.Empty ? nodeString : $"{nodeString}.{result}";
                    if (memberExpression.Expression is not null)
                    {
                        GetBicepExpression(memberExpression.Expression, ref result);
                    }
                    break;
                case UnaryExpression unaryExpression:
                    break;
                case MethodCallExpression methodCallExpression:
                    break; // skip
                case ParameterExpression parameterExpression:
                    return; // we have reached the root
                default:
                    throw new InvalidOperationException($"Unsupported expression type {expression.GetType().Name}");
            }
        }
    }
}
