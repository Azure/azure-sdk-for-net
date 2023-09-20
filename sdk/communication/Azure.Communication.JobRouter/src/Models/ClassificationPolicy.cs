// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ClassificationPolicy")]
    [CodeGenSuppress("ClassificationPolicy")]
    public partial class ClassificationPolicy
    {
        /// <summary> Initializes a new instance of ClassificationPolicy. </summary>
        internal ClassificationPolicy()
        {
            _queueSelectors = new ChangeTrackingList<QueueSelectorAttachment>();
            _workerSelectors = new ChangeTrackingList<WorkerSelectorAttachment>();
        }

        [CodeGenMember("QueueSelectors")]
        internal IList<QueueSelectorAttachment> _queueSelectors
        {
            get
            {
                return QueueSelectors != null && QueueSelectors.Any()
                    ? QueueSelectors.ToList()
                    : new ChangeTrackingList<QueueSelectorAttachment>();
            }
            set
            {
                QueueSelectors.AddRange(value);
            }
        }

        [CodeGenMember("WorkerSelectors")]
        internal IList<WorkerSelectorAttachment> _workerSelectors
        {
            get
            {
                return WorkerSelectors != null && WorkerSelectors.Any()
                    ? WorkerSelectors.ToList()
                    : new ChangeTrackingList<WorkerSelectorAttachment>();
            }
            set
            {
                WorkerSelectors.AddRange(value);
            }
        }

        /// <summary> The queue selectors to resolve a queue for a given job. </summary>
        public List<QueueSelectorAttachment> QueueSelectors { get; } = new List<QueueSelectorAttachment>();

        /// <summary> The worker label selectors to attach to a given job. </summary>
        public List<WorkerSelectorAttachment> WorkerSelectors { get; } = new List<WorkerSelectorAttachment>();

        /// <summary> (Optional) The name of the classification policy. </summary>
        public string Name { get; internal set; }

        /// <summary> The fallback queue to select if the queue selector doesn't find a match. </summary>
        public string FallbackQueueId { get; internal set; }
        /// <summary>
        /// A rule of one of the following types:
        ///
        /// StaticRule:  A rule providing static rules that always return the same result, regardless of input.
        /// DirectMapRule:  A rule that return the same labels as the input labels.
        /// ExpressionRule: A rule providing inline expression rules.
        /// AzureFunctionRule: A rule providing a binding to an HTTP Triggered Azure Function.
        /// WebhookRule: A rule providing a binding to a webserver following OAuth2.0 authentication protocol.
        /// Please note <see cref="RouterRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="FunctionRouterRule"/>, <see cref="DirectMapRouterRule"/>, <see cref="ExpressionRouterRule"/>, <see cref="StaticRouterRule"/> and <see cref="WebhookRouterRule"/>.
        /// </summary>
        public RouterRule PrioritizationRule { get; internal set; }
    }
}
