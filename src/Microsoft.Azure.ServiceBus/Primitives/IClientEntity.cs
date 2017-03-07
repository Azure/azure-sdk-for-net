// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System.Threading.Tasks;

    public interface IClientEntity
    {
        string ClientId { get; }

        Task CloseAsync();

        void Close();
    }
}