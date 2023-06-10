# SecurityQuestionsApp

The Security Questions Application is a console-based application that allows users to store and answer security questions. It provides a simple flow where users can provide their name, store answers to security questions, and subsequently answer those questions to verify their identity.

<h2>Design Intent</h2>
The intent of the application is to provide a secure and user-friendly way for individuals to store and retrieve their security question answers. The application aims to achieve the following goals:

<h3>Data Persistence:</h3>
The application stores the user's information, security questions, and corresponding answers in a SQL Server LocalDB database. It utilizes Entity Framework Core to handle database operations and facilitate data persistence.

<h3>Code Organization:</h3>
The application follows a modular design, separating concerns into individual classes. It adheres to principles such as SOLID and separation of concerns to ensure maintainability, testability, and code readability.

<3>User Interaction:</h3> The application provides a user-friendly console interface to interact with the users. It prompts for user input, displays messages, and guides users through the process of storing and answering security questions.

<h2>Design Choices</h2>
Dependency Injection: The application utilizes Dependency Injection (DI) to inject dependencies, such as the database context, input reader, and output writer, into the classes that require them. This promotes loose coupling, testability, and maintainability of the codebase.

<h3>Entity Framework Core And Code First:</h3> Entity Framework Core is chosen as the ORM (Object-Relational Mapping) tool to interact with the database. It provides a convenient way to perform database operations and simplifies the data access layer.

<h3>Separation of Concerns:</h3>
The application separates concerns into individual classes, following the Single Responsibility Principle. This ensures that each class has a clear and focused purpose, making the code easier to understand, test, and maintain.

<h2>Getting Started</h2>
<p>To run ...</p>
<ul>
<li>Clone it.</li>
  <liOpen it in Visual Studio.</li>
  <li>NuGet package restore.</li>
  <li>Run the  Code First migrations and update-database to set up sql server using localdb and to seed it with questions data.</li>
  <li>Set up the SQL Server LocalDB database using Code First migration.</li>
  <li>Build, compile, run.</li>
  <li>Have fun!</li>
  </ul>
