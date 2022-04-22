// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Copy from: https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/TypeUtility.cs.
    /// </summary>
    internal static class TypeUtility
    {
        internal static string GetFriendlyName(Type type)
        {
            if (TypeUtility.IsNullable(type))
            {
                return string.Format(CultureInfo.InvariantCulture, "Nullable<{0}>", type.GetGenericArguments()[0].Name);
            }
            else
            {
                return type.Name;
            }
        }

        internal static bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        internal static bool IsJObject(Type type)
        {
            return type == typeof(JObject);
        }

        // Task<T> --> T
        // Task --> void
        // T --> T
        internal static Type UnwrapTaskType(Type type)
        {
            if (type == typeof(Task))
            {
                return typeof(void);
            }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return type.GetGenericArguments()[0];
            }
            return type;
        }

        /// <summary>
        /// Walk from the parameter up to the containing type, looking for an instance
        /// of the specified attribute type, returning it if found.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        internal static T GetHierarchicalAttributeOrNull<T>(ParameterInfo parameter) where T : Attribute
        {
            return (T)GetHierarchicalAttributeOrNull(parameter, typeof(T));
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
        internal static T GetHierarchicalAttributeOrNull<T>(MethodInfo method) where T : Attribute
        {
            return (T)GetHierarchicalAttributeOrNull(method, typeof(T));
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

        public static bool IsAsync(MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            var stateMachineAttribute = methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>();
            if (stateMachineAttribute != null)
            {
                var stateMachineType = stateMachineAttribute.StateMachineType;
                if (stateMachineType != null)
                {
                    return stateMachineType.GetCustomAttribute<CompilerGeneratedAttribute>() != null;
                }
            }
            return false;
        }

        public static bool IsAsyncVoid(MethodInfo methodInfo)
        {
            return IsAsync(methodInfo) && (methodInfo.ReturnType == typeof(void));
        }

        public static bool TryGetReturnType(MethodInfo methodInfo, out Type type)
        {
            Type returnType = methodInfo.ReturnType;
            if (returnType == typeof(void) || returnType == typeof(Task))
            {
                type = null;
            }
            else if (typeof(Task).IsAssignableFrom(methodInfo.ReturnType))
            {
                type = returnType.GetGenericArguments()[0];
            }
            else
            {
                type = returnType;
            }

            return type != null;
        }
    }
}
