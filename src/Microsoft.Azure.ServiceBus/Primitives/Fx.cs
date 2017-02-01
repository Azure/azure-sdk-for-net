// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Diagnostics;

    static class Fx
    {
        static ExceptionUtility exceptionUtility;

        public static ExceptionUtility Exception
        {
            get
            {
                if (exceptionUtility == null)
                {
                    exceptionUtility = new ExceptionUtility();
                }

                return exceptionUtility;
            }
        }

        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }

        public static class Tag
        {
            public enum CacheAttrition
            {
                None,
                ElementOnTimer,

                // A finalizer/WeakReference based cache, where the elements are held by WeakReferences (or hold an
                // inner object by a WeakReference), and the weakly-referenced object has a finalizer which cleans the
                // item from the cache.
                ElementOnGC,

                // A cache that provides a per-element token, delegate, interface, or other piece of context that can
                // be used to remove the element (such as IDisposable).
                ElementOnCallback,

                FullPurgeOnTimer,
                FullPurgeOnEachAccess,
                PartialPurgeOnTimer,
                PartialPurgeOnEachAccess,
            }

            public enum Location
            {
                InProcess,
                OutOfProcess,
                LocalSystem,
                LocalOrRemoteSystem, // as in a file that might live on a share
                RemoteSystem,
            }

            public enum SynchronizationKind
            {
                LockStatement,
                MonitorWait,
                MonitorExplicit,
                InterlockedNoSpin,
                InterlockedWithSpin,

                // Same as LockStatement if the field type is object.
                FromFieldType,
            }

            [Flags]
            public enum BlocksUsing
            {
                MonitorEnter,
                MonitorWait,
                ManualResetEvent,
                AutoResetEvent,
                AsyncResult,
                IAsyncResult,
                PInvoke,
                InputQueue,
                ThreadNeutralSemaphore,
                PrivatePrimitive,
                OtherInternalPrimitive,
                OtherFrameworkPrimitive,
                OtherInterop,
                Other,

                NonBlocking, // For use by non-blocking SynchronizationPrimitives such as IOThreadScheduler
            }

            public static class Strings
            {
                internal const string ExternallyManaged = "externally managed";
                internal const string AppDomain = "AppDomain";
                internal const string DeclaringInstance = "instance of declaring class";
                internal const string Unbounded = "unbounded";
                internal const string Infinite = "infinite";
            }

            [AttributeUsage(
                AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Constructor,
                AllowMultiple = true,
                Inherited = false)]
            [Conditional("CODE_ANALYSIS")]
            public sealed class ExternalResourceAttribute : Attribute
            {
                readonly Location location;
                readonly string description;

                public ExternalResourceAttribute(Location location, string description)
                {
                    this.location = location;
                    this.description = description;
                }

                public Location Location
                {
                    get
                    {
                        return this.location;
                    }
                }

                public string Description
                {
                    get
                    {
                        return this.description;
                    }
                }
            }

            [AttributeUsage(AttributeTargets.Field)]
            [Conditional("CODE_ANALYSIS")]
            public sealed class CacheAttribute : Attribute
            {
                readonly Type elementType;
                readonly CacheAttrition cacheAttrition;

                public CacheAttribute(Type elementType, CacheAttrition cacheAttrition)
                {
                    this.Scope = Strings.DeclaringInstance;
                    this.SizeLimit = Strings.Unbounded;
                    this.Timeout = Strings.Infinite;

                    if (elementType == null)
                    {
                        throw Fx.Exception.ArgumentNull(nameof(elementType));
                    }

                    this.elementType = elementType;
                    this.cacheAttrition = cacheAttrition;
                }

                public Type ElementType
                {
                    get
                    {
                        return this.elementType;
                    }
                }

                public CacheAttrition CacheAttrition
                {
                    get
                    {
                        return this.cacheAttrition;
                    }
                }

                public string Scope { get; set; }

                public string SizeLimit { get; set; }

                public string Timeout { get; set; }
            }

            [AttributeUsage(AttributeTargets.Field)]
            [Conditional("CODE_ANALYSIS")]
            public sealed class QueueAttribute : Attribute
            {
                readonly Type elementType;

                public QueueAttribute(Type elementType)
                {
                    this.Scope = Strings.DeclaringInstance;
                    this.SizeLimit = Strings.Unbounded;

                    if (elementType == null)
                    {
                        throw Fx.Exception.ArgumentNull(nameof(elementType));
                    }

                    this.elementType = elementType;
                }

                public Type ElementType
                {
                    get
                    {
                        return this.elementType;
                    }
                }

                public string Scope { get; set; }

                public string SizeLimit { get; set; }

                public bool StaleElementsRemovedImmediately { get; set; }

                public bool EnqueueThrowsIfFull { get; set; }
            }

            // Set on a class when that class uses lock (this) - acts as though it were on a field
            //     object this;
            [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, Inherited = false)]
            [Conditional("CODE_ANALYSIS")]
            public sealed class SynchronizationObjectAttribute : Attribute
            {
                public SynchronizationObjectAttribute()
                {
                    this.Blocking = true;
                    this.Scope = Strings.DeclaringInstance;
                    this.Kind = SynchronizationKind.FromFieldType;
                }

                public bool Blocking { get; set; }

                public string Scope { get; set; }

                public SynchronizationKind Kind { get; set; }
            }

            [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
            [Conditional("CODE_ANALYSIS")]
            public sealed class SynchronizationPrimitiveAttribute : Attribute
            {
                readonly BlocksUsing blocksUsing;

                public SynchronizationPrimitiveAttribute(BlocksUsing blocksUsing)
                {
                    this.blocksUsing = blocksUsing;
                }

                public BlocksUsing BlocksUsing
                {
                    get
                    {
                        return this.blocksUsing;
                    }
                }

                public bool SupportsAsync { get; set; }

                public bool Spins { get; set; }

                public string ReleaseMethod { get; set; }

                [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public sealed class BlockingAttribute : Attribute
                {
                    public string CancelMethod { get; set; }

                    public Type CancelDeclaringType { get; set; }

                    public string Conditional { get; set; }
                }

                // Sometime a method will call a conditionally-blocking method in such a way that it is guaranteed
                // not to block (i.e. the condition can be Asserted false).  Such a method can be marked as
                // GuaranteeNonBlocking as an assertion that the method doesn't block despite calling a blocking method.
                //
                // Methods that don't call blocking methods and aren't marked as Blocking are assumed not to block, so
                // they do not require this attribute.
                [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public sealed class GuaranteeNonBlockingAttribute : Attribute
                {
                    public GuaranteeNonBlockingAttribute()
                    {
                    }
                }

                [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public sealed class NonThrowingAttribute : Attribute
                {
                    public NonThrowingAttribute()
                    {
                    }
                }

                [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true, Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public class ThrowsAttribute : Attribute
                {
                    readonly Type exceptionType;
                    readonly string diagnosis;

                    public ThrowsAttribute(Type exceptionType, string diagnosis)
                    {
                        if (exceptionType == null)
                        {
                            throw Fx.Exception.ArgumentNull(nameof(exceptionType));
                        }
                        if (string.IsNullOrEmpty(diagnosis))
                        {
                            ////throw Fx.Exception.ArgumentNullOrEmpty("diagnosis");
                            throw new ArgumentNullException(nameof(diagnosis));
                        }

                        this.exceptionType = exceptionType;
                        this.diagnosis = diagnosis;
                    }

                    public Type ExceptionType
                    {
                        get
                        {
                            return this.exceptionType;
                        }
                    }

                    public string Diagnosis
                    {
                        get
                        {
                            return this.diagnosis;
                        }
                    }
                }

                [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public sealed class InheritThrowsAttribute : Attribute
                {
                    public InheritThrowsAttribute()
                    {
                    }

                    public Type FromDeclaringType { get; set; }

                    public string From { get; set; }
                }

                [AttributeUsage(
                    AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class |
                    AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method |
                    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface |
                    AttributeTargets.Delegate, AllowMultiple = false,
                    Inherited = false)]
                [Conditional("CODE_ANALYSIS")]
                public sealed class SecurityNoteAttribute : Attribute
                {
                    public SecurityNoteAttribute()
                    {
                    }

                    public string Critical { get; set; }

                    public string Safe { get; set; }

                    public string Miscellaneous { get; set; }
                }
            }
        }
    }
}