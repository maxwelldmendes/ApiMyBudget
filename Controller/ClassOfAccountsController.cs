using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMyBudget.Models;
using ApiMyBudget.ModelsDTO;

using ApiMyBudget.Data;

namespace ApiMyBudget.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesOfAccountsController : ControllerBase
    {
        private readonly AppDbContext _myBudgetContext;

        public ClassesOfAccountsController(AppDbContext myBudgetContext)
        {
            _myBudgetContext = myBudgetContext;
        }

        // GET: api/ClassesOfAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadClassOfAccountsDTO>>> GetClassesOfAccount()
        {
            // Retrieve all classes of account from the database
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.ToListAsync();
            // Map the retrieved entities to DTOs
            var classesOfAccountDto = classesOfAccount.Select(c => new ReadClassOfAccountsDTO
            {
                Id = c.Id,
                SubGroupId = c.SubGroupId,
                ClassDescription = c.ClassDescription,
                ClassCode = c.ClassCode
            }).ToList();
            // Return the list of DTOs
            return Ok(classesOfAccountDto);
        }


        // GET: api/ClassesOfAccounts/{Id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadClassOfAccountsDTO>> GetClassesOfAccount(int id)
        {
            // Retrieve the class of account with the specified ID from the database
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);
            // If the class of account is not found, return a 404 Not Found response
            if (classesOfAccount == null)
            {
                return NotFound();
            }
            // Map the retrieved entity to a DTO
            var classesOfAccountDto = new ReadClassOfAccountsDTO
            {
                Id = classesOfAccount.Id,
                SubGroupId = classesOfAccount.SubGroupId,
                ClassDescription = classesOfAccount.ClassDescription,
                ClassCode = classesOfAccount.ClassCode
            };
            // Return the DTO
            return Ok(classesOfAccountDto);
        }

        // POST: api/ClassesOfAccounts
        [HttpPost]
        public async Task<ActionResult<CreateClassOfAccountDTO>> CreateClassesOfAccount(CreateClassOfAccountDTO classesOfAccountDto)
        {
            // Create a new ClassesOfAccount entity from the provided DTO
            var classesOfAccount = new ClassesOfAccount
            {
                SubGroupId = classesOfAccountDto.SubGroupId,
                ClassDescription = classesOfAccountDto.ClassDescription,
                ClassCode = classesOfAccountDto.ClassCode
            };
            // Add the new entity to the database context and save changes
            _myBudgetContext.ClassesOfAccount.Add(classesOfAccount);
            await _myBudgetContext.SaveChangesAsync();

            // Create a DTO to return the newly created class of account
            var classesOfAccountDtoResult = new ReadClassOfAccountsDTO
            {
                Id = classesOfAccount.Id,
                SubGroupId = classesOfAccount.SubGroupId,
                ClassDescription = classesOfAccount.ClassDescription,
                ClassCode = classesOfAccount.ClassCode
            };

            // Return a 201 Created response with the location of the newly created resource
            return CreatedAtAction(nameof(GetClassesOfAccount), new { id = classesOfAccount.Id }, classesOfAccountDtoResult);
        }

        // PUT: api/ClassesOfAccounts/{Id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassesOfAccount(int id, ReadClassOfAccountsDTO classesOfAccountDto)
        {
            // Check if the provided ID matches the ID in the DTO
            if (id != classesOfAccountDto.Id)
            {
                return BadRequest();
            }

            // Retrieve the existing class of account from the database
            var existingClassesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);
            if (existingClassesOfAccount == null)
            {
                return NotFound();
            }

            // Update the properties of the existing entity with the values from the DTO
            existingClassesOfAccount.SubGroupId = classesOfAccountDto.SubGroupId;
            existingClassesOfAccount.ClassDescription = classesOfAccountDto.ClassDescription;
            existingClassesOfAccount.ClassCode = classesOfAccountDto.ClassCode;

            // Mark the entity as modified and save changes to the database
            _myBudgetContext.Entry(existingClassesOfAccount).State = EntityState.Modified;
            await _myBudgetContext.SaveChangesAsync();

            // Return a 204 No Content response to indicate successful update
            //return NoContent();

            // Create a DTO to return the newly created class of account
            var classesOfAccountDtoResult = new ReadClassOfAccountsDTO
            {
                Id = existingClassesOfAccount.Id,
                SubGroupId = existingClassesOfAccount.SubGroupId,
                ClassDescription = existingClassesOfAccount.ClassDescription,
                ClassCode = existingClassesOfAccount.ClassCode
            };

            // Return a 201 Created response with the location of the newly created resource
            return CreatedAtAction(nameof(GetClassesOfAccount), new { id = classesOfAccountDto.Id }, classesOfAccountDtoResult);
        }

        // DELETE: api/ClassesOfAccounts/{Id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassesOfAccount(int id)
        {
            // Retrieve the class of account with the specified ID from the database
            var classesOfAccount = await _myBudgetContext.ClassesOfAccount.FindAsync(id);
            // If the class of account is not found, return a 404 Not Found response
            if (classesOfAccount == null)
            {
                return NotFound();
            }
            // Remove the entity from the database context and save changes
            _myBudgetContext.ClassesOfAccount.Remove(classesOfAccount);
            await _myBudgetContext.SaveChangesAsync();
            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
    }
}