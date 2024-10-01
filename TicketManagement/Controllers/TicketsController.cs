using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Sockets;
using TicketManagement.Models;

namespace TicketManagement.Controllers
{
    public class TicketsController : Controller
    {
        private readonly List<Ticket> _tickets;

        public TicketsController()
        {
            // Initialize the list of tickets
            //_tickets = new List<Ticket>
            //{
            //    new Ticket { Id = 1, Title = "Ticket 1", Description = "This is ticket 1", Status = "Open" },
            //    new Ticket { Id = 2, Title = "Ticket 2", Description = "This is ticket 2", Status = "Close" },
            //    new Ticket { Id = 3, Title = "Ticket 3", Description = "This is ticket 3", Status = "In Progress" }
            //};

            // read the Tickets from tickets.json file
            _tickets = JsonConvert.DeserializeObject<List<Ticket>>(System.IO.File.ReadAllText("Json\\tickets.json"));
        }

        public IActionResult Index()
        {
            // Get all tickets
            return View(_tickets);
        }


        public IActionResult Details(int id)
        {
            // Find the ticket with the specified id
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            // if (ModelState.IsValid)
            {
                // Generate a new id for the ticket
                ticket.Id = _tickets.Max(t => t.Id) + 1;

                ticket.CreatedBy = "Admin";
                ticket.CreatedOn = DateTime.Now;

                // Add the ticket to the list
                _tickets.Add(ticket);
                // write file tickets.json
                System.IO.File.WriteAllText("Json\\tickets.json", JsonConvert.SerializeObject(_tickets));


                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            // Find the ticket with the specified id
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            // if (ModelState.IsValid)
            {
                // Find the index of the ticket in the list
                var index = _tickets.FindIndex(t => t.Id == id);
                var oldticket = _tickets[index];

                if (index == -1)
                {
                    return NotFound();
                }

                // Update the ticket in the list
                ticket.CreatedBy = oldticket.CreatedBy;
                ticket.CreatedOn = oldticket.CreatedOn;
                ticket.LastUpdatedOn = DateTime.Now;
                
                _tickets[index] = ticket;
                System.IO.File.WriteAllText("Json\\tickets.json", JsonConvert.SerializeObject(_tickets));
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        public IActionResult Delete(int id)
        {
            // Find the ticket with the specified id
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }
            var alltickets = JsonConvert.DeserializeObject<List<Ticket>>(System.IO.File.ReadAllText("Json\\tickets.json"));
            alltickets?.RemoveAll(t => t.Id == ticket.Id);
            // write to file
            System.IO.File.WriteAllText("Json\\tickets.json", JsonConvert.SerializeObject(alltickets));
            return View(ticket);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the ticket with the specified id
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            // Remove the ticket from the list
            _tickets.Remove(ticket);

            return RedirectToAction("Index");
        }

    }
}
