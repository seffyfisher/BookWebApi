using BO;
using BLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookWebApi.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {

        /// <summary>
        /// return all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllAuthors()
        {
            AuthorManager AuthorManager = new AuthorManager();

            try
            {
                List<AuthorModel> authors = AuthorManager.GetAllAuthors();
                return Request.CreateResponse(HttpStatusCode.OK, authors);
            }
            catch(Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);

            }
        }

        /// <summary>
        /// return specfic book by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        public HttpResponseMessage GetAuthor(string name)
        {
            AuthorManager AuthorManager = new AuthorManager();

            try
            {
                AuthorModel author = AuthorManager.GetAuthor(name);
                if (author == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "sorry there is no author name with the name " + name);
                }
                return Request.CreateResponse(HttpStatusCode.OK, author);
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);

            }
        }


        [HttpPut]
        [Route("{name}")]
        public HttpResponseMessage EditAuthor([FromUri]string name,[FromBody] AuthorModel newAuthor)
        {
            if (ModelState.IsValid)
            {
                AuthorManager AuthorManager = new AuthorManager();
                
                if (AuthorManager.EditAuthor(name, newAuthor))
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
        public HttpResponseMessage AddAuthor([FromBody] AuthorModel newAuthor)
        {
            if (ModelState.IsValid)
            {
                AuthorManager AuthorManager = new AuthorManager();

                if (AuthorManager.AddAuthor(newAuthor))
                {
                    return Request.CreateResponse(HttpStatusCode.Created,newAuthor);
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
        public HttpResponseMessage RemoveAuthor([FromUri]string name)
        {
            
                AuthorManager AuthorManager = new AuthorManager();

                if (AuthorManager.RemoveAuthor(name))
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

