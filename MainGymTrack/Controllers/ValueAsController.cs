using MainGymTrack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MainGymTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueAsController : ControllerBase
    {
        private readonly TraineeContext _dbContext;

        public ValueAsController(TraineeContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public  async Task <ActionResult<IEnumerable<Model1>>> GetModel()
        {
            if(_dbContext.model1 == null)
            {
                return NotFound();
            }
            return await _dbContext.model1.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model1>> GetModel(int id)
        {
            if (_dbContext.model1 == null)
            {
                return NotFound();
            }

            var model = await _dbContext.model1.FindAsync(id);
            if (model == null)
            {
                return NotFound ();
            } 
            return model; 
        }
            [HttpPost]
            public async Task<ActionResult<Model1>> PostModel (Model1 model)
            {
                _dbContext.model1.Add(model);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetModel), new { id = model.Id }, model) ;
            }

        }
    }
    
