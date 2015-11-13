// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Represents an index action that operates on a document.
    /// </summary>
    public class IndexAction : IndexActionBase<Document>
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
        public IndexAction(Document document) : this(default(IndexActionType), document)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the IndexAction class with the given action type.
        /// </summary>
        /// <param name="actionType">The type of action to perform on the document.</param>
        /// <param name="document">The document on which the action will be performed.</param>
        public IndexAction(IndexActionType actionType, Document document) : base(actionType, document)
        {
            // Do nothing.
        }

        /// <summary>
        /// Creates a new instance of the IndexAction class.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="document">The document on which the action will be performed.</param>
        /// <returns>A new IndexAction.</returns>
        /// <remarks>
        /// You can use this method as a convenience if you don't want to explicitly specify your model class as a
        /// type parameter.
        /// </remarks>
        public static IndexAction<T> Create<T>(T document) where T : class
        {
            return new IndexAction<T>(document);
        }

        /// <summary>
        /// Creates a new instance of the IndexAction class.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="actionType">The type of action to perform on the document.</param>
        /// <param name="document">The document on which the action will be performed.</param>
        /// <returns>A new IndexAction.</returns>
        /// <remarks>
        /// You can use this method as a convenience if you don't want to explicitly specify your model class as a
        /// type parameter.
        /// </remarks>
        public static IndexAction<T> Create<T>(IndexActionType actionType, T document) where T : class
        {
            return new IndexAction<T>(actionType, document);
        }
    }
}
