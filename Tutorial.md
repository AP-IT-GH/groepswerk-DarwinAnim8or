# Shooting Gallery VR
*Groep: Bert Van Itterbeeck, Gianni Selleslagh , Vanommeslaeghe Gie , Slabbinck Siemen,
Bavo Debraekeleer ,Jorik Van Looke*


Het project bestaat uit een Vr en een AI aspect, De AI en de speler zullen allebei moeten schieten op targets en een zo hoog mogelijke score halen om te winnen. in deze tutorial gaan wij je begeleiden om dit project na te maken.  

## 1. Setup
voor dit project gebruiken we unity 2020.3, en voor de package ML-Agents gebruiken we versie 2.0.1.

## 2. Het Spel
het spel verloopt als volt. je begint voor je shooting gallery die eruit ziet als een shietkraam op de kermis, je krijgt een aantal targets waarop je moet schieten. Je schiet op deze taegets en je probeert meer punten te halen dan de AI.

## 3. Methoden
De belangrijkste objecten in het spel zijn de agent (de AI), de speler en de shooting gallery. 

### 3.1 De Agent
de agent heeft als enige taak het schieten op objecten. we hebben er door layers voor gezorgd dat onze AI alleen de targets ziet en verder niets. Verder hebben we hierbij ook gewerkt met stacked vectors, deze hebben als functie dat de AI dan meerdere beelden heeft van dezelfde scene. Dit is nodig omdat onze targets bewegen en anders weet de AI dti niet  
De AI heeft 3 observaties, zijn positie in de wereld, zijn rotatie in de wereld en als laatste of er al geschoten is.Wat kan de Agent nu doen: hij kan roteren om zo de gehele shooting gallery te kunnen zien en verder kan hij schieten

#### 3.1.1 Beloningen
de AI krijgt als hij schiet een beloning van +0.1f. De 2de beloning die de AI kan krijgen is een reward van +1.0f als hij een target geraakt heeft. 

### 3.2 De Speler
De speler is een VR speler, hij kan net zoals de Agent roteren en schieten op de targets. als er een target geraakt word krijgt hij punten

### 3.3 De Shooting gallery
in de shooting gallery is er eigenlijk maar 1 object belangrijk de targets. De targets bewegen rond op inde gallery als fazanten, en deze moet je gaan schieten om je punten te krijgen.

## 4. Afwijken van onepager
volgens onze onepager was dit project Waren er een aantal verschillen. Ten eerste werken we niet met een specifiek aantal kogels, je kan gewooon schieten. Ook zijn de beloningen van de AI anders dan in onze onepager, hier was die slechts +1.0f als hij een target raakt. Verder is er slechts 1 moeilijkheid, omdat we de AI heel moeilijk getrained kregen.
De mogelijke verdieping hebben we ook niet gebruikt in ons project, maar dit was voorzien.
 ### 4.1 Opepager verdieping
  * Herladen na 10 kogels 
  * Randomised targets 
  * Lachende hond 
  * Meerdere settings 
  * Very optional extra: multiplayer 
  * Weer (fog, wind,...) 

## Resultaten

### Conclusie
![](https://github.com/AP-IT-GH/groepswerk-DarwinAnim8or/blob/808682d40577fbf1f7764f41ca1812b46a61e6e9/Pictures/ProjectScene.JPG)
Het resultaat van ons project is deze prachtige shooting gallery met een Vr functionaliteit en een AI om tegen te spelen.

Wij vinden dat we een redlijk goed project hebben afgeleverd, de AI heeft veel verschillende problemen gehad waardoor we niet meer hebben kunnen doen met de verdiepingen in de onepager. Dit is dus ook wat ik naar de toekomst toe zou verbeteren: alles wat bij de onepager onder verdieping stond.
