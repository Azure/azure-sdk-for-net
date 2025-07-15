// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="invocation"></param>
/// <param name="innerTask"></param>
/// <returns></returns>
public delegate ValueTask<T> AsyncCallInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask);
