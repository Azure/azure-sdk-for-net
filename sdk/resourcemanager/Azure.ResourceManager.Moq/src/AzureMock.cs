// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

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
            if (ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                // TODO -- some methods are not directly calling the method on extension client with the same signature
                // instead those are calling another static method in the same extension class
                // we need to find a way to identify those
                if (typeof(ArmResource).IsAssignableFrom(typeof(T)))
                {
                    var extensionClientType = MockingExtensions.FindExtensionType(typeof(T), extensionMethodInfo);

                    return this.RedirectMock(expression, extensionClientType);
                }
                // TODO -- we need to distinguish two cases: some of them are scope resource calls, others are constructing resource instances
                if (typeof(ArmClient).IsAssignableFrom(typeof(T)))
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();
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
            if (ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                var extensionClientType = MockingExtensions.FindExtensionType(typeof(T), extensionMethodInfo);

                return this.RedirectMock(expression, extensionClientType);
            }
            else
            {
                return base.Setup(expression);
            }
        }

        // TODO -- there are other `Setup` methods, we might need to write an override for them as well.
    }
}
