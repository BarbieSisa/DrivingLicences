using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        private readonly DrivingLicenceDbContext dbContext;

        public UserContext(DrivingLicenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(User item)
        {
            try
            {
                dbContext.Users.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    return dbContext.Users.FirstOrDefault(b => b.Id == key);
                }
                else
                {
                    return dbContext.Users.Find(key);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<User> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query;
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(User item, bool useNavigationalProperties = false)
        {
            try
            {
                User UserFromDb = Read(item.Id, useNavigationalProperties);

                if (UserFromDb == null)
                {
                    Create(item);
                    return;
                }

                UserFromDb.IDcardNumber = item.IDcardNumber;
                UserFromDb.Fname = item.Fname;
                UserFromDb.Mname = item.Mname;
                UserFromDb.Lname = item.Lname;
                UserFromDb.EGN = item.EGN;
                UserFromDb.Birthdate = item.Birthdate;
                UserFromDb.Location = item.Location;
                UserFromDb.Address = item.Address;
                UserFromDb.Username = item.Username;
                UserFromDb.Email = item.Email;
                UserFromDb.Password = item.Password;
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                User UserFromDb = Read(key);

                if (UserFromDb != null)
                {
                    dbContext.Users.Remove(UserFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("User with that key does not exist!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
