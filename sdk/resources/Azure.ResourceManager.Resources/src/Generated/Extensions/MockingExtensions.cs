// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;
using System;
using Moq;
using Mock = Moq.Mock;
using System.Reflection;
using System.Linq;

namespace Azure.ResourceManager.Resources.Mocking
{
    internal static class MockingExtensions
    {
        internal static void SetupAzureExtensionMethod<T>(this Mock<T> mock, Expression<Action<T>> expression) where T : ArmResource
        {
            // we would like the customer to use this in this way:
            // tenantResourceMock.SetupAzureExtensionMethod(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)).Returns(Task.FromResult(Response.FromValue(mockResult, null)));
            // this setup method is accepting an expression: tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default),
            // instead we need to hack it and create a new mock instance of the corresponding extension client (using reflection maybe)
            // for instance we get it like this: var tenantExtensionClient = new Mock<TenantExtensionClient>();
            // and then call this method instead:
            // tenantExtensionClient.Setup(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)) // using the same expression but change the type of the argument to extension client

            // first find the type name we are using in the expression
            var name = typeof(T).Name;
            // construct a new name from the above name to its corresponding extension client
            var extensionClientName = name + "ExtensionClient";
            // TODO -- get the namespace of the current SDK dynamically
            var ns = "Azure.ResourceManager.Resources"; // maybe we need to find the extension method and get the namespace of its containing type
            var extensionClientType = Type.GetType($"{ns}.{extensionClientName}");

            var newMockType = typeof(Mock<>).MakeGenericType(extensionClientType);
            var ctor = newMockType.GetConstructor(Array.Empty<Type>());
            var newMock = ctor.Invoke(Array.Empty<object>());
            var parameterType = typeof(Expression<>).MakeGenericType(typeof(Action<>).MakeGenericType(extensionClientType));
            var setupMethod = newMockType.GetMethod("Setup", new[] { parameterType });

            // TODO -- need to construct a new expression using the parameter of the new type from the old "expression"
            var newExpression = new ChangeTypeVisitor(typeof(T), extensionClientType).ChangeType(expression);
            setupMethod.Invoke(newMock, new[] { newExpression });
        }

        internal class ChangeTypeVisitor : ExpressionVisitor
        {
            private readonly Type _originalType;
            private readonly Type _newType;
            private readonly ParameterExpression _newParameter;

            public ChangeTypeVisitor(Type originalType, Type newType)
            {
                _originalType = originalType;
                _newType = newType;
                _newParameter = Expression.Parameter(newType);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _newParameter;
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Object != null && node.Object.Type == _originalType)
                {
                    var newMethodInfo = _newType.GetMethod(node.Method.Name, node.Method.GetParameters().Select(p => p.ParameterType).ToArray());
                    var newObject = Visit(node.Object);
                    var newArguments = node.Arguments.Select(Visit);
                    return Expression.Call(newObject, newMethodInfo, newArguments);
                }
                return base.VisitMethodCall(node);
            }

            public Expression ChangeType(Expression expression)
            {
                return Visit(expression);
            }
        }
    }
}
