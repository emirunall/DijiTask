using BL.IServices;
using DAL.UnitOfWork;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(T TEntity)
        {
            // Önce var mı diye kontrol edelim
            var existingEntity = await _unitOfWork.GetRepository<T>().FindAsync(TEntity.Id);
            if (existingEntity != null)
            {
                // Zaten varsa hata döndürebiliriz veya üzerine yazabiliriz, size bağlı
                return false; // veya throw new SomeException("Entity with the same key already exists.");
            }

            await _unitOfWork.GetRepository<T>().CreateAsync(TEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var data = await _unitOfWork.GetRepository<T>().GetAllAsync();
            return data;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var data = await _unitOfWork.GetRepository<T>().GetAllAsync(predicate);
            return data;
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var data = await _unitOfWork.GetRepository<T>().GetByFilterAsync(predicate);
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.GetRepository<T>().FindAsync(id);
            return data;
        }

        public async Task RemoveAsync(int id)
        {
            // Önce var mı diye kontrol edelim
            var existingEntity = await _unitOfWork.GetRepository<T>().FindAsync(id);

            _unitOfWork.GetRepository<T>().Remove(existingEntity);
            var result = await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T Tentity)
        {
            // Önce var mı diye kontrol edelim
            var existingEntity = await _unitOfWork.GetRepository<T>().FindAsync(Tentity.Id);
            if (existingEntity == null)
            {
                // Eğer yoksa hata döndürebiliriz veya ekleyebiliriz, size bağlı
                return false; // veya throw new SomeException("Entity with the given key does not exist.");
            }

            _unitOfWork.GetRepository<T>().Update(Tentity);
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
