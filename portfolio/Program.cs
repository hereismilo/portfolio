var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // This points to your custom "Friendly 404/Error" page we styled earlier
    app.UseExceptionHandler("/Error");

    // Forces the browser to use HTTPS for better security (SEO boost too!)
    app.UseHsts();
}

// 1. Force all traffic to HTTPS (Essential for public portfolios)
app.UseHttpsRedirection();

// 2. THIS IS KEY: This allows the browser to find your PDF at /files/Milo_Resume.pdf
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Optimized asset mapping for CSS/JS
app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();