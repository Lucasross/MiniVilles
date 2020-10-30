# MiniVille
Projet réalisé au cours de la licence informatique jeux vidéo du Cnam.

# Gameplay
Le jeu se joue au clavier uniquement. Toutes les instructions sont affiché à l'écran.
L'implémentation du jeu de base à été réalisé vec l'ensemble des améliorations suivantes :
- Choix de la difficulté.
- Deux dés et nouvelles cartes avec activation entre 7 et 12.
- Une IA avancée qui prend des décisions rationnelle basé sur l'état actuelle du jeu.
 
# Difficultés
* Choix du nombres de pièces pour gagner : 
  * 10
  * 20
  * 30

* Choix du mode normal ou expert :
  * Normal, atteindre le nombre de pièces cible.
  * Expert, obtenir toute les cartes et le nombres de pièce cible.

# Dés

Chaque dés lancés et la sommes des deux dés active les effets des cartes.
Exemple :

Premier dé -> 4

Deuxième dé -> 3

Somme dés -> 7

Les cartes avec une valeurs de 4, 3 et 7 seront activé. (Tout en respectant les codes couleurs)

# Nouvelles cartes
[7] BLUE - Cinéma : Recevez 4 pièce. - 3    
[8] BLUE - Usine : Recevez 3 pièce. - 1                        
[9] RED - Foire : Recevez 3 pièce du joueur qui à lancé le dé - 1  
[10] GREEN - Piscine : Recevez 5 pièce. - 4     
[11] GREEN - Centre commercial : Recevez 6 pièce. - 4    
[12] GREEN - Festival : Recevez 10 pièce. - 6               
[12] BLUE - Musée des sciences : Recevez 8 pièce. - 5       
[12] RED - Boite de nuit : Recevez 5 pièce du joueur qui à lancé le dé - 3

# IA
* Si l'IA nommé ici Jeremy à plus de 15 coins alors il arrête d'acheter des cartes.
* Si il a moins de 5 Coins et moins de 6 cartes alors il achète la carte, sans la regarder.
* Si nous ne sommes pas dans les deux conditions précédentes alors il regarde la carte et ne l'achète que si elle est Bleu.
* Enfin si aucune des conditions n'a été respecté jusqu'ici, il va regarder dans son jeu si il ne possède aucune carte avec la valeur d'activations de celle piochée, si c'est le cas il l'achète.

Défoit c'est plus simple à comprendre avec le code sous les yeux :
```CSharp
if (Coins >= 15)
    return false;
if (Coins <= 5 && cards.Count <= 6)
    return true;
if (card.Info.Color == Colors.BLUE)
    return true;
return cards.Find(c => c.Info.ActivationValue == activationValue) == null;
```
