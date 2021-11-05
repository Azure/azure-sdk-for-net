// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ExtendedLocation.Tests.ScenarioTests
{
    using System;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.ExtendedLocation.Models;
    
    public class Paging
    {
        public static bool PageListResult(Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation> start, Func<string, IPage<CustomLocation>> getNext)
        {
            var page = start;
            bool foundCL = false;
            for (;;)
            {
                foreach (var currCL in page)
                {
                    // check for created CL in List  
                    if (currCL.Name == CustomLocationTestData.ResourceName) {Console.WriteLine("CL: "+currCL.Name);foundCL = true; break;}
                }   
                if (string.IsNullOrEmpty(page.NextPageLink))
                {
                    break;
                }
                page = (Microsoft.Azure.Management.ExtendedLocation.Models.Page<CustomLocation>)getNext(page.NextPageLink);
            }
            return foundCL;   
        }
    }
}


