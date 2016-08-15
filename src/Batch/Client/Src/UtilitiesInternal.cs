// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
        internal static IList<Protocol.Models.CertificateVisibility?> CertificateVisibilityToList(Common.CertificateVisibility? value)
        {
            List<Protocol.Models.CertificateVisibility?> result = new List<Protocol.Models.CertificateVisibility?>();
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
        /// Parse enum values for type CertificateVisibility.
        /// </summary>
        /// <param name='value'>
        /// The value to parse.
        /// </param>
        /// <returns>
        /// The enum value.
        /// </returns>
        internal static Common.CertificateVisibility? ParseCertificateVisibility(IList<Protocol.Models.CertificateVisibility?> value)
        {
            if (value == null)
            {
                return null;
            }

            Common.CertificateVisibility flags = CertificateVisibility.None;

            foreach (Protocol.Models.CertificateVisibility? visibility in value)
            {
                Common.CertificateVisibility? convertedEnum = UtilitiesInternal.MapNullableEnum<Protocol.Models.CertificateVisibility, Common.CertificateVisibility>(visibility);

                if (convertedEnum.HasValue)
                {
                    flags |= convertedEnum.Value;
                }
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

        private static TList ConvertCollection<TIn, TOut, TList>(
            IEnumerable<TIn> items,
            Func<TIn, TOut> objectCreationFunc,
            Func<TList> listCreationFunc) 
            where TList : class, IList<TOut> 
            where TIn : class 
            where TOut : class
        {
            if (null == items)
            {
                return null;
            }

            TList result = listCreationFunc();

            foreach (TIn protocolItem in items)
            {
                TOut omObject;
                if (protocolItem == null)
                {
                    omObject = null;
                }
                else
                {
                    omObject = objectCreationFunc(protocolItem);
                }
                
                result.Add(omObject);
            }

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
                () => new List<TOut>());

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
                () => new ConcurrentChangeTrackedModifiableList<TOut>());

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
    }

}
