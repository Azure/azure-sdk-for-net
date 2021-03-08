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
            var result = ManagementException.GetResponseDetails("TestStart");
            Assert.NotNull(result);
        }
    }
}
