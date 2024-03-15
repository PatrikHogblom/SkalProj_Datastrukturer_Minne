# Ovning4_SkalProj

##Teori och fakta
1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess  grundläggande funktion

Svar: 

Stacken är en Last-In First-Out(LIFO) datastruktur. Ett exempel på hur stacken fungerar är att är om du lägger 3 böcker i en låda, för att komma åt första boken som är längst ner i lådan så behöver du flytta de 2 övre böckerna först. Stacken är självunderhållande och därmed minnet rensas när metoden har exekverats klart.

Heap används för lagra dynamiskt allokerade objekt, när en objekt skapas så skapas en pekare/referens till objektet i stacken. Heap datastrukturen efterliknas med att ha en hög med kläder utspritt och är tillängligt på en gång med enkel åtkomst, dvs lätt och fort att komma åt dess objekt om vi vet vad vi vill komma åt. Från skillnad stacken så är inte heapen självunderhållande och därmed kommer heapminnet inte rensas när efter metoden har exekverats klart och därmed behöver oroa sig för "Garbage Collection".   

2.Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
Svar: 

Value Types: Lagras på stacken, exempel på värdestyper är: int, bool, byte, char, decimal, double, long, float, enum, short, struct och mera.

Reference Typer: Själva objektet/datan av referenstyperna lagras i heapen, medan referensen till typerna sparas i stacken som i sin tur pekar mot objektet som finns i heapen. Exempel på referenstyper är class, interface, object, delegate, string


3.Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
Svar: 

ReturnValue():

1. denna metod först lägger till värdetypen x i stacken, dvs x = 3
2. därefter så lägger den till värdetypen y överst i stacken, här har vi y = x och därmed så får vi y = 3
3. nu ändrar metoden värdet genom tilldela y = 4
4. sist så returnerar vi värdestypen x som har värdet 3.

ReturnValue2():
1. Ni skapar först klassobjektet Myint x, detta leder til vi lägger till en referens till x i stacken samt objektvärdet i heap, x.MyValue = 3
2. Nu skapar vi klassobjektet Myint y, detta leder till vi lägger en referens till y överst i stacken över x refererensen samt lägger till objektet y i heapen
3. Då vi använder y = x, så betyder att y och x kommer att peka på samma objekt, därmed blir minnesobjektet samma och därmed y.MyValue = x.MyValue = 3
4. Nu tilldelar vi värdet y.MyValue = 4, då objektet y och x pekar på samma minnesobjekt så innebär om vi gör ändringar i y.MyValue så kommer x.MyValue att ändras, dvs y.MyValue = x.MyValue = 4
5. sist så returnerar vi objektvärdet 4 från x.MyValue 


## Datastrukturer och minneseffektivitet
### Övning 1:

1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar. 

2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 

3. Med hur mycket ökar kapaciteten? 

4. Varför ökar inte listans kapacitet i samma takt som element läggs till? 

5. Minskar kapaciteten när element tas bort ur listan? 

6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 

### Övning 2:

### Övning 3:


