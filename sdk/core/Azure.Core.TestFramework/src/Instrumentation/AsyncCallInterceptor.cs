// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    public delegate ValueTask<T> AsyncCallInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask);
}