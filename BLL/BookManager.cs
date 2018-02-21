using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
namespace BLL
{
    class BookManager
    {

        public BookModel[] GetAll()
        {
            
            using (BooksDBEntities db = new BooksDBEntities())
            {
                List<Book> dbList = db.Books.ToList();
                    
                var tempList = dbList.Select(b =>
                {
                     return new BookModel
                     {
                         BookName = b.BookName,
                         NumOfPages = (int)b.NumOfPages,
                         Price = b.Price
                     };
                }).ToArray();
                return tempList;

            }
        }


        //public BookModel[] GetBookById(int id)
        //{

        //    using (BooksDBEntities db = new BooksDBEntities())
        //    {
        //        Book tempBook = db.Books.Where(b => b.Id == id).Select(b=>
                    
        //        {
        //            return new BookModel { 
        //                BookName = b.BookName,
        //                Id=b.Id,
        //                Author=///
        //                }

        //        });
                
               
        //        return tempBook;

        //    }
        //}




        public bool Add(BookModel newBook)
        {
            try { 
                using (BooksDBEntities db = new BooksDBEntities())
                {
                    List<DAL.Book> dbList = db.Books.ToList();

                    dbList.Add(

                        new Book
                        {
                            Id = (int)newBook.Id,
                            Price = newBook.Price,
                            BookName = newBook.BookName,
                            NumOfPages = newBook.NumOfPages,
                            AuthorID = (int)newBook.Author.Id
                            
                        });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception err)
            {
                return false;
            }

        }


        public void Remove(int id)
        {
            using (BooksDBEntities db = new BooksDBEntities())
            {
                List<Book> dbList = db.Books.ToList();

                dbList.RemoveAt(id);
                db.SaveChanges();
            }
        }

        public bool Edit(int id)
        {
            try {
                using (BooksDBEntities db = new BooksDBEntities())
                {
                    Book bookToRemove = db.Books.Where(b => b.Id == id).FirstOrDefault();

                    db.Books.Remove(bookToRemove);
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception err)
            {
                return false;
            }
        }



    }
        
    }

