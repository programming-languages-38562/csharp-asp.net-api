C# + ASP.NET Core: A Simple RESTful API Guide

This guide is designed to help students learn the basics of building RESTful APIs using .NET 8 (LTS) and ASP.NET Core, while following a layered architecture.

🎯 Purpose of this Guide

- Introduce students to ASP.NET Core Web API and project setup using the .NET SDK.
- Teach the concept of layered architecture (Model, Service, Controller) while skipping the repository for now by using Collections/Dictionary as an in-memory database.
- Provide a hands-on exercise in creating, retrieving, updating, and deleting student records through simple GET, POST, PUT, and DELETE endpoints.
- Reinforce core OOP concepts such as encapsulation (in the model) and abstraction (in the service interface).
- Explain the purpose of attributes like [ApiController] and [Route] in ASP.NET Core.
- Practice API testing using Postman.

⚠️ Rules & Important Notes
❗ Failure to follow instructions will result in grade deductions.

- Always follow the layered architecture layout (Model → Service → Controller).
- Use .NET 8 LTS for this activity.
- Use HTTP port 9090 for consistency.
- Do not modify Program.cs unnecessarily—the controller will handle the endpoints.
- Ensure proper encapsulation in models and abstraction in service interfaces.

📝 Commit Message Guidelines

- When submitting your work, follow these commit message rules:
- feat: <message> → For new activities submission or adding new features
- chore: <message> → Cleanup or general chores
- fix: <message> → Fixes or debugging activities

Example:

feat: add Student model and service interface
chore: cleanup unused files
fix: update student retrieval logic

📝 Pull Request Title Guidelines

When creating a Pull Request (PR), use the following format:

activity-name [LASTNAME]

Example:
csharp-aspnet-api [AMPATIN]

This sets the expectations, rules, and workflow for students, similar to your Spring Boot guide but tailored for C# ASP.NET Core.
