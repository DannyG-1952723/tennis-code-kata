# Tennis Code Kata

Dit is een implementatie in .NET van de [Coding Dojo Tennis Kata](https://codingdojo.org/kata/Tennis/).

De Tennis code kan verkregen worden door deze repository te clonen via het volgende command:
```bash
git clone https://github.com/DannyG-1952723/tennis-code-kata.git
```

Om de code te kunnen compileren moet .NET geïnstalleerd zijn. Deze implementatie is geschreven in .NET 9.0, de installer voor deze versie kan gedownload worden op de [Download .NET 9.0 pagina](https://dotnet.microsoft.com/en-us/download/dotnet/9.0). De testen kunnen uitgevoerd worden door `dotnet test` te runnen in de root directory van deze repository. De applicatie kan uitgevoerd worden door `dotnet run` of `dotnet publish` te runnen in de `Tennis` folder.

`dotnet run` voert de applicatie rechtstreeks uit. `dotnet publish` maakt een executable file in de `Tennis/bin/Release/net9.0/publish` directory. Deze kan dan vervolgens uitgevoerd worden door `./Tennis.exe` te runnen in die directory.

Deze implementatie voorziet twee modes: `console` en `random`. Bij de `console` mode kies je zelf welke speler een punt krijgt, bij de `random` mode wordt telkens random een speler gekozen. De modes kunnen op de volgende manieren geselecteerd worden:
```bash
# Voor dotnet run
dotnet run                # Runt de default mode, wat console is
dotnet run -- console     # Runt de console mode
dotnet run -- random      # Runt de random mode

# Voor de executable
./Tennis.exe              # Runt de default mode, wat console is
./Tennis.exe console      # Runt de console mode
./Tennis.exe random       # Runt de random mode
```
