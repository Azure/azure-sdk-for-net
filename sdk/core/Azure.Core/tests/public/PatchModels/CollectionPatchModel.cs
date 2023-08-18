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
        private readonly ChangeList _rootChanges;
        private ChangeListElement _changes => _rootChanges.RootElement;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CollectionPatchModel()
        {
            _rootChanges = new ChangeList();
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal CollectionPatchModel(ChangeList changes, string id, ChangeListDictionary<string> values)
        {
            _id = id;
            _variables = values;

            _rootChanges = changes;
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

        private ChangeListDictionary<string>? _variables;
        /// <summary> Environment variables which are defined as a set of &lt;name,value&gt; pairs. </summary>
        public IDictionary<string, string> Variables
        {
            get
            {
                _variables ??= new ChangeListDictionary<string>(_changes.GetElement("variables"));
                return _variables;
            }
        }
    }
}
