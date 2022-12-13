// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using Azure.ResourceManager;

namespace Azure.Core
{
    internal interface IOperationSourceProvider<T>
    {
#if NET7_0_OR_GREATER
        /// <summary> Get the IOperationSource of type T. </summary>
        /// <param name="armClient"> The ArmClient to use. </param>
        static abstract IOperationSource<T> GetOperationSource(ArmClient armClient);
#endif
    }
}
