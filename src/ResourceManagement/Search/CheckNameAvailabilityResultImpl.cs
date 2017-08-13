// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    /// <summary>
    /// Implementation for CheckNameAvailabilityResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlYXJjaC5pbXBsZW1lbnRhdGlvbi5DaGVja05hbWVBdmFpbGFiaWxpdHlSZXN1bHRJbXBs
    internal partial class CheckNameAvailabilityResultImpl  :
        Wrapper<Models.CheckNameAvailabilityOutputInner>,
        ICheckNameAvailabilityResult
    {
        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:562D753448CEF36C619F52730D08D2C6
        public bool IsAvailable()
        {
            if(Inner.IsNameAvailable.HasValue)
            {
                return Inner.IsNameAvailable.Value;
            }

            return false;
        }

        ///GENMHASH:39A7E2BFDDD2D6F13D7EBE13673EA7FA:91E168D34C41BF1A16DAE45344230978
        public string UnavailabilityReason()
        {
            return Inner.Reason;
        }

        ///GENMHASH:3A8C639760DE81ABB3D12F40D11FF27C:5B8B726F24C830BD6A787FF161E2712A
        public string UnavailabilityMessage()
        {
            return Inner.Message;
        }

        /// <summary>
        /// Creates an instance of the check name availability result object.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:F7B06C22561C685C282AECC79C4C203E:25393C7B0FB3F6DE794B90C20B030BC2
        internal  CheckNameAvailabilityResultImpl(CheckNameAvailabilityOutputInner inner) : base(inner)
        {
        }
    }
}