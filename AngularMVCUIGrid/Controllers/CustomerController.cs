using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMVCUIGrid.Models;

namespace AngularMVCUIGrid.Controllers
{
    public class CustomerController : ApiController
    {
        NorthwindDBContext dbContext = new NorthwindDBContext();

        [HttpGet]
        public IHttpActionResult GetCustomer()
        {
            return Json(dbContext.Customers.ToList());
        }

        [HttpPost]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                //Code to Save the data
                dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                //Return Ok response if data saved successfully
                return Content(HttpStatusCode.OK, "Data Saved Successfully");

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Data Save Failed" + ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            try
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                return Content(HttpStatusCode.OK, "Customer" + customer.ContactName + " has been created");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Inserting customer failed : " + ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int customerID)
        {
            try
            {
                //code to delete the data
                Customer customer = dbContext.Customers.Find(customerID);
                if (customer == null)
                {
                    return Content(HttpStatusCode.NotFound, "Customer with id : " + customerID + " is not found");
                }
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
                return Content(HttpStatusCode.OK, "Customer id : " + customerID + " has been deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Deleting customer id failed : " + ex.Message);
            }
        }
    }
}
