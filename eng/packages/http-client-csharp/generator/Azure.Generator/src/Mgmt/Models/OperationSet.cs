// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Mgmt.Models
{
    /// <summary>
    /// An <see cref="OperationSet"/> represents a collection of <see cref="Operation"/> with the same request path.
    /// </summary>
    internal class OperationSet : IReadOnlyCollection<InputOperation>, IEquatable<OperationSet>
    {
        /// <summary>
        /// The raw request path of string of the operations in this <see cref="OperationSet"/>
        /// </summary>
        public RequestPath RequestPath { get; }

        public InputClient InputClient { get; }

        /// <summary>
        /// The operation set
        /// </summary>
        private HashSet<InputOperation> _operations;

        public int Count => _operations.Count;

        public OperationSet(RequestPath requestPath, InputClient inputClient)
        {
            InputClient = inputClient;
            RequestPath = requestPath;
            _operations = new HashSet<InputOperation>();
        }

        /// <summary>
        /// Add a new operation to this <see cref="OperationSet"/>
        /// </summary>
        /// <param name="operation">The operation to be added</param>
        /// <exception cref="InvalidOperationException">when trying to add an operation with a different path from <see cref="RequestPath"/></exception>
        public void Add(InputOperation operation)
        {
            var path = operation.GetHttpPath();
            if (!path.Equals(RequestPath))
                throw new InvalidOperationException($"Cannot add operation with path {path} to OperationSet with path {RequestPath}");
            _operations.Add(operation);
        }

        public IEnumerator<InputOperation> GetEnumerator() => _operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _operations.GetEnumerator();

        public override int GetHashCode()
        {
            return RequestPath.GetHashCode();
        }

        public bool Equals([AllowNull] OperationSet other)
        {
            if (other is null)
                return false;

            return RequestPath == other.RequestPath;
        }

        public override string? ToString()
        {
            return RequestPath;
        }
    }
}
