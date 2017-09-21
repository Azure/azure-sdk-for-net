// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Azure CLI has a get-access-token command. This class mocks the process manager, so that Azure CLI token provider can be unit tested. 
    /// </summary>
    internal class MockProcessManager : IProcessManager
    {
        private readonly MockProcessManagerRequestType _requestType;

        // HitCount allows for the cache to be tested. 
        public int HitCount;

        // Different response types
        internal enum MockProcessManagerRequestType
        {
            ProcessNotFound, // When requested program is not installed
            Success,
            NoToken
        }

        internal MockProcessManager(MockProcessManagerRequestType requestType)
        {
            _requestType = requestType;
        }

        /// <summary>
        /// Return a response based on the request type
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public Task<Tuple<bool, string>> ExecuteAsync(Process process)
        {
            HitCount++;
                                   
            // This token will expire after 5 minutes and 2 seconds.
            // This is used to test the cache.
            var tokenResult = TokenHelper.GetUserTokenResponse(5*60 + 2);

            switch (_requestType)
            {
                case MockProcessManagerRequestType.Success:
                    return Task.FromResult(new Tuple<bool, string>(true, tokenResult));

                case MockProcessManagerRequestType.ProcessNotFound:
                    throw new Exception(Constants.ProgramNotFoundError);

            }

            throw new Exception();
        }
    }
}
