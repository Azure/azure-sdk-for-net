// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

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
        /// <summary>
        /// Initializes a new instance of the IndexBatchBase class.
        /// </summary>
        /// <param name="actions">The index actions to include in the batch.</param>
        protected IndexBatchBase(IEnumerable<TAction> actions)
        {
            Throw.IfArgumentNull(actions, "actions");

            Actions = actions;
        }

        /// <summary>
        /// Gets the sequence of actions in the batch.
        /// </summary>
        [JsonProperty("value")]
        public IEnumerable<TAction> Actions
        {
            // NOTE: We use IEnumerable so callers can stream each batch of documents if they want.
            get;
            private set;
        }
    }
}
