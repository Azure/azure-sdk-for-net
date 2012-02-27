using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// SQL-based rule filter.
    /// </summary>
    public interface ISqlRuleFilter: IRuleFilter
    {
        /// <summary>
        /// Gets filter's SQL expression.
        /// </summary>
        string Expression { get; }
    }
}
