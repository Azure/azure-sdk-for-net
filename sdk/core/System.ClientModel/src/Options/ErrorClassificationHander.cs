// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Primitives;

public abstract class ErrorClassificationHander
{
    public abstract bool TryClassify(PipelineMessage message, out bool isError);
}
