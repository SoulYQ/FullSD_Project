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
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _unitOfWork.Members.GetAll();
            return Ok(members);
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _unitOfWork.Members.Get(Queryable => Queryable.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Members.Update(member);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {

            await _unitOfWork.Members.Insert(member);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _unitOfWork.Members.Get(q => q.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            await _unitOfWork.Members.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        private async Task<bool> MemberExists(int id)
        {
            var member = await _unitOfWork.Members.Get(q => q.Id == id);
            return member != null;
        }
    }
}
