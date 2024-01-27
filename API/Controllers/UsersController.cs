using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] //local/api/users --> users is from the class name UsersController
public class UsersController : ControllerBase
{
    //_context is a controller 
    private readonly DataContext _context; //alternate way to use this.context everywhere ---> install editorconfig.txt

    //constructor
    //creates a new instance of DataContext and injects into context
    public UsersController(DataContext context)
    {
        _context = context;
    }

    //Data endpoints
    [HttpGet]  // api/users
    //IEnumberable returns a list of users

    // **** Synchronous function ****
    // public ActionResult<IEnumerable<AppUser>> GetUsers(){
    //     var users = _context.Users.ToList();
    //     return users; or return _context.Users.ToList();
    // }

    // Async considers ActionResult as a Task and returns once it is completed.
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        return await _context.Users.ToListAsync();
    }


    [HttpGet("{id}")] // api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id){
        return await _context.Users.FindAsync(id);
    }

}
