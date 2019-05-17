// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Azure.ServiceBus.Diagnostics;

    internal class ServiceBusDiagnosticSource
    {
        public const string DiagnosticListenerName = "Microsoft.Azure.ServiceBus";
        public const string BaseActivityName = "Microsoft.Azure.ServiceBus.";

        public const string ExceptionEventName = BaseActivityName + "Exception";
        public const string ProcessActivityName =  BaseActivityName + "Process";

        public const string ActivityIdPropertyName = "Diagnostic-Id";
        public const string CorrelationContextPropertyName = "Correlation-Context";
        public const string RelatedToTag = "RelatedTo";
        public const string MessageIdTag = "MessageId";
        public const string SessionIdTag = "SessionId";

        private static readonly DiagnosticListener DiagnosticListener = new DiagnosticListener(DiagnosticListenerName);
        private readonly string entityPath;
        private readonly Uri endpoint;

        public ServiceBusDiagnosticSource(string entityPath, Uri endpoint)
        {
            this.entityPath = entityPath;
            this.endpoint = endpoint;
        }

        public static bool IsEnabled()
        {
            return DiagnosticListener.IsEnabled();
        }


        #region Send

        internal Activity SendStart(IList<Message> messageList)
        {
            Activity activity = Start("Send", () => new
                {
                    Messages = messageList,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, messageList)
            );

            Inject(messageList);

            return activity;
        }

        internal void SendStop(Activity activity, IList<Message> messageList, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Messages = messageList,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region Process

        internal Activity ProcessStart(Message message)
        {
            return ProcessStart("Process", message, () => new
                {
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));
        }

        internal void ProcessStop(Activity activity, Message message, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region ProcessSession

        internal Activity ProcessSessionStart(IMessageSession session, Message message)
        {
            return ProcessStart("ProcessSession", message, () => new
                {
                    Session = session,
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));
        }

        internal void ProcessSessionStop(Activity activity, IMessageSession session, Message message, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Session = session,
                    Message = message,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region Schedule

        internal Activity ScheduleStart(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            Activity activity = Start("Schedule", () => new
                {
                    Message = message,
                    ScheduleEnqueueTimeUtc = scheduleEnqueueTimeUtc,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetTags(a, message));

            Inject(message);

            return activity;
        }

        internal void ScheduleStop(Activity activity, Message message, DateTimeOffset scheduleEnqueueTimeUtc, TaskStatus? status, long sequenceNumber)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Message = message,
                    ScheduleEnqueueTimeUtc = scheduleEnqueueTimeUtc,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    SequenceNumber = sequenceNumber,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region Cancel

        internal Activity CancelStart(long sequenceNumber)
        {
            return Start("Cancel", () => new
            {
                SequenceNumber = sequenceNumber,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void CancelStop(Activity activity, long sequenceNumber, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    SequenceNumber = sequenceNumber,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region Receive

        internal Activity ReceiveStart(int messageCount)
        {
            return Start("Receive", () => new
            {
                RequestedMessageCount = messageCount,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void ReceiveStop(Activity activity, int messageCount, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                SetRelatedOperations(activity, messageList);
                SetTags(activity, messageList);
                DiagnosticListener.StopActivity(activity, new
                {
                    RequestedMessageCount = messageCount,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted,
                    Messages = messageList
                });
            }
        }

        #endregion


        #region Peek

        internal Activity PeekStart(long fromSequenceNumber, int messageCount)
        {
            return Start("Peek", () => new
            {
                FromSequenceNumber = fromSequenceNumber,
                RequestedMessageCount = messageCount,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void PeekStop(Activity activity, long fromSequenceNumber, int messageCount, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                SetRelatedOperations(activity, messageList);
                SetTags(activity, messageList);

                DiagnosticListener.StopActivity(activity, new
                {
                    FromSequenceNumber = fromSequenceNumber,
                    RequestedMessageCount = messageCount,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted,
                    Messages = messageList
                });
            }
        }

        #endregion


        #region ReceiveDeferred

        internal Activity ReceiveDeferredStart(IEnumerable<long> sequenceNumbers)
        {
            return Start("ReceiveDeferred", () => new
            {
                SequenceNumbers = sequenceNumbers,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void ReceiveDeferredStop(Activity activity, IEnumerable<long> sequenceNumbers, TaskStatus? status, IList<Message> messageList)
        {
            if (activity != null)
            {
                SetRelatedOperations(activity, messageList);
                SetTags(activity, messageList);

                DiagnosticListener.StopActivity(activity, new
                {
                    SequenceNumbers = sequenceNumbers,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Messages = messageList,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region  Complete

        internal Activity CompleteStart(IList<string> lockTokens)
        {
            return Start("Complete", () => new
            {
                LockTokens = lockTokens,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void CompleteStop(Activity activity, IList<string> lockTokens, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    LockTokens = lockTokens,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region Dispose

        internal Activity DisposeStart(string operationName, string lockToken)
        {
            return Start(operationName, () => new
            {
                LockToken = lockToken,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void DisposeStop(Activity activity, string lockToken, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    LockToken = lockToken,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion

 
        #region RenewLock

        internal Activity RenewLockStart(string lockToken)
        {
            return Start("RenewLock", () => new
            {
                LockToken = lockToken,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void RenewLockStop(Activity activity, string lockToken, TaskStatus? status, DateTime lockedUntilUtc)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    LockToken = lockToken,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted,
                    LockedUntilUtc = lockedUntilUtc
                });
            }
        }

        #endregion


        #region AddRule

        internal Activity AddRuleStart(RuleDescription description)
        {
            return Start("AddRule", () => new
            {
                Rule = description,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void AddRuleStop(Activity activity, RuleDescription description, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Rule = description,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region RemoveRule

        internal Activity RemoveRuleStart(string ruleName)
        {
            return Start("RemoveRule", () => new
            {
                RuleName = ruleName,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void RemoveRuleStop(Activity activity, string ruleName, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    RuleName = ruleName,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region GetRules

        internal Activity GetRulesStart()
        {
            return Start("GetRules", () => new
            {
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            null);
        }

        internal void GetRulesStop(Activity activity, IEnumerable<RuleDescription> rules, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    Rules = rules,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region AcceptMessageSession

        internal Activity AcceptMessageSessionStart(string sessionId)
        {
            return Start("AcceptMessageSession", () => new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId)
            );
        }

        internal void AcceptMessageSessionStop(Activity activity, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region GetSessionStateAsync

        internal Activity GetSessionStateStart(string sessionId)
        {
            return Start("GetSessionState", () => new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId));
        }

        internal void GetSessionStateStop(Activity activity, string sessionId, byte[] state, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted,
                    State = state
                });
            }
        }

        #endregion


        #region SetSessionState

        internal Activity SetSessionStateStart(string sessionId, byte[] state)
        {
            return Start("SetSessionState", () => new
                {
                    State = state,
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint
                },
                a => SetSessionTag(a, sessionId));
        }

        internal void SetSessionStateStop(Activity activity, byte[] state, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    State = state,
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion


        #region RenewSessionLock

        internal Activity RenewSessionLockStart(string sessionId)
        {
            return Start("RenewSessionLock", () => new
            {
                SessionId = sessionId,
                Entity = this.entityPath,
                Endpoint = this.endpoint
            },
            a => SetSessionTag(a, sessionId));
        }

        internal void RenewSessionLockStop(Activity activity, string sessionId, TaskStatus? status)
        {
            if (activity != null)
            {
                DiagnosticListener.StopActivity(activity, new
                {
                    SessionId = sessionId,
                    Entity = this.entityPath,
                    Endpoint = this.endpoint,
                    Status = status ?? TaskStatus.Faulted
                });
            }
        }

        #endregion

        internal void ReportException(Exception ex)
        {
            if (DiagnosticListener.IsEnabled(ExceptionEventName))
            {
                DiagnosticListener.Write(ExceptionEventName,
                    new
                    {
                        Exception = ex,
                        Entity = this.entityPath,
                        Endpoint = this.endpoint
                    });
            }
        }

        private Activity Start(string operationName, Func<object> getPayload, Action<Activity> setTags)
        {
            Activity activity = null;
            string activityName = BaseActivityName + operationName;
            if (DiagnosticListener.IsEnabled(activityName, this.entityPath))
            {
                activity = new Activity(activityName);
                setTags?.Invoke(activity);

                if (DiagnosticListener.IsEnabled(activityName + ".Start"))
                {
                    DiagnosticListener.StartActivity(activity, getPayload());
                }
                else
                {
                    activity.Start();
                }
            }

            return activity;
        }

        private void Inject(IList<Message> messageList)
        {
            var currentActivity = Activity.Current;
            if (currentActivity != null && messageList != null)
            {
                var correlationContext = SerializeCorrelationContext(currentActivity.Baggage.ToList());

                foreach (var message in messageList)
                {
                    Inject(message, currentActivity.Id, correlationContext);
                }
            }
        }

        private void Inject(Message message)
        {
            var currentActivity = Activity.Current;
            if (currentActivity != null)
            {
                Inject(message, currentActivity.Id, SerializeCorrelationContext(currentActivity.Baggage.ToList()));
            }
        }

        private void Inject(Message message, string id, string correlationContext)
        {
            if (message != null && !message.UserProperties.ContainsKey(ActivityIdPropertyName))
            {
                message.UserProperties[ActivityIdPropertyName] = id;
                if (correlationContext != null)
                {
                    message.UserProperties[CorrelationContextPropertyName] = correlationContext;
                }
            }
        }

        private string SerializeCorrelationContext(IList<KeyValuePair<string,string>> baggage)
        {
            if (baggage != null && baggage.Count > 0)
            {
                return string.Join(",", baggage.Select(kvp => kvp.Key + "=" + kvp.Value));
            }
            return null;
        }

        private void SetRelatedOperations(Activity activity, IList<Message> messageList)
        {
            if (messageList != null && messageList.Count > 0)
            {
                var relatedTo = new List<string>();
                foreach (var message in messageList)
                {
                    if (message.TryExtractId(out string id))
                    {
                        relatedTo.Add(id);
                    }
                }

                if (relatedTo.Count > 0)
                {
                    activity.AddTag(RelatedToTag, string.Join(",", relatedTo.Distinct()));
                }
            }
        }

        private Activity ProcessStart(string operationName, Message message, Func<object> getPayload, Action<Activity> setTags)
        {
            Activity activity = null;
            string activityName = BaseActivityName + operationName;

            if (message != null && DiagnosticListener.IsEnabled(activityName, entityPath))
            {
                var tmpActivity = message.ExtractActivity(activityName);
                setTags?.Invoke(tmpActivity);
                
                if (DiagnosticListener.IsEnabled(activityName, entityPath, tmpActivity))
                {
                    activity = tmpActivity;
                    if (DiagnosticListener.IsEnabled(activityName + ".Start"))
                    {
                        DiagnosticListener.StartActivity(activity, getPayload());
                    }
                    else
                    {
                        activity.Start();
                    }
                }
            }
            return activity;
        }

        private void SetTags(Activity activity, IList<Message> messageList)
        {
            if (messageList == null)
            {
                return;
            }

            var messageIds = messageList.Where(m => m.MessageId != null).Select(m => m.MessageId).ToArray();
            if (messageIds.Any())
            {
                activity.AddTag(MessageIdTag, string.Join(",", messageIds));
            }

            var sessionIds = messageList.Where(m => m.SessionId != null).Select(m => m.SessionId).Distinct().ToArray();
            if (sessionIds.Any())
            {
                activity.AddTag(SessionIdTag, string.Join(",", sessionIds));
            }
        }

        private void SetTags(Activity activity, Message message)
        {
            if (message == null)
            {
                return;
            }

            if (message.MessageId != null)
            {
                activity.AddTag(MessageIdTag, message.MessageId);
            }

            SetSessionTag(activity, message.SessionId);
        }

        private void SetSessionTag(Activity activity, string sessionId)
        {
            if (sessionId != null)
            {
                activity.AddTag(SessionIdTag, sessionId);
            }
        }
    }
}