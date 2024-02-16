// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Azure.Core;

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
        public T Properties { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource{T}"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="resourceName">The resouce name.</param>
        /// <param name="resourceType">The resourceType.</param>
        /// <param name="version">The version.</param>
        /// <param name="createProperties">Lambda to create the ARM properties.</param>
        protected Resource(IConstruct scope, Resource? parent, string resourceName, ResourceType resourceType, string version, Func<string, T> createProperties)
            : base(scope, parent, resourceName, resourceType, version, (name) => createProperties(name))
        {
            Properties = (T)ResourceData;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertySelector"></param>
        /// <param name="parameter"></param>
        /// <exception cref="NotSupportedException"></exception>
        public void AssignParameter(Expression<Func<T, object?>> propertySelector, Parameter parameter)
        {
            (object instance, string name, string expression) = EvaluateLambda(propertySelector);
            AssignParameter(instance, name, parameter);
        }

        /// <summary>
        /// Adds an output to the resource.
        /// </summary>
        /// <param name="propertySelector"></param>
        /// <param name="outputName">The name of the output.</param>
        /// <param name="isLiteral">Is the output literal.</param>
        /// <param name="isSecure">Is the output secure.</param>
        /// <returns>The <see cref="Output"/>.</returns>
        public Output AddOutput(Expression<Func<T, object?>> propertySelector, string outputName, bool isLiteral = false, bool isSecure = false)
        {
            (object instance, string name, string expression) = EvaluateLambda(propertySelector);

            return AddOutput(outputName, instance, name, expression, isLiteral, isSecure);
        }

        private (object Instance, string PropertyName, string Expression) EvaluateLambda(Expression<Func<T, object?>> propertySelector)
        {
            ParameterExpression? root = null;
            Expression? body = null;
            string? name = null;
            string expression = string.Empty;
            if (propertySelector is LambdaExpression lambda)
            {
                root = lambda.Parameters[0];
                if (lambda.Body is MemberExpression member)
                {
                    GetBicepExpression(member, ref expression);
                    body = member.Expression;
                    name = member.Member.Name;
                }
                else if (lambda.Body is UnaryExpression { NodeType: ExpressionType.Convert, Operand: MemberExpression member2 })
                {
                    body = member2.Expression;
                    name = member2.Member.Name;
                }
                else if (lambda.Body is IndexExpression { Arguments.Count: 1 } indexer)
                {
                    throw new InvalidOperationException("Indexer expressions are not supported");
                }
                else if (lambda.Body is MethodCallExpression { Method.Name: "get_Item", Arguments.Count: 1 } call)
                {
                    body = call.Object;
                    name = Expression.Lambda(call.Arguments[0], root).Compile().DynamicInvoke(Properties) as string;
                }
            }

            if (body is null || name is null || root is null || expression == null)
            {
                throw new NotSupportedException();
            }

            object instance = Expression.Lambda(body, root).Compile().DynamicInvoke(Properties)!;
            return (instance, name, expression);
        }

        private void GetBicepExpression(Expression expression, ref string result)
        {
            switch (expression)
            {
                case MemberExpression memberExpression:
                    var attrib = memberExpression.Member.GetCustomAttributes(false).First(a => a.GetType().Name == "WirePathAttribute");
                    result = result == string.Empty ? attrib!.ToString()! : $"{memberExpression.Member.GetCustomAttributes(false).First(a => a.GetType().Name == "WirePathAttribute")}.{result}";
                    if (memberExpression.Expression is not null)
                    {
                        GetBicepExpression(memberExpression.Expression, ref result);
                    }
                    break;
                case ParameterExpression parameterExpression:
                    return; // we have reached the root
                default:
                    throw new InvalidOperationException($"Unsupported expression type {expression.GetType().Name}");
            }
        }

        private Stack<string> GetBicepExpression(Expression body)
        {
            //We get two different results from body.ToString()
            // - "Convert(website.Identity.PrincipalId, Object)"
            // - "store.Endpoint"
            var span = body.ToString().AsSpan();
            var start = span.IndexOf('.');
            span = span.Slice(start + 1);
            var end = span.IndexOf(',');
            span = span.Slice(0, end == -1 ? span.Length : end);

            Stack<string> stack = new Stack<string>();
            while (true)
            {
                int index = span.LastIndexOf('.');
                if (index == -1)
                {
                    stack.Push(span.ToString());
                    break;
                }
                else
                {
                    stack.Push(span.Slice(index + 1).ToString());
                    span = span.Slice(0, index);
                }
            }
            return stack;
        }
    }
}
