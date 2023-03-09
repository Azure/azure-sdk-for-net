// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Shared
{
    /// <summary> An interface for representing resource of data. </summary>
    /// <typeparam name="T">The data of the resource. </typeparam>
    public interface IData<T> where T : ISerializable, new()
    {
        /// <summary> Gets the data representing this Feature. </summary>
        T Data { get; }
    }
}
