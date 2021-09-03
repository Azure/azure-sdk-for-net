// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Storage.Test.Shared
{
    // TODO Consider https://docs.nunit.org/articles/nunit-engine/extensions/Event-Listeners.html but that requires NUnit 3.4
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public partial class StorageTestListenerAttribute : Attribute, ITestAction
    {
        private static List<Action<ITest>> s_afterTestActions = new List<Action<ITest>>();
        private static List<Action<ITest>> s_beforeTestActions = new List<Action<ITest>>();

        static StorageTestListenerAttribute()
        {
            foreach (var method in typeof(StorageTestListenerAttribute).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                var parameters = method.GetParameters();
                if (method.IsStatic && parameters.Length == 1 && parameters[0].ParameterType == typeof(ITest))
                {
                    if (method.Name.Contains("After"))
                    {
                        s_afterTestActions.Add(test => method.Invoke(null, new object[] { test }));
                    }
                    else if (method.Name.Contains("Before"))
                    {
                        s_beforeTestActions.Add(test => method.Invoke(null, new object[] { test }));
                    }
                }
            }
        }

        public ActionTargets Targets { get; } = ActionTargets.Test;

        public void AfterTest(ITest test)
        {
            var context = TestContext.CurrentContext;
            foreach (var action in s_afterTestActions)
            {
                action.Invoke(test);
            }
        }

        public void BeforeTest(ITest test)
        {
            foreach (var action in s_beforeTestActions)
            {
                action.Invoke(test);
            }
        }
    }
}
