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

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Rest.Azure;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public static class InterceptorFactory
    {
        public static IEnumerable<Protocol.RequestInterceptor> CreateGetJobRequestInterceptor(Protocol.Models.CloudJob jobToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.JobGetOptions, Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>(jobToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddJobRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.JobAddParameter,
                Protocol.Models.JobAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.JobAddHeaders>>();
        }
        
        public static IEnumerable<Protocol.RequestInterceptor> CreateGetTaskRequestInterceptor(Protocol.Models.CloudTask TaskToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.TaskGetOptions, Protocol.Models.CloudTask, Protocol.Models.TaskGetHeaders>(TaskToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateGetPoolRequestInterceptor(Protocol.Models.CloudPool poolToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.PoolGetOptions, Protocol.Models.CloudPool, Protocol.Models.PoolGetHeaders>(poolToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateGetComputeNodeRequestInterceptor(Protocol.Models.ComputeNode nodeToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.ComputeNodeGetOptions, Protocol.Models.ComputeNode, Protocol.Models.ComputeNodeGetHeaders>(nodeToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddPoolRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.PoolAddParameter,
                Protocol.Models.PoolAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.PoolAddHeaders>>();
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateGetJobScheduleRequestInterceptor(Protocol.Models.CloudJobSchedule jobScheduleToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.JobScheduleGetOptions, Protocol.Models.CloudJobSchedule, Protocol.Models.JobScheduleGetHeaders>(jobScheduleToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddJobScheduleRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.JobScheduleAddParameter,
                Protocol.Models.JobScheduleAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.JobScheduleAddHeaders>>();
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateGetCertificateRequestInterceptor(Protocol.Models.Certificate certificateToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.CertificateGetOptions, Protocol.Models.Certificate, Protocol.Models.CertificateGetHeaders>(certificateToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddCertificateRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.CertificateAddParameter,
                Protocol.Models.CertificateAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.CertificateAddHeaders>>();
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateListTasksRequestInterceptor(IEnumerable<Protocol.Models.CloudTask> tasksToReturn)
        {
            return CreateListRequestInterceptor<
                Protocol.Models.TaskListOptions,
                Protocol.Models.CloudTask,
                Protocol.Models.TaskListHeaders>(tasksToReturn);
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddTaskCollectionInterceptor(IEnumerable<Protocol.Models.TaskAddResult> resultsToReturn)
        {
            return CreateAddRequestInterceptor<
                IList<Protocol.Models.TaskAddParameter>,
                Protocol.Models.TaskAddCollectionOptions,
                AzureOperationResponse<Protocol.Models.TaskAddCollectionResult, Protocol.Models.TaskAddCollectionHeaders>>(
                    responseFactory: () => new AzureOperationResponse<Protocol.Models.TaskAddCollectionResult, Protocol.Models.TaskAddCollectionHeaders>()
                        {
                            Body = new Protocol.Models.TaskAddCollectionResult()
                                {
                                    Value = resultsToReturn.ToList()
                                }
                        });
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateAddRequestInterceptor<TBody, TOptions, TResponse>(Func<TResponse> responseFactory = null)
            where TOptions : Protocol.Models.IOptions, new()
            where TResponse : IAzureOperationResponse, new()
        {
            yield return new Protocol.RequestInterceptor(req =>
                {
                    var requestType = (Protocol.BatchRequest<TBody, TOptions, TResponse>)req;

                    requestType.ServiceRequestFunc = ct =>
                        {
                            return Task.FromResult(responseFactory == null ? new TResponse() : responseFactory());
                        };
                });
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateGetRequestInterceptor<TOptions, TResponse, TResponseHeaders>(TResponse valueToReturn)
            where TOptions : Protocol.Models.IOptions, new()
        {
            yield return new Protocol.RequestInterceptor(req =>
                {
                    var castReq = (Protocol.BatchRequest<
                        TOptions,
                        AzureOperationResponse<TResponse, TResponseHeaders>>)req;

                    castReq.ServiceRequestFunc = ct =>
                        {
                            return Task.FromResult(new AzureOperationResponse<TResponse, TResponseHeaders>()
                                {
                                    Body = valueToReturn
                                });
                        };
                });
        }

        public static IEnumerable<Protocol.RequestInterceptor> CreateListRequestInterceptor<TOptions, TResponse, TResponseHeaders>(
            IEnumerable<TResponse> valueToReturn)
            where TOptions : Protocol.Models.IOptions, new()
        {
            yield return new Protocol.RequestInterceptor(req =>
                {
                    var castReq = (Protocol.BatchRequest<
                        TOptions,
                        AzureOperationResponse<IPage<TResponse>, TResponseHeaders>>)req;

                    castReq.ServiceRequestFunc = ct =>
                        {
                            return Task.FromResult(new AzureOperationResponse<IPage<TResponse>, TResponseHeaders>()
                                {
                                    Body = new FakePage<TResponse>(valueToReturn.ToList())
                                });
                        };
                });
        }
    }
}
