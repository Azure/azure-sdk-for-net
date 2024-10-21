// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Test.Shared;

/// <summary>
/// Class for managing IDisposable objects to determine if an
/// arbitrary concept is "in scope." Great for temporarily
/// enabling a behavior.
/// </summary>
public class ScopeManager
{
    private class Scope : IDisposable
    {
        private readonly ScopeManager _parent;

        public Scope(ScopeManager parent)
        {
            _parent = parent;
        }

        public void Dispose()
        {
            _parent._scopes.Remove(this);
        }
    }

    private readonly HashSet<Scope> _scopes = new();

    public bool InScope => _scopes.Count > 0;

    public IDisposable GetScope()
    {
        Scope scope = new(this);
        _scopes.Add(scope);
        return scope;
    }
}
