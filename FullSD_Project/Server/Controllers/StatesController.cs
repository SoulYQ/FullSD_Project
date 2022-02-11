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
    public class StatesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/States
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            var states = await _unitOfWork.States.GetAll();
            return Ok(states);
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetState(int id)
        {
            var state = await _unitOfWork.States.Get(Queryable => Queryable.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            _unitOfWork.States.Update(state);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StateExists(id))
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

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            //_context.States.Add(state);
            //await _context.SaveChangesAsync();
            await _unitOfWork.States.Insert(state);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetState", new { id = state.Id }, state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _unitOfWork.States.Get(q => q.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            await _unitOfWork.States.Delete(id);
            await _unitOfWork.Save(HttpContext);
            

            return NoContent();
        }

        private async Task<bool> StateExists(int id)
        {
            var state = await _unitOfWork.States.Get(q => q.Id == id);
            return state != null;
        }
    }
}
