// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    public static class FunctionInstanceExtensions
    {
        public static IServiceProvider GetInstanceServices(this IFunctionInstance instance)
        {
            if (instance is IFunctionInstanceEx functionInstance)
            {
                return functionInstance.InstanceServices;
            }

            return null;
        }

        internal static IFunctionInvokerEx GetFunctionInvoker(this IFunctionInstance instance)
        {
            if (instance.Invoker == null)
            {
                return null;
            }

            if (instance.Invoker is IFunctionInvokerEx invoker)
            {
                return invoker;
            }


            return new FunctionInvokerWrapper(instance.Invoker);
        }
    }
}
