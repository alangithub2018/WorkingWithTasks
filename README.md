## Technologies Used

- [![C#](https://img.shields.io/badge/csharp-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [![.NET](https://img.shields.io/badge/.NET-%2363299E.svg?style=for-the-badge&logo=.net&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/)
- [![Task](https://img.shields.io/badge/Task-Asynchronous-blue?style=for-the-badge)](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl)

# Tasks in C#: Functionality Testing

This project is a test of the functionality of `Tasks` in C#, where we explore how to create tasks, cancel them using `CancellationToken`, wait for their completion, and handle errors.

## What are Tasks in C#?

In C#, a `Task` represents an asynchronous operation that can be executed in the background. `Tasks` are part of the `Task Parallel Library (TPL)` and are fundamental for asynchronous programming in .NET.

### Key Features:
- **Asynchrony**: Allows running operations without blocking the main thread.
- **Cancellation**: Can be canceled using `CancellationToken`.
- **Waiting**: You can wait for one or multiple tasks to complete.
- **Error Handling**: Exceptions can be caught and handled properly.

### Task Cancellation

```csharp
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

Task.Run(() => {
    while (!token.IsCancellationRequested) {
        // Perform work...
    }
    token.ThrowIfCancellationRequested();
}, token);

// Cancel the task
cts.Cancel();
