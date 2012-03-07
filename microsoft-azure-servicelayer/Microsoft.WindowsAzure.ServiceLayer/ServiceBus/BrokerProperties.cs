using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Properties of a brokered message.
    /// </summary>
    [DataContract]
    public sealed class BrokerProperties
    {
        [DataMember]
        public string CorrelationId { get; internal set; }

        [DataMember]
        public string SessionId { get; internal set; }

        [DataMember]
        public int? DeliveryCount { get; internal set; }

        [DataMember]
        public DateTime? LockedUntil { get; internal set; }

        [DataMember]
        public string LockToken { get; internal set; }

        [DataMember]
        public string MessageId { get; internal set; }

        [DataMember]
        public string Label { get; internal set; }

        [DataMember]
        public string ReplyTo { get; internal set; }

        [DataMember]
        public long? SequenceNumber { get; internal set; }

        [DataMember]
        public double? TimeToLive { get; internal set; }

        [DataMember]
        public string To { get; internal set; }

        [DataMember]
        public DateTime? ScheduledEnqueueTime { get; internal set; }

        [DataMember]
        public string ReplyToSessionId { get; internal set; }

        [DataMember]
        public string MessageLocation { get; internal set; }

        [DataMember]
        public string LockLocation { get; internal set; }

        internal BrokerProperties()
        {
        }

        /// <summary>
        /// Creates an object from JSon data.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        internal static BrokerProperties Deserialize(string jsonData)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(jsonData);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                BrokerProperties properties = serializer.ReadObject(stream) as BrokerProperties;
                return properties;
            }
        }
    }
}
