// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public const string DummyToken = "ZmFrZQ==";

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
            var client = BatchClient.Open(CreateDummySharedKeyCredential());
            client.CustomBehaviors = client.CustomBehaviors.Where(behavior => !(behavior is RetryPolicyProvider)).ToList();

            return client;
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
