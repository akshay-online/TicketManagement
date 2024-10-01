using Microsoft.AspNetCore.Mvc;
using TicketManagement.Controllers;
using TicketManagement.Models;

namespace TicketTest
{
    public class Tickets
    {
        private TicketsController _controller;
        private List<Ticket> _tickets;

        public Tickets()
        {
            // Initialize the list of tickets
            _tickets = new List<Ticket>
            {
                new Ticket { Id = 1, Title = "Ticket 1", Description = "This is ticket 1", Status = "Open" },
                new Ticket { Id = 2, Title = "Ticket 2", Description = "This is ticket 2", Status = "Close" },
                new Ticket { Id = 3, Title = "Ticket 3", Description = "This is ticket 3", Status = "In Progress" }
            };

            // Initialize the controller
            _controller = new TicketsController();
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfTickets()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Ticket>>(result.Model);
            Assert.Equal(3, ((List<Ticket>)result.Model).Count);
        }

        [Fact]
        public void Details_ValidId_ReturnsViewResult_WithTicket()
        {
            // Act
            var result = _controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Ticket>(result.Model);
            Assert.Equal(1, ((Ticket)result.Model).Id);
        }

        [Fact]
        public void Details_InvalidId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.Details(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ValidTicket_RedirectsToIndex()
        {
            // Arrange
            var newTicket = new Ticket { Title = "New Ticket", Description = "New Description", Status = "Open" };

            // Act
            var result = _controller.Create(newTicket) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Edit_ValidId_ReturnsViewResult_WithTicket()
        {
            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Ticket>(result.Model);
            Assert.Equal(1, ((Ticket)result.Model).Id);
        }

        [Fact]
        public void Edit_InvalidId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.Edit(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ValidId_ReturnsViewResult_WithTicket()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Ticket>(result.Model);
            Assert.Equal(1, ((Ticket)result.Model).Id);
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.Delete(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteConfirmed_ValidId_RedirectsToIndex()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void DeleteConfirmed_InvalidId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.DeleteConfirmed(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}