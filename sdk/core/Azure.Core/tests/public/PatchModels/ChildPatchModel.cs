// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a nested child model in a parent model.
    /// </summary>
    public partial class ChildPatchModel
    {
#pragma warning disable AZC0020 // Avoid using banned types in libraries
        private readonly MutableJsonElement _element;

        // Make the element available to the parent
        internal MutableJsonElement Element => _element;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ChildPatchModel()
        {
            _element = MutableJsonDocument.Parse(MutableJsonDocument.EmptyJson).RootElement;
        }

        /// <summary> Serialization constructor. </summary>
        /// <param name="element"></param>
        internal ChildPatchModel(MutableJsonElement element)
        {
            _element = element;
        }

        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get
            {
                if (_element.TryGetProperty("a", out MutableJsonElement value))
                {
                    return value.GetString();
                }
                return null;
            }
            set => _element.SetProperty("a", value);
        }

        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get
            {
                if (_element.TryGetProperty("b", out MutableJsonElement value))
                {
                    return value.GetString();
                }
                return null;
            }
            set => _element.SetProperty("b", value);
        }
#pragma warning restore AZC0020 // Avoid using banned types in libraries
    }
}
