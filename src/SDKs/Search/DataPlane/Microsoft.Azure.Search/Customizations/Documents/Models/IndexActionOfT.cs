// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public class IndexAction<T> : IndexActionBase<T> where T : class
    {
        internal IndexAction(IndexActionType actionType, T document)
            : base(actionType, document)
        {
        }
    }
}
