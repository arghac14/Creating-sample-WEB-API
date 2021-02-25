Feature: Actor Resource

@GetActors
Scenario: Get all actors
	Given I am a client
	When I make GET Request 'api/actors'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}]'

@GetActorById
Scenario: Get Actor
	Given I am a client
	When I make GET Request 'api/actors/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}'

@AddActor
Scenario: Add an Actor
Given I am a client
When  I make POST request to 'api/actors' with data '{"Name":"Robert Downey Jr","Gender":"M","Bio":"American Actor","DOB":"2000-01-01T00:00:00"}'
Then response code must be '201'

@UpdateActor
Scenario: Update an Actor
Given I am a client
When I make PUT Request 'api/actors/1' with data '{"name":"Robert Downey","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}'
Then response code must be '200'

@DeleteActor
Scenario: Delete an Actor
Given I am a client
When I make Delete Request 'api/actors/1'
Then response code must be '200'