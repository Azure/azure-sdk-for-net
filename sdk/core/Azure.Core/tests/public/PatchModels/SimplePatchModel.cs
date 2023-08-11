// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    public partial class SimplePatchModel
    {
        private readonly MutableJsonElement _element;

        /// <summary> Public constructor. </summary>
        public SimplePatchModel()
        {
            _element = MutableJsonDocument.Parse(MutableJsonDocument.EmptyJson).RootElement;
        }

        /// <summary> Serialization constructor. </summary>
        /// <param name="element"></param>
        internal SimplePatchModel(MutableJsonElement element)
        {
            _element = element;
        }

        /// <summary> Optional string property corresponding to JSON """{"name": "abc"}""". </summary>
        public string Name
        {
            get
            {
                if (_element.TryGetProperty("name", out MutableJsonElement value))
                {
                    return value.GetString();
                }
                return null;
            }
            set => _element.SetProperty("name", value);
        }

        /// <summary> Optional int property corresponding to JSON """{"count": 1}""". </summary>
        public int? Count
        {
            get
            {
                if (_element.TryGetProperty("count", out MutableJsonElement value))
                {
                    return value.GetInt32();
                }
                return null;
            }
            set => _element.SetProperty("count", value);
        }

        /// <summary> Optional DateTimeOffset property corresponding to JSON """{"updatedOn": "2020-06-25T17:44:37.6830000Z"}""". </summary>
        public DateTimeOffset? UpdatedOn
        {
            get
            {
                if (_element.TryGetProperty("updatedOn", out MutableJsonElement value))
                {
                    return value.GetDateTimeOffset();
                }
                return null;
            }
            set => _element.SetProperty("updatedOn", value);
        }
    }
}
