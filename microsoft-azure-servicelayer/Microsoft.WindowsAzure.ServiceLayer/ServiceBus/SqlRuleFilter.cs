using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// SQL-based rule filter.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect")]
    public sealed class SqlRuleFilter: IRuleFilter, ISqlRuleFilter
    {
        /// <summary>
        /// SQL filter expression.
        /// </summary>
        [DataMember(Name="SqlExpression")]
        public string Expression { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expression">Filter's SQL expression.</param>
        public SqlRuleFilter(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            Expression = expression;
        }
    }
}
