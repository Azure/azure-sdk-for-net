// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Azure.Core;
using Moq;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureMock<T> : Mock<T> where T : ArmResource
    {
        public new ISetup<T, R> Setup<R>(Expression<Func<T, R>> expression)
        {
            if (ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                // find the type of extension client: using pattern: $"{T}Extension"
                // TODO -- update the pattern: $"{RPName}{T}Extension"
                var extensionClientName = typeof(T).Name + "ExtensionClient";
                var typeOfExtension = extensionMethodInfo.DeclaringType;
                // get the namespace of the current SDK dynamically
                var thisNamespace = typeOfExtension.Namespace;
                var extensionClientType = typeOfExtension.Assembly.GetType($"{thisNamespace}.{extensionClientName}");

                return this.RedirectMock(expression, extensionClientType);
            }
            else
            {
                return base.Setup(expression);
            }
        }
    }
}
