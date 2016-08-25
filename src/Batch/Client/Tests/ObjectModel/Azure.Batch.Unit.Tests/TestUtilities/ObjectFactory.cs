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

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ObjectFactory
    {
        private readonly Random random;
        private readonly IList<ObjectFactoryConstructionSpecification> typeConstructionSpecifications;

        private static readonly double DateTimeDeltaTicks = DateTime.MaxValue.Ticks - DateTime.MinValue.Ticks;
        private static readonly double TimeSpanDeltaTicks = TimeSpan.MaxValue.Ticks - TimeSpan.MinValue.Ticks;

        public ObjectFactory(IList<ObjectFactoryConstructionSpecification> typeConstructionSpecifications = null)
        {
            this.random = new Random();
            this.typeConstructionSpecifications = typeConstructionSpecifications ?? new List<ObjectFactoryConstructionSpecification>();
        }

        public T GenerateNew<T>() where T : new()
        {
            return (T)this.GenerateNew(typeof (T));
        }

        public object GenerateNew(Type objectType)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type wrappedType = objectType.GetGenericArguments()[0];
                return this.GenerateNew(wrappedType);
            }
            else if (objectType.IsGenericType &&
                (objectType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                objectType.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                Type listType = typeof (List<>);
                Type wrappedType = objectType.GetGenericArguments()[0];
                Type genericListType = listType.MakeGenericType(wrappedType);

                IList genericList = (IList)Activator.CreateInstance(genericListType);

                //Add between 0 and 9 items to the list
                int itemsToAdd = this.random.Next(10);

                for (int i = 0; i < itemsToAdd; i++)
                {
                    object o = this.GenerateNew(wrappedType);
                    genericList.Add(o);
                }

                return genericList;
            }
            else if (objectType == typeof(DateTime))
            {
                double randTicks = this.random.NextDouble() * (DateTimeDeltaTicks) + DateTime.MinValue.Ticks;
                DateTime time = new DateTime((long)randTicks);

                return time;
            }
            else if (objectType == typeof(TimeSpan))
            {
                double randTicks = this.random.NextDouble() * (TimeSpanDeltaTicks) + TimeSpan.MinValue.Ticks;
                TimeSpan timeSpan = new TimeSpan((long)randTicks);

                return timeSpan;
            }
            else if (objectType.IsEnum)
            {
                Array enumValues = Enum.GetValues(objectType);
                int enumIndex = this.random.Next(enumValues.Length);

                return enumValues.GetValue(enumIndex);
            }
            else if (objectType == typeof(int))
            {
                return this.random.Next(int.MinValue, int.MaxValue);
            }
            else if (objectType == typeof(bool))
            {
                return this.RandomBool();
            }
            else if (objectType == typeof(long))
            {
                //Generate a negative or a positive number
                bool negative = this.RandomBool();

                long result;
                if (negative)
                {
                    result = (long)(this.random.NextDouble() * long.MinValue);
                }
                else
                {
                    result = (long)(this.random.NextDouble() * long.MaxValue);
                }
                return result;
            }
            else if (objectType == typeof(double))
            {
                //Generate a negative or a positive number
                bool negative = this.RandomBool();

                double result;
                if (negative)
                {
                    result = this.random.NextDouble() * double.MinValue;
                }
                else
                {
                    result = this.random.NextDouble() * double.MaxValue;
                }
                return result;
            }
            else if (objectType == typeof(string))
            {
                string result = Guid.NewGuid().ToString();
                return result;
            }
            else
            {
                //Complex type
                object o = this.CreateInstance(objectType);

                List<PropertyInfo> properties = objectType.GetProperties().Where(p => p.CanWrite).ToList();

                //Use reflection to set properties randomly
                IEnumerable<PropertyInfo> propertiesToSet = this.RandomSubset(properties);
                foreach (PropertyInfo property in propertiesToSet)
                {
                    property.SetValue(o, this.GenerateNew(property.PropertyType));
                }

                return o;
            }
        }

        public T CreateInstance<T>(Type type)
        {
            return (T)this.CreateInstance(type);
        }

        public object CreateInstance(Type type)
        {
            ObjectFactoryConstructionSpecification specification = this.GetCustomObjectConstructionSpecificationOrNull(type);

            if (specification != null)
            {
                return specification.Constructor();
            }
            else
            {
                IEnumerable<ConstructorInfo> constructorInfoCollection =
                    type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                ConstructorInfo constructorInfo = constructorInfoCollection.FirstOrDefault(constructor => !constructor.GetParameters().Any()) ??
                                                  constructorInfoCollection.First();

                //Create a collection of default values
                IEnumerable<Type> constructorTypes = constructorInfo.GetParameters().Select(info => info.ParameterType);
                IEnumerable<object> defaultArguments = constructorTypes.Select(this.GenerateNew);

                object objectUnderTest = constructorInfo.Invoke(defaultArguments.ToArray());

                return objectUnderTest;
            }
        }

        private bool RandomBool()
        {
            int randomInt = this.random.Next(2);
            return randomInt != 0;
        }

        private ObjectFactoryConstructionSpecification GetCustomObjectConstructionSpecificationOrNull(Type t)
        {
            ObjectFactoryConstructionSpecification typeConstructionSpecification =
                this.typeConstructionSpecifications.FirstOrDefault(spec => spec.Type.Equals(t));

            return typeConstructionSpecification;
        }

        private IEnumerable<T> RandomSubset<T>(List<T> properties)
        {
            List<T> result = new List<T>();
            List<T> unpickedItems = new List<T>(properties);

            int itemsCountToPick = this.random.Next(properties.Count + 1);

            for (int i = 0; i < itemsCountToPick; i++)
            {
                int propIndex = this.random.Next(unpickedItems.Count);
                T propertyToSet = unpickedItems[propIndex];

                unpickedItems.RemoveAt(propIndex);

                result.Add(propertyToSet);
            }

            return result;
        }
    }
}
