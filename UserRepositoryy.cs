using System;
using System.Collections.Generic;
using System.Linq;
using UserRepository.Models;
using UserRepository.Repositories;

namespace UserRepositoryExample.Repositories
{
    public class UserRepositoryy : IUserRepository
    {
        private static List<User> _users = new List<User>();
        private int _nextId = 1;

 

        public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

 

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

 

        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Id = _nextId++;
            _users.Add(user);
        }

 

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var existingUser = GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
            }
        }

 

        public void Delete(int id)
        {
            var userToDelete = GetById(id);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
        }
    }
}