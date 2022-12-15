// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.ResourceManager;

namespace Azure.Core
{
#if NET7_0_OR_GREATER
#pragma warning disable SA1649 // File name should match first type name
    internal interface IOperationSourceProvider<T>
#pragma warning restore SA1649
    {
        /// <summary> Get the IOperationSource of type T. </summary>
        /// <param name="armClient"> The ArmClient to use. </param>
        static abstract IOperationSource<T> GetOperationSource(ArmClient armClient);
    }
#endif
}
