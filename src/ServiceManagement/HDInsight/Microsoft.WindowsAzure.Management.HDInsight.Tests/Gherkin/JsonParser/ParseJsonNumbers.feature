@CheckIn
Feature: ParseJsonNumbers
	In order to read and write json data
	As a developer
	I want an easy to use Json parser

Scenario Outline: Numeric Parser errors are cought by the parser
   Given I have the json content '<content>'
    When I parse the content as a json number
	Then the parsed json item should be an error
Examples:
| content  | Comment                                  |
| f        | No Number Start Sequence                 |
| -f       | No Decmial after neg sign                |
| -        | Nothing after neg sign                   |
| 0.ef     | No decimal after exp sign (e)            |
| 0.EF     | No decimal after exp sign (E)            |
| 0.e+F    | No decimal after exp pos                 |
| 0.e      | Nothing after exp sign after decimal (e) |
| 0E       | Nothing after exp sign (E)               |
| 0.e-f    | No decimal after exp neg sign            |
| 0.e+     | Nothing after exp pos sign               |
| 0.e-     | Nothing after exp neg sign               |
| 5.0e-345 | Excessive min exponent                   |
| 1.7e309  | Excessive max exponent                   |

Scenario Outline: Parseing stopes when a valid number is found and no continuation exists
   Given I have the json content '<content>'
    When I parse the content as a json number
	Then the parsed json item should not be an error
	 And the next character on the parser buffer is a 'f'
Examples:
| content |
| -0f     |
| 0f      |
| 0.0f    |
| 0.0e0f  |

Scenario Outline: I can parse a json number
	Given I have the json content '<content>'
	 When I parse the content as a json number
	 Then the parsed json item should not be an error
	  And the parsed json item should be an <type>
	  And the parsed json <type> should have a value of <content>
Examples: 
| content     | type    |
| 0           | integer |
| 1           | integer |
| 2           | integer |
| 3           | integer |
| 4           | integer |
| 5           | integer |
| 6           | integer |
| 7           | integer |
| 8           | integer |
| 9           | integer |
| 1.0         | float   |
| 1.09        | float   |
| 1.181       | float   |
| 1.272       | float   |
| 1.363       | float   |
| 1.454       | float   |
| 1.545       | float   |
| 1.636       | float   |
| 1.727       | float   |
| 1.818       | float   |
| 1.909       | float   |
| 0e0         | float   |
| 0E1         | float   |
| 0e2         | float   |
| 0E3         | float   |
| 0e4         | float   |
| 0E5         | float   |
| 0e6         | float   |
| 0E7         | float   |
| 0e8         | float   |
| 0E9         | float   |
| 1e09        | float   |
| 1E181       | float   |
| 1e308       | float   |
| 0e+0        | float   |
| 0E-1        | float   |
| 0e+2        | float   |
| 0E-3        | float   |
| 0e+4        | float   |
| 0E-5        | float   |
| 0e+6        | float   |
| 0E-7        | float   |
| 0e+8        | float   |
| 0E-9        | float   |
| 1e-09       | float   |
| 1E+18       | float   |
| 1E-181      | float   |
| 1e+272      | float   |
| 1E-324      | float   |
| 1e+308      | float   |
| 0.0e+0      | float   |
| 0.1E-1      | float   |
| 0.2e+2      | float   |
| 0.3E-3      | float   |
| 0.4e+4      | float   |
| 0.5E-5      | float   |
| 0.6e+6      | float   |
| 0.7E-7      | float   |
| 0.8e+8      | float   |
| 0.9E-9      | float   |
| 1.09e-09    | float   |
| 1.18E+18    | float   |
| 1.090e+090  | float   |
| 1.181E-181  | float   |
| 1.272e+272  | float   |
| 1.363E-324  | float   |
| 1.454e+308  | float   |
| 1.545E-324  | float   |
| 1.699e+308  | float   |
| 1.727E-324  | float   |
| 1.700e+308  | float   |
| 1.909E-324  | float   |
| -0          | integer |
| -1          | integer |
| -2          | integer |
| -3          | integer |
| -4          | integer |
| -5          | integer |
| -6          | integer |
| -7          | integer |
| -8          | integer |
| -9          | integer |
| -1.0        | float   |
| -1.1        | float   |
| -1.2        | float   |
| -1.3        | float   |
| -1.4        | float   |
| -1.5        | float   |
| -1.6        | float   |
| -1.7        | float   |
| -1.8        | float   |
| -1.9        | float   |
| -1.09       | float   |
| -1.18       | float   |
| -1.181      | float   |
| -1.272      | float   |
| -0e0        | float   |
| -0E1        | float   |
| -0e2        | float   |
| -0E3        | float   |
| -0e4        | float   |
| -0E5        | float   |
| -0e6        | float   |
| -0E7        | float   |
| -0e8        | float   |
| -0E9        | float   |
| -1E18       | float   |
| -1e090      | float   |
| -1E181      | float   |
| -1E307      | float   |
| -1e308      | float   |
| -0e+0       | float   |
| -0E-1       | float   |
| -0e+2       | float   |
| -0E-3       | float   |
| -0e+4       | float   |
| -0E-5       | float   |
| -0e+6       | float   |
| -0E-7       | float   |
| -0e+8       | float   |
| -0E-9       | float   |
| -1e-09      | float   |
| -1E+18      | float   |
| -1e-27      | float   |
| -1E+21      | float   |
| -1E-181     | float   |
| -1e+272     | float   |
| -1E-324     | float   |
| -1e+308     | float   |
| -0.0e+0     | float   |
| -0.1E-1     | float   |
| -0.2e+2     | float   |
| -0.3E-3     | float   |
| -0.4e+4     | float   |
| -0.5E-5     | float   |
| -0.6e+6     | float   |
| -0.7E-7     | float   |
| -0.8e+8     | float   |
| -0.9E-9     | float   |
| -1.09e-09   | float   |
| -1.18E+18   | float   |
| -1.27e-27   | float   |
| -1.36E+36   | float   |
| -1.090e+090 | float   |
| -1.181E-181 | float   |
| -1.272e+272 | float   |
| -1.363E-324 | float   |
| -1.454e+308 | float   |
| -1.545E-324 | float   |
| -1.699e+308 | float   |
| -1.727E-324 | float   |
| -1.700e+308 | float   |
| -1.909E-324 | float   |
