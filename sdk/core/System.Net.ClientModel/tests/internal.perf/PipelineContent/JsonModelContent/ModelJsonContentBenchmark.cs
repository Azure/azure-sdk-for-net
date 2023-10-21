// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Content;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public abstract class ModelJsonContentBenchmark<T> : RequestContentBenchmark<IJsonModel<T>> where T : class, IJsonModel<T>
    {
        protected override PipelineContent CreatePipelineContent()
        {
            return PipelineContent.CreateContent(_model);
        }
    }
}
