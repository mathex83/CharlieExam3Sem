Dette er vores projekt til 3. semesters Systemudviklingseksamen.

Gruppenavn: Charlie
Gruppemedlemmer: Frederik, Janus og Martin

For at benytte vores VS-projekt, kræves det at Entity Framework til Visual Studio.
Vi har haft Visual Studio 16.11.7 installeret på vores pc'er, der indeholder .Net 5. Noget af koden kræver det.
Når projektet er åbnet skal databasen indlæses fra migration-filerne.
	1. Åbn View -> Other windows -> Package Manager Console.
	2. Vinduet åbner typisk nederst i Visual Studio-vinduet.
	3. Klik ind i Package Manager-framen og skriv "update-database".
Der går lidt tid og til sidst skulle den gerne skrive "Build succeded" og "Done."
Nu er databasen indlæst.

Kør programmet med "Debug -> Start Debugging" eller "Debug -> Start Witout Debugging".

Når programmet er klart kan man nu oprette sig som bruger med linket "Registrer dig" i menuen øverst.
Eller man kan benytte Facebook eller Google som login.
Når bruger er oprettet, kan man med "Log ind"-linket i samme del af menuen logge ind med den oprettede bruger,
Facebook-login eller Google-login. Man skal lave en form for godkendelse af sin mail, ved at klikke det næste link midt på siden.

Derefter er det muligt at tilføje løbere fra menuen øverst.