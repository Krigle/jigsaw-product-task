# Product Browser - ASP.NET Core MVC

Hey there! 👋 This is my take on the Jigsaw Finance technical task - building a simple product browser using ASP.NET Core MVC. I wanted to create something clean, functional, and that shows good separation of concerns.

## What I Built

A web application that displays products from the DummyJSON API in a nice, paginated list. Users can browse through products and click on any to see detailed information. I also added a currency converter because why not make it more useful?

## My Approach & Thinking

I started by reading the requirements carefully - needed an MVC app with two pages, server-side API calls, pagination, and error handling. No database, keep it simple.

**Architecture Decisions:**

- Went with the classic MVC pattern because that's what was asked for
- Created separate layers: Controllers for HTTP handling, Services for business logic, Http for API calls
- Used dependency injection throughout for clean, testable code
- Kept the API calls server-side as specified

**Key Challenges & Solutions:**

- **Pagination**: The DummyJSON API uses `limit` and `skip` parameters. I converted page numbers to skip values in the service layer.
- **Error Handling**: Added try-catch blocks in controllers with proper HTTP status codes and user-friendly error views.
- **Data Flow**: Controllers → Services → Http Client → External API. This keeps concerns separated.
- **UI**: Used Bootstrap for quick, responsive styling. Added a currency converter as a nice-to-have feature.

**What I'm Proud Of:**

- Clean code structure that's easy to follow
- Proper error handling that doesn't crash the app
- The currency converter - it was fun to implement and makes the app more international
- Server-side API calls mean the external API key (if needed) stays secure

## Features

- Product List: Paginated display with thumbnails, titles, prices, and tags
- Product Details: Full product info including description, images, and shipping details
- Currency Converter: Switch between USD, GBP, and EUR
- Pagination: Navigate through product pages
- Error Handling: Graceful handling of API failures

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- C# for the backend logic
- Razor views for the UI
- Bootstrap for styling
- DummyJSON API for product data

## Running It

1. Make sure you have .NET 8 installed
2. Clone this repo
3. Navigate to the `ProductBrowser` folder
4. Run `dotnet restore` to get dependencies
5. Run `dotnet run` to start the app

## Project Structure

```
ProductBrowser/
├── Controllers/     # MVC controllers
├── Models/         # Data models
├── Services/       # Business logic
├── Http/          # API client
├── Views/         # Razor templates
├── wwwroot/       # Static files (CSS, JS)
└── Program.cs     # App startup
```

I focused on readability and maintainability - the code should be easy to understand and extend. The separation of concerns makes it simple to add new features or modify existing ones.

This was a great exercise in building a complete web application from scratch. I enjoyed working with ASP.NET Core MVC and implementing the requirements in a clean way!
