var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HttpClient to DI container
builder.Services.AddHttpClient("SchoolApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5077"); // API base URL, match the one from launchSettings.json
    client.DefaultRequestHeaders.Add("Accept", "application/json"); // Specify headers if needed
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SchoolClient}/{action=GetAllSchools}/{id?}"); // Default route to GetAllSchools
app.Run();
