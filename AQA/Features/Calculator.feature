Feature: Contact form negative tests

Scenario: Full name validation negative tests
	Given user opens application URL
	When user enters "Null" text into Full Name input
	And the user clicks on Agree checkbox
	And the user clicks on Send button
	Then Full Name input should contain "Поле обязательно для заполнения." text
	And Contact form should contain "Одно или несколько полей содержат ошибочные данные. Пожалуйста, проверьте их и попробуйте ещё раз." text

Scenario: Email validation - empty value
	Given user opens application URL
	When user enters "Null" text into Email input
	And the user clicks on Agree checkbox
	And the user clicks on Send button
	Then Contact form should contain "Одно или несколько полей содержат ошибочные данные. Пожалуйста, проверьте их и попробуйте ещё раз." text
	And Email input should contain "Поле обязательно для заполнения." text

Scenario: Email validation - invalid value
	Given user opens application URL
	When user enters "abcd" text into Email input
	And the user clicks on Agree checkbox
	And the user clicks on Agree checkbox
	And the user clicks on Send button
	Then Contact form should contain "Одно или несколько полей содержат ошибочные данные. Пожалуйста, проверьте их и попробуйте ещё раз." text
	And Email input should contain "Неверно введён электронный адрес." text

