// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using BatchTestCommon;
    using Microsoft.Azure.Batch.Common;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public class EnumUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public EnumUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestHandcodedEnumsMatchSwaggerGeneratedEnums()
        {
            TypeInfo arbitraryHandcraftedEnum = typeof(JobState).GetTypeInfo();
            string handcraftedEnumNamespace = arbitraryHandcraftedEnum.Namespace;

            //Gather all handcoded enumerations
            List<Type> enumTypes = arbitraryHandcraftedEnum.Assembly.GetTypes().Where(t => t.GetTypeInfo().IsEnum && t.Namespace == handcraftedEnumNamespace).ToList();

            //Gather all codegenerated enums
            TypeInfo arbitraryGeneratedEnum = typeof(Protocol.Models.JobState).GetTypeInfo();
            string generatedEnumNamespace = arbitraryGeneratedEnum.Namespace;
            List<Type> generatedEnumTypes = arbitraryGeneratedEnum.Assembly.GetTypes().Where(t => t.GetTypeInfo().IsEnum && t.Namespace == generatedEnumNamespace).ToList();

            this.testOutputHelper.WriteLine("Generated types: ");
            foreach (Type generatedEnumType in generatedEnumTypes)
            {
                this.testOutputHelper.WriteLine(generatedEnumType.ToString());
            }

            this.testOutputHelper.WriteLine("");

            this.testOutputHelper.WriteLine("Handcrafted types: ");
            foreach (Type enumType in enumTypes)
            {
                this.testOutputHelper.WriteLine(enumType.ToString());
            }

            //First assert we have the same collection content
            Assert.Equal(enumTypes.Count, generatedEnumTypes.Count);
            IEnumerable<Type> enumsThatDontMatch = enumTypes.Where(
                handcraftedEnum => generatedEnumTypes.FirstOrDefault(generatedEnum => this.DoEnumTypeMatch(generatedEnum, handcraftedEnum)) == null);
            Assert.Empty(enumsThatDontMatch);

            //Now assert that the content of each enum is the same
            foreach (Type generatedEnumType in generatedEnumTypes)
            {
                Type handcraftedEnumType = enumTypes.First(t => this.DoEnumTypeMatch(generatedEnumType, t));
                
                //Some of the enum cases don't match, which is okay, so we toLower them all
                IEnumerable<string> generatedEnumNames = Enum.GetNames(generatedEnumType).Select(s => s.ToLower());
                IEnumerable<string> handcraftedEnumNames = Enum.GetNames(handcraftedEnumType).Select(s => s.ToLower());

                // Flags enums are a bit special so we have to have a special case for them
                if (handcraftedEnumType.Name == nameof(CertificateVisibility) || handcraftedEnumType.Name == nameof(AccessScope))
                {
                    handcraftedEnumNames = handcraftedEnumNames.Where(item => item != "none");
                }

                Assert.Equal(generatedEnumNames, handcraftedEnumNames);
            }
        }

        private bool DoEnumTypeMatch(Type generatedType, Type handcraftedType)
        {
            return generatedType.Name == handcraftedType.Name ||
                   generatedType.Name == "CertificateStoreLocation" && handcraftedType.Name == "CertStoreLocation" || 
                   generatedType.Name == "TaskAddStatus" && handcraftedType.Name == "AddTaskStatus";
        }
    }
}
