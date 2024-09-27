using DataMatrix.Models;

namespace DataMatrix.Services
{
    public interface IUserService
    {

        /*
            Create a new user.
        */
        Task<UserEntity> CreateUser(UserPayload userCreate);

        /*
            Update a new user.
        */
        Task<UserEntity> UpdateUser(UserPayload userPayload);

        /*
            Get a user by its id.
        */
        Task<UserEntity> GetUserById(int userId);

        /*
            Get a users list.
        */
        Task<List<UserEntity>> GetUsers(int page, int pageSize);

        Task<bool> DeleteUser(int id);
    }
}
