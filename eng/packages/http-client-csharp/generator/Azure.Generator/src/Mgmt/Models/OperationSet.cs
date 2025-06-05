// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Mgmt.Models
{
    /// <summary>
    /// An <see cref="OperationSet"/> represents a collection of <see cref="Operation"/> with the same request path.
    /// </summary>
    internal class OperationSet : IReadOnlyCollection<InputOperation>, IEquatable<OperationSet>
    {
        private readonly InputClient? _inputClient;

        /// <summary>
        /// The raw request path of string of the operations in this <see cref="OperationSet"/>
        /// </summary>
        public string RequestPath { get; }

        /// <summary>
        /// The operation set
        /// </summary>
        private HashSet<InputOperation> _operations;

        public int Count => _operations.Count;

        public OperationSet(string requestPath, InputClient? inputClient)
        {
            _inputClient = inputClient;
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
            if (path != RequestPath)
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

        /// <summary>
        /// Get the operation with the given verb.
        /// We cannot have two operations with the same verb under the same request path, therefore this method is only returning one operation or null
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public InputOperation? GetOperation(RequestMethod method)
        {
            foreach (var operation in _operations)
            {
                if (operation.HttpMethod == method.ToString())
                    return operation;
            }

            return null;
        }

        private InputOperation? FindBestOperation()
        {
            // first we try GET operation
            var getOperation = FindOperation(RequestMethod.Get);
            if (getOperation != null)
                return getOperation;
            // if no GET operation, we return PUT operation
            var putOperation = FindOperation(RequestMethod.Put);
            if (putOperation != null)
                return putOperation;

            // if no PUT or GET, we just return the first one
            return _operations.FirstOrDefault();
        }

        public InputOperation? FindOperation(RequestMethod method)
        {
            return this.FirstOrDefault(operation => operation.HttpMethod == method.ToString());
        }

        public override string? ToString()
        {
            return RequestPath;
        }
    }
}
