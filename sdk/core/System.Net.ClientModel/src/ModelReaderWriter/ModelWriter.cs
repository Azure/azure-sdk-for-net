// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core
{
    internal class ModelWriter : ModelWriter<object>
    {
        public ModelWriter(IJsonModel<object> model, ModelReaderWriterOptions options)
            : base(model, options)
        {
        }
    }
}
