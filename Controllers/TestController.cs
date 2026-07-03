using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly SupabaseService _supabase;

    public TestController(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            // Example: Replace 'Product' with your actual table model
            var items = await _supabase.GetAllAsync<Product>();

            return Ok(new 
            { 
                message = "✅ Successfully connected using Supabase C# Client!",
                database = "Supabase",
                itemCount = items.Count,
                status = "Connected"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new 
            { 
                message = "❌ Connection failed", 
                error = ex.Message 
            });
        }
    }
}