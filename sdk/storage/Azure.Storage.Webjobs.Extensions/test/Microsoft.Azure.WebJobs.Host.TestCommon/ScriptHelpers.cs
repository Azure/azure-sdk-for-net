// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    // Helpers for testing some Script Scenarios 
    public static class ScriptHelpers
    {
        public static async Task<bool> CanBindAsync(IBindingProvider provider, Attribute attribute, Type t)
        {
            ParameterInfo parameterInfo = new FakeParameterInfo(
                t,
                new FakeMemberInfo(),
                attribute,
                null);

            BindingProviderContext bindingProviderContext = new BindingProviderContext(
                parameterInfo, bindingDataContract: null, cancellationToken: CancellationToken.None);

            try
            {
                var binding = await provider.TryCreateAsync(bindingProviderContext);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // A non-reflection based implementation
        class FakeParameterInfo : ParameterInfo
        {
            private readonly Collection<Attribute> _attributes = new Collection<Attribute>();

            public FakeParameterInfo(Type parameterType, MemberInfo memberInfo, Attribute attribute, Attribute[] additionalAttributes)
            {
                ClassImpl = parameterType;
                AttrsImpl = ParameterAttributes.In;
                NameImpl = "?";
                MemberImpl = memberInfo;

                // union all the parameter attributes
                _attributes.Add(attribute);
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                return _attributes.Where(p => p.GetType() == attributeType).ToArray();
            }
        } // end class FakeParameterInfo


        // Reflection requires the Parameter's member property is mocked out. 
        class FakeMemberInfo : MemberInfo
        {
            public override Type DeclaringType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override MemberTypes MemberType
            {
                get
                {
                    return MemberTypes.All;
                }
            }

            public override string Name
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override Type ReflectedType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override object[] GetCustomAttributes(bool inherit)
            {
                throw new NotImplementedException();
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }

            public override bool IsDefined(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }
        }
    }
}