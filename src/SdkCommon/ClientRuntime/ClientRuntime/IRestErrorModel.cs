// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest
{
    public interface IRestErrorModel
    {
        void CreateAndThrowException(HttpRequestMessageWrapper reqMessage, HttpResponseMessageWrapper respMessage);
    }
}