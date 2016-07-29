// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;

    public static class ClientUnitTestCommon
    {
        public const string DummyBaseUrl = "testbatch://batch-test.windows-int.net";
        public const string DummyAccountName = "Dummy";
        public const string DummyAccountKey = "ZmFrZQ==";

        public static BatchSharedKeyCredentials CreateDummySharedKeyCredential()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                ClientUnitTestCommon.DummyBaseUrl,
                ClientUnitTestCommon.DummyAccountName,
                ClientUnitTestCommon.DummyAccountKey);

            return credentials;
        }

        public static BatchClient CreateDummyClient()
        {
            return BatchClient.Open(CreateDummySharedKeyCredential());
        }

        public static IList<BatchClientBehavior> SimulateServiceResponse<TOptions, TResponse>(Func<TOptions, TResponse> simulator)
            where TOptions : IOptions, new()
            where TResponse : class, IAzureOperationResponse
        {
            var interceptor = new RequestInterceptor(baseRequest =>
                {
                    BatchRequest<TOptions, TResponse> request = (BatchRequest<TOptions, TResponse>)baseRequest;

                    request.ServiceRequestFunc = token =>
                    {
                        return Task.FromResult(simulator(request.Options));
                    };
                });

            return new List<BatchClientBehavior> { interceptor };
        }

        public static IList<BatchClientBehavior> SimulateServiceResponse<TParameters, TOptions, TResponse>(Func<TParameters, TOptions, TResponse> simulator)
            where TOptions : IOptions, new()
            where TResponse : class, IAzureOperationResponse
        {
            var interceptor = new RequestInterceptor(baseRequest =>
            {
                BatchRequest<TParameters, TOptions, TResponse> request = (BatchRequest<TParameters, TOptions, TResponse>)baseRequest;

                request.ServiceRequestFunc = token =>
                {
                    return Task.FromResult(simulator(request.Parameters, request.Options));
                };
            });

            return new List<BatchClientBehavior> { interceptor };
        }
    }
}
