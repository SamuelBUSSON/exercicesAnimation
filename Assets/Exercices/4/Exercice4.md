# Exercice #4

*Objectif:* Manipuler les textures

## Généralité

Pour chaque sous-exercice, dupliquez, renommez et faîtes les ajustements nécessaires.

## Exercice 4.1

*Objectif:* Appliquer une texture et comprendre les coordonnées de texture et leur utilisation dans un fragment shader

Remplacer la couleur bleue du carré de l'exercice 3.1 par la texture d'arbre.

## Exercice 4.2

*Objectif:* Pouvoir configurer la fonction de mélange

Corriger la fonction de mélange du carré de l'exercice 4.1 afin de considérer correctement la transparence. Le contour de l'arbre ne devrait pas être blanc mais bien affiché...

## Exercice 4.3

*Objectif:* Paramétrer une texture et y appliquer une transformation

En utilisant une variable uniforme représentant le temps, faire défiler la texture sur le carré de l'exercice 4.2.

## Exercice 4.4

*Objectif:* Appliquer un effet faisant intervenir plusieurs textures

En utilisant la texture de déformation et une variable uniforme représentant le temps, appliquer une déformation dynamique sur la texture du carré de l'exercice 4.2.

L’algorithme suggéré est le suivant:
- Calculer l’intensité de la déformation à appliquer selon le temps, par la recherche d’une valeur dans la texture *intensity*, aux coordonnées *(Time, 0.5)*. Mettre cette intensité à l’échelle avec une variable uniforme *Scale*.
- Chercher un vecteur de déformation dans la texture *deformation*, aux coordonnées de texture du fragment décalé d’une valeur tirée du temps (par exemple, le sinus du temps). Moduler ce vecteur de déformation par l’intensité précédente.
- Chercher la couleur finale dans la texture d'entrée aux coordonnées de texture du fragment, décalées du vecteur de déformation.

## Exercice 4.5

*Objectif:* Utiliser une texture dans un vertex shader

En utilisant la texture de terrain et la texture d'altitude, créer un maillage utilisant une carte de hauteur (heightmap). Vous devrez créer un maillage horizontal contenant plusieurs sommets déformés à l'aide du vertex shader et y appliquer la texture d'altitude par le fragment shader.
Pour bien visualiser le tout, faîtes pivoter l'objet autour de l'axe vertical, en modifiant son composant Transform depuis le code C#.
