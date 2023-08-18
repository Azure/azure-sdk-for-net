// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates collection properties on Patch models.
    /// </summary>
    public partial class CollectionPatchModel
    {
        private readonly ChangeList _rootChanges = new();
        private readonly ChangeListElement _changes;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CollectionPatchModel()
        {
            _changes = _rootChanges.RootElement;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal CollectionPatchModel(string id, IDictionary<string, string> values)
        {
            _id = id;
            _variables = values;
        }

        private string _id;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                _changes.Set("id", value);
            }
        }

        private IDictionary<string, string> _variables;
        /// <summary> Environment variables which are defined as a set of &lt;name,value&gt; pairs. </summary>
        public IDictionary<string, string> Variables
        {
            get
            {
                _variables ??= new ChangeListDictionary<string>("variables", _changes);
                return _variables;
            }
        }
    }
}
