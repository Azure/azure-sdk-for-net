// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using Common;
    using Utils;

    internal static class UtilitiesInternal
    {
        internal static TTo MapEnum<TFrom, TTo>(TFrom otherEnum)
            where TTo : struct
            where TFrom : struct
        {
            TTo result = (TTo)Enum.Parse(typeof(TTo), otherEnum.ToString(), ignoreCase: true);
            return result;
        }

        internal static TTo? MapNullableEnum<TFrom, TTo>(TFrom? otherEnum)
            where TTo : struct
            where TFrom : struct
        {
            if (otherEnum == null)
            {
                return null;
            }

            return UtilitiesInternal.MapEnum<TFrom, TTo>(otherEnum.Value);
        }

        /// <summary>
        /// Convert an enum of type CertificateVisibility to a List of Protocol.Models.CertificateVisibility.
        /// </summary>
        /// <param name='value'>
        /// The value to convert.
        /// </param>
        /// <returns>
        /// The enum value to convert into list format.
        /// </returns>
        internal static IList<Protocol.Models.CertificateVisibility> CertificateVisibilityToList(Common.CertificateVisibility? value)
        {
            List<Protocol.Models.CertificateVisibility> result = new List<Protocol.Models.CertificateVisibility>();
            if (value.HasValue)
            {
                IList<Common.CertificateVisibility> enumValues = new List<Common.CertificateVisibility>(
                    (Common.CertificateVisibility[])Enum.GetValues(typeof(Common.CertificateVisibility)));

                enumValues.Remove(Common.CertificateVisibility.None); //None is an artifact of the OM so skip it

                foreach (Common.CertificateVisibility enumValue in enumValues)
                {
                    if (value.Value.HasFlag(enumValue))
                    {
                        Protocol.Models.CertificateVisibility protoEnumValue = UtilitiesInternal.MapEnum<Common.CertificateVisibility, Protocol.Models.CertificateVisibility>(enumValue);
                        result.Add(protoEnumValue);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Convert an enum of type AccessScope to a List of Protocol.Models.AccessScope.
        /// </summary>
        /// <param name='value'>
        /// The value to convert.
        /// </param>
        /// <returns>
        /// The enum value to convert into list format.
        /// </returns>
        internal static IList<Protocol.Models.AccessScope> AccessScopeToList(Common.AccessScope value)
        {
            List<Protocol.Models.AccessScope> result = new List<Protocol.Models.AccessScope>();

            IList<Common.AccessScope> enumValues = new List<Common.AccessScope>((Common.AccessScope[])Enum.GetValues(typeof(Common.AccessScope)));

            enumValues.Remove(Common.AccessScope.None); //None is an artifact of the OM so skip it

            foreach (Common.AccessScope enumValue in enumValues)
            {
                if (value.HasFlag(enumValue))
                {
                    Protocol.Models.AccessScope protoEnumValue = UtilitiesInternal.MapEnum<Common.AccessScope, Protocol.Models.AccessScope>(enumValue);
                    result.Add(protoEnumValue);
                }
            }

            return result;
        }

        /// <summary>
        /// Parse enum values for type CertificateVisibility.
        /// </summary>
        /// <param name='value'>
        /// The value to parse.
        /// </param>
        /// <returns>
        /// The enum value.
        /// </returns>
        internal static Common.CertificateVisibility? ParseCertificateVisibility(IList<Protocol.Models.CertificateVisibility> value)
        {
            if (value == null)
            {
                return null;
            }

            Common.CertificateVisibility flags = CertificateVisibility.None;

            foreach (Protocol.Models.CertificateVisibility visibility in value)
            {
                Common.CertificateVisibility convertedEnum = UtilitiesInternal.MapEnum<Protocol.Models.CertificateVisibility, Common.CertificateVisibility>(visibility);

                flags |= convertedEnum;
            }

            return flags;
        }


        /// <summary>
        /// Parse enum values for type AccessScope.
        /// </summary>
        /// <param name='value'>
        /// The value to parse.
        /// </param>
        /// <returns>
        /// The enum value.
        /// </returns>
        internal static Common.AccessScope ParseAccessScope(IList<Protocol.Models.AccessScope> value)
        {
            if (value == null)
            {
                return Common.AccessScope.None;
            }

            Common.AccessScope flags = AccessScope.None;

            foreach (Protocol.Models.AccessScope visibility in value)
            {
                Common.AccessScope convertedEnum = UtilitiesInternal.MapEnum<Protocol.Models.AccessScope, Common.AccessScope>(visibility);
                
                flags |= convertedEnum;
            }

            return flags;
        }


        internal static void ThrowOnUnbound(BindingState bindingState)
        {
            if (BindingState.Unbound == bindingState)
            {
                throw OperationForbiddenOnUnboundObjects;
            }
        }
        
        internal static TWrappedItem CreateObjectWithNullCheck<TItem, TWrappedItem>(TItem item, Func<TItem, TWrappedItem> factory, Func<TWrappedItem> nullFactory = null)
            where TItem : class
            where TWrappedItem : class
        {
            if (item == null)
            {
                if (nullFactory != null)
                {
                    return nullFactory();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return factory(item);
            }
        }
        
        #region Collection conversions

        /// <summary>
        /// Converts a collection of object model items into a corresponding collection of transport layer items.
        /// If the <paramref name="items"/> collection is null, null is returned.
        /// </summary>
        /// <returns>
        /// A collection of type <typeparam name="T"/> generated by calling 
        /// <see cref="ITransportObjectProvider{T}.GetTransportObject"/> on each element of the input collection.
        /// </returns>
        internal static IList<T> ConvertToProtocolCollection<T>(IEnumerable<ITransportObjectProvider<T>> items)
        {
            if (null == items)
            {
                return null;
            }

            List<T> protocolItems = new List<T>();

            foreach (ITransportObjectProvider<T> item in items)
            {
                T protocolItem = item.GetTransportObject();

                // add the protocol object to the return collection
                protocolItems.Add(protocolItem);
            }

            return protocolItems;
        }

        /// <summary>
        /// Converts a collection of object model items into a corresponding array of transport layer items.
        /// If the <paramref name="items"/> collection is null, null is returned.
        /// </summary>
        /// <returns>
        /// A collection of type <typeparam name="T"/> generated by calling 
        /// <see cref="ITransportObjectProvider{T}.GetTransportObject"/> on each element of the input collection.
        /// </returns>
        internal static T[] ConvertToProtocolArray<T>(IEnumerable<ITransportObjectProvider<T>> items)
        {
            IEnumerable<T> protocolCollection = ConvertToProtocolCollection(items);

            if (protocolCollection != null)
            {
                return protocolCollection.ToArray();
            }
            else
            {
                return null;
            }
        }

        internal static IList<TTo> ConvertEnumCollection<TFrom, TTo>(IEnumerable<TFrom> items)
            where TFrom : struct
            where TTo : struct
        {
            return items?.Select(MapEnum<TFrom, TTo>).ToList();
        }

        internal static IList<TTo?> ConvertEnumCollection<TFrom, TTo>(IEnumerable<TFrom?> items)
            where TFrom : struct
            where TTo : struct
        {
            return items?.Select(MapNullableEnum<TFrom, TTo>).ToList();
        }

        private static TList ConvertCollection<TIn, TOut, TList>(
            IEnumerable<TIn> items,
            Func<TIn, TOut> objectCreationFunc,
            Func<IEnumerable<TOut>, TList> listCreationFunc) 
            where TList : class, IList<TOut> 
            where TIn : class 
            where TOut : class
        {
            if (null == items)
            {
                return null;
            }

            TList result = listCreationFunc(items.Select(item => item == null ? null : objectCreationFunc(item)));

            return result;
        }

        /// <summary>
        /// Applies the <paramref name="objectCreationFunc"/> to each item in <paramref name="items"/> and returns a non-threadsafe collection containing the results.
        /// </summary>
        /// <typeparam name="TIn">The type of the input collection.</typeparam>
        /// <typeparam name="TOut">The type of the output collection.</typeparam>
        /// <param name="items">The collection to convert.</param>
        /// <param name="objectCreationFunc">The function used to created each <typeparamref name="TOut"/> type object.</param>
        /// <returns>A non-threadsafe collection containing the results of the conversion, or null if <paramref name="items"/> was null.</returns>
        internal static List<TOut> CollectionToNonThreadSafeCollection<TIn, TOut>(
            IEnumerable<TIn> items,
            Func<TIn, TOut> objectCreationFunc)
            where TIn : class
            where TOut : class
        {
            List<TOut> result = UtilitiesInternal.ConvertCollection(
                items,
                objectCreationFunc,
                (convertedItemsEnumerable) => new List<TOut>(convertedItemsEnumerable));

            return result;
        }

        /// <summary>
        /// Applies the <paramref name="objectCreationFunc"/> to each item in <paramref name="items"/> and returns a non-threadsafe collection containing the results.
        /// </summary>
        /// <typeparam name="TIn">The type of the input collection.</typeparam>
        /// <typeparam name="TOut">The type of the output collection.</typeparam>
        /// <param name="items">The collection to convert.</param>
        /// <param name="objectCreationFunc">The function used to created each <typeparamref name="TOut"/> type object.</param>
        /// <returns>A non-threadsafe collection containing the results of the conversion, or null if <paramref name="items"/> was null.</returns>
        internal static IList<TOut> CollectionToThreadSafeCollection<TIn, TOut>(
            IEnumerable<TIn> items,
            Func<TIn, TOut> objectCreationFunc)
            where TIn : class
            where TOut : class
        {
            ConcurrentChangeTrackedList<TOut> result = UtilitiesInternal.ConvertCollection(
                items,
                objectCreationFunc,
                (convertedItemsEnumerable) => new ConcurrentChangeTrackedList<TOut>(convertedItemsEnumerable));

            return result;
        }

        /// <summary>
        /// Applies the <paramref name="objectCreationFunc"/> to each item in <paramref name="items"/> and returns a threadsafe collection containing the results.
        /// </summary>
        /// <typeparam name="TIn">The type of the input collection.</typeparam>
        /// <typeparam name="TOut">The type of the output collection.</typeparam>
        /// <param name="items">The collection to convert.</param>
        /// <param name="objectCreationFunc">The function used to created each <typeparamref name="TOut"/> type object.</param>
        /// <returns>A threadsafe collection containing the results of the conversion, or null if <paramref name="items"/> was null.</returns>
        internal static ConcurrentChangeTrackedModifiableList<TOut> CollectionToThreadSafeCollectionIModifiable<TIn, TOut>(
            IEnumerable<TIn> items,
            Func<TIn, TOut> objectCreationFunc)
            where TIn : class
            where TOut : class, IPropertyMetadata
        {
            ConcurrentChangeTrackedModifiableList<TOut> result = UtilitiesInternal.ConvertCollection(
                items,
                objectCreationFunc,
                (convertedItemsEnumerable) => new ConcurrentChangeTrackedModifiableList<TOut>(convertedItemsEnumerable));

            return result;
        }
        
        #endregion

        internal static Exception OperationForbiddenOnUnboundObjects
        {
            get
            {
                return new InvalidOperationException(BatchErrorMessages.OperationForbiddenOnUnboundObjects);
            }
        }

        internal static Exception OperationForbiddenOnBoundObjects
        {
            get
            {
                return new InvalidOperationException(BatchErrorMessages.OperationForbiddenOnBoundObjects);
            }
        }
        
        internal static Exception MonitorRequiresConsistentHierarchyChain
        {
            get
            {
                return new InvalidOperationException(BatchErrorMessages.MonitorInstancesMustHaveSameServerSideParent);
            }
        }

        internal static Exception IncorrectTypeReturned
        {
            get
            {
                return new InvalidOperationException(BatchErrorMessages.IncorrectTypeReturned);
            }
        }
        
        /// <summary>
        /// Reads entire Stream into a string.  When null encoding is provided, UTF8 is used.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        internal static string StreamToString(Stream s, Encoding encoding)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            //Avoid disposing of the underlying stream -- the streams lifetime is not owned by this method
            //and disposing the reader will dispose the underlying stream.
            
            //Note: detectEncodingFromByteOrderMarks default is true, and bufferSize default is 1024, we have to pass those here in order to
            //get access to the leaveOpen parameter.
            using (StreamReader reader = new StreamReader(s, encoding, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true))
            {
                string txt = reader.ReadToEnd();

                return txt;
            }
        }

        /// <summary>
        /// Enumerates an enumerable asyncronously if required.  If the enumerable is of type IPagedCollection(T) then 
        /// ToListAsync is called on it.  Otherwise the enumerable is returned as is. 
        /// </summary>
        internal static async Task<IEnumerable<T>> EnumerateIfNeededAsync<T>(IEnumerable<T> enumerable, CancellationToken cancellationToken)
        {
            IEnumerable<T> result;
            
            IPagedEnumerable<T> pagedEnumerable = enumerable as IPagedEnumerable<T>;
            
            if (pagedEnumerable != null)
            {
                result = await pagedEnumerable.ToListAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                result = enumerable;
            }

            return result;
        }

        internal static void WaitAndUnaggregateException(this Task task)
        {
            task.GetAwaiter().GetResult();
        }

        internal static T WaitAndUnaggregateException<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        internal static void WaitAndUnaggregateException(this Task task, IEnumerable<BatchClientBehavior> rootBehaviors, IEnumerable<BatchClientBehavior> additionalBehaviors)
        {
            BehaviorManager bhMgr = new BehaviorManager(rootBehaviors, additionalBehaviors);
            SynchronousMethodExceptionBehavior exceptionBehavior = bhMgr.GetBehaviors<SynchronousMethodExceptionBehavior>().LastOrDefault();
            if (exceptionBehavior != null)
            {
                exceptionBehavior.Wait(task);
            }
            else
            {
                task.WaitAndUnaggregateException();
            }
        }

        internal static T WaitAndUnaggregateException<T>(this Task<T> task, IEnumerable<BatchClientBehavior> rootBehaviors, IEnumerable<BatchClientBehavior> additionalBehaviors)
        {
            BehaviorManager bhMgr = new BehaviorManager(rootBehaviors, additionalBehaviors);
            SynchronousMethodExceptionBehavior exceptionBehavior = bhMgr.GetBehaviors<SynchronousMethodExceptionBehavior>().LastOrDefault();
            T result;
            if (exceptionBehavior != null)
            {
                exceptionBehavior.Wait(task);
                result = task.Result;
            }
            else
            {
                result = task.WaitAndUnaggregateException();
            }

            return result;
        }

        /// <summary>
        /// Gets the object if the property has been changed, otherwise returns null.
        /// </summary>
        /// <exception cref="InvalidOperationException">When the property was changed to null, since the patch REST verb does not support that today in Batch.</exception>
        internal static T? GetIfChangedOrNull<T>(this PropertyAccessor<T?> property)
            where T : struct
        {
            if (property.HasBeenModified)
            {
                if (property.Value == null)
                {
                    throw new InvalidOperationException(BatchErrorMessages.CannotPatchNullValue);
                }
                return property.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the transport object if the property has been changed, otherwise returns null.
        /// </summary>
        /// <exception cref="InvalidOperationException">When the property was changed to null, since the patch REST verb does not support that today in Batch.</exception>
        internal static TProtocol GetTransportObjectIfChanged<TObjectModel, TProtocol>(this PropertyAccessor<TObjectModel> property)
            where TObjectModel : class, ITransportObjectProvider<TProtocol>
            where TProtocol : class
        {
            if (property.HasBeenModified)
            {
                if (property.Value == null)
                {
                    throw new InvalidOperationException(BatchErrorMessages.CannotPatchNullValue);
                }
                return CreateObjectWithNullCheck(property.Value, item => item.GetTransportObject());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the transport object if the property has been changed, otherwise returns null.
        /// </summary>
        /// <exception cref="InvalidOperationException">When the property was changed to null, since the patch REST verb does not support that today in Batch.</exception>
        internal static TProtocol[] GetTransportObjectIfChanged<TObjectModel, TProtocol>(this PropertyAccessor<IList<TObjectModel>> property)
            where TObjectModel : class, ITransportObjectProvider<TProtocol>
            where TProtocol : class
        {
            if (property.HasBeenModified)
            {
                if (property.Value == null)
                {
                    throw new InvalidOperationException(BatchErrorMessages.CannotPatchNullValue);
                }
                return ConvertToProtocolArray(property.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Begins asynchronous call to return the contents of the file as a string.
        /// </summary>
        /// <param name="copyStreamFunc">The stream copy function.</param>
        /// <param name="encoding">The encoding used to interpret the file data. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">The file byte range to retrieve. If null, the entire file is retrieved.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        internal static async Task<string> ReadNodeFileAsStringAsync(
            Func<Stream, GetFileRequestByteRange, IEnumerable<BatchClientBehavior>, CancellationToken, Task> copyStreamFunc,
            Encoding encoding,
            GetFileRequestByteRange byteRange,
            IEnumerable<BatchClientBehavior> additionalBehaviors,
            CancellationToken cancellationToken)
        {
            using (Stream streamToUse = new MemoryStream())
            {
                // get the data
                Task asyncTask = copyStreamFunc(streamToUse, byteRange, additionalBehaviors, cancellationToken);

                // wait for completion
                await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                streamToUse.Seek(0, SeekOrigin.Begin); //We just wrote to this stream, have to seek to the beginning
                // convert to string
                return StreamToString(streamToUse, encoding);
            }
        }
    }

}
