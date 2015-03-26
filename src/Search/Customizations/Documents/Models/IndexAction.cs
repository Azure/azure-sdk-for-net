// 
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
    /// Represents an index action that operates on a document.
    /// </summary>
    public class IndexAction : IndexAction<Document>
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
        public IndexAction(Document document) : base(document)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the IndexAction class with the given action type.
        /// </summary>
        /// <param name="actionType">The type of action to perform on the document.</param>
        public IndexAction(IndexActionType actionType) : base(actionType)
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
