using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Brokered message obtained from the service.
    /// </summary>
    public sealed class BrokeredMessageInfo
    {
        /// <summary>
        /// Gets the URI of the message.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the lock ID for locked messages.
        /// </summary>
        public string LockId { get; private set; }

        /// <summary>
        /// Gets the sequence number of the locked message.
        /// </summary>
        public int SequenceNumber { get; private set; }

        /// <summary>
        /// Gets the message text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Constructor. Initializes the object from the HTTP response.
        /// </summary>
        /// <param name="response">HTTP reponse with the data.</param>
        internal BrokeredMessageInfo(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            throw new NotImplementedException();
        }
    }
}
