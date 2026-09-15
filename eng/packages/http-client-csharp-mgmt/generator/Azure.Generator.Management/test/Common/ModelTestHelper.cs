// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Azure.Generator.Management.Tests.Common
{
    public static class ModelTestHelper
    {
        public static string GetLocation(string filePath)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1)!.GetMethod()!;
            string testsLocation = Directory.GetParent(method.DeclaringType!.Assembly.Location)!.FullName;

            var startNamespace = testsLocation.IndexOf("bin") + 4;
            var endNamespace = testsLocation.IndexOf("Debug") - 1;
            var namespaceLength = endNamespace - startNamespace;
            var testNamespace = method.DeclaringType.Namespace!.Substring(namespaceLength);
            var segments = testNamespace.Split('.');
            foreach (var segment in segments)
            {
                testsLocation = Path.Combine(testsLocation, segment);
            }
            return Path.Combine(testsLocation, filePath);
        }

        public static void SetLastContractView(TypeProvider typeProvider, TypeProvider lastContractView)
        {
            typeof(TypeProvider).GetField(
                    "_lastContractView",
                    BindingFlags.NonPublic | BindingFlags.Instance)!
                .SetValue(typeProvider, new Lazy<TypeProvider?>(() => lastContractView));
        }
    }
}
