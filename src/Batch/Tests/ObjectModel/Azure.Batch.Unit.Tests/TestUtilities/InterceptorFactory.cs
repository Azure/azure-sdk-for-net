namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public static class InterceptorFactory
    {
        public static Protocol.RequestInterceptor CreateGetJobRequestInterceptor(Protocol.Models.CloudJob jobToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.JobGetOptions, Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>(jobToReturn);
        }

        public static Protocol.RequestInterceptor CreateAddJobRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.JobAddParameter,
                Protocol.Models.JobAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.JobAddHeaders>>();
        }

        public static Protocol.RequestInterceptor CreateGetTaskRequestInterceptor(Protocol.Models.CloudTask taskToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.TaskGetOptions, Protocol.Models.CloudTask, Protocol.Models.TaskGetHeaders>(taskToReturn);
        }


        public static Protocol.RequestInterceptor CreateGetPoolRequestInterceptor(Protocol.Models.CloudPool poolToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.PoolGetOptions, Protocol.Models.CloudPool, Protocol.Models.PoolGetHeaders>(poolToReturn);
        }

        public static Protocol.RequestInterceptor CreateAddPoolRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.PoolAddParameter,
                Protocol.Models.PoolAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.PoolAddHeaders>>();
        }

        public static Protocol.RequestInterceptor CreateGetJobScheduleRequestInterceptor(Protocol.Models.CloudJobSchedule jobScheduleToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.JobScheduleGetOptions, Protocol.Models.CloudJobSchedule, Protocol.Models.JobScheduleGetHeaders>(jobScheduleToReturn);
        }

        public static Protocol.RequestInterceptor CreateAddJobScheduleRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.JobScheduleAddParameter,
                Protocol.Models.JobScheduleAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.JobScheduleAddHeaders>>();
        }

        public static Protocol.RequestInterceptor CreateGetCertificateRequestInterceptor(Protocol.Models.Certificate certificateToReturn)
        {
            return CreateGetRequestInterceptor<Protocol.Models.CertificateGetOptions, Protocol.Models.Certificate, Protocol.Models.CertificateGetHeaders>(certificateToReturn);
        }

        public static Protocol.RequestInterceptor CreateAddCertificateRequestInterceptor()
        {
            return CreateAddRequestInterceptor<
                Protocol.Models.CertificateAddParameter,
                Protocol.Models.CertificateAddOptions,
                AzureOperationHeaderResponse<Protocol.Models.CertificateAddHeaders>>();
        }

        public static Protocol.RequestInterceptor CreateAddRequestInterceptor<TBody, TOptions, TResponse>()
            where TOptions : Protocol.Models.IOptions, new()
            where TResponse : IAzureOperationResponse, new()
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var requestType = (Protocol.BatchRequest<TBody, TOptions, TResponse>)req;

                requestType.ServiceRequestFunc = ct =>
                {
                    return Task.FromResult(new TResponse());
                };
            });
        }

        public static Protocol.RequestInterceptor CreateGetRequestInterceptor<TOptions, TResponse, TResponseHeaders>(TResponse valueToReturn)
            where TOptions : Protocol.Models.IOptions, new()
        {
            return new Protocol.RequestInterceptor(req =>
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
    }
}
