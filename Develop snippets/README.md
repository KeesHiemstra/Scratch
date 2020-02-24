# Scratch experiments

### try ... catch ... finally

Example on how responds.
```csharp
      try
      {
        int divide = 0;
        Console.WriteLine(1 / divide);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Exception {ex.Message}");
        if (!UseExit)
        {
          return;
        }
        else
        {
          Environment.Exit(1);
        }
      }
      finally
      {
        Console.WriteLine("Finally is executed");
      }

      Console.WriteLine("Never executed");
```

The `finally` block is executed while `return` returns to the process. With `Environment.Exit()` break directly to the previous process.