using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Represents a no-op filter action.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect")]
    public sealed class EmptyRuleAction : IRuleAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EmptyRuleAction()
        {
            // Do nothing.
        }
    }
}
