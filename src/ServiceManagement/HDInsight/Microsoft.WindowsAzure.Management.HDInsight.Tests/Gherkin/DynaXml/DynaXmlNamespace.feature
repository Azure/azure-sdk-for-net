Feature: DynaXmlNamespace
	In order to easily use XPath expressions
	As a developer
	I want to be able to manipulate prefixes and namespaces easily

@mytag
Scenario: It should accept documents with no namespaces.
	Given I have the xml content with:
	""" 
		<Root /> 
	"""
	When I generate the namespace table
	Then the namespace table should have 1 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should have 1 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"

Scenario: It should map the defualt namespace when there is only one namespace
	Given I have the xml content with:
	"""
		<Root xmlns="default" />
	"""
	When I generate the namespace table
	Then the namespace table should have 2 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should match the prefix "def" to the namespace "default"
	 And the namespace table should have 2 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"
	 And the namespace table should match the uri "default" to the prefixes "def"

Scenario: It should allow the default namespace to be overriden
	Given I have the xml content with:
	"""
		<Root xmlns="default" >
			<Child xmlns="default1" />
		</Root>
	"""
	When I generate the namespace table
	Then the namespace table should have 3 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should match the prefix "def" to the namespace "default"
	 And the namespace table should match the prefix "def.1" to the namespace "default1"
	 And the namespace table should have 3 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"
	 And the namespace table should match the uri "default" to the prefixes "def"
	 And the namespace table should match the uri "default1" to the prefixes "def.1"

Scenario: Overriding a prefix with the same uri should not cause a conflict
	Given I have the xml content with:
	"""
		<Root xmlns="default" >
			<Child xmlns="default" />
		</Root>
	"""
	When I generate the namespace table
	Then the namespace table should have 2 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should match the prefix "def" to the namespace "default"
	 And the namespace table should have 2 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"
	 And the namespace table should match the uri "default" to the prefixes "def"

Scenario: Two prefixes with the same uri should still exist
	Given I have the xml content with:
	"""
		<Root xmlns="default" >
			<Child xmlns:a="default" />
		</Root>
	"""
	When I generate the namespace table
	Then the namespace table should have 3 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should match the prefix "def" to the namespace "default"
	 And the namespace table should match the prefix "a" to the namespace "default"
	 And the namespace table should have 2 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"
	 And the namespace table should match the uri "default" to the prefixes "def,a"

Scenario: Complex remapping situations should be handled
	Given I have the xml content with:
	"""
		<root xmlns="default" >
		  <a xmlns="default" />
		  <b xmlns:a="1" />
		  <c xmlns:a="2" >
			<c1 xmlns ="default3" />
			<c2 xmlns = "default2" />
			<c3 xmlns:c = "default" />
		  </c>
		  <d xmlns:a="3" />
		</root>
	"""
	When I generate the namespace table
	Then the namespace table should have 8 prefix matches defined
	 And the namespace table should match the prefix "empty" to the namespace ""
	 And the namespace table should match the prefix "def" to the namespace "default"
	 And the namespace table should match the prefix "a" to the namespace "1"
	 And the namespace table should match the prefix "a.1" to the namespace "2"
	 And the namespace table should match the prefix "def.1" to the namespace "default3"
	 And the namespace table should match the prefix "def.2" to the namespace "default2"
	 And the namespace table should match the prefix "c" to the namespace "default"
	 And the namespace table should match the prefix "a.2" to the namespace "3"
	 And the namespace table should have 7 namespace matches defined
	 And the namespace table should match the uri "" to the prefixes "empty"
	 And the namespace table should match the uri "default" to the prefixes "def,c"
	 And the namespace table should match the uri "1" to the prefixes "a"
	 And the namespace table should match the uri "2" to the prefixes "a.1"
	 And the namespace table should match the uri "default3" to the prefixes "def.1"
	 And the namespace table should match the uri "default2" to the prefixes "def.2"
	 And the namespace table should match the uri "3" to the prefixes "a.2"
