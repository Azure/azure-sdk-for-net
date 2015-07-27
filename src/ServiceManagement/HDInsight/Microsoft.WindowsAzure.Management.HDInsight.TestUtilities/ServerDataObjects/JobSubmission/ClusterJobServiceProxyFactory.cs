using System.Diagnostics;
using System.Reflection;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.Core.Logging;
using Microsoft.ClusterServices.Core.Utils;
using Microsoft.ClusterServices.DataAccess.Context.Extensions;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Class that creates ClusterJobServiceProxy objects.
    /// </summary>
    public class ClusterJobServiceProxyFactory : IClusterJobServiceProxyFactory
    {
        static readonly Logger Log = Logger.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);

        /// <inheritdocs/>
        public IClusterJobServiceProxy CreateClusterJobServiceProxy(DataAccess.Context.ClusterContainer container)
        {
            Contract.AssertArgNotNull(container, "container");
            Contract.AssertArgNotNull(container.Deployment, "container.Deployment");
            
            var clusterAddress =
                    string.Format(
                        "https://{0}:{1}",
                        container.CNameMapping ?? string.Format(Constants.CNameMappingFormatString, container.DnsName),
                        WebHCatResources.WebHCatDefaultPort);
            
            if (!string.IsNullOrEmpty(container.CNameMapping))
            {
                Log.LogResourceExtensionEvent(container.SubscriptionId, JobSubmissionConstants.ResourceExtentionName,
                                              container.DnsName,
                                              string.Format(
                                                  JobSubmissionConstants.BypassServerCertValidationLogMessage,
                                                  clusterAddress), TraceEventType.Information);
            }

            return new ClusterJobServiceProxy(clusterAddress, container.Deployment.ClusterUsername, container.Deployment.GetClearTextClusterPassword(),!string.IsNullOrEmpty(container.CNameMapping));
        }
    }
}