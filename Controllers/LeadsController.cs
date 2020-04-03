using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Newtonsoft.Json.Linq;
namespace TodoApi.Controllers {
    [Route ("api/leads")]
    [ApiController]
    public class leadsController : ControllerBase {
        private readonly MysqlContext _context;
        public leadsController (MysqlContext context) {
            _context = context;
        }

        // GET api/leads
        [HttpGet]
        public ActionResult<List<leads>> GetAll () {
            var listl = _context.leads;
            var listc = _context.customers;


            if (listl == null) {
                return NotFound ("Not Found");
            }
            var verification = false;
            List<leads> list_lead = new List<leads> ();
            List<customers> list_customer = new List<customers>();


            foreach (var customer in listc) {
                 list_customer.Add (customer);
                   

                 }

            DateTime currentDate = DateTime.Now.AddDays (-30);
            foreach (var lead in listl) {
                 foreach (var customer in list_customer) {
                    if(lead.Email == customer.contact_email){
                      if (lead.Created_at >= currentDate) {
                   
                   

                           list_lead.Add (lead);
                           return list_lead;

                       
                    
                       }

                     }

                }


                
            }
            return list_lead;
            
        }

    //     [HttpGet("LatestLeads")]
    //     public ActionResult<List<leads>> GetLatestLeads()
    //     {
    //         var rightnow = DateTime.UtcNow;
    //         var leads = _context.leads
    //             .Where(l => l.customer_id == null)
    //             .Where(l => l.Created_at.Year == rightnow.Year)
    //             .Where(l => l.Created_at.DayOfYear <= rightnow.DayOfYear && l.Created_at.DayOfYear >= rightnow.DayOfYear-30)
    //             .ToList();
    //         // var leads = this.context.Leads.Where(l => l.customer_id == null && LastThirtyDays(l)).ToList();
    //         return leads;
        
    // }
    }
}