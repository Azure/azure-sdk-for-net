using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Models
{
    public class EventsResults<T> : EventsResults where T : EventsResultData
    {
        /// <summary>
        /// Typed version of parent's Value.
        /// </summary>
        public new IList<T> Value
        {
            get { return (IList<T>) base.Value; }
            internal set { base.Value = (IList<EventsResultData>)value; }
        }
    }
}
