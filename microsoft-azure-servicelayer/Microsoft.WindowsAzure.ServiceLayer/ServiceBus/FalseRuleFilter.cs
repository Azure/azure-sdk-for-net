using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// False SQL rule filter.
    /// </summary>
    public sealed class FalseRuleFilter: IRuleFilter, ISqlRuleFilter
    {
        /// <summary>
        /// Gets rule's SQL expression.
        /// </summary>
        public string Expression { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expression">Rule's SQL expression.</param>
        public FalseRuleFilter(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            Expression = expression;
        }
    }
}
