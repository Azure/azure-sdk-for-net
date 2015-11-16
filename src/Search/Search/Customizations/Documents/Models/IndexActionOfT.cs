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
        /// <summary>
        /// Initializes a new instance of the IndexAction class.
        /// </summary>
        public IndexAction()
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the IndexAction class.
        /// </summary>
        /// <param name="document">The document on which the action will be performed.</param>
        public IndexAction(T document) : this(default(IndexActionType), document)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the IndexAction class with the given action type.
        /// </summary>
        /// <param name="actionType">The type of action to perform on the document.</param>
        /// <param name="document">The document on which the action will be performed.</param>
        public IndexAction(IndexActionType actionType, T document) : base(actionType, document)
        {
        }
    }
}
