using Microsoft.AspNetCore.Mvc;
using Docker_Api.Data;
using Docker_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTableController : ControllerBase
    {
        private readonly TestDbContext _context;

        public TestTableController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTable>>> Get()
        {
            return await _context.TestTable.ToListAsync();
        }
    }
}