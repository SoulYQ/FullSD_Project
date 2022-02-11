using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullSD_Project.Server.Data;
using FullSD_Project.Shared.Domain;
using FullSD_Project.Server.IRepository;

namespace FullSD_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToolsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tools
        [HttpGet]
        public async Task<IActionResult> GetTools()
        {
            var tools = await _unitOfWork.Tools.GetAll(includes: q => q.Include(x => x.State).Include(x => x.Brand));

            return Ok(tools);
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTool(int id)
        {
            var tool = await _unitOfWork.Tools.Get(Queryable => Queryable.Id == id);

            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // PUT: api/Tools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTool(int id, Tool tool)
        {
            if (id != tool.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Tools.Update(tool);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ToolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tool>> PostTool(Tool tool)
        {
            
            await _unitOfWork.Tools.Insert(tool);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTool", new { id = tool.Id }, tool);
        }

        // DELETE: api/Tools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            var tool = await _unitOfWork.Tools.Get(q => q.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            await _unitOfWork.Tools.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        private async Task<bool> ToolExists(int id)
        {
            var tool = await _unitOfWork.Tools.Get(q => q.Id == id);
            return tool != null;
        }
    }
}
