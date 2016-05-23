using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Test;

namespace Microsoft.WindowsAzure.Testing
{
    public class ComputeTestsUtilities
    {
        public static string GenerateRandomPassword()
        {
            return TestUtilities.GenerateName(prefix: "AzureSDK1") + Guid.NewGuid().ToString();
        }
    }
}
