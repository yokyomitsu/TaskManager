# Task Manager

A simple and extensible task management application built using .NET 8.0, designed with a clean architecture and developed as a Console Application using [Spectre.Console](https://spectreconsole.net/) for a rich command-line interface. This application supports basic task management functionalities such as adding, listing, deleting, and marking tasks as complete, with data persistence using a JSON file.

## Features

- **Add Task**: Add tasks with a title to the task list.
- **List Tasks**: View all tasks with their status (Incomplete/Complete).
- **Mark Task as Complete**: Mark a specific task as complete using its ID.
- **Delete Task**: Remove a task from the list by ID.
- **Data Persistence**: All tasks are stored in a JSON file, allowing the data to persist between application runs.
- **Unit Tested**: The application includes unit tests to ensure functionality and stability.

## Technologies Used

- **.NET 8.0**: The core framework for building this application.
- **Spectre.Console**: For creating a rich and user-friendly command-line interface.
- **xUnit**: For unit testing the application's core functionalities.

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) should be installed on your machine.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yokyomitsu/taskmanager.git
   cd taskmanager
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```

### Running the Application

You can run the Task Manager CLI with the following command:

```bash
dotnet run --project TaskManager.CLI
```

### Available Commands

- **Add a Task**:
  
  ```bash
  dotnet run --project TaskManager.CLI -- add "Task Title"
  ```

- **List All Tasks**:

  ```bash
  dotnet run --project TaskManager.CLI -- list
  ```

- **Mark a Task as Complete**:

  ```bash
  dotnet run --project TaskManager.CLI -- complete <task-id>
  ```

- **Delete a Task**:

  ```bash
  dotnet run --project TaskManager.CLI -- delete <task-id>
  ```

### Data Persistence

The tasks are stored in a `tasks.json` file located in the root directory of the `TaskManager.CLI` project. This file ensures that your tasks persist even after you exit the application.

## Testing

The project includes unit tests written with xUnit. To run the tests:

```bash
dotnet test
```

You should see all tests pass, ensuring that the core functionality of the task manager works correctly.

## Project Structure

```
TaskManager/
│
├── TaskManager.CLI/             # The console application project
│   ├── Commands/                # Command implementations
│   ├── DependencyInjection/     # DI-related classes
│   └── Program.cs               # The main entry point for the CLI
│
├── TaskManager.Core/            # Core business logic and models
│   ├── Models/                  # TaskItem model
│   ├── Services/                # Business logic services
│   └── Repositories/            # Repository interfaces and implementations
│
└── TaskManager.Tests/           # Unit test project
    ├── TestUtilities/           # Test utility classes
    └── TaskServiceTests.cs      # Unit tests for TaskService
```

## Future Enhancements

- **Editing Tasks**: Add the ability to edit existing tasks.
- **Task Deadlines**: Allow users to set and manage task deadlines.
- **Task Prioritization**: Introduce priority levels for tasks (e.g., High, Medium, Low).
- **Category/Tag Support**: Enable categorizing or tagging tasks for better organization.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a Pull Request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.