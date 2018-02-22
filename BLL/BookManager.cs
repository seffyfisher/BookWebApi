using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using DAL;
namespace BLL
{
    public class BookManager
    {
        public List<BookModel> GettAllBooks()
        {

            using (BooksDBEntities db = new BooksDBEntities())
            {
                return db.Books.Select(b =>
                       new BookModel()
                       {
                           BookName = b.BookName,
                           NumOfPages = b.NumOfPages,
                           Price = b.Price,
                           Author = new AuthorModel()
                           {
                               Age = b.Author.Age,
                               Image = b.Author.Image,
                               Name = b.Author.Name
                           }
                       }

                       ).ToList();

            }
            
        }


        public BookModel GetBook(string name)
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
                return db.Books
                    .Where(b => b.BookName == name)
                    .Select(b =>
                       new BookModel()
                       {
                           BookName = b.BookName,
                           NumOfPages = b.NumOfPages,
                           Price = b.Price,
                           Author = new AuthorModel()
                           {
                               Age = b.Author.Age,
                               Image = b.Author.Image,
                               Name = b.Author.Name
                           }

                       }).FirstOrDefault();

            };
        }

        public bool EditBook(string name, BookModel newBook)
        {
            try
            {
                using (BooksDBEntities db = new BooksDBEntities())
                {
                    var toEdit = db.Books
                        .Where(b => b.BookName == name).FirstOrDefault();

                    toEdit.NumOfPages = newBook.NumOfPages;
                    toEdit.Price = newBook.Price;
                    db.SaveChanges();
                    return true;
                };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddBook(BookModel newBook)
        {
            try
            {
                using (BooksDBEntities db = new BooksDBEntities())
                {
                    db.Books.Add(
                        new Book()
                        {
                            Price = newBook.Price,
                            NumOfPages=newBook.NumOfPages,
                            BookName=newBook.BookName,
                            Author=new Author
                            {
                                Age=newBook.Author.Age,
                                Image=newBook.Author.Image,
                                Name=newBook.Author.Name
                            }
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

        public bool RemoveBook(string name)
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
                var BookToRemove = db.Books
                   .Where(b => b.BookName == name).FirstOrDefault();
                if (BookToRemove != null)
                {

                    db.Books.Remove(BookToRemove);
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

