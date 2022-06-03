using BankingApi.DTO;
using BankingApi.Application.AccauntOperations.Commands.CreateAccaunt;
using BankingApi.Application.AccauntOperations.Commands.UpdateAccaunt;
using BankingApi.Application.AccauntOperations.Commands.DeleteAccaunt;
using BankingApi.Application.AccauntOperations.Queries.GetAccaunts;
using BankingApi.Application.AccauntOperations.Queries.GetAccauntDetail;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BankingApi.Controllers;

[ApiController]
[Route("[controller]s")]

public class AccauntController : ControllerBase
{
    private readonly IAccauntsDbContext _context;
    private readonly IMapper _mapper;
    public AccauntController(IAccauntsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Get Method
    [HttpGet]
    public IActionResult GetFilms()
    {
       GetAccauntsQuery query = new GetAccauntsQuery(_context, _mapper);
       var result = query.Handle();
       return Ok(result);
    } 
    
    //Get method with id
    [HttpGet("{id}")]
    public IActionResult GetFilm(int id)
    {
        AccauntDetailViewModel result;
        try
        {
            GetAccauntDetailQuery query = new GetAccauntDetailQuery(_context, _mapper);
            query.AccauntId = id;
            result = query.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        

        return Ok(result);
    }
    
    
    //Post method
    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateAccauntModel newAccaunt)
    {
        try
        {
            CreateAccauntCommand command = new CreateAccauntCommand(_context, _mapper);
            command.Model = newAccaunt;                
            command.Handle();         
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();   
    }
    
    //Put method
    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateAccauntModel updatedFilm)
    {
        try
        {
            UpdateAccauntCommand command = new UpdateAccauntCommand(_context);
            command.AccauntId = id;
            command.Model = updatedFilm;
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    //Delete method
    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        try
        {
            DeleteAccauntCommand command = new DeleteAccauntCommand(_context);
            command.AccauntId = id;
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }    
} 