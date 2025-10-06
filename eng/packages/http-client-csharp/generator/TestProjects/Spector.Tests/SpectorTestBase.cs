// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestProjects.Spector.Tests
{
    public abstract class SpectorTestBase
    {
        public async Task Test(Func<Uri, Task> test)
        {
            var server = SpectorServerSession.Start();

            try
            {
                await test(server.Host);
            }
            catch (Exception ex)
            {
                try
                {
                    await server.DisposeAsync();
                }
                catch (Exception disposeException)
                {
                    throw new AggregateException(ex, disposeException);
                }

                throw;
            }

            await server.DisposeAsync();
        }

        internal static async Task<object?> InvokeMethodAsync(object obj, string methodName, params object[] args)
        {
            Task? task = (Task?)InvokeMethod(obj, methodName, args);
            if (task != null)
            {
                await task;
                return GetProperty(task, "Result");
            }
            return null;
        }

        internal static object? GetProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)!.GetValue(obj);
        }

        internal static object? InvokeMethod(object obj, string methodName, params object[] args)
            => InvokeMethodInternal(obj.GetType(), obj, methodName, [],
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, args);


        private static object? InvokeMethodInternal(Type type,
            object obj,
            string methodName,
            IEnumerable<Type> genericArgs,
            BindingFlags flags,
            params object[] args)
        {
            var methods = type.GetMethods(flags);
            MethodInfo? methodInfo = null;
            foreach (var method in methods)
            {
                var methodToTry = method;
                if (genericArgs.Any())
                {
                    methodToTry = methodToTry.MakeGenericMethod([.. genericArgs]);
                }

                if (!methodToTry.Name.Equals(methodName, StringComparison.Ordinal))
                    continue;

                var parameters = methodToTry.GetParameters();
                if (parameters.Length < args.Length)
                    continue;

                //verify the types match for all the args passed in
                int i = 0;
                bool isMatch = true;
                foreach (var parameter in parameters.Take(args.Length))
                {
                    if (!parameter.ParameterType.IsAssignableFrom(args[i++]?.GetType()) &&
                        !CanAssignNull(parameter.ParameterType, args[i - 1]))
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    methodInfo = methodToTry;
                    break;
                }
            }

            if (methodInfo == null)
                throw new MissingMethodException(
                    $"No matching method found for type {type} with the provided name {methodName}.");

            return methodInfo.Invoke(obj,
                [.. args, .. methodInfo.GetParameters().Skip(args.Length).Select(p => p.DefaultValue)]);
        }

        private static bool CanAssignNull(Type parameterType, object arg)
        {
            if (arg is not null)
                return false;

            return !parameterType.IsValueType ||
                   (parameterType.IsGenericType && parameterType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }
    }
}
