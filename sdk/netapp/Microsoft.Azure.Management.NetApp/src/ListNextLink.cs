using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.NetApp
{
    public static class ListNextLink<T>
    {
        public static List<T> GetAllResourcesByPollingNextLink(IPage<T> resourcePage, Func<string, IPage<T>> getNextLink)
        {
            var resourceList = new List<T>();

            var nextPageLink = AddResourceToListAndReturnNextPageLink(resourcePage, resourceList);

            while (!string.IsNullOrEmpty(nextPageLink))
            {
                var nextVnetPage = getNextLink(nextPageLink);
                nextPageLink = AddResourceToListAndReturnNextPageLink(nextVnetPage, resourceList);
            }

            return resourceList;
        }

        private static string AddResourceToListAndReturnNextPageLink(IPage<T> resourcePage, List<T> resourceList)
        {
            foreach (var resource in resourcePage)
            {
                resourceList.Add(resource);
            }

            return resourcePage.NextPageLink;
        }
    }
}
