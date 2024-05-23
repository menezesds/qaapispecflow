Feature: To test the get request

A short summary of the feature

@tag1
Scenario: GET request testing
	Given the user sends a get request with url as "https://reqres.in/api/users/2"
	Then the request should be success and returnn status code 200
