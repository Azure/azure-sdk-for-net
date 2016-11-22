// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// The com.microsoft.azure.management.trafficmanager.TrafficManagerProfiles.checkDnsNameAvailability action result.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLkNoZWNrUHJvZmlsZURuc05hbWVBdmFpbGFiaWxpdHlSZXN1bHQ=
    internal partial class CheckProfileDnsNameAvailabilityResult 
    {
        private TrafficManagerNameAvailabilityInner inner;
        /// <return>
        /// True if the DNS name is available to use, false if the name has already been taken
        /// or invalid and cannot be used.
        /// </return>
        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:4F919944D8D2F904C2402C730D63DA07
        public bool IsAvailable()
        {
            //$ return inner.NameAvailable();
            //$ }

            return false;
        }

        /// <return>The reason that the DNS name could not be used.</return>
        ///GENMHASH:5D3E8FC383AE40AAD3262C598E63D4A1:C811416A07055B5B1E64A3967CCACF6E
        public ProfileDnsNameUnavailableReason Reason()
        {
            //$ return new ProfileDnsNameUnavailableReason(inner.Reason());
            //$ }

            return null;
        }

        /// <summary>
        /// Creates an instance of CheckProfileDnsNameAvailabilityResult.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:9DB00CCE0DA7D08C2634E2FEDA4635F7:BC4B1282CA708DC220050F834F17A184
        public  CheckProfileDnsNameAvailabilityResult(TrafficManagerNameAvailabilityInner inner)
        {
            //$ this.inner = inner;
            //$ }

        }

        /// <return>An error message explaining the reason value in more detail.</return>
        ///GENMHASH:E703019D95A4EEA3549CBD7305C71A96:340D0580E29C483CD3A1D98F49B79FD7
        public string Message()
        {
            //$ return inner.Message();
            //$ }

            return null;
        }
    }
}