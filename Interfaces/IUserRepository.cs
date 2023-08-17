﻿namespace Rideshare_API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task AddUser(User user);
    }
}
