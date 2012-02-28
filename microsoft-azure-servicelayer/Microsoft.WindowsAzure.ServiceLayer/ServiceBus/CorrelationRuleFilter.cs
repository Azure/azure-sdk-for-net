using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Correlation rule filter.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="CorrelationFilter")]
    public sealed class CorrelationRuleFilter : IRuleFilter
    {
        /// <summary>
        /// Correlation ID.
        /// </summary>
        [DataMember(Order = 0)]
        public string CorrelationId { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="correlationId">Correlation ID.</param>
        public CorrelationRuleFilter(string correlationId)
        {
            if (correlationId == null)
            {
                throw new ArgumentNullException("correlationId");
            }
            CorrelationId = correlationId;
        }
    }
}
