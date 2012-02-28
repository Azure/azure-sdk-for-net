using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Rule's SQL filter action.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="SqlRuleAction")]
    public sealed class SqlRuleAction : IRuleAction
    {
        /// <summary>
        /// Action string,
        /// </summary>
        [DataMember(Order = 0, Name="SqlExpression")]
        public string Action { get; private set; }

        [DataMember(Order = 1)]
        public int CompatibilityLevel { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="action">Rule's SQL action string.</param>
        public SqlRuleAction(string action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            Action = action;
            CompatibilityLevel = Constants.CompatibilityLevel;
        }
    }
}
