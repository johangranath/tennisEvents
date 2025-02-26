# Prompt Plan for Tennis League Management System

This document outlines a detailed, step-by-step blueprint for building the Tennis League Management System along with a series of iterative, test-driven LLM prompts. The prompts are designed to guide incremental development, ensuring that every component is built, tested, and integrated properly.

---

## Project Blueprint

### Phase 1: Project Setup

#### 1. Initialize Backend
- Create a new .NET Minimal API project.
- Set up `Program.cs` with a basic API skeleton.
- Configure environment variables for the MongoDB connection.

#### 2. Configure Database
- Install the `MongoDB.Driver` NuGet package.
- Create a helper class (`MongoDbContext`) that manages database connections.
- Implement a basic health check endpoint to verify database connectivity.

#### 3. Initialize Frontend
- Create a new Vue 3 project using Vite.
- Set up basic routing using `vue-router` and state management with `Pinia`.
- Implement a simple home page to confirm that the project is running.

#### 4. CI/CD Pipeline
- Set up GitHub Actions for automated builds and tests.
- Configure Docker for containerized deployment.

---

### Phase 2: Backend API Development

#### 5. Player Management (Backend)
- **Model & Repository:**
  - Create a `Player` model with properties: `ID`, `Name`, and `PhoneNumber`.
  - Implement a `PlayersRepository` with methods for adding, retrieving, updating, and deleting players.
- **Controller:**
  - Implement `PlayersController` with the following endpoints:
    - `POST /players` to add a new player.
    - `GET /players` to list all players.
    - `PUT /players/{id}` to update a player.
    - `DELETE /players/{id}` to remove a player.
- **Validation & Testing:**
  - Prevent duplicate names and validate phone number formatting.
  - Write unit tests for the repository.
  - Write integration tests for the controller.

#### 6. Player Management (Frontend)
- Create a Vue component (`PlayerList.vue`) to display players.
- Implement forms for adding new players.
- Add update and delete functionalities.
- Connect the frontend to the backend API.
- Ensure that the component reflects real-time updates.

---

### Phase 3: Season & Division Management

#### 7. Season Management (Backend)
- **Model & Repository:**
  - Create a `Season` model with properties: `ID`, `Name`, `StartDate`, `EndDate`, and a list of `DivisionIDs`.
  - Implement a `SeasonsRepository` with CRUD operations.
- **Controller:**
  - Implement `SeasonsController` with endpoints:
    - `POST /seasons` to create a new season.
    - `GET /seasons` to retrieve seasons.
    - `PUT /seasons/{id}` to update a season.
    - `DELETE /seasons/{id}` to delete a season.
- **Testing:**
  - Write unit tests for the repository.
  - Write integration tests for the controller.

#### 8. Division Management (Backend)
- **Model & Repository:**
  - Create a `Division` model with properties: `ID`, `SeasonID`, `Name`, a list of `PlayerIDs`, and a list of `MatchIDs`.
  - Implement a `DivisionsRepository` with CRUD operations.
- **Controller:**
  - Implement `DivisionsController` with endpoints:
    - `POST /divisions` to create a new division linked to a season.
    - `GET /divisions` to retrieve divisions.
    - `PUT /divisions/{id}` to update a division.
    - `DELETE /divisions/{id}` to delete a division.
- **Testing:**
  - Write unit and integration tests ensuring proper linkages between seasons, divisions, and players.

---

### Phase 4: Match Scheduling & Results

#### 9. Match Scheduling (Backend)
- **Model & Repository:**
  - Define a `Match` model with properties: `ID`, `SeasonID`, `DivisionID`, `ScheduledDate`, and team details (e.g., `Team1`, `Team2`).
  - Implement a `MatchRepository` to auto-generate weekly matches based on available court times.
  - Ensure that every player partners with each other once per season.
- **Controller:**
  - Implement `MatchesController` with endpoints:
    - `POST /matches/schedule` to trigger match scheduling.
    - `GET /matches` to retrieve scheduled matches.
- **Validation & Testing:**
  - Validate scheduling logic to handle odd-numbered players (assigning byes) and prevent duplicate matchups.
  - Write unit tests for scheduling logic.
  - Write integration tests for the scheduling endpoints.

#### 10. Match Results (Backend)
- **Model & Repository:**
  - Define a `MatchResults` model to capture set scores and game differentials.
  - Implement a `ResultsRepository` to record and update match results.
- **Controller:**
  - Implement `ResultsController` with endpoints:
    - `POST /results` to submit match results.
    - `PUT /results/{id}` to update results (with constraints on editing locked matches).
- **Validation & Testing:**
  - Validate scoring logic (e.g., three-set matches with each set contributing 4 points).
  - Prevent modifications to locked results.
  - Write unit and integration tests.

---

### Phase 5: Rankings & Public Data

#### 11. Rankings (Backend)
- **Logic & Controller:**
  - Develop ranking calculation logic based on match results, set scores, and game differentials.
  - Implement `RankingsController` with an endpoint:
    - `GET /rankings` to retrieve player standings.
- **Testing:**
  - Write unit tests for ranking calculations.
  - Write integration tests for the endpoint.

#### 12. Public Access (Backend & Frontend)
- **Backend:**
  - Create endpoints for public data:
    - `GET /public/schedules` for match schedules.
    - `GET /public/matches/{id}` for detailed match information.
    - `GET /public/rankings` for current standings.
- **Frontend:**
  - Develop Vue components for viewing schedules, match details, and rankings.
- **Testing:**
  - Write integration tests ensuring data is safe and correctly exposed.

---

### Phase 6: Authentication & Admin Controls

#### 13. Admin Authentication (Backend)
- **Authentication Implementation:**
  - Implement admin authentication using username/password.
  - Create an authentication middleware to secure endpoints.
  - Securely store passwords using a robust hashing algorithm.
- **Testing:**
  - Write tests to ensure unauthorized access is blocked.
  - Validate that correct credentials allow access.

#### 14. Admin Login (Frontend)
- **Frontend Implementation:**
  - Create an `AdminLogin.vue` component with a login form.
  - Connect the login form to the backend authentication endpoint.
  - Use Vue state management (Vuex or Pinia) to store the authentication token.
  - Protect admin routes so only authenticated users can access them.
- **Testing:**
  - Write tests for login functionality and route protection.

---

### Phase 7: Admin Dashboard & Integration (Frontend)
- **Dashboard Components:**
  - Develop an admin dashboard layout that integrates:
    - Player management UI.
    - Season and division management UI.
    - Match scheduling and results entry UI.
    - Rankings view.
- **Integration:**
  - Ensure all components communicate with the secured backend endpoints.
  - Handle errors and display notifications for both successes and failures.
- **Testing:**
  - Write end-to-end tests for the entire dashboard workflow.

---

### Phase 8: Deployment & Finalization
- **End-to-End Testing:**
  - Conduct comprehensive tests covering all aspects of the application.
- **Deployment:**
  - Set up the deployment environment (e.g., Azure, AWS, DigitalOcean).
  - Deploy both backend and frontend using containerization (Docker).
- **Monitoring & Logging:**
  - Integrate logging and monitoring tools for diagnostics.
- **Final Testing:**
  - Validate deployment by ensuring API endpoints and frontend functionalities are accessible and performant.

---

## LLM Prompts for Implementation

### Prompt 1: Setting Up a .NET Minimal API
```text
You are a .NET developer setting up a new Minimal API project.

1. Create a new `.NET Minimal API` project.
2. Set up `Program.cs` to initialize a basic REST API.
3. Add an endpoint `GET /health` that returns `{ "status": "ok" }`.
4. Ensure the project builds and runs without errors.
5. Write a basic test to verify that `GET /health` returns a 200 response.

Follow best practices and ensure the project structure allows for further expansion.


### Prompt 1: Setting Up a .NET Minimal API
You are a .NET developer setting up a new Minimal API project.

1. Create a new `.NET Minimal API` project.
2. Set up `Program.cs` to initialize a basic REST API.
3. Add an endpoint `GET /health` that returns `{ "status": "ok" }`.
4. Ensure the project builds and runs without errors.
5. Write a basic test to verify that `GET /health` returns a 200 response.

Follow best practices and ensure the project structure allows for further expansion.

---

### Prompt 2: Setting Up MongoDB Connectivity
You are a .NET developer configuring MongoDB for a Minimal API.

1. Install the `MongoDB.Driver` NuGet package.
2. Create a helper class `MongoDbContext` that handles database connections.
3. Use `IConfiguration` to load connection strings from `appsettings.json`.
4. Implement a basic test to verify MongoDB connectivity by inserting and retrieving a dummy document.

Follow clean code principles and ensure error handling is in place.

---

### Prompt 3: Implementing Player Management (Backend)
You are implementing a player management system in .NET Minimal API.

1. Create a `Player` model with `ID`, `Name`, and `PhoneNumber`.
2. Implement `PlayersRepository` with methods for:
   - Adding a player.
   - Retrieving all players.
   - Updating a player.
   - Deleting a player.
3. Implement `PlayersController` with endpoints:
   - `POST /players` to add a new player.
   - `GET /players` to retrieve a list of players.
   - `PUT /players/{id}` to update player information.
   - `DELETE /players/{id}` to remove a player.
4. Add validation to prevent duplicate names and enforce phone number formatting.
5. Write unit tests for `PlayersRepository`.
6. Write integration tests for `PlayersController`.

Ensure best practices for error handling, logging, and testability.

---

### Prompt 4: Implementing Player Management (Frontend)
You are developing the frontend for player management using Vue 3.

1. Create a Vue component `PlayerList.vue` that:
   - Fetches and displays players from `GET /players`.
   - Provides a form to add a new player.
2. Implement an API service using `axios` to interact with the backend.
3. Add form validation to prevent duplicate names and incorrect phone numbers.
4. Implement update and delete functionality.
5. Ensure real-time updates after add/update/delete actions.

Follow best practices in Vue component structure and state management.

---

### Prompt 5: Implementing Season Management (Backend)
You are implementing the season management component for the Tennis League Management System in .NET Minimal API.

1. Create a `Season` model with properties: `ID`, `Name`, `StartDate`, `EndDate`, and a list of associated `DivisionIDs`.
2. Implement a `SeasonsRepository` with CRUD operations: Add, Retrieve, Update, and Delete a season.
3. Create a `SeasonsController` with endpoints:
   - `POST /seasons` to create a new season.
   - `GET /seasons` to retrieve all seasons.
   - `PUT /seasons/{id}` to update a season.
   - `DELETE /seasons/{id}` to delete a season.
4. Validate inputs to ensure valid dates and required fields.
5. Write unit tests for the `SeasonsRepository`.
6. Write integration tests for the `SeasonsController` ensuring proper HTTP responses and data integrity.

Ensure best practices, proper error handling, and logging throughout.

---

### Prompt 6: Implementing Division Management (Backend)
You are implementing the division management component for the Tennis League Management System in .NET Minimal API.

1. Create a `Division` model with properties: `ID`, `SeasonID`, `Name`, a list of `PlayerIDs`, and a list of `MatchIDs`.
2. Implement a `DivisionsRepository` with CRUD operations for divisions.
3. Create a `DivisionsController` with endpoints:
   - `POST /divisions` to create a new division, associating it with a season.
   - `GET /divisions` to retrieve divisions.
   - `PUT /divisions/{id}` to update a division.
   - `DELETE /divisions/{id}` to delete a division.
4. Ensure validations such as verifying the associated season exists and that players being added are valid.
5. Write unit tests for the `DivisionsRepository`.
6. Write integration tests for the `DivisionsController` ensuring that divisions are correctly linked to seasons and players.

Follow best practices and include clear error messages.

---

### Prompt 7-14: Continuing Implementation
(Include remaining prompts 7-14 following the same detailed breakdown, ensuring they are added in order.)

Prompt 7: Implementing Match Scheduling (Backend)
You are implementing the match scheduling component for the Tennis League Management System in .NET Minimal API.

1. Create a `Match` model with properties: `ID`, `SeasonID`, `DivisionID`, `ScheduledDate`, and team details (e.g., `Team1`, `Team2`).
2. Implement a `MatchRepository` to handle match scheduling logic:
   - Auto-generate weekly matches based on available court times.
   - Ensure every player partners with each other once within the season.
3. Create a `MatchesController` with endpoints:
   - `POST /matches/schedule` to trigger the scheduling process.
   - `GET /matches` to retrieve scheduled matches.
4. Add validation logic to:
   - Handle cases with an odd number of players (assigning byes).
   - Prevent duplicate matchups.
5. Write unit tests for the scheduling logic.
6. Write integration tests for the scheduling endpoints.

Ensure the solution is modular, testable, and adheres to clean design principles.

Prompt 8: Implementing Match Results (Backend)
You are implementing the match results component for the Tennis League Management System in .NET Minimal API.

1. Create a `MatchResults` model to capture set scores and game differentials.
2. Implement a `ResultsRepository` to record and update match results.
3. Create a `ResultsController` with endpoints:
   - `POST /results` to submit match results.
   - `PUT /results/{id}` to update match results (ensuring editing is only allowed for unlocked matches).
4. Implement validation to:
   - Verify correct scoring for three-set matches (with each set contributing 4 points).
   - Prevent modifications of locked (finalized) results.
5. Write unit tests for the result recording and validation logic.
6. Write integration tests for the results endpoints.

Ensure comprehensive error handling and logging throughout the implementation.

Prompt 9: Implementing Rankings (Backend)
You are implementing the rankings component for the Tennis League Management System in .NET Minimal API.

1. Develop ranking calculation logic that computes player standings based on match results, set scores, and game differentials.
2. Create a `RankingsController` with an endpoint:
   - `GET /rankings` to retrieve current player standings.
3. Write unit tests for the ranking calculation logic.
4. Write integration tests for the rankings endpoint ensuring accurate and consistent output.

Ensure that the ranking logic is modular and extensible for future ranking criteria.


Prompt 10: Implementing Public Access Endpoints
You are implementing public access endpoints for the Tennis League Management System in .NET Minimal API.

1. Create endpoints to serve public data:
   - `GET /public/schedules` to retrieve match schedules.
   - `GET /public/matches/{id}` to retrieve detailed match information.
   - `GET /public/rankings` to retrieve current player standings.
2. Ensure these endpoints only expose data intended for public viewing (no sensitive admin details).
3. Write integration tests to verify that the endpoints return correct and safe data.

Follow RESTful best practices and provide clear endpoint documentation.

Prompt 11: Implementing Admin Authentication (Backend)
You are implementing admin authentication for the Tennis League Management System in .NET Minimal API.

1. Implement admin authentication using username/password:
   - Create an authentication middleware that validates admin credentials.
   - Store passwords securely using a robust hashing algorithm.
2. Secure all admin endpoints (e.g., player management, season and division management, match scheduling, and results entry) using the authentication middleware.
3. Write tests to verify that:
   - Unauthorized requests are correctly blocked.
   - Valid credentials allow access.
4. Ensure error messages are generic to avoid exposing sensitive details.

Follow security best practices and ensure the authentication mechanism is robust.

Prompt 12: Implementing Admin Login (Frontend)
You are implementing the admin login functionality for the Tennis League Management System frontend using Vue 3.

1. Create a Vue component `AdminLogin.vue` featuring a login form for username and password.
2. Integrate this component with the backend authentication endpoint to validate credentials.
3. Implement state management (using Vuex or Pinia) to securely store the authentication token.
4. Protect the admin dashboard and routes so that they are only accessible after a successful login.
5. Write frontend tests to ensure:
   - Incorrect credentials display an appropriate error.
   - Successful login redirects to the admin dashboard.

Follow secure coding practices and ensure a user-friendly interface.

Prompt 13: Implementing the Admin Dashboard and Integration (Frontend)
You are developing the admin dashboard for the Tennis League Management System frontend using Vue 3.

1. Create a dashboard layout that integrates various management components:
   - Player management interface.
   - Season and division management interfaces.
   - Match scheduling and results entry interface.
   - Rankings view.
2. Integrate the components you previously developed (e.g., `PlayerList.vue`, season/division forms, match scheduling UI).
3. Ensure the dashboard communicates with secured backend endpoints to fetch and update data.
4. Implement error handling and notifications for both successful and failed operations.
5. Write end-to-end tests to validate that the entire dashboard flow works correctly.

Ensure that all components are modular and integrated into a cohesive admin dashboard.


Prompt 14: Deployment and CI/CD Pipeline Setup
You are setting up deployment and a CI/CD pipeline for the Tennis League Management System.

1. Configure GitHub Actions to:
   - Build and test both the backend (.NET) and frontend (Vue 3) projects on every push.
   - Run automated unit and integration tests.
2. Create Dockerfiles for both the backend and frontend services to enable containerized deployments.
3. Develop a deployment script that packages the application and deploys it to a cloud provider (e.g., Azure, AWS, or DigitalOcean).
4. Write tests to verify the deployment process (e.g., ensuring containers start correctly and API endpoints are accessible).
5. Integrate logging and monitoring to facilitate post-deployment diagnostics.

Follow industry best practices for CI/CD, containerization, and cloud deployment.

