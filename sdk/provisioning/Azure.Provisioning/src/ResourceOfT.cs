// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// <param name="properties">The properites.</param>
        protected Resource(IConstruct scope, Resource? parent, string resourceName, ResourceType resourceType, string version, T properties)
            : base(scope, parent, resourceName, resourceType, version, properties)
        {
            Properties = properties;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="parameter"></param>
        /// <exception cref="NotSupportedException"></exception>
        public void AssignParameter(Expression<Func<T, string>> selector, Parameter parameter)
        {
            if (selector is not LambdaExpression lambda ||
                lambda.Body is not MemberExpression member)
            {
                throw new NotSupportedException();
            }

            object instance = Expression.Lambda(member.Expression!, lambda.Parameters[0]).Compile().DynamicInvoke(Properties)!;
            AssignParameter(instance, member.Member.Name, parameter);
        }
    }
}
