﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Abstract base class for index actions that operate on a document.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public abstract class IndexActionBase<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the IndexActionBase class.
        /// </summary>
        protected IndexActionBase()
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the IndexActionBase class with the given action type.
        /// </summary>
        /// <param name="actionType">The type of action to perform on the document.</param>
        /// <param name="document">The document on which the action will be performed.</param>
        protected IndexActionBase(IndexActionType actionType, T document)
        {
            this.Document = document;
            this.ActionType = actionType;
        }

        /// <summary>
        /// Gets or sets a value indicating the action to perform on a document in an indexing batch; 
        /// Default is <c cref="Microsoft.Azure.Search.Models.IndexActionType.Upload">Upload</c>.
        /// </summary>
        public IndexActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets the document on which the action will be performed; Must contain only a key for delete actions.
        /// </summary>
        public T Document { get; set; }
    }
}
