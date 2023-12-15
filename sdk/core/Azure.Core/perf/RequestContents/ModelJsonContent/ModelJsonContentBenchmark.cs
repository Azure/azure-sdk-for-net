// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Perf.RequestContents.ModelJsonContent
{
    public abstract class ModelJsonContentBenchmark<T> : RequestContentBenchmark<IModelJsonSerializable<T>> where T : class, IModelJsonSerializable<T>
    {
        protected override RequestContent CreateRequestContent()
        {
            return RequestContent.Create(_model);
        }
    }
}
