// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage
{
    /// <summary>
    /// Houses <see cref="IDisposable"/> references across a function that may
    /// create new disposables over time in various scopes, making the
    /// <c>using</c> pattern difficult to manage. For example, the following
    /// snippet makes it hard to declare the new resource in a using statement
    /// and still have access to the resource later in the method.
    /// <code>
    /// using (var bucket = new DisposableBucket())
    /// {
    ///     ...
    ///     MyDisposableType resource = null;
    ///     if (expression)
    ///     {
    ///         var resource = GetMyDisposableResource();
    ///         bucket.Add(resource)
    ///     }
    ///     ...
    ///     // use resource if available
    ///     // this use is outside the scope the IDisposable was found in
    ///     resource?.MyFunc();
    /// }
    /// </code>
    /// </summary>
    internal class DisposableBucket : IDisposable
    {
        private List<IDisposable> Disposables { get; } = new List<IDisposable>();

        public void Add(IDisposable disposable) => Disposables.Add(disposable);

        public void Dispose()
        {
            foreach (IDisposable disposable in Disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
