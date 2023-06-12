// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureMock<T> : Mock<T> where T : class
    {
        public new ISetup<T, R> Setup<R>(Expression<Func<T, R>> expression)
        {
            // add this check since we only have extension methods on `ArmResource` and `ArmClient`
            if (typeof(ArmResource).IsAssignableFrom(typeof(T)) && ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                var extensionClientType = MockingExtensions.FindExtensionType(typeof(T), extensionMethodInfo);

                return this.RedirectMock(expression, extensionClientType);
            } // TODO -- add another branch to deal with the methods that extends on `ArmClient`
            else
            {
                return base.Setup(expression);
            }
        }

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
