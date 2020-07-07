// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal static class FunctionInvokerFactory
    {
        public static IFunctionInvoker Create(MethodInfo method, IJobActivator activator)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            if (activator == null)
            {
                throw new ArgumentNullException("activator");
            }

            Type reflectedType = method.ReflectedType;
            MethodInfo genericMethodDefinition = typeof(FunctionInvokerFactory).GetMethod("CreateGeneric",
                BindingFlags.NonPublic | BindingFlags.Static);
            Debug.Assert(genericMethodDefinition != null);

            Type returnType;
            if (!TypeUtility.TryGetReturnType(method, out returnType))
            {
                returnType = typeof(object);
            }

            MethodInfo genericMethod = genericMethodDefinition.MakeGenericMethod(reflectedType, returnType);
            Debug.Assert(genericMethod != null);
            Func<MethodInfo, IJobActivator, IFunctionInvoker> lambda =
                (Func<MethodInfo, IJobActivator, IFunctionInvoker>)Delegate.CreateDelegate(
                typeof(Func<MethodInfo, IJobActivator, IFunctionInvoker>), genericMethod);
            return lambda.Invoke(method, activator);
        }

        private static IFunctionInvoker CreateGeneric<TReflected, TReturnValue>(
            MethodInfo method,
            IJobActivator activator)
        {
            Debug.Assert(method != null);

            List<string> parameterNames = method.GetParameters().Select(p => p.Name).ToList();

            IMethodInvoker<TReflected, TReturnValue> methodInvoker = MethodInvokerFactory.Create<TReflected, TReturnValue>(method);

            IJobInstanceFactory<TReflected> instanceFactory = CreateInstanceFactory<TReflected>(method, activator);

            return new FunctionInvoker<TReflected, TReturnValue>(parameterNames, instanceFactory, methodInvoker);
        }

        private static IJobInstanceFactory<TReflected> CreateInstanceFactory<TReflected>(MethodInfo method,
            IJobActivator jobActivator)
        {
            Debug.Assert(method != null);

            if (method.IsStatic)
            {
                return NullInstanceFactory<TReflected>.Instance;
            }
            else
            {
                return new ActivatorInstanceFactory<TReflected>(jobActivator);
            }
        }
    }
}
