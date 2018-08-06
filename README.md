# Super heroes/Villains

### The Problem
SPPA (Super-Powered People Association) wants to develop a new application to give them the opportunity of identifying which kind of Super-Powered person you are. According to this, we need to identify if a Super-Powered person is a Super-Hero or a Villain. 

As you can see this is a key process in our customer's business so our solution must be implemented with high accuracy.

These are the requirements:
-	All Super-Powered people will be listed in the Resources/RESGISTRADOS.DAT file.
-	We must divide the results in Super-Hero or Villain.
-	Villains are those Super-Powered people whose names contain a "D". But this requirement may vary in a low-end future.
-	Super-Heroes must be saved in a file called SuperHeroes.dat.
-	Villains must be saved in a file called Villains.dat.

Also, customer has asked to be able to query the results over the internet so they've asked for web service based on the result of the previous calculation to return the list of the Super-Powered People.

### The Rules
-	Implement a solution to solve the proposed problem.
-	The main point to be evaluated is the maintainability of the developed code. That means that if the code is handled by someone else, they are able to modify it in an easy way (clear and simple code); that if a modification should be done, it’s not necessary to modify all the classes / functions of the project (loosely coupled code) and there is a way to verify that the changes do not break the rest of the application (unit tests and / or integration test).
-	Following aspects will be evaluated aswell:
  -	Good practices:
    -	Naming – Good naming conventions.
    -	Clear and simple application flows. Low cyclomatic complexity.
    -	NULL and empty values handling.
    -	Application of SOLID, KISS and DRY principles.
  -	Instrumentalization: Exceptions handling, logging, etc.
  -	Modularity of the solution.
  -	Testing: unit tests and/or integration tests.
-	If a specific topic is not known by the candidate, a Readme.txt file should be added to the solution, specifying those unknown topics in order to ignore them when we are reviewing the proposed solution.
-	Any framework for Mocking, DI, Testing, Nuget libraries, etc can be used when deemed necessary.

### Developer's Problems and Assumptions:
1. It wasn't clear as to when the super powered people are divided would occur.
   - I called the codes in Startup class of the web service project. So each time the service is started, it will divide them.
2. Web service project is pretty straight forward.
   - So I didn't add unit tests for it, but added full integration tests.
3. *Also, customer has asked to be able to query the results over the internet so they've asked for web service based on the result of the previous calculation to return the list of the Super-Powered People.*
    - I assumed that the data to be served by the web service are each of the DAT files. Created 3 endpoints to serve each file:
	  - / - All super powered people are returned.
	  - /superhero - All super heroes are returned.
	  - /villain - All villains are returned
