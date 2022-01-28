mkdir Deploy
dotnet publish -r win-x64

move  Example.json ./Deploy/
cd bin\Debug\net6.0\win-x64\publish
move UnitTest.exe ../../../../../Deploy/

cmd /k