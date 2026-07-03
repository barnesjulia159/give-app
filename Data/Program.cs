var builder = WebApplication.CreateBuilder(args);

// Connect to Supabase
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseConnection")));

var app = builder.Build();

var builder = WebApplication.CreateBuilder(args);

// Register Supabase Service
builder.Services.AddSingleton<SupabaseService>();

var app = builder.Build();

// Initialize Supabase on startup
var supabaseService = app.Services.GetRequiredService<SupabaseService>();
await supabaseService.InitializeAsync();

app.Run();