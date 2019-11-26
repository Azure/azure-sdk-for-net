// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Xunit;

    public class GetAutocompleteTests : AutocompleteTests
    {
        [Fact]
        public void CanAutocompleteStaticallyTypedDocuments()
        {
            Run(TestAutocompleteStaticallyTypedDocuments);
        }

        [Fact]
        public void CanAutocompleteThrowsWhenRequestIsMalformed()
        {
            Run(TestAutocompleteThrowsWhenRequestIsMalformed);           
        }

        [Fact]
        public void CanAutcompleteThrowsWhenGivenBadSuggesterName()
        {
            Run(TestAutcompleteThrowsWhenGivenBadSuggesterName);            
        }

        [Fact]
        public void CanAutocompleteFuzzyIsOffByDefault()
        {
            Run(TestAutocompleteFuzzyIsOffByDefault);            
        }
        
        [Fact]
        public void CanAutocompleteOneTerm()
        {
            Run(TestAutocompleteOneTerm);           
        }

        [Fact]
        public void CanAutocompleteDefaultsToOneTermMode()
        {
            Run(TestAutocompleteDefaultsToOneTermMode);
        }

        [Fact]
        public void CanAutocompleteTwoTerms()
        {
            Run(TestAutocompleteTwoTerms);                     
        }

        [Fact]
        public void CanAutocompleteOneTermWithContext()
        {
            Run(TestAutocompleteOneTermWithContext);          
        }

        [Fact]
        public void CanAutocompleteOneTermWithFuzzy()
        {
            Run(TestAutocompleteOneTermWithFuzzy);           
        }

        [Fact]
        public void CanAutocompleteTwoTermsWithFuzzy()
        {
            Run(TestAutocompleteTwoTermsWithFuzzy);           
        }

        [Fact]
        public void CanAutocompleteOneTermWithContextWithFuzzy()
        {
            Run(TestAutocompleteOneTermWithContextWithFuzzy);           
        }

        [Fact]
        public void CanAutocompleteCanUseHitHighlighting()
        {
            Run(TestAutocompleteCanUseHitHighlighting);           
        }

        [Fact]
        public void CanAutocompleteTopTrimsResults()
        {
            Run(TestAutocompleteTopTrimsResults);
        }

        [Fact]
        public void CanAutocompleteWithSelectedFields()
        {
            Run(TestAutocompleteWithSelectedFields);
        }

        [Fact]
        public void CanAutocompleteWithMultipleSelectedFields()
        {
            Run(TestAutocompleteWithMultipleSelectedFields);
        }

        [Fact]
        public void CanAutocompleteExcludesFieldsNotInSuggester()
        {
            Run(TestAutocompleteExcludesFieldsNotInSuggester);
        }

        [Fact]
        public void CanAutocompleteWithFilter()
        {
            Run(TestAutocompleteWithFilter);
        }

        [Fact]
        public void CanAutocompleteWithFilterAndFuzzy()
        {
            Run(TestAutocompleteWithFilterAndFuzzy);
        }
    }
}
