// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates optional read/write "primitive" properties.
    /// </summary>
    public partial class ParentPatchModel
    {
        private readonly MutableJsonElement _element;

        /// <summary> Public constructor. </summary>
        public ParentPatchModel()
        {
            _element = MutableJsonDocument.Parse(MutableJsonDocument.EmptyJson).RootElement;
        }

        /// <summary> Serialization constructor. </summary>
        /// <param name="element"></param>
        internal ParentPatchModel(MutableJsonElement element)
        {
            _element = element;
        }

        /// <summary> Optional string property corresponding to JSON """{"id": "abc"}""". </summary>
        public string Id
        {
            get
            {
                if (_element.TryGetProperty("id", out MutableJsonElement value))
                {
                    return value.GetString();
                }
                return null;
            }
            set => _element.SetProperty("id", value);
        }

        private ChildPatchModel _child;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON
        /// """{"child": {"a":"aa", "b": "bb"}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                if (_child == null)
                {
                    _element.SetProperty("passFailCriteria", new { });
                    _child = new ChildPatchModel(_element.GetProperty("child"));
                }

                return _child;
            }

            // TODO: need to test what happens if caller sets this, how the interaction
            // across MJEs in the MJD works.
            set { _child = value; }
        }
    }
}
