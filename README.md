# TaskManager

Usage:
```bash
git clone https://github.com/yokyomitsu/TaskManager.git
cd TaskManager
dotnet clean
dotnet build
```

You can use commands.

1. Add a task:
```bash
dotnet run --project TaskManager.CLI -- add "Test Task"
```

2. List tasks to find the ID of the added task:
```bash
dotnet run --project TaskManager.CLI -- list
```

3. Mark the task as complete using the ID:
```bash
dotnet run --project TaskManager.CLI -- complete <task-id>
```

4. List tasks again to verify the status change:
```bash
dotnet run --project TaskManager.CLI -- list
```
5. Delete a task using the ID:
```bash
dotnet run --project TaskManager.CLI -- delete <task-id> 
```