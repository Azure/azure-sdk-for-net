using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    /// <summary>
    /// Abstract base class for all passthrough actions. (added to support logging).
    /// </summary>
    public abstract class PassthroughAction : IPassthroughAction
    {
        protected string subscriptionId;

        protected PassthroughAction(string subscriptionId)
        {
            this.subscriptionId = subscriptionId;
        }

        public abstract Task<PassthroughResponse> Execute();
    }
}