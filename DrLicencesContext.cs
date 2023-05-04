using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DrLicencesContext : IDb<DrLicence, int>
    {
        private readonly DrivingLicenceDbContext dbContext;

        public DrLicencesContext(DrivingLicenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(DrLicence item )
        {
            try
            {
                dbContext.DrLicences.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            } 
        }
        public DrLicence Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    return dbContext.DrLicences.Include(b => b.Documents).FirstOrDefault(b => b.Id == key);
                }
                else
                {
                    return dbContext.DrLicences.Find(key);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<DrLicence> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<DrLicence> query = dbContext.DrLicences;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b.Documents);
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(DrLicence item, bool useNavigationalProperties = false)
        {
            try
            {
                DrLicence DrLicenceFromDb = Read(item.Id, useNavigationalProperties);

                if (DrLicenceFromDb == null)
                {
                    Create(item);
                    return;
                }

                DrLicenceFromDb.LicenceStatus = item.LicenceStatus;
                DrLicenceFromDb.DateofSubmition = item.DateofSubmition;
                DrLicenceFromDb.Type = item.Type;
                

                if (useNavigationalProperties)
                {
                    List<Documents> Documentss = new List<Documents>();

                    foreach (Documents p in item.Documents)
                    {
                        Documents DocumentsFromDb = dbContext.Documents.Find(p.ID);

                        if (DocumentsFromDb != null)
                        {
                            Documentss.Add(DocumentsFromDb);
                        }
                        else
                        {
                            Documentss.Add(p);
                        }

                    }

                    DrLicenceFromDb.Documents = Documentss;
                }

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
              DrLicence DrLicenceFromDb = Read(key);

                if (DrLicenceFromDb != null)
                {
                    dbContext.DrLicences.Remove(DrLicenceFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("DrLicence with that key does not exist!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
