// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class TypeUtility
    {
        internal static TAttribute GetResolvedAttribute<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
        {
            var attribute = parameter.GetCustomAttribute<TAttribute>();

            var attributeConnectionProvider = attribute as IConnectionProvider;
            if (attributeConnectionProvider != null && string.IsNullOrEmpty(attributeConnectionProvider.Connection))
            {
                // if the attribute doesn't specify an explicit connnection, walk up
                // the hierarchy looking for an override specified via attribute
                var connectionProviderAttribute = attribute.GetType().GetCustomAttribute<ConnectionProviderAttribute>();
                if (connectionProviderAttribute?.ProviderType != null)
                {
                    var connectionOverrideProvider = GetHierarchicalAttributeOrNull(parameter, connectionProviderAttribute.ProviderType) as IConnectionProvider;
                    if (connectionOverrideProvider != null && !string.IsNullOrEmpty(connectionOverrideProvider.Connection))
                    {
                        attributeConnectionProvider.Connection = connectionOverrideProvider.Connection;
                    }
                }
            }

            return attribute;
        }

        /// <summary>
        /// Walk from the parameter up to the containing type, looking for an instance
        /// of the specified attribute type, returning it if found.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="attributeType">The attribute type to look for.</param>
        internal static Attribute GetHierarchicalAttributeOrNull(ParameterInfo parameter, Type attributeType)
        {
            if (parameter == null)
            {
                return null;
            }

            var attribute = parameter.GetCustomAttribute(attributeType);
            if (attribute != null)
            {
                return attribute;
            }

            var method = parameter.Member as MethodInfo;
            if (method == null)
            {
                return null;
            }
            return GetHierarchicalAttributeOrNull(method, attributeType);
        }

        /// <summary>
        /// Walk from the method up to the containing type, looking for an instance
        /// of the specified attribute type, returning it if found.
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <param name="type">The attribute type to look for.</param>
        internal static Attribute GetHierarchicalAttributeOrNull(MethodInfo method, Type type)
        {
            var attribute = method.GetCustomAttribute(type);
            if (attribute != null)
            {
                return attribute;
            }

            attribute = method.DeclaringType.GetCustomAttribute(type);
            if (attribute != null)
            {
                return attribute;
            }

            return null;
        }
    }
}