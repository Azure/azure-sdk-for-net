// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a patch model with properties that are nested models.
    /// </summary>
    public partial class ParentPatchModel
    {
#pragma warning disable AZC0020 // Avoid using banned types in libraries
        private readonly MutableJsonElement _element;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ParentPatchModel()
        {
            _element = MutableJsonDocument.Parse(MutableJsonDocument.EmptyJson).RootElement;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal ParentPatchModel(MutableJsonElement element)
        {
            _element = element;
        }

        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
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
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                if (_child == null)
                {
                    if (!_element.TryGetProperty("child", out MutableJsonElement element))
                    {
                        _element.SetProperty("child", new { });
                        element = _element.GetProperty("child");
                    }

                    _child = new ChildPatchModel(element);
                }

                return _child;
            }

            // Note: a child patch model isn't settable on the parent.
            // This is because its _element property needs to have the
            // same root MutableJsonDocument as the parent.
            //
            // It's unclear how we would plug it in after the fact if we wanted
            // to make an instance of the child model something that could be
            // used in multiple places.
        }
#pragma warning restore AZC0020 // Avoid using banned types in libraries
    }
}
