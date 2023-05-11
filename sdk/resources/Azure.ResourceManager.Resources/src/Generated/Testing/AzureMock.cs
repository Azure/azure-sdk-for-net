// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using System.Reflection;
using Moq;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureMock<T> : Mock<T> where T : ArmResource
    {
        private const string _mockingMethodName = "SetupAzureExtensionMethod";

        public new ISetup<T, R> Setup<R>(Expression<Func<T, R>> expression)
        {
            if (ExpressionUtilities.IsExtensionMethod(expression))
            {
                // if it is extension method
                var name = typeof(T).Name;
                // find the type of extension client
                var extensionClientName = name + "ExtensionClient";
                // get the namespace of the current SDK dynamically
                var thisNamespace = typeof(MockingExtensions).Namespace;
                var ns = thisNamespace.Substring(0, thisNamespace.Length - 8);
                var extensionClientType = typeof(MockingExtensions).Assembly.GetType($"{ns}.{extensionClientName}");
                // calling the SetupAzureExtensionMethod
                var methodInfo = extensionClientType.GetMethod(_mockingMethodName, BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(R));
                var newExpression = ExpressionUtilities.ChangeType(expression, extensionClientType);
                var intermediateSetup = methodInfo.Invoke(null, new object[] { this, newExpression });

                return new AzureSetupAdapter<T, R>(intermediateSetup, extensionClientType);
            }
            else
            {
                return base.Setup(expression);
            }
        }
    }
}
