using ProyectoMongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Añadir servicio de MongoDB
builder.Services.AddSingleton<MongoDbService>();

//Añadir sesiones a la app
builder.Services.AddSession();

var app = builder.Build();

//Habilitar uso de sesiones
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Main/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Main}/{action=Index}/{id?}"
);

app.Run();
