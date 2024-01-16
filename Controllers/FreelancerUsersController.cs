using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDNApi.Models;

namespace CDNApi.Controllers
{
    [Route("CDNapi/")]
    [ApiController]
    public class FreelancerUsersController : ControllerBase
    {
        private readonly AssementsContext _context;

        public FreelancerUsersController(AssementsContext context)
        {
            _context = context;
        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IEnumerable<TblFreelancerUserList>> Get()
        {
            return await _context.TblFreelancerUserLists.ToListAsync();
        }

        /// <summary>
        /// Get a list of FreelancerUsers.
        /// </summary>
        /// <param name="id">Id Details</param>
        /// <returns>A JSON list of product numbers.</returns>
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.TblFreelancerUserLists.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        /// <summary>
        /// Inserts list of FreelancerUsers.
        /// </summary>
        /// <param name="TblFreelancerUserList">List of FreelancerUsers</param>
        /// <returns>Succes message</returns>
        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(TblFreelancerUserList user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Updates Freelancer User.
        /// </summary>
        /// <param name="TblFreelancerUserList"> Freelancer User</param>
        /// <returns>Succes message</returns>
        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(TblFreelancerUserList user)
        {
            if (user == null || user.Id == 0)
                return BadRequest();

            var FLuserList = await _context.TblFreelancerUserLists.FindAsync(user.Id);
            if (FLuserList == null)
                return NotFound();
            FLuserList.Username = user.Username;
            FLuserList.Mail = user.Mail;
            FLuserList.PhoneNumber = user.PhoneNumber;
            FLuserList.Skillsets = user.Skillsets;
            FLuserList.Hobby = user.Hobby;
            await _context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Deletes FreelancerUser by Id.
        /// </summary>
        /// <param name="id">Id Details</param>
        /// <returns>Success message.</returns>
        [HttpDelete("RemoveUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.TblFreelancerUserLists.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.TblFreelancerUserLists.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
