// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest
{
    /// <summary>
    /// Interface defining a method that will instantiate exception object and throw it
    /// Implementing error models will know what corresponding exception object to throw
    /// </summary>
    public interface IRestErrorModel
    {
        void CreateAndThrowException(string errorMessage, HttpRequestMessageWrapper request, HttpResponseMessageWrapper response, int httpStatusCode);
    }
}