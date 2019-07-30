using Newtonsoft.Json;
using Xunit;
using Microsoft.Rest.Azure;
using System.Net.Http;
using System.Net;
using CR.Azure.FullDesktop.Tests.Fakes;
using System.Collections.Generic;
using Microsoft.Rest;

namespace CR.Azure.FullDesktop.Tests
{
    public class CloudExceptionSerializationTests
    {
        private static IEnumerable<HttpResponseMessage> GetExceptionResponse()
        {

            var ex = new CloudException("test cloud exception");
            ex.Body = new CloudError()
            {
                Message = "Inner error message",
                Code = "1234"
            };
            var response1 = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(ex))
            };

            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");
            yield return response1;
        }
        
        [Fact]
        public void TestCloudExceptionDeserialization()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(GetExceptionResponse());
            var fakeClient = new CloudExceptionFakeServiceClient(tokenCredentials, handler);
            var ex = Assert.Throws<System.AggregateException>(() => fakeClient.CloudExceptionFakeOperations.GetOperationSync().Result);
            Assert.IsType<CloudException>(ex.InnerException);
            var cloudEx = (CloudException)ex.InnerException;
            Assert.Equal("1234", cloudEx.Body.Code);
        }
    }
}
