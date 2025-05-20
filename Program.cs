using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

Console.WriteLine($"Database path: {db.DbPath}");

Console.WriteLine("Insert a new blog");

db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
await db.SaveChangesAsync();

Console.WriteLine("Querying for a blog");

// This will be a single blog, since we are ordering by BlogId and taking the first one.
//Reading the first blog in the database
Console.WriteLine("Querying for a blog");
var blog = await db.Blogs
    .OrderBy(b => b.BlogId)
    .FirstAsync();

Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet/";
blog.Posts.Add(new Post { Title = "Hello World", Content = "Hello World" });
await db.SaveChangesAsync();

// Deleting the blog
Console.WriteLine("Delete the blog");
db.Remove(blog);
await db.SaveChangesAsync();