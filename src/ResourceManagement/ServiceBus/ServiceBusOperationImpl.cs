// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// The implementation of ServiceBusOperation.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c09wZXJhdGlvbkltcGw=
    internal partial class ServiceBusOperationImpl  :
        Wrapper<Models.Operation>,
        IServiceBusOperation
    {
        ///GENMHASH:8F968AA6E7B1B058C45C87EDB27F7F26:C0C35E00AF4E17F141675A2C05C7067B
        public ServiceBusOperationImpl(Operation innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:DB658DCFC241120D67B9FB4B1439839E:9997726062B279B35ABB492517DB4661
        public OperationDisplay DisplayInformation()
        {
            return Inner.Display;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public string Name()
        {
            return Inner.Name;
        }
    }
}