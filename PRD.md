# Product Requirements Document (PRD)  
## Listing de jeux vidéo avec dashboard (Blazor WASM + LumexUI)

### 1. Objectif
Fournir une application web permettant de lister, filtrer et visualiser des informations sur des jeux vidéo.  
Dashboard interactif pour statistiques et aperçu rapide des données.  
Hébergement possible sur GitHub Pages, fonctionnement entièrement côté client.  

---

### 2. Utilisateurs cibles
- Joueurs souhaitant suivre leur collection ou découvrir de nouveaux jeux.  
- Streamers ou créateurs de contenu voulant organiser une base de données de jeux.  
- Développeurs ou testeurs souhaitant une interface pour visualiser les jeux.  

---

### 3. Fonctionnalités principales
1. **Listing de jeux**
   - Affichage sous forme de tableau ou cartes (`Table`, `Card`).  
   - Champs principaux : titre, plateforme, genre, date de sortie, note.  
   - Filtrage par plateforme, genre, note minimale.  
   - Tri par titre, date, note.  

2. **Dashboard**
   - Vue d’ensemble avec statistiques clés :  
     - Nombre total de jeux.  
     - Répartition par plateforme (graphique circulaire).  
     - Répartition par genre (bar chart).  
     - Moyenne des notes.  
   - Visualisation des tendances ou nouveaux ajouts.  

3. **Recherche**
   - Barre de recherche pour trouver un jeu par titre ou mot-clé.  

4. **Interface**
   - Composants LumexUI (https://github.com/LumexUI/lumexui , https://lumexui.org/docs/getting-started/overview) : `Card`, `Table`, `Chart`, `Button`, `Badge`.  
   - Responsive desktop et mobile.  
   - Thème clair/sombre optionnel.  

---

### 4. Fonctionnalités secondaires (optionnelles)
- Ajouter des jeux à une liste personnelle (favoris).  
- Évaluer les jeux avec notation personnelle.  
- Export CSV ou JSON de la liste des jeux.  
- Pagination pour grandes listes.  

---

### 5. Contraintes techniques
- Framework : **Blazor WebAssembly** (C#).  
- UI : **LumexUI** pour dashboard et composants interactifs.  
- Hébergement : GitHub Pages.  
- Stockage : depuis JSON statique pour catalogue.  

---

### 6. Architecture
- **Components** :  
  - `GameList.razor` : tableau ou grille des jeux avec filtres.  
  - `GameDashboard.razor` : statistiques et graphiques.  
  - `SearchBar.razor` : barre de recherche et filtres.  
  - `GameCard.razor` : affichage détaillé d’un jeu.  

- **Services** :  
  - `GameService.cs` : gestion de la liste de jeux, filtres, tri, recherche.  
  - `DashboardService.cs` : calcul des statistiques et préparation des données graphiques.  

---

### 7. Flux utilisateur
1. L’utilisateur charge l’application.  
2. La liste de jeux et le dashboard sont affichés.  
3. L’utilisateur peut rechercher, filtrer ou trier les jeux.  
4. Le dashboard se met à jour dynamiquement en fonction des filtres.  
5. L’utilisateur peut consulter les détails d’un jeu ou ajouter aux favoris.  

---

### 8. Roadmap
- **MVP (Version 1)** : listing statique des jeux + dashboard simple.  
- **V2** : filtres avancés, favoris, tri dynamique.  
- **V3** : export CSV/JSON, thème sombre, pagination.  

---

### 9. Critères de réussite
- Listing des jeux correctement filtré et trié.  
- Dashboard affichant statistiques correctes en temps réel.  
- Interface responsive et fluide avec LumexUI.  
- Fonctionne entièrement côté client sur GitHub Pages.
