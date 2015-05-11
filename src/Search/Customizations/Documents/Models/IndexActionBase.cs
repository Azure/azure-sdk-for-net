﻿// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

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
            Document = document;
            ActionType = actionType;
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
