using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ExceptionTest
    {
        [TestCase]
        public void TypeCheck()
        {
            ArmException managementException = new ArmException("Invalid Content-Type (application/octet-stream).  These are supported: application/json");
            //Assert.AreEqual("INVALID_CONTENT_TYPE", managementException.Code);
            //Assert.AreEqual("Sample Target", managementException.Target);
            //Assert.AreEqual(2, managementException.Details.Count);
            //Assert.IsTrue(managementException.Details.Contains("Details One"));
            //Assert.AreEqual(2, managementException.AdditionalInfo.Count);
            //KeyValuePair<string, string> key1 = new("key1", "value1");
            //Assert.IsTrue(managementException.AdditionalInfo.Contains(key1));
            Assert.Ignore();
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<ArmException> CreateManagementExceptionAsync(Response response, string? message = null, string? errorCode = null, IDictionary<string, string>? additionalInfo = null, Exception? innerException = null)
        {
            var content = await ReadContentAsync(response, true).ConfigureAwait(false);
            if (message == null)
            {
                message = (string)ArmException.GetResponseProperty(content, "message");
            }
            if (errorCode == null)
            {
                errorCode= (string)ArmException.GetResponseProperty(content, "code");
            }
            ArmException managementException = new ArmException(response.Status, message, errorCode, innerException, content);
            return managementException;
        }

        private static async ValueTask<string?> ReadContentAsync(Response response, bool async)
        {
            string? content = null;

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    content = async ? await streamReader.ReadToEndAsync().ConfigureAwait(false) : streamReader.ReadToEnd();
                }
            }

            return content;
        }
    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
