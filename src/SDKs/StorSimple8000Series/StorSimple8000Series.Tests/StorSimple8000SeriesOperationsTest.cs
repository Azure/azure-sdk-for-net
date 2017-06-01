using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StorSimple8000Series.Tests
{
    public class StorSimple8000SeriesTest : TestBase
    {
        [Fact]
        public void SampleTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new StorSimple8000SeriesTestBase(context);

                //List all resources in the subscription
                var createdResources = testBase.client.Managers.List();
            }
        }
    }
}
