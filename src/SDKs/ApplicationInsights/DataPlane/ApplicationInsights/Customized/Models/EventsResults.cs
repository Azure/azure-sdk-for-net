using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public class EventsResults<T> : EventsResults where T : EventsResultData
    {
        /// <summary>
        /// Typed version of parent's Value.
        /// </summary>
        public new IList<T> Value
        {
            get { return base.Value.OfType<T>().ToList(); }
            internal set { base.Value = value.OfType<EventsResultData>().ToList(); }
        }
    }
}
