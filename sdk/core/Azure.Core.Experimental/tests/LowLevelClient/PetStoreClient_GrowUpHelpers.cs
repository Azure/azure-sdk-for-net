// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Experimental.Tests.Models;
using Azure.Core.Pipeline;
using Azure;
using System.Linq;

namespace Azure.Core.Experimental.Tests
{
    /// <summary> The PetStore service client. </summary>
    public partial class PetStoreClient
    {
        public static Pet GetPetFromBinaryData(BinaryData data)
        {
            return data;
        }

        //        public virtual AsyncPageable<BinaryData> GetPetsAsync()
        //#pragma warning restore AZC0002
        //        {
        //            // TODO: handle need for continuation token and
        //            AsyncPageable<BinaryData> pets = GetPetsAsync(new());
        //            pets.AsPages()

        //            //return PageableHelpers.create(i => { pets.AsPages}, _clientDiagnostics, "PetStoreClient.GetPets");
        //            //async IAsyncEnumerable<Page<BinaryData>> CreateEnumerableAsync(string nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        //            //{
        //            //    do
        //            //    {
        //            //        var message = string.IsNullOrEmpty(nextLink)
        //            //            ? CreateGetPetsRequest()
        //            //            : CreateGetPetsNextPageRequest(nextLink);
        //            //        var page = await LowLevelPageableHelpers.ProcessMessageAsync(Pipeline, message, _clientDiagnostics, options, "value", "nextLink", cancellationToken).ConfigureAwait(false);
        //            //        nextLink = page.ContinuationToken;
        //            //        yield return page;
        //            //    } while (!string.IsNullOrEmpty(nextLink));
        //            //}
        //        }

        // TODO: extend to generic
        private class PetPage<Pet> : Page<Pet>
        {
            private Page<BinaryData> _page;

            public PetPage(Page<BinaryData> page)
            {
                _page = page;
            }

            //public override IReadOnlyList<Pet> Values => ()_page.Values.Select(data => GetPetFromBinaryData(data)).ToList().AsReadOnly();
            //public override IReadOnlyList<Pet> Values => (IReadOnlyList<Pet>)_page.Values.Select(data => GetPetFromBinaryData(data));//.ToList().AsReadOnly();
            public override IReadOnlyList<Pet> Values => (IReadOnlyList<Pet>)_page.Values.Select(data =>
            {
                // Pet pet = (Pet)data; // does not compile
                return GetPetFromBinaryData(data);
            });

            public override string ContinuationToken => _page.ContinuationToken;

            public override Response GetRawResponse() => _page.GetRawResponse();
        }
    }
}
