using System.Net.Http;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    public interface IPassthroughActionFactory
    {
        IPassthroughAction GetPassthroughAction(string resourceExtension, HttpRequestMessage request,
                                                DataAccess.Context.ClusterContainer container, string subscriptionId);
    }
}