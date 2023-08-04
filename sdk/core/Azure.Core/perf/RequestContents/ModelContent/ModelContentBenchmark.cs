// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Perf.RequestContents.ModelContent
{
    public abstract class ModelContentBenchmark<T> : RequestContentBenchmark<IModelSerializable<T>> where T : class, IModelSerializable<T>
    {
        protected override RequestContent CreateRequestContent()
        {
            return RequestContent.Create(_model);
        }
    }
}
