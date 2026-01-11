// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.AI.AgentServer.Core.Common;

/// <summary>
/// Provides a composite disposable that disposes multiple disposable objects together.
/// </summary>
public class CompositeDisposable : IDisposable
{
    private readonly IDisposable[] _disposables;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeDisposable"/> class.
    /// </summary>
    /// <param name="disposables">The collection of disposable objects to manage.</param>
    public CompositeDisposable(params IDisposable?[] disposables)
    {
        _disposables = disposables.Where(d => d != null).ToArray()!;
    }

    /// <summary>
    /// Disposes all managed disposable objects.
    /// </summary>
    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
