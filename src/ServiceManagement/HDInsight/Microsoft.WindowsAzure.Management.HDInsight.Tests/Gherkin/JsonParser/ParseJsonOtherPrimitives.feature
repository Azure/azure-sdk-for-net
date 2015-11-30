@CheckIn
Feature: ParseJsonOtherPrimitives
	In order to read and write json data
	As a developer
	I want an easy to use Json parser

Scenario Outline: I can parse a Json Boolean
	Given I have the json content '<content>'
     When I parse the content as a json boolean
	 Then the parsed json item should not be an error
	  And the parsed json item should be a boolean
	  And the parsed json boolean should have a value of <content>
Examples:
| content |
| true    |
| false   |

Scenario Outline: Invalid Boolean Content yields an error
	Given I have the json content '<content>'
     When I parse the content as a json boolean
	 Then the parsed json item should be an error
Examples:
| content |
| b       |
| t       |
| f       |
| tb      |
| fb      |
| tr      |
| trb     |
| fa      |
| fab     |
| tru     |
| trub    |
| fal     |
| falb    |
| fals    |
| falsb   |

Scenario: I can parse a Json Null
	Given I have the json content 'null'
     When I parse the content as a json null
	 Then the parsed json item should not be an error
	  And the parsed json item should be a null

Scenario Outline: Invalid Null Content yields an error
	Given I have the json content '<content>'
     When I parse the content as a json null
	 Then the parsed json item should be an error
Examples:
| content |
| n       |
| nb      |
| nu      |
| nub     |
| nul     |
| nulb    |
