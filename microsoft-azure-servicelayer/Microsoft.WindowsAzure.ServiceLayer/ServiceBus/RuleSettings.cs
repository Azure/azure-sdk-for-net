using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Settings for creating subscription rules.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "RuleDescription")]
    public sealed class RuleSettings
    {
        /// <summary>
        /// Gets rule's filter.
        /// </summary>
        [DataMember(Order = 0)]
        public IRuleFilter Filter { get; private set; }

        /// <summary>
        /// Gets rule's action.
        /// </summary>
        [DataMember(Order = 1)]
        public IRuleAction Action { get; private set; }

        /// <summary>
        /// Constructor for a rule with an empty action.
        /// </summary>
        /// <param name="filter">Rule's filter.</param>
        public RuleSettings(IRuleFilter filter)
            : this(filter, new EmptyRuleAction())
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filter">Rule's filter.</param>
        /// <param name="action">Rule's action.</param>
        public RuleSettings(IRuleFilter filter, IRuleAction action)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            Filter = filter;
            Action = action;
        }
    }
}
