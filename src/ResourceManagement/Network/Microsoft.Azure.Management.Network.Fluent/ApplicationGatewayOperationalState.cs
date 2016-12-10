using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayOperationalState
    {
        public static readonly ApplicationGatewayOperationalState STOPPED = new ApplicationGatewayOperationalState("Stopped");
        public static readonly ApplicationGatewayOperationalState STARTING = new ApplicationGatewayOperationalState("Starting");
        public static readonly ApplicationGatewayOperationalState RUNNING = new ApplicationGatewayOperationalState("Running");
        public static readonly ApplicationGatewayOperationalState STOPPING = new ApplicationGatewayOperationalState("Stopping");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(ApplicationGatewayOperationalState lhs, ApplicationGatewayOperationalState rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ApplicationGatewayOperationalState lhs, ApplicationGatewayOperationalState rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is ApplicationGatewayOperationalState))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            ApplicationGatewayOperationalState rhs = (ApplicationGatewayOperationalState)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        public override string ToString()
        {
            return this.value;
        }

        /// <summary>
        /// Creates ApplicationGatewayOperationalState.
        /// </summary>
        /// <param name="value">The value.</param>
        public ApplicationGatewayOperationalState(string value)
        {
            this.value = value;
        }
    }
}
