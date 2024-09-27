using DataMatrix.Models;
using DataMatrix.Services;
using DataMatrix.Utils;
using System.Net.NetworkInformation;

namespace DataMatrix.Repositories
{
    public class UserRepository
    {
        private readonly IDbService _dbService;

        private readonly string BASE_QUERY = 
            """
            SELECT
            u.id,
            u.name,
            u.surename,
            u.phone,
            u.email,
            COUNT(*) OVER() AS count_rows
            FROM users as u
            """;

        private readonly string BASE_INSERT =
            """
            INSERT INTO users
            (name, surname, phone, email)
            VALUES
            (@Name, @Surname, @Phone, @Email)
            """;

        private readonly string BASE_UPDATE =
            """
            UPDATE users 
            SET name = @Name, surename = @Surename, phone = @Phone, email = @Mail 
            WHERE id = @Id
            """;

        private readonly string BASE_DELETE =
            """
            DELETE FROM users WHERE id = @Id
            """;

        public UserRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        /*
            Save a new user.
        */
        public async Task<UserEntity> Save(UserPayload user)
        {
            var userId = await _dbService.EditData(
                BASE_INSERT,
                new
                {
                    user.Name,
                    user.Surname,
                    user.Phone,
                    user.Email
                }
            );
            var userEntity = await FindUserById(userId);
            return userEntity;
        }

        /*
           Query a user by user id.
       */
        public async Task<UserEntity> FindUserById(int id)
        {
            var query = string.Format("{0} WHERE u.id=@id LIMIT 1", BASE_QUERY);
            var userEntity = await _dbService.GetAsync<UserEntity>(query, new { id });
            return userEntity;
        }

        /*
           Query update a user.
       */
        public async Task<UserEntity> UpdateUser(UserPayload userPayload)
        {            
            var userId = await _dbService.EditData(BASE_UPDATE,
                new
                {
                    userPayload.Name,
                    userPayload.Surname,
                    userPayload.Phone,
                    userPayload.Email
                });
            var userEntity = await FindUserById(userId);
            return userEntity;
        }

        /*
           Query are users.
       */
        public async Task<List<UserEntity>> FindUsers(int pageNum, int pageSize)
        {
            var query = DBUtils.MakeQueryPaginated(BASE_QUERY, pageNum, pageSize);
            return await _dbService.GetAll<UserEntity>(query, new {});
        }

        /*
           Query a delete user.
       */
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var deletedRows = await _dbService.EditData(BASE_DELETE, new { @Id = id });

                if (deletedRows > 0)
                {
                    return true; 
                }
                else
                {                    
                    return false;
                }
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Deletion error: {ex.Message}");                
                return false;
            }
        }
    }
}
