[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AppDbContext _context;

    public TestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var count = await _context.YourEntities.CountAsync();
        return Ok(new { message = "✅ Successfully connected to Supabase!", recordCount = count });
    }
}