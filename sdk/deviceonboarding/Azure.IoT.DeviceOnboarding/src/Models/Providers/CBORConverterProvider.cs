// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models.Providers
{
    /// <summary>
    /// Interface for consumer to provide CBOR conversion
    /// </summary>
    public abstract class CBORConverterProvider
    {
        /// <summary>
        /// Method for deserializing CBOR bytes to specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public abstract T Deserialize<T>(byte[] bytes);

        /// <summary>
        /// Method for serializing object to CBOR bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public abstract byte[] Serialize<T>(T content);
    }
}
