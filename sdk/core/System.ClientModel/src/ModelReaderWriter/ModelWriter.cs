// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.Internal;

internal class ModelWriter : ModelWriter<object>
{
    public ModelWriter(IJsonModel<object> model, ModelReaderWriterOptions options)
        : base(model, options)
    {
    }
}
