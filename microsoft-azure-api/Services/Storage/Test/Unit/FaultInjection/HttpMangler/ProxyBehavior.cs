// -----------------------------------------------------------------------------------------
// <copyright file="ProxyBehavior.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------


namespace Microsoft.WindowsAzure.Test.Network
{
    using System;
    using Fiddler;

    /// <summary>
    /// The ProxyBehavior class controls how the HttpMangler processes the incoming and outgoing network data.
    /// </summary>
    public class ProxyBehavior
    {
        /// <summary>
        /// Holds the options for this behavior
        /// </summary>
        private readonly BehaviorOptions options;

        /// <summary>
        /// Holds the predicate controlling the conditions in which this behavior will fire or not.
        /// </summary>
        private readonly Func<Session, bool> behaviorSelectionPredicate;

        /// <summary>
        /// In conjunction with the behavior selection predicate above, controls when this behavior will fire.
        /// </summary>
        private readonly TriggerType type;

        /// <summary>
        /// Holds the action associated with this delegate, when the selector above returns true.
        /// </summary>
        private readonly Action<Session> onSessionSelected;

        /// <summary>
        /// Initializes a new instance of the ProxyBehavior class.
        /// </summary>
        /// <param name="action">Gives the action to take when this behavior has been selected.</param>
        /// <param name="predicate">Controls in which conditions this behavior will fire. If null, this behavior will always be selected.</param>
        /// <param name="options">Governs how many sessions the behavior should be applied to, and whether there is a expiration time for the behavior.</param>
        /// <param name="type">In conjunction with the behavior selection predicate above, controls when this behavior will fire.</param>
        public ProxyBehavior(
            Action<Session> action, 
            Func<Session, bool> predicate = null,
            BehaviorOptions options = null, 
            TriggerType type = TriggerType.All)
        {
            this.onSessionSelected = action;
            this.behaviorSelectionPredicate = predicate ?? Selectors.Always();
            this.options = options ?? new BehaviorOptions();
            this.type = type;
        }

        /// <summary>
        /// Gets the predicate controlling the conditions in which this behavior will fire or not.
        /// </summary>
        public Func<Session, bool> Selector
        {
            get { return this.behaviorSelectionPredicate; }
        }

        /// <summary>
        /// Gets the options for this behavior, including how many sessions the behavior should be applied to, 
        /// and whether there is a expiration time for the behavior.
        /// </summary>
        public BehaviorOptions Options
        {
            get { return this.options; }
        }

        /// <summary>
        /// Gets the circumstances in which this selector is intended to fire.
        /// </summary>
        public TriggerType TriggerFlags
        {
            get { return this.type; }
        }

        /// <summary>
        /// Execute fires the behavior associated with this selector.
        /// </summary>
        /// <param name="relatedSession">The session on which the behavior will be acting.</param>
        public void Execute(Session relatedSession)
        {
            this.options.DecrementSessionCount();

            if (this.onSessionSelected != null)
            {
                this.onSessionSelected(relatedSession);
            }
        }
    }
}
