using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Rule description.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "RuleDescription")]
    public sealed class RuleInfo
    {
        /// <summary>
        /// Name of the rule.
        /// </summary>
        [IgnoreDataMember]
        public string Name { get; private set; }

        /// <summary>
        /// URI of the rule.
        /// </summary>
        [IgnoreDataMember]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets rule's filter.
        /// </summary>
        [DataMember(Order = 0)]
        public IRuleFilter Filter { get; internal set; }

        /// <summary>
        /// Gets rule's action.
        /// </summary>
        [DataMember(Order = 1)]
        public IRuleAction Action { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal RuleInfo()
        {
        }

        /// <summary>
        /// Initializes deserialized item with the data from the atom feed item.
        /// </summary>
        /// <param name="item">Atom item</param>
        internal void Initialize(SyndicationItem item)
        {
            Name = item.Title.Text;
            Uri = new Uri(item.Id);
        }
    }
}
