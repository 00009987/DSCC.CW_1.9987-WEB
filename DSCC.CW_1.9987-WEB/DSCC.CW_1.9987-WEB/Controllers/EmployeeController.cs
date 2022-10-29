using DSCC.CW_1._9987_WEB.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace DSCC.CW_1._9987_WEB.Controllers
{
    public class EmployeeController : Controller
    {
        // Hosted web API Service base url
        private string baseUrl = "";

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            List<Employee> Employees = new List<Employee>();
           
            using(var client = new HttpClient())
            {
                // passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                // define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // sending a request
                string apiEndpoint = "api/Product";
                HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                // validate the response
                if (response.IsSuccessStatusCode)
                {
                    // storing response details received from the API
                    var responseResult = response.Content.ReadAsStringAsync().Result;

                    // parse from string to object
                    Employees = JsonConvert.DeserializeObject<List<Employee>>(responseResult);
                }
            }

            return View(Employees);
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Employee employee = new Employee();

            using (var client = new HttpClient())
            {
                // passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                // define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // sending a request
                string apiEndpoint = "api/Product/" + id;
                HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                // validate the response
                if (response.IsSuccessStatusCode)
                {
                    // storing response details received from the API
                    var responseResult = response.Content.ReadAsStringAsync().Result;

                    // parse from string to object
                    employee = JsonConvert.DeserializeObject<Employee>(responseResult);
                }
            }

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    // passing service base url
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    string apiEndpoint = "api/Product/";
                    var employeeInJson = JsonConvert.SerializeObject(employee);
                    var requestBody = new StringContent(employeeInJson, Encoding.UTF8, "application/json"); 
                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, requestBody);

                    // validate the response
                    if (response.IsSuccessStatusCode)
                    {
                        // storing response details received from the API
                        var responseResult = response.Content.ReadAsStringAsync().Result;

                       // TODO: let the user know about the creation of new employee
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
