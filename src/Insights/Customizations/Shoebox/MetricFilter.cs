using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The stucture of the Filter represents an expression in disjunctive-normal-form
    /// Each filter contain a set of subfilters (the conjunctions) with the total filter being the disjunction of them
    /// </summary>
    public class MetricFilter
    {
        private TimeSpan? timeGrain;
        private DateTime? startTime;
        private DateTime? endTime;
        private IEnumerable<string> names;

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public TimeSpan TimeGrain
        {
            get
            {
                if (this.timeGrain == null)
                {
                    throw new InvalidOperationException("TimeGrain is not set");
                }

                return this.timeGrain ?? default(TimeSpan);
            }

            set
            {
                if (this.timeGrain != null)
                {
                    throw new InvalidOperationException("TimeGrain is already set");
                }

                if (value < TimeSpan.Zero)
                {
                    throw new InvalidOperationException("TimeGrain must be a positive duration");
                }

                this.timeGrain = value;
            }
        }

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                if (this.startTime == null)
                {
                    throw new InvalidOperationException("StartTime is not set");
                }

                return this.startTime ?? default(DateTime);
            }

            set
            {
                if (this.startTime != null)
                {
                    throw new InvalidOperationException("StartTime is already set");
                }

                if (this.endTime != null && value > this.endTime)
                {
                    throw new InvalidOperationException("StartTime must come before EndTime");
                }

                this.startTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                if (this.endTime == null)
                {
                    throw new InvalidOperationException("EndTime is not set");
                }

                return this.endTime ?? default(DateTime);
            }

            set
            {
                if (this.endTime != null)
                {
                    throw new InvalidOperationException("EndTime is already set");
                }

                if (this.startTime != null && value < this.startTime)
                {
                    throw new InvalidOperationException("EndTime must come after StartTime");
                }

                this.endTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public IEnumerable<string> Names
        {
            get
            {
                return this.names;
            }

            set
            {
                if (this.names != null)
                {
                    throw new InvalidOperationException("Names is already set");
                }

                if (!(value == null || value.Any()))
                {
                    throw new InvalidOperationException("Names must be null or non-empty");
                }

                this.names = value;
            }
        }
    }
}
