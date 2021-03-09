using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ExceptionTest
    {
        [TestCase]
        public void TypeCheck()
        {
            ManagementException managementException = new ManagementException("Invalid Content-Type (application/octet-stream).  These are supported: application/json");
            Assert.AreEqual("INVALID_CONTENT_TYPE", managementException.Code);
            Assert.AreEqual("Sample Target", managementException.Target);
            Assert.AreEqual(2, managementException.Details.Count);
            Assert.IsTrue(managementException.Details.Contains("Details One"));
            Assert.AreEqual(2, managementException.AdditionalInfo);
            KeyValuePair<string, string> key1 = new("key1", "value1");
            Assert.IsTrue(managementException.AdditionalInfo.Contains(key1));
        }
    }
}
