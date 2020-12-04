// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    internal static class ClientDiagnosticsExtension
    {
        internal static T RunScoped<T>(this ClientDiagnostics clientDiagnostics, Func<T> func, string className, string methodName)
        {
            using DiagnosticScope scope = clientDiagnostics.CreateScope($"{className}.{methodName}");
            scope.Start();
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static async Task<T> RunScopedAsync<T>(this ClientDiagnostics clientDiagnostics, Func<Task<T>> func, string className, string methodName)
        {
            using DiagnosticScope scope = clientDiagnostics.CreateScope($"{className}.{methodName}");
            scope.Start();
            try
            {
                return await func().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
