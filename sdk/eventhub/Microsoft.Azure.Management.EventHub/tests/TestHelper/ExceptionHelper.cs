using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub.Tests.ScenarioTests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using Microsoft.Azure.Management.EventHub.Models;

    public partial class ScenarioTests
    {
        internal void DisplayExceptionDetails(ErrorResponseException ex)
        {
            throw new Exception(string.Format("Status Code : {0}, Responsecontent: {1}", ex.Response.StatusCode.ToString(), ex.Response.Content.ToString()));
        }
    }
}
