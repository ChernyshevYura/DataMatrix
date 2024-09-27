using DataMatrix.Models;
using DataMatrix.Repositories;

namespace DataMatrix.Services.lmpl
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity> CreateUser(UserPayload userCreate)
        {
            var user = await _repository.Save(userCreate);
            return user;
        }

        public async Task<UserEntity> UpdateUser(UserPayload userPayload)
        {
            var user = await _repository.UpdateUser(userPayload);
            return user;
        }

        public async Task<UserEntity> GetUserById(int userId)
        {
            var user = await _repository.FindUserById(userId);
            return user;
        }

        public async Task<List<UserEntity>> GetUsers(int page, int pageSize)
        {
            var users = await _repository.FindUsers(page, pageSize);
            return users;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var isDeleted = await _repository.DeleteUser(id);
            return isDeleted;
        }
    }
}
