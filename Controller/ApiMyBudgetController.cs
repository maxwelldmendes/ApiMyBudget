using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMyBudget.Models;
using ApiMyBudget.ModelsDTO;

using ApiMyBudget.Data;

namespace ApiMyBudget.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiMyBudgetController : ControllerBase
    {
        private readonly AppDbContext _myBudgetContext;

        public ApiMyBudgetController(AppDbContext myBudgetContext)
        {
            _myBudgetContext = myBudgetContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassesOfAccountDto>>> GetClassesOfAccount()
        {
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.ToListAsync();

            var classesOfAccountDto = classesOfAccount.Select(c => new ClassesOfAccountDto
            {
                Id = c.Id,
                SubGroupId = c.SubGroupId,
                ClassDescription = c.ClassDescription,
                ClassCode = c.ClassCode
            }).ToList();

            return Ok(classesOfAccountDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassesOfAccountDto>> GetClassesOfAccount(int id)
        {
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);

            if (classesOfAccount == null)
            {
                return NotFound();
            }

            var classesOfAccountDto = new ClassesOfAccountDto
            {
                Id = classesOfAccount.Id,
                SubGroupId = classesOfAccount.SubGroupId,
                ClassDescription = classesOfAccount.ClassDescription,
                ClassCode = classesOfAccount.ClassCode
            };

            return Ok(classesOfAccountDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClassesOfAccountDto>> CreateClassesOfAccount(ClassesOfAccountDto classesOfAccountDto)
        {
            var classesOfAccount = new ClassesOfAccount
            {
                SubGroupId = classesOfAccountDto.SubGroupId,
                ClassDescription = classesOfAccountDto.ClassDescription,
                ClassCode = classesOfAccountDto.ClassCode
            };

            _myBudgetContext.ClassesOfAccount.Add(classesOfAccount);
            await _myBudgetContext.SaveChangesAsync();

            var classesOfAccountDtoResult = new ClassesOfAccountDto
            {
                //Id = classesOfAccount.Id,
                SubGroupId = classesOfAccount.SubGroupId,
                ClassDescription = classesOfAccount.ClassDescription,
                ClassCode = classesOfAccount.ClassCode
            };

            return CreatedAtAction(nameof(GetClassesOfAccount), new { id = classesOfAccount.Id }, classesOfAccountDtoResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassesOfAccount(int id, ClassesOfAccountDto classesOfAccountDto)
        {
            if (id != classesOfAccountDto.Id)
            {
                return BadRequest();
            }

            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);

            if (classesOfAccount == null)
            {
                return NotFound();
            }

            classesOfAccount.SubGroupId = classesOfAccountDto.SubGroupId;
            classesOfAccount.ClassDescription = classesOfAccountDto.ClassDescription;
            classesOfAccount.ClassCode = classesOfAccountDto.ClassCode;

            _myBudgetContext.Entry(classesOfAccount).State = EntityState.Modified;
            await _myBudgetContext.SaveChangesAsync();

            classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);

            if (classesOfAccount == null)
            {
                return NotFound();
            }

            classesOfAccountDto = new ClassesOfAccountDto
            {
                Id = classesOfAccount.Id,
                SubGroupId = classesOfAccount.SubGroupId,
                ClassDescription = classesOfAccount.ClassDescription,
                ClassCode = classesOfAccount.ClassCode
            };

            return Ok(classesOfAccountDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassesOfAccount(int id)
        {
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);

            if (classesOfAccount == null)
            {
                return NotFound();
            }

            _myBudgetContext.ClassesOfAccount.Remove(classesOfAccount);
            await _myBudgetContext.SaveChangesAsync();

            return NoContent();
        }
    }
}