using DSCC.CW_1._9987_WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DSCC.CW_1._9987_WEB.Controllers
{
    public class BlogController : Controller
    {
        // Hosted web API Service base url
        private string baseUrl = "https://localhost:44300";

        // GET: Blog
        public async Task<ActionResult> Index()
        {
            List<Blog> blogs = new List<Blog>();

            using (var client = new HttpClient())
            {
                // passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                // define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // sending a request
                string apiEndpoint = "api/Blog";
                HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                // validate the response
                if (response.IsSuccessStatusCode)
                {
                    // storing response details received from the API
                    var responseResult = response.Content.ReadAsStringAsync().Result;

                    // parse from string to object
                    blogs = JsonConvert.DeserializeObject<List<Blog>>(responseResult);
                    
                    // format written date properly
                    foreach (var blog in blogs)
                    {
                        blog.FormattedWrittenDate = blog.WrittenDate.Value.ToString("dd/MM/yyyy");
                    }
                }
            }

            return View(blogs);
        }

        // GET: Blog/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Blog blog = new Blog();

            using (var client = new HttpClient())
            {
                // passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                // define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // sending a request
                string apiEndpoint = "api/Blog/" + id;
                HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                // validate the response
                if (response.IsSuccessStatusCode)
                {
                    // storing response details received from the API
                    var responseResult = response.Content.ReadAsStringAsync().Result;

                    // parse from string to object
                    blog = JsonConvert.DeserializeObject<Blog>(responseResult);
                    blog.FormattedWrittenDate = blog.WrittenDate.Value.ToString("dd/MM/yyyy");
                }
            }

            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public async Task<ActionResult> Create(Blog blog)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // passing service base url
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    string apiEndpoint = "api/Blog/";
                    var blogPostInJson = JsonConvert.SerializeObject(blog);
                    var requestBody = new StringContent(blogPostInJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, requestBody);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Blog blog = new Blog();

            using (var client = new HttpClient())
            {
                // passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                // define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // sending a request
                string apiEndpoint = "api/Blog/" + id;
                HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                // validate the response
                if (response.IsSuccessStatusCode)
                {
                    // storing response details received from the API
                    var responseResult = response.Content.ReadAsStringAsync().Result;

                    // parse from string to object
                    blog = JsonConvert.DeserializeObject<Blog>(responseResult);
                    blog.FormattedWrittenDate = blog.WrittenDate.Value.ToString("dd/MM/yyyy");
                }
            }

            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // passing service base url
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    string apiEndpoint = "api/Blog/" + id;
                    HttpResponseMessage response = await client.DeleteAsync(apiEndpoint);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
