# BookStore API (.NET 10)

Welcome to the **BookStore API**, a robust backend built using .NET 10, Entity Framework Core, and ASP.NET Core Identity. This API uses JWT Bearer Tokens for global authentication.

---

## 🚀 Features
* **Authentication & Authorization**: Identity integration with JWT Tokens.
* **Architecture**: Generic Repository Pattern for clean data access.
* **API Documentation**: Automated using .NET 10 OpenAPI and integrated with **Scalar** for modern interactive UI.

---

## 🛠️ How to Connect and Test (Global Authentication)

We use **Scalar** for API testing. You don't need to pass the token to every single endpoint manually.

### Steps to Authenticate:
1. Run the project in `Development` mode.
2. Navigate to the Scalar UI endpoint (usually `http://localhost:<port>/scalar/v1` or via the default landing page).
3. Look for the **"Authorize"** / **"Authentication"** button in the global header or sidebar.
4. Select **Bearer** as your preferred scheme.
5. Paste your generated JWT token. 
6. *Voila!* All subsequent API requests will automatically include the `Authorization: Bearer <your_token>` header globally.

---

## 🗄️ Database Setup
Before running the application, make sure to update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
}