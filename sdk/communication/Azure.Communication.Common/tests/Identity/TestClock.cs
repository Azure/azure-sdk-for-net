// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using IScheduledAction = Azure.Communication.ThreadSafeRefreshableAccessTokenCache.IScheduledAction;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// Test utility to manipulate time and timers. Pass the UtcNow and Schedule members to the code under test and
    /// call Tick to change the clock and excute any scheduled actions that are due.
    /// </summary>
    internal class TestClock
    {
        private readonly List<ScheduledAction> _scheduledActions = new List<ScheduledAction>();
        public IEnumerable<IScheduledAction> ScheduledActions => _scheduledActions.Where(x => !x.IsDisposed && !x.HasExecuted).Cast<IScheduledAction>();

        public IScheduledAction Schedule(Action action, TimeSpan period)
        {
            var scheduledAction = new ScheduledAction(action, UtcNow + period);
            _scheduledActions.Add(scheduledAction);
            return scheduledAction;
        }

        public DateTimeOffset UtcNow { get; private set; } = DateTimeOffset.FromUnixTimeMilliseconds(0);

        public void Tick(TimeSpan? timeSpan = null)
        {
            UtcNow += timeSpan ?? TimeSpan.FromSeconds(0);
            RunAllTriggeredActions();

            void RunAllTriggeredActions()
            {
                var actionsDueNow = _scheduledActions.Where(x => !x.HasExecuted && x.DueTime <= UtcNow).ToList();
                foreach (var scheduledAction in actionsDueNow)
                {
                    scheduledAction.Action();
                }
            }
        }

        private class ScheduledAction : IScheduledAction
        {
            public readonly DateTimeOffset DueTime;
            public readonly Action Action;
            public bool HasExecuted { get; private set; }
            public bool IsDisposed { get; private set; }

            public ScheduledAction(Action action, DateTimeOffset dueTime)
            {
                Action = () =>
                {
                    HasExecuted = true;
                    action();
                };
                DueTime = dueTime;
            }

            public void Dispose() => IsDisposed = true;
        }
    }
}
