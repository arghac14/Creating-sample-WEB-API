Feature: Genre Resource

Background: 
	Given I am a client

@GetGenres
Scenario: Get all Genres
	When I make GET Request 'api/genres'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Thriller"}]'

@GetGenreById
Scenario: Get Genre
	When I make GET Request 'api/genres/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Thriller"}'

Scenario: Add Genre
	When  I make POST request to 'api/genres' with data '{"Name":"Sci-Fi"}'
	Then response code must be '201'

Scenario: Update Genre
	When I make PUT Request 'api/genres/1' with data '{"Name":"Drama"}'
	Then response code must be '200'

Scenario: Delete Genre
	When I make Delete Request 'api/genres/1'
	Then response code must be '200'