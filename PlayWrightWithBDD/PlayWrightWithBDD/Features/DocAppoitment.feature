Feature: DocAppoitment

A short summary of the feature

@tag1
Scenario: MakeAppoitment
	Given Open Url "https://katalon-demo-cura.herokuapp.com/"
	When Click Make Opitment
	Then Enter username "John Doe"
	And Enter Passowrd "ThisIsNotAPassword"
	Then Click Login Button
	When Loged In Checked Header "Make Appointment"
	Then Select Faculty
	And Check Apply
	And Select Radio button Medicare
	And Visit Date
	And Write Comment
	And Click Book Appoitement  

