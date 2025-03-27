# EuphoriaOpdracht

## Vraag 1
- Efficient mogelijk indelen van taxis, dus bijvoorbeeld niet een grote bus gebruiken voor 1 persoon maar daarvoor een taxi gebruiken. - Belang van taxibedrijf
- Taxi moet zoveel mogelijk gevuld zijn met passagiers dus zo min mogelijk tijd tussen afzetten en ophalen. - Belang van taxibedrijf want taxi zonder passagier levert geen geld op

## Vraag 2
Aangezien de Excel sheet niet makkelijk geformatteerd kan worden naar een leesbaarder formaat zoals CSV en ik geen ervaring had met het direct uitlezen van Excel bestanden heb ik ChatGPT omhulp gevraagd, deze kwam met het idee om een functie te schrijven die de header cell van de tabel zoekt en vanuit die cell kan je heel makkelijk alle data uitlezen.  
Ik heb objecten aangemaakt voor de verschillende entiteiten die in de sheet voorkomt.  
Verder heb ik ook een Route object aangemaakt ter voorbereiding van de volgende vraag.

## Vraag 3
Ik heb 2 manieren bedacht om dit op te lossen, dit is namelijk het standaard "Traveling Salesman Problem" en die kun je of met een algoritme oplossen of met een brute force methode. Ik heb gekozen voor de brute force methode omdat deze voor deze kleine opdracht makkelijker was om te implementeren dan een volledig algoritme toepassen. Nu is deze brute force techniek niet heel efficient want er zijn ontzettend veel combinaties mogelijk. 

In deze situatie, waarbij er 9 te berekenen locaties zijn (start en eind locatie staan vast dus die zijn niet deel van de berekening), zijn er 9! combinaties mogelijk. Dit zijn 362880 combinaties. Dit is nog te doen voor een computer, maar als er bijvoorbeeld 20 locaties zijn dan zijn er 20! = 2432902008176640000 combinaties mogelijk. Dit is al een stuk lastiger voor een computer om te berekenen. Daarom zou ik voor een productieomgeving voor een algoritme gaan. 

Je zou bijvoorbeeld Google OR Tools kunnen gebruiken, ik heb hier bij mijn vorige baan al kort mee gewerkt. Met een tool zoals Google OR Tools is het ook makkelijker om meerdere constraints toe te voegen zoals bijvoorbeeld dat een taxi niet meer dan 4 passagiers mag hebben of dat de taxi op een bepaald moment op een bepaalde locatie moet zijn.