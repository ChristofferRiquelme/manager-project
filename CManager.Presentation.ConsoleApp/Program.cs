using CManager.Application.Services;
using CManager.Infrastructure.Repositories;
using CManager.Presentation.ConsoleApp.Controllers;

var repository = new CustomerRepository();
var service = new CustomerService(repository);
var controller = new MenuController(service);

controller.Run();