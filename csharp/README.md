# GameOfLife

#### Technologies:
* C#
* .Net Core 2.1
* xUnit

#### Run
There are two mandatory arguments. First is the **size** and the other is **iterations**.
If you run the program without args it will display some helpful information.
```
C:\GameOfLife\bin\Release\netcoreapp2.1> dotnet .\GameOfLife.dll
Please enter numeric arguments for size and iterations.
Usage: GameOfLife <size> <iterations>
```

##### Example
```
C:\GameOfLife\bin\Release\netcoreapp2.1> dotnet .\GameOfLife.dll 10 10
-|X|X|-|-|-|-|-|-|-
-|X|X|-|-|-|-|-|-|-
-|-|-|X|-|-|-|-|-|-
-|X|-|X|-|-|-|-|-|-
-|X|-|X|-|-|-|-|-|-
-|X|-|-|-|-|-|-|X|X
-|-|X|X|-|-|-|-|X|X
-|X|-|-|X|-|-|-|-|-
-|-|X|X|-|-|-|-|-|-
-|-|-|-|-|-|-|-|-|-
```
