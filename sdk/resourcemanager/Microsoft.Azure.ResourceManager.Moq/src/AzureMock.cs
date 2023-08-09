// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Moq;
using Moq.Language.Flow;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.ResourceManager.Moq
{
    /// <summary>
    /// Mock{T} extension for Azure Management SDKs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AzureMock<T> : Mock<T> where T : class
    {
        /// <summary>
        /// The fixed version of Setup{R} for Azure Management SDKs
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new ISetup<T, R> Setup<R>(Expression<Func<T, R>> expression)
        {
            // add this check since we only have extension methods on `ArmResource` and `ArmClient`
            var extensionMethodInfo = ExpressionUtilities.GetExtensionMethod(expression);
            if (extensionMethodInfo != null && IsSupportedTypes(extensionMethodInfo))
            {
                var mockingExtensionType = MockingExtensions.FindExtensionType(typeof(T), extensionMethodInfo);

                return this.RedirectMock(expression, mockingExtensionType);
            }
            else
            {
                return base.Setup(expression);
            }
        }

        /// <summary>
        /// The fixed version of Setup{R} for Azure Management SDKs
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new ISetup<T> Setup(Expression<Action<T>> expression)
        {
            var extensionMethodInfo = ExpressionUtilities.GetExtensionMethod(expression);
            if (extensionMethodInfo != null && IsSupportedTypes(extensionMethodInfo))
            {
                var extensionClientType = MockingExtensions.FindExtensionType(typeof(T), extensionMethodInfo);

                return this.RedirectMock(expression, extensionClientType);
            }
            else
            {
                return base.Setup(expression);
            }
        }

        private static bool IsSupportedTypes(MethodInfo extensionMethodInfo)
        {
            var declaringType = extensionMethodInfo.DeclaringType;
            if (!declaringType.Namespace.StartsWith(Constants.AzureSDKNamespacePrefix))
                return false;
            return typeof(ArmResource).IsAssignableFrom(typeof(T)) || typeof(ArmClient).IsAssignableFrom(typeof(T));
        }
    }
}
