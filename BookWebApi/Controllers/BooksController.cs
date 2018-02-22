using BO;
using BLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookWebApi.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
            [HttpGet]
            [Route("")]
            public HttpResponseMessage GetAllAuthors()
            {
                
                BookManager BookManager = new BookManager();

                try
                {
                    List<BookModel> books = BookManager.GettAllBooks();
                    return Request.CreateResponse(HttpStatusCode.OK, books);
                }
                catch (Exception err)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, err);

                }

        }


        [HttpGet]
        [Route("{name}")]
        public HttpResponseMessage GetBook(string name)
        {
            BookManager BookManager = new BookManager();

            try
            {
                BookModel book = BookManager.GetBook(name);
                if (book == null) {
                 return Request.CreateResponse(HttpStatusCode.NotFound,"sorry there is no books name with the name "+name);}
                return Request.CreateResponse(HttpStatusCode.OK, book);
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);

            }
        }



        [HttpPut]
        [Route("{name}")]
        public HttpResponseMessage EditBook([FromUri]string name,[FromBody] BookModel newBook)
        {
            if (ModelState.IsValid)
            {
                BookManager BookManager = new BookManager();
                
                if (BookManager.EditBook(name, newBook))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }
        
        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddBook([FromBody] BookModel newBook)
        {
            if (ModelState.IsValid)
            {
                BookManager BookManager = new BookManager();

                if (BookManager.AddBook(newBook))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, newBook);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }

            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        [HttpDelete]
        [Route("{name}")]
        public HttpResponseMessage RemoveBook([FromUri]string name)
        {

            BookManager BookManager = new BookManager();

            if (BookManager.RemoveBook(name))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }


        }



    }
}
