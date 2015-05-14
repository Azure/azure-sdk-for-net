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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Abstract base class for batches of upload, merge, and/or delete actions to send to the Azure Search index.
    /// </summary>
    /// <typeparam name="TAction">
    /// The type of action to be contained in the batch. Must be derived from IndexActionBase.
    /// </typeparam>
    /// <typeparam name="TDoc">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public abstract class IndexBatchBase<TAction, TDoc> 
        where TAction : IndexActionBase<TDoc>
        where TDoc : class
    {
        // NOTE: We use IEnumerable so callers can stream each batch of documents if they want.
        [JsonProperty("value")]
        private IEnumerable<TAction> _actions;

        /// <summary>
        /// Initializes a new instance of the IndexBatchBase class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        protected IndexBatchBase(IEnumerable<TAction> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            _actions = actions;
        }

        /// <summary>
        /// Gets the sequence of actions in the batch.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<TAction> Actions
        {
            get { return _actions; }
        }
    }
}
