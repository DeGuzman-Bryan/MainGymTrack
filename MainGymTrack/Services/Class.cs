using MainGymTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace MainGymTrack.Services
{
    public class TraineeService
    {
        private readonly TraineeContext _dbContext;

        public TraineeService(TraineeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Model1>> GetAllModelsAsync()
        {
            return await _dbContext.model1.ToListAsync();
        }

        public async Task<Model1?> GetModelByIdAsync(int id)
        {
            return await _dbContext.model1.FindAsync(id);
        }

        public async Task<Model1> CreateModelAsync(Model1 model)
        {
            _dbContext.model1.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> UpdateModelAsync(int id, Model1 model)
        {
            if (id != model.Id)
                return false;

            _dbContext.Entry(model).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ModelExistsAsync(id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteModelAsync(int id)
        {
            var model = await _dbContext.model1.FindAsync(id);
            if (model == null)
                return false;

            _dbContext.model1.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> ModelExistsAsync(int id)
        {
            return await _dbContext.model1.AnyAsync(x => x.Id == id);
        }
    }
}