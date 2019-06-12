// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Xunit;
    using Microsoft.Azure.Search.Tests.Infrastructure;

    public class GetAutocompleteTests : AutocompleteTests
    {
        [Fact]
        [LiveTest]
        public void CanAutocompleteStaticallyTypedDocuments()
        {
            Run(TestAutocompleteStaticallyTypedDocuments);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteThrowsWhenRequestIsMalformed()
        {
            Run(TestAutocompleteThrowsWhenRequestIsMalformed);           
        }

        [Fact]
        [LiveTest]
        public void CanAutcompleteThrowsWhenGivenBadSuggesterName()
        {
            Run(TestAutcompleteThrowsWhenGivenBadSuggesterName);            
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteFuzzyIsOffByDefault()
        {
            Run(TestAutocompleteFuzzyIsOffByDefault);            
        }
        
        [Fact]
        [LiveTest]
        public void CanAutocompleteOneTerm()
        {
            Run(TestAutocompleteOneTerm);           
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteDefaultsToOneTermMode()
        {
            Run(TestAutocompleteDefaultsToOneTermMode);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteTwoTerms()
        {
            Run(TestAutocompleteTwoTerms);                     
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteOneTermWithContext()
        {
            Run(TestAutocompleteOneTermWithContext);          
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteOneTermWithFuzzy()
        {
            Run(TestAutocompleteOneTermWithFuzzy);           
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteTwoTermsWithFuzzy()
        {
            Run(TestAutocompleteTwoTermsWithFuzzy);           
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteOneTermWithContextWithFuzzy()
        {
            Run(TestAutocompleteOneTermWithContextWithFuzzy);           
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteCanUseHitHighlighting()
        {
            Run(TestAutocompleteCanUseHitHighlighting);           
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteTopTrimsResults()
        {
            Run(TestAutocompleteTopTrimsResults);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteWithSelectedFields()
        {
            Run(TestAutocompleteWithSelectedFields);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteWithMultipleSelectedFields()
        {
            Run(TestAutocompleteWithMultipleSelectedFields);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteExcludesFieldsNotInSuggester()
        {
            Run(TestAutocompleteExcludesFieldsNotInSuggester);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteWithFilter()
        {
            Run(TestAutocompleteWithFilter);
        }

        [Fact]
        [LiveTest]
        public void CanAutocompleteWithFilterAndFuzzy()
        {
            Run(TestAutocompleteWithFilterAndFuzzy);
        }
    }
}
