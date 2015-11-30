using System.Threading.Tasks;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;
using Microsoft.ClusterServices.RDFEProvider.ResourceTypes;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    /// <summary>
    /// Interface for actions based on a passthrough.
    /// </summary>
    public interface IPassthroughAction
    {
        /// <summary>
        /// Method that executes the desired action.
        /// </summary>
        /// <returns>An HttpResponseMessage that contains the response/result of the given action.</returns>
        Task<PassthroughResponse> Execute();
    }
}