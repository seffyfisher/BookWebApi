using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class AuthorManager
    {
        public List<AuthorModel> GetAllAuthors()
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
               return db.Authors.Select(a =>
                      new AuthorModel()
                    {
                        Age = a.Age,
                        Image = a.Image,
                        Name = a.Name
                    }).ToList();
                
            }
        }


        public AuthorModel GetAuthor(string name)
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
               return db.Authors
                   .Where(a => a.Name == name)
                   .Select(a =>
                      new AuthorModel()
                      {
                          Age = a.Age,
                          Image = a.Image,
                          Name = a.Name
                      }).FirstOrDefault();
                
            };
        }

        public bool EditAuthor(string name,AuthorModel newAuthor)
        {
            try { 
            using (BooksDBEntities db = new BooksDBEntities())
            {
                var toEdit= db.Authors
                    .Where(a => a.Name == name).FirstOrDefault();

                toEdit.Age = newAuthor.Age;
                toEdit.Image = newAuthor.Image;
                db.SaveChanges();
                return true;
            };
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AddAuthor(AuthorModel newAuthor)
        {
            try
            {
                using (BooksDBEntities db = new BooksDBEntities())
                {
                    db.Authors.Add(
                        new Author()
                        {
                            Age = newAuthor.Age,
                            Image = newAuthor.Image,
                            Name = newAuthor.Name
                        }
                        );
                    db.SaveChanges();
                    return true;
                };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAuthor(string name)
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
                var AuthorToRemove = db.Authors
                   .Where(a => a.Name == name).FirstOrDefault();
                if (AuthorToRemove != null) {

                    db.Authors.Remove(AuthorToRemove);
                    db.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }


            };
        }

  
    }
}
